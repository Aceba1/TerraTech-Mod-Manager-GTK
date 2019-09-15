using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Gtk;
using TerraTechModManagerGTK;
using TerraTechModManagerGTK.Downloader;

public partial class MainWindow : Gtk.Window
{
    public static ListStore ModListStoreLocal, ModListStoreGithub;
    public static TreeModelFilter ModFilterLocal, ModFilterGithub;
    public static TreeModelSort ModSortLocal, ModSortGithub;

    public static MainWindow inst;

    private DialogGithubToken _dialogGithubToken;
    private DialogDescription _dialogDescription;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        //Kill running QModManager processes, if there are any
        KillPatcher();

        Build();
        SetupTree();

        comboboxModState.RemoveText(1);

        SkipStartAction.Active = ConfigHandler.CacheValue("skipstart", false);
        inst = this;
        ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)0x0FF0; //System.Net.SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

        Tasks.AddToTaskQueue(new Task(SleepForTime));
        Tasks.AddToTaskQueue(new Task(GetLocalMods));
        Tasks.AddToTaskQueue(new Task(UpdateProgram.V_LookForProgramUpdate));
        Tasks.AddToTaskQueue(new Task(InstallModLoader));
        Tasks.AddToTaskQueue(new Task(GetGithubMods));
    }

    private void SleepForTime()
    {
        System.Threading.Thread.Sleep(500);
    }

    private void InstallModLoader()
    {
        try
        {
            string ManagedFolder = System.IO.Path.Combine(ModInfoTools.DataFolder, "Managed");
            Patcher.PathToExe = System.IO.Path.Combine(ManagedFolder, "QModManager.exe");

            if (!System.IO.File.Exists(Patcher.PathToExe))
            {
                Patcher.UpdatePatcher(ManagedFolder);
                Patcher.RunExe("-i");
            }
            else if (ConfigHandler.CacheValue("lastpatchversion", "0.0.0") != Tools.Version_Number)
            {
                Patcher.UpdatePatcher(ManagedFolder);
                Patcher.RunExe("-u");
                Patcher.IsReinstalling = true;
            }
            else
            {
                Patcher.RunExe("-i");
            }
            ConfigHandler.SetValue("lastpatchversion", Tools.Version_Number);
        }
        catch (Exception E)
        {
            _SupressGithubMessage = true;
            Log("Unable to use patcher! Game may not load mods!\n" + E.Message);
        }
    }

    bool _SupressGithubMessage;

    private void GetGithubMods()
    {
        try
        {
            if (!_SupressGithubMessage)
            {
                Log("Finding Github mods...");
            }
            buttonSearchMods.Visible = ModInfoTools.GetFirstGithubMods();
        }
        catch (Exception E)
        {
            if (!_SupressGithubMessage)
            {
                Log("Unable to get Github mods!\n" + E.Message);
            }
        }
        _SupressGithubMessage = false;
    }
    private void GetMoreGithubMods()
    {
        try
        {
            Log("Finding more Github mods...");
            buttonSearchMods.Visible = ModInfoTools.GetMoreGithubMods();
        }
        catch (Exception E)
        {
            Log("Unable to get Github mods!\n" + E.Message);
        }
    }
    private void GetLocalMods()
    {
        Log("Finding local mods...");
        ModInfoTools.GetLocalMods(ModListStoreLocal);
    }

    private TreeViewColumn AddColumn(string ColumnTitle, TreeView TreeView, CellRenderer NewRenderer, string Attribute, int Index)
    {
        var Column = new TreeViewColumn
        {
            Title = ColumnTitle
        };
        TreeView.AppendColumn(Column);
        Column.PackStart(NewRenderer, true);
        Column.AddAttribute(NewRenderer, Attribute, Index);
        return Column;
    }

    private void SetupTree()
    {
        treeviewLocalMods.Selection.Changed += TreeView_SelectionChanged;

        var SC = AddColumn("Active", treeviewLocalMods, new CellRendererToggle(), "active", 0);
        SC.Clickable = true; SC.Clicked += StateColumn_Clicked;
        AddColumn("Name", treeviewLocalMods, new CellRendererText(), "markup", 1);
        AddColumn("Description", treeviewLocalMods, new CellRendererText(), "text", 2);
        AddColumn("Author", treeviewLocalMods, new CellRendererText(), "text", 3);
        ModListStoreLocal = new ListStore(typeof(bool), typeof(string), typeof(string), typeof(string), typeof(ModInfoHolder));
        ModFilterLocal = new TreeModelFilter(ModListStoreLocal, null);
        ModSortLocal = new TreeModelSort(ModFilterLocal);
        treeviewLocalMods.Model = ModSortLocal;

        ModFilterLocal.VisibleFunc = new TreeModelFilterVisibleFunc(FilterTree);
        ModSortLocal.DefaultSortFunc = new TreeIterCompareFunc(SortTree);

        treeviewGithubMods.Selection.Changed += TreeView_SelectionChanged;

        SC = AddColumn("Installed", treeviewGithubMods, new CellRendererToggle(), "active", 0);
        SC.Clickable = true; SC.Clicked += StateColumn_Clicked;
        AddColumn("Name", treeviewGithubMods, new CellRendererText(), "markup", 1);
        AddColumn("Description", treeviewGithubMods, new CellRendererText(), "text", 2);
        AddColumn("Author", treeviewGithubMods, new CellRendererText(), "text", 3);
        ModListStoreGithub = new ListStore(typeof(bool), typeof(string), typeof(string), typeof(string), typeof(ModInfoHolder));
        ModFilterGithub = new TreeModelFilter(ModListStoreGithub, null);
        ModSortGithub = new TreeModelSort(ModFilterGithub);
        treeviewGithubMods.Model = ModSortGithub;

        ModFilterGithub.VisibleFunc = new TreeModelFilterVisibleFunc(FilterTree);
        ModSortGithub.DefaultSortFunc = new TreeIterCompareFunc(SortTree);
    }

    private bool FilterTree(TreeModel treeModel, TreeIter iter)
    {
        string search = entryModSearch.Text.ToLower();
        if (string.IsNullOrWhiteSpace(search))
            return true;
        return ((string)treeModel.GetValue(iter, (int)TreeColumnInfo.Name)).ToLower().Contains(search) ||
            ((string)treeModel.GetValue(iter, (int)TreeColumnInfo.Author)).ToLower().Contains(search) ||
            ((string)treeModel.GetValue(iter, (int)TreeColumnInfo.Desc)).ToLower().Contains(search);
    }

    private int SortTree(TreeModel treeModel, TreeIter A, TreeIter B)
    {
        return 0;
    }

    TreeView CurrentTreeView
    {
        get
        {
            switch (TabPagerMods.Page)
            {
                case 0: return treeviewLocalMods;
                case 1: return treeviewGithubMods;
                default: return null;
            }
        }
    }

    public void CloseAll()
    {
        ConfigHandler.SaveConfig();
        Tasks.ClearTasks();
        DownloadFolder.KillDownload = 1;
        Application.Quit();
        Tools.AllowedToRun = false;

        //Kill running QModManager processes, if there are any
        KillPatcher();
    }

    public void KillPatcher()
    {
        foreach (var k in System.Diagnostics.Process.GetProcessesByName("QModManager")) k.Kill();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        CloseAll();
        a.RetVal = true;
    }

    public void Log(string CurrentState)
    {
        if (string.IsNullOrEmpty(CurrentState))
        {
            Tools.invoke.Add(delegate
            {
                labelCurrentTask.Text = "";
            });
            return;
        }
        Tools.invoke.Add(delegate 
        {
            var i = CurrentState.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string str = i[0];
            if (i.Length > 1)
            {
                str += "\n" + i[1];
            }
            labelCurrentTask.Text = str;
        });
        Console.WriteLine(CurrentState);
    }

    protected void SetGithubToken_Clicked(object sender, EventArgs e)
    {
        if (_dialogGithubToken == null) _dialogGithubToken = new DialogGithubToken();
        else _dialogGithubToken.ActivateFocus();
        _dialogGithubToken.Destroyed += SetGithubToken_Clear;
        _dialogGithubToken.Show();
    }

    private void SetGithubToken_Clear(object sender, EventArgs e)
    {
        _dialogGithubToken = null;
    }

    void StateColumn_Clicked(object sender, EventArgs e)
    {
        CurrentTreeView.Selection.GetSelected(out var iter);
    }

    private void TreeView_SelectionChanged(object sender, EventArgs e)
    {
        bool flag = CurrentTreeView.Selection.CountSelectedRows() != 0;
        if (flag)
        {
            var mod = GetModInfoFromSelected();
            ModInfoVBox.Visible = mod != null;
            if (mod != null)
                UpdateModInfoUI(mod);
        }
        else
        {
            ModInfoVBox.Visible = false;
        }
    }

    private void UpdateModInfoUI(ModInfoHolder modInfo)
    {
        labelModTitle.Markup = "<b>" + modInfo.FancyName() + "</b>";
        labelModLink.Text = modInfo.Site;
        labelModDesc.Text = modInfo.InlineDescription;
        if (TabPagerMods.CurrentPage == 0)
        {
            comboboxModState.Visible = true;
            buttonModDownload.Label = "Update";
            buttonModRemove.Visible = true;

            comboboxModState.Active = (int)modInfo.State;
        }
        else
        {
            comboboxModState.Visible = false;
            buttonModDownload.Label = "Download";
            buttonModRemove.Visible = false;
        }
    }

    private ModInfoHolder GetModInfoFromSelected()
    {
        CurrentTreeView.Selection.GetSelected(out var iter);
        return GetModInfoFromIter(iter);
    }
    private ModInfoHolder GetModInfoFromIter(TreeIter Row)
    {
        switch (TabPagerMods.CurrentPage)
        {
            case 0: return (ModInfoHolder)ModSortLocal.GetValue(Row, (int)TreeColumnInfo.ModInfo);
            case 1: return (ModInfoHolder)ModSortGithub.GetValue(Row, (int)TreeColumnInfo.ModInfo);
            default: return null;
        }
    }

    protected void EntryModSearchActivated(object sender, EventArgs e)
    {
        ModFilterGithub.Refilter();
        ModFilterLocal.Refilter();
        Log("Refiltered");
    }

    protected void ButtonSearchModsClicked(object sender, EventArgs e)
    {
        Log("That button doesn't do anything yet, sorry");
    }

    protected void ChangeSkipStart(object o, EventArgs args)
    {
        ConfigHandler.SetValue("skipstart", SkipStartAction.Active);
    }

    protected void GetModFromCloud(object sender, EventArgs e)
    {
        var modInfo = GetModInfoFromSelected();
        DownloadMod(modInfo, TabPagerMods.CurrentPage);
    }

    public void DownloadMod(ModInfoHolder ModRef, int TabPage)
    {
        if (TabPage != 0) // Is a server tab
        {
            if (ModRef.FoundOther == 1)
            {
                var localMod = ModInfoTools.LocalMods[ModRef.Name];
                //if (localMod.State == ModInfoHolder.ModState.Disabled)
                //{
                //    Log("Can't update a disabled mod!");
                //    return;
                //}
                if (ModDownloader.AddModDownload(ModRef, ModListStoreGithub))
                {
                    ModListStoreLocal.SetValue(localMod.TreeIter, (int)TreeColumnInfo.Desc, "Updating...");
                }
                return;
            }
            ModDownloader.AddModDownload(ModRef, ModListStoreGithub);
            return;
        }
        if (!string.IsNullOrEmpty(ModRef.CloudName))
        {
            ModInfoHolder cloudModInfo = null;
            if (ModRef.FoundOther == 0)
            {
                bool flag = true;
                try
                {
                    var repoItem = GetRepos.GetOneRepo(ModRef.CloudName);
                    if (ModInfoTools.GetGithubMod(repoItem))
                    {
                        cloudModInfo = ModInfoTools.lastGithubMod;
                        flag = false;
                    }
                }
                catch (Exception E)
                {
                    Console.WriteLine(E);
                }
                if (flag)
                {
                    Log("Could not locate server mod!");
                    ModRef.FoundOther = -1;
                    return;
                }
            }
            if (cloudModInfo != null || ModInfoTools.GithubMods.TryGetValue(ModRef.CloudName, out cloudModInfo))
            {
                //if (modInfo.State == ModInfoHolder.ModState.Disabled)
                //{
                //    Log("Can't update a disabled mod!");
                //    return;
                //}
                if (ModDownloader.AddModDownload(cloudModInfo, ModListStoreGithub))
                {
                    ModListStoreLocal.SetValue(ModRef.TreeIter, (int)TreeColumnInfo.Desc, "Updating...");
                    return;
                }
            }
        }
        Log("Can't download mod!");
    }

    protected void SetModState(object sender, EventArgs e)
    {
        if (TabPagerMods.CurrentPage != 0) return;
        var modInfo = GetModInfoFromSelected();
        if (modInfo != null)
        {
            var newState = (ModInfoHolder.ModState)comboboxModState.Active;
            SetModState(modInfo, newState);
        }
    }

    private void SetModState(ModInfoHolder modInfo, ModInfoHolder.ModState newState)
    {
        if (newState == modInfo.State)
            return;
        //if (modInfo.State == ModInfoHolder.ModState.Disabled)
        //{
        //    SetLocalModDisabled(ref modInfo.FilePath, false);
        //}
        modInfo.State = newState;
        ModListStoreLocal.SetValue(modInfo.TreeIter, (int)TreeColumnInfo.State, newState == ModInfoHolder.ModState.Enabled);
        //if (newState == ModInfoHolder.ModState.Disabled)
        //{
        //    SetLocalModDisabled(ref modInfo.FilePath, true);
        //    Log("Relocated " + modInfo.FancyName());
        //    return;
        //}
        modInfo.EditModJson("Enable", modInfo.State == ModInfoHolder.ModState.Enabled);
        if (newState == ModInfoHolder.ModState.Enabled)
        {
            Log("Activated " + modInfo.FancyName() + (EnableDependencies(modInfo) ? " and dependencies" : ""));
        }
        else if (newState == ModInfoHolder.ModState.Inactive)
        {
            Log("Deactivated " + modInfo.FancyName());
        }
    }

    //internal void SetLocalModDisabled(ref string path, bool Disable)
    //{
    //    string newPath = ModInfoTools.RootFolder + @"/QMods" + (Disable ? @"-Disabled/" : @"/") + new System.IO.DirectoryInfo(path).Name;
    //    System.IO.Directory.Move(path, newPath);
    //    path = newPath;
    //}

    private bool EnableDependencies(ModInfoHolder mod)
    {
        bool result = false;
        foreach (string dependency in mod.RequiredModNames)
        {
            if (ModInfoTools.LocalMods.TryGetValue(dependency.Substring(dependency.LastIndexOf('/') + 1), out ModInfoHolder modDependency))
            {
                if (modDependency.State != ModInfoHolder.ModState.Enabled)
                {
                    SetModState(modDependency, ModInfoHolder.ModState.Enabled);
                    result = true;
                }
            }
        }
        return result;
    }

    protected void DeleteLocalMod(object sender, EventArgs e)
    {
        var modToDelete = GetModInfoFromSelected();
        Log("Deleting " + modToDelete.Name + "...");
        if (modToDelete.FoundOther == 1 && ModInfoTools.GithubMods.TryGetValue(modToDelete.CloudName, out ModInfoHolder cloudModInfo))
        {
            ModListStoreGithub.SetValue(cloudModInfo.TreeIter, (int)TreeColumnInfo.State, false);
        }
        if ((string)ModListStoreLocal.GetValue(modToDelete.TreeIter, (int)TreeColumnInfo.Desc) == "Updating...")
        {
            if (ModDownloader.Downloads[0].CloudName == modToDelete.CloudName)
            {
                Log("Killing update process for " + modToDelete.Name + "...");
                DownloadFolder.KillDownload = 2;
            }
            else
            {
                ModDownloader.Downloads.Remove(ModInfoTools.GithubMods[modToDelete.CloudName]);
                System.IO.Directory.Delete(modToDelete.FilePath, true);
                Log("Cancelled update; Deleted " + modToDelete.Name + "...");
            }
        }
        else
        {
            System.IO.Directory.Delete(modToDelete.FilePath, true);
            Log("Deleted " + modToDelete.Name + "...");
        }
        ModInfoTools.LocalMods.Remove(modToDelete.Name);
        if (modToDelete.CloudName != null && ModInfoTools.GithubMods.TryGetValue(modToDelete.CloudName, out ModInfoHolder cloudMod))
        {
            cloudMod.FoundOther = 0;
            ModListStoreGithub.SetValue(cloudMod.TreeIter, (int)TreeColumnInfo.State, false);
        }
        ModListStoreLocal.Remove(ref modToDelete.TreeIter);
        treeviewLocalMods.Selection.UnselectAll();
    }

    protected void TryDownloadAllModUpdates(object sender, EventArgs e)
    {
        foreach (var localMod in ModInfoTools.LocalMods)
        {
            if (localMod.Value.CloudName != null)
            {
                ModInfoHolder cloudModInfo = null;
                if (localMod.Value.FoundOther == 0)
                {
                    bool flag = true;
                    try
                    {
                        var repoItem = GetRepos.GetOneRepo(localMod.Value.CloudName);
                        if (ModInfoTools.GetGithubMod(repoItem))
                        {
                            cloudModInfo = ModInfoTools.lastGithubMod;
                            flag = false;
                        }
                    }
                    catch (Exception E)
                    {
                        Console.WriteLine(E);
                    }
                    if (flag)
                    {
                        localMod.Value.FoundOther = -1;
                    }
                }
                if (cloudModInfo != null || ModInfoTools.GithubMods.TryGetValue(localMod.Value.CloudName, out cloudModInfo))
                {
                    if (localMod.Value.CurrentVersion == cloudModInfo.CurrentVersion) continue;

                    //if (localMod.Value.State == ModInfo.ModState.Disabled)
                    //{
                    //    Log("Can't update a disabled mod! (" + localMod.Value.Name + ")", Color.OrangeRed);
                    //    continue;
                    //}
                    if (ModDownloader.AddModDownload(cloudModInfo, ModListStoreGithub))
                    {
                        ModListStoreLocal.SetValue(localMod.Value.TreeIter, (int)TreeColumnInfo.Desc, "Updating...");
                    }
                    continue;
                }
            }
        }
    }

    protected void OpenGithubPage(object sender, EventArgs e)
    {
        Process.Start("https://github.com/Aceba1/TerraTech-Mod-Manager-GTK");
    }

    protected void OpenForumPage(object sender, EventArgs e)
    {
        Process.Start("https://forum.terratechgame.com/index.php?threads/terratech-mod-manager.17208/");
    }

    protected void OpenWikiPage(object sender, EventArgs e)
    {
        Process.Start("https://terratech.gamepedia.com/TerraTech_Mod_Manager");
    }

    protected void TabChanged(object o, SwitchPageArgs args)
    {
        TreeView_SelectionChanged(o, args);
    }

    protected void UserInstallPatch(object sender, EventArgs e)
    {
        Patcher.RunByUser = true;
        Patcher.RunExe("-i");
    }

    protected void UserRemovePatch(object sender, EventArgs e)
    {
        Patcher.RunByUser = true;
        Patcher.RunExe("-u");
    }

    protected void UserUpdatePatch(object sender, EventArgs e)
    {
        KillPatcher();
        Patcher.RunByUser = false;
        ConfigHandler.SetValue("lastpatchversion", Tools.Version_Number);
        Tasks.AddToTaskQueue(new Task(UpdatePatch));
    }

    private void UpdatePatch()
    {
        Patcher.UpdatePatcher(System.IO.Path.Combine(ModInfoTools.DataFolder, "Managed"));
        Patcher.RunExe("-u");
        Patcher.IsReinstalling = true;
    }

    protected void UserUpdateTTMM(object sender, EventArgs e)
    {
        if (!UpdateProgram.LookForProgramUpdate())
            Log("No program update is available");
    }

    protected void ModDescPreviewer(object sender, EventArgs e)
    {
        if (_dialogDescription == null) _dialogDescription = new DialogDescription();
        else _dialogDescription.ActivateFocus();
        _dialogDescription.Destroyed += Description_Clear;
        _dialogDescription.Show();
        var modInfo = GetModInfoFromSelected();
        _dialogDescription.Site = modInfo.Site;
        _dialogDescription.Folder = modInfo.FilePath;
        _dialogDescription.Set(modInfo, TabPagerMods.CurrentPage != 0? DialogDescription.DescType.ServerModInfo : DialogDescription.DescType.LocalModInfo, modInfo.CurrentVersion, modInfo.GetDescription(), modInfo.FancyName());
    }

    private void Description_Clear(object sender, EventArgs e)
    {
        _dialogDescription = null;
    }
}