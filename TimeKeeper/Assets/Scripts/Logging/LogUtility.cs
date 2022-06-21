using System;
using System.IO;
using System.Threading;
using System.Security.Cryptography;
using System.Text;

public static class LogUtility
{

    public static void CreateRootDirectories()
    {

        // folder path
        string folderpath = GlobalData.RootPath + "/";

        // create folders
        Directory.CreateDirectory(folderpath);


    }

    public static string CreateFilePath(string filename)
    {

        // file path
        string filepath = GlobalData.RootPath + filename + ".json";

        return filepath;
    }

    public static void WriteData(string fullFilepath, string data)
    {
        Thread thread = new Thread(() => ThreadWrite(fullFilepath, data));
        thread.Start();
    }

    private static void ThreadWrite(string fullFilepath, string data)
    {
        File.WriteAllText(fullFilepath, data);
    }
}

