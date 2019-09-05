using System;
using System.Diagnostics;
namespace TerraTechModManagerGTK
{
    public partial class DialogDescription : Gtk.Dialog
    {
        public int Return = 0;

        public string Site, Folder, CloudName;

        private ModInfoHolder Mod;

        public enum DescType { NoButtons, LocalModInfo, ServerModInfo, UpdateInfo }

        public DialogDescription()
        {
            this.Build();
            entry3.Visible = false;
        }

        public void Set(ModInfoHolder Mod, DescType WindowType, string Title, string Message, string WindowTitle = null)
        {
            this.Mod = Mod;
            LocalModInfoArea.Visible = false;
            ServerModInfoArea.Visible = false;
            UpdateInfoArea.Visible = false;
            switch (WindowType)
            {
                case DescType.LocalModInfo: LocalModInfoArea.Visible = true; break;
                case DescType.ServerModInfo: ServerModInfoArea.Visible = true; break;
                case DescType.UpdateInfo: UpdateInfoArea.Visible = true; break;
            }
            labelTitle.Markup = "<b>" + Title + "</b>";
            labelTextView.Text = "";
            labelTextView.Markup = MarkdownConvert.ToPangoString(Message);
            if (string.IsNullOrWhiteSpace(labelTextView.Text))
            {
                labelTextView.Text = Message;
            }
            if (string.IsNullOrWhiteSpace(WindowTitle))
            {
                this.Title = "TTMM - " + Title;
            }
            else
            {
                this.Title = "TTMM - " + WindowTitle;
            }
        }

        protected void OpenFolderEvent(object sender, EventArgs e)
        {
            if (Tools.IsLinux)
            {
                Process.Start("xdg-open", Folder);
            }
            else
            {
                Process.Start(Folder);
            }
        }

        protected void OpenSiteEvent(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Site))
            {
                Process.Start(Site);
            }
            else
            {
                OpenFolderEvent(sender, e);
            }
        }

        protected void InstallModEvent(object sender, EventArgs e)
        {
            MainWindow.inst.DownloadMod(Mod, 1);
        }

        protected void InstallUpdateEvent(object sender, EventArgs e)
        {
            this.Destroy();
            UpdateProgram.UpdateAccepted();
        }

        protected void OnCloseEvent(object sender, EventArgs e)
        {
            this.Destroy();
        }

        protected void OnChanged(object sender, EventArgs e)
        {
            labelTextView.Markup = MarkdownConvert.ToPangoString(entry3.Text.Replace("\\n","\n"));
        }

        protected void OnTextview1InsertAtCursor(object o, Gtk.InsertAtCursorArgs args)
        {
        }

        protected void OnTextview1PopulatePopup(object o, Gtk.PopulatePopupArgs args)
        {
        }
    }
}
