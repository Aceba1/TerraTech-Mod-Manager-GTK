using System;

namespace TerraTechModManagerGTK
{
    public partial class DialogGithubToken : Gtk.Dialog
    {
        public DialogGithubToken()
        {
            this.Build();
            entryGithubKey.Text = Tools.GithubToken.Value;
        }

        protected void Dialog_Accepted(object sender, EventArgs e)
        {
            Tools.GithubToken.Value = entryGithubKey.Text;
            this.Destroy();
        }

        protected void DestroyDialog(object sender, EventArgs e)
        {
            this.Destroy();
        }
    }
}
