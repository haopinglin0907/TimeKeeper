using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Load : MonoBehaviour
{

    void Start()
    {
        // create data directory if not created already
        string rootPath = Application.persistentDataPath + "/Data/";
        if (!Directory.Exists(rootPath)) Directory.CreateDirectory(rootPath);
        GlobalData.RootPath = rootPath;


        // set target frame rate
        Application.targetFrameRate = 60;

        // disable screen dimming
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        // go to connect scene
        SceneManager.LoadScene("Home");
    }
}
