namespace app_for_fun
{
    using System;
    using System.IO;

    static public class ShutDownFile
    {
        static public void ShutDown(int seconds)
        {
            String text = String.Format("@echo off \nC:\\Windows\\System32\\shutdown.exe -s -t {0}", seconds);
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
