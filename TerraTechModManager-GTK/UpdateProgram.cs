using System;
using System.Diagnostics;
using System.IO;

namespace TerraTechModManagerGTK
{
    public static class UpdateProgram
    {
        public static void V_LookForProgramUpdate() => LookForProgramUpdate();

        public static bool LookForProgramUpdate()
        {
            bool result = false;
            try
            {
                var latest = Downloader.GetUpdateInfo.GetRelease("Aceba1/TerraTech-Mod-Manager-GTK");
                if (latest.tag_name != Tools.Version_Number)
                {
                    result = true;
                    MainWindow.inst.Log("TTMM update found!");
                    Tools.invoke.Add(delegate
                    {
                        using (var updateScreen = new DialogDescription())
                        {
                            updateScreen.Set(DialogDescription.DescType.UpdateInfo, $"<b>Update: {latest.name}</b>", latest.body, latest.tag_name);
                            updateScreen.Site = latest.html_url;
                            updateScreen.Show();
                        }
                    });
                }
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                MainWindow.inst.Log("Update check failed" + E.Message);
            }
            return result;
        }

        public static void UpdateAccepted()
        {
            string targetPath = AppDomain.CurrentDomain.BaseDirectory;
            string downloadPath = Path.Combine(targetPath, "Update");
            var info = Directory.CreateDirectory(downloadPath);
            Downloader.DownloadFolder.Download("https://github.com/Aceba1/TerraTech-Mod-Manager-GTK/tree/master/Build/TTMM", "Aceba1/TerraTech-Mod-Manager-GTK", downloadPath);
            string executable = Path.Combine(targetPath, info.GetFiles("*.exe")[0].Name);

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            if (Tools.IsLinux)
            {
                startInfo.FileName = "/bin/bash";
                startInfo.Arguments = $" -c \"" +
                    $"echo Begin install...&&" +
                    $"sleep 5s&&" +
                    $"cd '{downloadPath}'&&" +
                    $"mv -f * ..&&" +
                    $"rm -r {downloadPath}" +
                    $"echo Done!&&" +
                    $"sleep 5s&&" +
                    $"mono '{executable}'\"";
                startInfo.CreateNoWindow = false;
            }
            else
            {
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C" +
                    $"echo Begin install...&" +
                    $"timeout 5&" +
                    $"move /y \"{downloadPath}\\*\" \"{targetPath}\"&" +
                    $"del /q {downloadPath}&" +
                    $"echo Done!&" +
                    $"timeout 5&" +
                    $"start \"ttmm2\" \"{executable}\"";
            }
            process.StartInfo = startInfo;
            process.Start();
            MainWindow.inst.CloseAll();
        }
    }
}
