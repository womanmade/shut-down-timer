namespace app_for_fun
{
    using System.IO;
    static public class DontShutDownFile
    {
        static public void DontShutDown()
        {
            string text = "@echo off \nC:\\Windows\\System32\\shutdown.exe -a";
            if (File.Exists("shut down.bat"))
            {
                File.Delete("shut down.bat");
                CreateBatFile.CreateBat(text);
            }
            else
            {
                CreateBatFile.CreateBat(text);
            }

        }
    }
}
