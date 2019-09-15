using System;
using System.IO;
using Gtk;

namespace TerraTechModManagerGTK
{
    public partial class Start : Gtk.Window
    {
        public static bool finished;
        public static string text_st;
        public Start() : base(Gtk.WindowType.Toplevel)
        {
            Build();
            buttonStart.GrabFocus();
            labelTip.Text = text_st;
            entryFileSelect.Text = Tools.TTRoot.Value;
            if (finished)
                base.Visible = false;//.Hide();
        }

        protected void OpenMain_Clicked(object sender, EventArgs e)
        {
            labelTip.Text = BootMain(entryFileSelect.Text);
            if (finished)
                base.Visible = false;//.Hide();
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

        protected void OnDeleteEvent(object o, Gtk.DeleteEventArgs args)
        {
            Application.Quit();
            Tools.AllowedToRun = false;
            Environment.Exit(0);
            //args.RetVal = true;
        }

        protected void OnDestroyEvent(object o, DestroyEventArgs args)
        {
            Application.Quit();
            Tools.AllowedToRun = false;
            Environment.Exit(0);
            //args.RetVal = true;
        }
    }
}
