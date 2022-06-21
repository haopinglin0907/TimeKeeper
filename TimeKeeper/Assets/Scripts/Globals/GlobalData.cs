// Data shared across scenes
using System.Collections.Generic;


public static class GlobalData
{
    private static string rootPath;

    public static string RootPath
    {
        get { return rootPath; }
        set { rootPath = value; }
    }
}