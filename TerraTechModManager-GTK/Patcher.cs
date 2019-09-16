using System;
using System.Diagnostics;
using System.IO;

namespace TerraTechModManagerGTK
{
    public static class Patcher
    {
        public static string PathToExe;
        public static Process EXE;
        public static bool IsReinstalling, RunByUser;


        public static void UpdatePatcher(string ManagedPath)
        {
            MainWindow.inst.Log("Downloading Patcher executable...");
            Downloader.DownloadFolder.Download("https://github.com/QModManager/TerraTech/tree/master/Installer", "QModManager/TerraTech", ManagedPath);
            MainWindow.inst.Log("Done!");
        }

        public static Process RunExe(string args = "")
        {
            try
            {
                if (EXE != null && !EXE.HasExited)
                {
                    MainWindow.inst.Log("The patcher is already running!");
                    return EXE;
                }
            }
            catch { /* fail silently */ }
            Process patcher = new Process();
            patcher.StartInfo.WorkingDirectory = Tools.IsLinux ? null : Path.Combine(PathToExe, @"../");
            patcher.StartInfo.FileName = Tools.IsLinux ? "/bin/bash" : PathToExe;
            patcher.StartInfo.Arguments = Tools.IsLinux ? $" -c \"cd '{System.IO.Directory.GetParent(PathToExe)}' && {(Tools.IsMacOSX?Tools.MonoMacOSX:"mono")} '{PathToExe}' {args}\"" : args;

            patcher.StartInfo.UseShellExecute = false;
            patcher.StartInfo.RedirectStandardOutput = true;
            patcher.StartInfo.CreateNoWindow = true;
            patcher.OutputDataReceived += HandlePatcher;
            try
            {
                patcher.Start();
                patcher.BeginOutputReadLine();
                EXE = patcher;
                if (RunByUser)
                {
                    MainWindow.inst.Log("Booted patcher");
                }
                return patcher;
            }
            catch (Exception E)
            {
                Console.WriteLine(E);
                MainWindow.inst.Log("Could not boot patcher!\n" + E.Message);
                return null;
            }
        }

        private static void HandlePatcher(object sender, DataReceivedEventArgs e)
        {
            if (e == null)
            {
                MainWindow.inst.Log("Communication with patcher is lost!");
                return;
            }
            if (string.IsNullOrEmpty(e.Data)) return;
            if (e.Data.EndsWith("exit..."))
            {
                EXE.CancelOutputRead();
                EXE.OutputDataReceived -= HandlePatcher;
                try
                {
                    EXE.Kill();
                }
                catch { /* fail silently */ }
                try
                {
                    EXE.Close();
                }
                catch { /* fail silently */ }
                if (IsReinstalling)
                {
                    IsReinstalling = false;
                    try
                    {
                        EXE.WaitForExit(5000);
                    }
                    catch { /* fail silently */ }
                    RunExe("-i");
                }
            }
            else if (e.Data.StartsWith("Tried to force"))
            {
                if (RunByUser)
                {
                    if (e.Data[15] == 'i')
                    {
                        MainWindow.inst.Log("The patch is already installed");
                    }
                    else
                    {
                        MainWindow.inst.Log("The patch is already not installed");
                    }
                }
            }
            else if (e.Data.EndsWith("successfully"))
            {
                MainWindow.inst.Log(e.Data);
            }
            Console.WriteLine(e.Data);
        }
    }
}
