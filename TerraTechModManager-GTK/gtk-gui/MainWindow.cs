
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;

	private global::Gtk.Action FileAction;

	private global::Gtk.Action ConfigAction;

	private global::Gtk.Action HelpAction;

	private global::Gtk.Action FileAction1;

	private global::Gtk.Action ConfigAction1;

	private global::Gtk.Action HelpAction1;

	private global::Gtk.Action InstallPatchAction;

	private global::Gtk.Action RemovePatchAction;

	private global::Gtk.Action DownloadLatestPatcherAction;

	private global::Gtk.Action LookForTTMMUpdateAction;

	private global::Gtk.Action DownloadAllModUpdatesAction;

	private global::Gtk.ToggleAction ShowLogAction;

	private global::Gtk.ToggleAction SkipStartAction;

	private global::Gtk.Action SetGithubTokenAction;

	private global::Gtk.Action TTMMGithubPageAction;

	private global::Gtk.Action TTMMForumPageAction;

	private global::Gtk.Action TTMMWikiPageAction;

	private global::Gtk.Action GithubReleasesAction;

	private global::Gtk.VBox vbox1;

	private global::Gtk.HBox hbox4;

	private global::Gtk.MenuBar menubar1;

	private global::Gtk.Label labelCurrentTask;

	private global::Gtk.HBox hbox2;

	private global::Gtk.Label labelFind;

	private global::Gtk.Entry entryModSearch;

	private global::Gtk.Button buttonSearchMods;

	private global::Gtk.Notebook TabPagerMods;

	private global::Gtk.ScrolledWindow GtkScrolledWindow1;

	private global::Gtk.TreeView treeviewLocalMods;

	private global::Gtk.Label tabLabelLocalMods;

	private global::Gtk.ScrolledWindow GtkScrolledWindow;

	private global::Gtk.TreeView treeviewGithubMods;

	private global::Gtk.Label tabLabelGithubMods;

	private global::Gtk.VBox ModInfoVBox;

	private global::Gtk.VBox vbox3;

	private global::Gtk.Label labelModTitle;

	private global::Gtk.HBox hbox1;

	private global::Gtk.Label labelModDesc;

	private global::Gtk.Label labelModLink;

	private global::Gtk.HBox hbox3;

	private global::Gtk.ComboBox comboboxModState;

	private global::Gtk.Button buttonModDownload;

	private global::Gtk.Button buttonModInfo;

	private global::Gtk.Button buttonModRemove;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
		this.FileAction = new global::Gtk.Action("FileAction", global::Mono.Unix.Catalog.GetString("File"), null, null);
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString("File");
		w1.Add(this.FileAction, null);
		this.ConfigAction = new global::Gtk.Action("ConfigAction", global::Mono.Unix.Catalog.GetString("Config"), null, null);
		this.ConfigAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Config");
		w1.Add(this.ConfigAction, null);
		this.HelpAction = new global::Gtk.Action("HelpAction", global::Mono.Unix.Catalog.GetString("Help"), null, null);
		this.HelpAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Help");
		w1.Add(this.HelpAction, null);
		this.FileAction1 = new global::Gtk.Action("FileAction1", global::Mono.Unix.Catalog.GetString("File"), null, null);
		this.FileAction1.ShortLabel = global::Mono.Unix.Catalog.GetString("File");
		w1.Add(this.FileAction1, null);
		this.ConfigAction1 = new global::Gtk.Action("ConfigAction1", global::Mono.Unix.Catalog.GetString("Config"), null, null);
		this.ConfigAction1.ShortLabel = global::Mono.Unix.Catalog.GetString("Config");
		w1.Add(this.ConfigAction1, null);
		this.HelpAction1 = new global::Gtk.Action("HelpAction1", global::Mono.Unix.Catalog.GetString("Help"), null, null);
		this.HelpAction1.ShortLabel = global::Mono.Unix.Catalog.GetString("Help");
		w1.Add(this.HelpAction1, null);
		this.InstallPatchAction = new global::Gtk.Action("InstallPatchAction", global::Mono.Unix.Catalog.GetString("Install Patch"), null, null);
		this.InstallPatchAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Install Patch");
		w1.Add(this.InstallPatchAction, null);
		this.RemovePatchAction = new global::Gtk.Action("RemovePatchAction", global::Mono.Unix.Catalog.GetString("Remove Patch"), null, null);
		this.RemovePatchAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Remove Patch");
		w1.Add(this.RemovePatchAction, null);
		this.DownloadLatestPatcherAction = new global::Gtk.Action("DownloadLatestPatcherAction", global::Mono.Unix.Catalog.GetString("Download Latest Patcher"), null, null);
		this.DownloadLatestPatcherAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Download Latest Patcher");
		w1.Add(this.DownloadLatestPatcherAction, null);
		this.LookForTTMMUpdateAction = new global::Gtk.Action("LookForTTMMUpdateAction", global::Mono.Unix.Catalog.GetString("Look for TTMM Update"), null, null);
		this.LookForTTMMUpdateAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Look for TTMM Update");
		w1.Add(this.LookForTTMMUpdateAction, null);
		this.DownloadAllModUpdatesAction = new global::Gtk.Action("DownloadAllModUpdatesAction", global::Mono.Unix.Catalog.GetString("Download All Mod Updates"), null, null);
		this.DownloadAllModUpdatesAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Download All Mod Updates");
		w1.Add(this.DownloadAllModUpdatesAction, null);
		this.ShowLogAction = new global::Gtk.ToggleAction("ShowLogAction", global::Mono.Unix.Catalog.GetString("Show Log"), null, null);
		this.ShowLogAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Show Log");
		w1.Add(this.ShowLogAction, null);
		this.SkipStartAction = new global::Gtk.ToggleAction("SkipStartAction", global::Mono.Unix.Catalog.GetString("Skip Start"), null, null);
		this.SkipStartAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Skip Start");
		w1.Add(this.SkipStartAction, null);
		this.SetGithubTokenAction = new global::Gtk.Action("SetGithubTokenAction", global::Mono.Unix.Catalog.GetString("Set Github Token"), null, null);
		this.SetGithubTokenAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Set Github Token");
		w1.Add(this.SetGithubTokenAction, null);
		this.TTMMGithubPageAction = new global::Gtk.Action("TTMMGithubPageAction", global::Mono.Unix.Catalog.GetString("TTMM Github Page"), null, null);
		this.TTMMGithubPageAction.ShortLabel = global::Mono.Unix.Catalog.GetString("TTMM Github Page");
		w1.Add(this.TTMMGithubPageAction, null);
		this.TTMMForumPageAction = new global::Gtk.Action("TTMMForumPageAction", global::Mono.Unix.Catalog.GetString("TTMM Forum Page"), null, null);
		this.TTMMForumPageAction.ShortLabel = global::Mono.Unix.Catalog.GetString("TTMM Forum Page");
		w1.Add(this.TTMMForumPageAction, null);
		this.TTMMWikiPageAction = new global::Gtk.Action("TTMMWikiPageAction", global::Mono.Unix.Catalog.GetString("TTMM Wiki Page"), null, null);
		this.TTMMWikiPageAction.ShortLabel = global::Mono.Unix.Catalog.GetString("TTMM Wiki Page");
		w1.Add(this.TTMMWikiPageAction, null);
		this.GithubReleasesAction = new global::Gtk.Action("GithubReleasesAction", global::Mono.Unix.Catalog.GetString("Github Releases"), null, null);
		this.GithubReleasesAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Github Releases");
		w1.Add(this.GithubReleasesAction, null);
		this.UIManager.InsertActionGroup(w1, 0);
		this.AddAccelGroup(this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("TerraTech Mod Manager");
		this.Icon = global::Gdk.Pixbuf.LoadFromResource("TerraTechModManagerGTK.Big TTMM Logo.png");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 3;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox4 = new global::Gtk.HBox();
		this.hbox4.Name = "hbox4";
		this.hbox4.Spacing = 6;
		// Container child hbox4.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString(@"<ui><menubar name='menubar1'><menu name='FileAction1' action='FileAction1'><menuitem name='InstallPatchAction' action='InstallPatchAction'/><menuitem name='RemovePatchAction' action='RemovePatchAction'/><menuitem name='DownloadLatestPatcherAction' action='DownloadLatestPatcherAction'/><menuitem name='LookForTTMMUpdateAction' action='LookForTTMMUpdateAction'/><menuitem name='DownloadAllModUpdatesAction' action='DownloadAllModUpdatesAction'/></menu><menu name='ConfigAction1' action='ConfigAction1'><menuitem name='SkipStartAction' action='SkipStartAction'/><menuitem name='SetGithubTokenAction' action='SetGithubTokenAction'/></menu><menu name='HelpAction1' action='HelpAction1'><menuitem name='TTMMGithubPageAction' action='TTMMGithubPageAction'/><menuitem name='TTMMForumPageAction' action='TTMMForumPageAction'/><menuitem name='TTMMWikiPageAction' action='TTMMWikiPageAction'/></menu></menubar></ui>");
		this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget("/menubar1")));
		this.menubar1.Name = "menubar1";
		this.hbox4.Add(this.menubar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.menubar1]));
		w2.Position = 0;
		w2.Expand = false;
		// Container child hbox4.Gtk.Box+BoxChild
		this.labelCurrentTask = new global::Gtk.Label();
		this.labelCurrentTask.Name = "labelCurrentTask";
		this.labelCurrentTask.Xalign = 1F;
		this.labelCurrentTask.LabelProp = global::Mono.Unix.Catalog.GetString("Idle");
		this.hbox4.Add(this.labelCurrentTask);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.labelCurrentTask]));
		w3.Position = 1;
		w3.Padding = ((uint)(5));
		this.vbox1.Add(this.hbox4);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox4]));
		w4.Position = 0;
		w4.Expand = false;
		w4.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox2 = new global::Gtk.HBox();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		this.hbox2.BorderWidth = ((uint)(5));
		// Container child hbox2.Gtk.Box+BoxChild
		this.labelFind = new global::Gtk.Label();
		this.labelFind.Name = "labelFind";
		this.labelFind.LabelProp = global::Mono.Unix.Catalog.GetString("Find");
		this.hbox2.Add(this.labelFind);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.labelFind]));
		w5.Position = 0;
		w5.Expand = false;
		w5.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.entryModSearch = new global::Gtk.Entry();
		this.entryModSearch.CanFocus = true;
		this.entryModSearch.Name = "entryModSearch";
		this.entryModSearch.IsEditable = true;
		this.entryModSearch.InvisibleChar = '•';
		this.hbox2.Add(this.entryModSearch);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.entryModSearch]));
		w6.Position = 1;
		// Container child hbox2.Gtk.Box+BoxChild
		this.buttonSearchMods = new global::Gtk.Button();
		this.buttonSearchMods.CanFocus = true;
		this.buttonSearchMods.Name = "buttonSearchMods";
		this.buttonSearchMods.UseUnderline = true;
		this.buttonSearchMods.Label = global::Mono.Unix.Catalog.GetString("Continue");
		this.hbox2.Add(this.buttonSearchMods);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.buttonSearchMods]));
		w7.Position = 2;
		w7.Expand = false;
		w7.Fill = false;
		this.vbox1.Add(this.hbox2);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
		w8.Position = 1;
		w8.Expand = false;
		w8.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.TabPagerMods = new global::Gtk.Notebook();
		this.TabPagerMods.CanFocus = true;
		this.TabPagerMods.Name = "TabPagerMods";
		this.TabPagerMods.CurrentPage = 0;
		// Container child TabPagerMods.Gtk.Notebook+NotebookChild
		this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
		this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
		this.treeviewLocalMods = new global::Gtk.TreeView();
		this.treeviewLocalMods.CanFocus = true;
		this.treeviewLocalMods.Name = "treeviewLocalMods";
		this.treeviewLocalMods.SearchColumn = 1;
		this.GtkScrolledWindow1.Add(this.treeviewLocalMods);
		this.TabPagerMods.Add(this.GtkScrolledWindow1);
		// Notebook tab
		this.tabLabelLocalMods = new global::Gtk.Label();
		this.tabLabelLocalMods.Name = "tabLabelLocalMods";
		this.tabLabelLocalMods.LabelProp = global::Mono.Unix.Catalog.GetString("Installed Mods");
		this.TabPagerMods.SetTabLabel(this.GtkScrolledWindow1, this.tabLabelLocalMods);
		this.tabLabelLocalMods.ShowAll();
		// Container child TabPagerMods.Gtk.Notebook+NotebookChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.treeviewGithubMods = new global::Gtk.TreeView();
		this.treeviewGithubMods.CanFocus = true;
		this.treeviewGithubMods.Name = "treeviewGithubMods";
		this.treeviewGithubMods.SearchColumn = 1;
		this.GtkScrolledWindow.Add(this.treeviewGithubMods);
		this.TabPagerMods.Add(this.GtkScrolledWindow);
		global::Gtk.Notebook.NotebookChild w12 = ((global::Gtk.Notebook.NotebookChild)(this.TabPagerMods[this.GtkScrolledWindow]));
		w12.Position = 1;
		// Notebook tab
		this.tabLabelGithubMods = new global::Gtk.Label();
		this.tabLabelGithubMods.Name = "tabLabelGithubMods";
		this.tabLabelGithubMods.LabelProp = global::Mono.Unix.Catalog.GetString("Github Mods");
		this.TabPagerMods.SetTabLabel(this.GtkScrolledWindow, this.tabLabelGithubMods);
		this.tabLabelGithubMods.ShowAll();
		this.vbox1.Add(this.TabPagerMods);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.TabPagerMods]));
		w13.Position = 2;
		// Container child vbox1.Gtk.Box+BoxChild
		this.ModInfoVBox = new global::Gtk.VBox();
		this.ModInfoVBox.Name = "ModInfoVBox";
		this.ModInfoVBox.Spacing = 6;
		// Container child ModInfoVBox.Gtk.Box+BoxChild
		this.vbox3 = new global::Gtk.VBox();
		this.vbox3.Name = "vbox3";
		this.vbox3.Spacing = 6;
		// Container child vbox3.Gtk.Box+BoxChild
		this.labelModTitle = new global::Gtk.Label();
		this.labelModTitle.Name = "labelModTitle";
		this.labelModTitle.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Name</b>");
		this.labelModTitle.UseMarkup = true;
		this.vbox3.Add(this.labelModTitle);
		global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.labelModTitle]));
		w14.Position = 0;
		w14.Expand = false;
		w14.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.labelModDesc = new global::Gtk.Label();
		this.labelModDesc.Name = "labelModDesc";
		this.labelModDesc.Xalign = 0F;
		this.labelModDesc.LabelProp = global::Mono.Unix.Catalog.GetString("An inline description of the selected mod");
		this.labelModDesc.Wrap = true;
		this.hbox1.Add(this.labelModDesc);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.labelModDesc]));
		w15.Position = 0;
		w15.Padding = ((uint)(5));
		// Container child hbox1.Gtk.Box+BoxChild
		this.labelModLink = new global::Gtk.Label();
		this.labelModLink.CanFocus = true;
		this.labelModLink.Name = "labelModLink";
		this.labelModLink.Xalign = 1F;
		this.labelModLink.LabelProp = global::Mono.Unix.Catalog.GetString("Link");
		this.labelModLink.UseUnderline = true;
		this.labelModLink.Selectable = true;
		this.hbox1.Add(this.labelModLink);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.labelModLink]));
		w16.Position = 1;
		w16.Expand = false;
		w16.Fill = false;
		w16.Padding = ((uint)(5));
		this.vbox3.Add(this.hbox1);
		global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox1]));
		w17.Position = 1;
		w17.Expand = false;
		w17.Fill = false;
		this.ModInfoVBox.Add(this.vbox3);
		global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.ModInfoVBox[this.vbox3]));
		w18.Position = 0;
		w18.Expand = false;
		w18.Fill = false;
		// Container child ModInfoVBox.Gtk.Box+BoxChild
		this.hbox3 = new global::Gtk.HBox();
		this.hbox3.Name = "hbox3";
		this.hbox3.Spacing = 6;
		this.hbox3.BorderWidth = ((uint)(5));
		// Container child hbox3.Gtk.Box+BoxChild
		this.comboboxModState = global::Gtk.ComboBox.NewText();
		this.comboboxModState.AppendText(global::Mono.Unix.Catalog.GetString("Enabled"));
		this.comboboxModState.AppendText(global::Mono.Unix.Catalog.GetString("Inactive"));
		this.comboboxModState.AppendText(global::Mono.Unix.Catalog.GetString("Disabled"));
		this.comboboxModState.Name = "comboboxModState";
		this.comboboxModState.Active = 2;
		this.hbox3.Add(this.comboboxModState);
		global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.comboboxModState]));
		w19.Position = 0;
		w19.Expand = false;
		w19.Fill = false;
		// Container child hbox3.Gtk.Box+BoxChild
		this.buttonModDownload = new global::Gtk.Button();
		this.buttonModDownload.CanFocus = true;
		this.buttonModDownload.Name = "buttonModDownload";
		this.buttonModDownload.UseUnderline = true;
		this.buttonModDownload.Label = global::Mono.Unix.Catalog.GetString("Download Mod");
		this.hbox3.Add(this.buttonModDownload);
		global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.buttonModDownload]));
		w20.Position = 1;
		// Container child hbox3.Gtk.Box+BoxChild
		this.buttonModInfo = new global::Gtk.Button();
		this.buttonModInfo.CanFocus = true;
		this.buttonModInfo.Name = "buttonModInfo";
		this.buttonModInfo.UseUnderline = true;
		this.buttonModInfo.Label = global::Mono.Unix.Catalog.GetString("Description");
		this.hbox3.Add(this.buttonModInfo);
		global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.buttonModInfo]));
		w21.Position = 2;
		w21.Expand = false;
		w21.Fill = false;
		// Container child hbox3.Gtk.Box+BoxChild
		this.buttonModRemove = new global::Gtk.Button();
		this.buttonModRemove.CanFocus = true;
		this.buttonModRemove.Name = "buttonModRemove";
		this.buttonModRemove.UseUnderline = true;
		this.buttonModRemove.Label = global::Mono.Unix.Catalog.GetString("Delete Mod");
		this.hbox3.Add(this.buttonModRemove);
		global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.buttonModRemove]));
		w22.Position = 3;
		w22.Expand = false;
		w22.Fill = false;
		this.ModInfoVBox.Add(this.hbox3);
		global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.ModInfoVBox[this.hbox3]));
		w23.Position = 1;
		w23.Expand = false;
		w23.Fill = false;
		this.vbox1.Add(this.ModInfoVBox);
		global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.ModInfoVBox]));
		w24.Position = 3;
		w24.Expand = false;
		w24.Fill = false;
		this.Add(this.vbox1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 822;
		this.DefaultHeight = 431;
		this.buttonSearchMods.Hide();
		this.ModInfoVBox.Hide();
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.InstallPatchAction.Activated += new global::System.EventHandler(this.UserInstallPatch);
		this.RemovePatchAction.Activated += new global::System.EventHandler(this.UserRemovePatch);
		this.DownloadLatestPatcherAction.Activated += new global::System.EventHandler(this.UserUpdatePatch);
		this.LookForTTMMUpdateAction.Activated += new global::System.EventHandler(this.UserUpdateTTMM);
		this.DownloadAllModUpdatesAction.Activated += new global::System.EventHandler(this.TryDownloadAllModUpdates);
		this.SkipStartAction.Toggled += new global::System.EventHandler(this.ChangeSkipStart);
		this.SetGithubTokenAction.Activated += new global::System.EventHandler(this.SetGithubToken_Clicked);
		this.TTMMGithubPageAction.Activated += new global::System.EventHandler(this.OpenGithubPage);
		this.TTMMForumPageAction.Activated += new global::System.EventHandler(this.OpenForumPage);
		this.TTMMWikiPageAction.Activated += new global::System.EventHandler(this.OpenWikiPage);
		this.entryModSearch.Activated += new global::System.EventHandler(this.EntryModSearchActivated);
        this.entryModSearch.Changed += new global::System.EventHandler(this.EntryModSearchActivated);
		this.buttonSearchMods.Clicked += new global::System.EventHandler(this.ButtonSearchModsClicked);
		this.TabPagerMods.SwitchPage += new global::Gtk.SwitchPageHandler(this.TabChanged);
		this.comboboxModState.Changed += new global::System.EventHandler(this.SetModState);
		this.buttonModDownload.Clicked += new global::System.EventHandler(this.GetModFromCloud);
		this.buttonModInfo.Clicked += new global::System.EventHandler(this.ModDescPreviewer);
		this.buttonModRemove.Clicked += new global::System.EventHandler(this.DeleteLocalMod);
	}
}
