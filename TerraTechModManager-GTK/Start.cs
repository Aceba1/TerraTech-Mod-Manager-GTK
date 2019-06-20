using System;
using System.IO;

namespace TerraTechModManagerGTK
{
    public partial class Start : Gtk.Window
    {
        public static bool finished;
        public static string text_st;
        public Start() : base(Gtk.WindowType.Toplevel)
        {
            Build();
            labelTip.Text = text_st;
            entryFileSelect.Text = Tools.TTRoot.Value;
            if (finished)
                base.Hide();
        }

        protected void OpenMain_Clicked(object sender, EventArgs e)
        {
            labelTip.Text = BootMain(entryFileSelect.Text);
            if (finished)
                base.Hide();
        }

        public static string BootMain(string path)
        {
            string rootpath = path;
            if (Directory.Exists(rootpath))
            {
                int file = Directory.GetFiles(rootpath, "TerraTech*.*", System.IO.SearchOption.TopDirectoryOnly).Length;
                string datafolder = "";
                if (file != 0)
                {
                    bool flag = false;
                    foreach (var folder in new System.IO.DirectoryInfo(rootpath).GetDirectories())
                        if (File.Exists(folder.FullName + "/Managed/Assembly-CSharp.dll"))
                        {
                            datafolder = folder.FullName;
                            flag = true;
                            break;
                        }
                    if (flag)
                    {
                        Tools.TTRoot.Value = rootpath;
                        ModInfoTools.RootFolder = rootpath;
                        ModInfoTools.DataFolder = datafolder;
                        MainWindow Main = new MainWindow();
                        finished = true;
                        Main.Show();
                        return "Loaded";
                    }
                }
                if (!finished)
                {
                    return "Invalid location";
                }
            }
            else
            {
                return "Path is nonexistent";
            }
            return "";
        }

    }
}
