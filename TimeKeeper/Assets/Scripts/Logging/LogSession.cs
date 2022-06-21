using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SessionData;
using System;
using System.IO;
using UnityEngine.Networking;

public class LogSession : MonoBehaviour
{
    public SubjectSessionData subjectSessionData;
    public AllSubjectSessionDatabase allSubjectSessionDatabase;
    public string filepath;
    public string filepath_synced;
    string url = "https://ttshml1.fhtsecethz.org/timerKeeperPost";
    public string dateCreated;
    public string timeStarted;
    public bool syncDone = false;

    private string syncDataFolder;

    public void Awake()
    {
        InitialiseSessionDatabase();
        dateCreated = DateTime.Now.ToString("yyyyMMdd");
        timeStarted = DateTime.Now.ToString("HHmmss");

        syncDataFolder = Application.persistentDataPath + "/Data/Synced";
        if (!Directory.Exists(syncDataFolder))
        {
            Directory.CreateDirectory(syncDataFolder);
        }
    }

    // SESSION DATA
    public void InitialiseSessionDatabase()
    {
        allSubjectSessionDatabase = new AllSubjectSessionDatabase();
        allSubjectSessionDatabase.AllSubjectSessionDataList = new List<SubjectSessionData>();
    }

    public SubjectSessionData InitialiseSessionSubject()
    {
        subjectSessionData = new SubjectSessionData();
        subjectSessionData.userData = LogGeneric.InitialiseUserData();
        subjectSessionData.baseData = LogGeneric.InitialiseBaseData();

        return subjectSessionData;

    }

    public void UpdateSessionSubjectData(SubjectSessionData subjectSessionData, int trainingState, string deviceName)
    {
        // 每個user 每秒鐘都跑一次這個
        string timestamp = DateTime.Now.ToString("HHmmss");
        subjectSessionData.baseData.timestamp.Add(timestamp);
        subjectSessionData.baseData.trainingState.Add(trainingState);
        subjectSessionData.baseData.deviceName.Add(deviceName);

        Debug.Log(subjectSessionData.userData.id + " " + timestamp + " " + "training state: " + trainingState.ToString() + " " + deviceName);
    }

    public void UpdateSessionSubjectDatabase(SubjectSessionData subjectSessionData)
    {   
        // Upon clicking "X" or end of task
        allSubjectSessionDatabase.AllSubjectSessionDataList.Add(subjectSessionData);
    }

    public void SaveSessionData()
    {
        string filename = String.Format("{0}-{1}", dateCreated, timeStarted);
        filepath = LogUtility.CreateFilePath(filename);
        // create json string
        string json = JsonUtility.ToJson(allSubjectSessionDatabase, true);

        // write data
        LogUtility.WriteData(filepath, json);

        // sync file
        StartCoroutine(PostFile(filepath, filename));

        // Move file
        MoveFile(filepath, filename);
    }

    public void MoveFile(string originalFilepath,string filename)
    {
        File.Move(originalFilepath, syncDataFolder + "/" + filename + ".json");
    }

    private IEnumerator PostFile(string originalFilepath, string filename)
    {
        WWWForm form = new WWWForm();
        string json = JsonUtility.ToJson(allSubjectSessionDatabase, true);

        form.AddField("file", json);
        form.AddField("session", filename);
        //byte[] bFile = File.ReadAllBytes(originalFilepath);
        //form.AddBinaryData("file", bFile, filename);

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        if (www.responseCode == (long)System.Net.HttpStatusCode.OK && string.IsNullOrEmpty(www.error))
        {
            syncDone = true;
        }
    }
    
}
