namespace app_for_fun
{
    using System.IO;
    using System.Diagnostics;
    static public class CreateBatFile
    {
        static public void CreateBat(string contains)
        {
            var file = new StreamWriter("shut down.bat");
            file.Write(contains);
            file.Close();
            Process.Start("shut down.bat");
        }
    }
}
