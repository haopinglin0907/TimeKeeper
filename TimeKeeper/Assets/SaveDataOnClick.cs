using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SessionData;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class SaveDataOnClick : MonoBehaviour
{
    GameObject appManager;
    LogSession logSession;
    GameObject[] playerList;
    PlayerDataCtrl PlayerDataCtrl;

    SubjectSessionData tempSubjectSessionData;

    public void Awake()
    {
        // get reference to data script from app manager
        appManager = GameObject.Find("AppManager");
        logSession = appManager.GetComponent<LogSession>();
        transform.GetComponent<Image>().enabled = false;
        transform.GetComponentInChildren<Text>().text = "";
    }

    public void Save()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player");
        logSession.InitialiseSessionDatabase();

        foreach (GameObject player in playerList)
        {
            PlayerDataCtrl = player.GetComponent<PlayerDataCtrl>();
            tempSubjectSessionData = PlayerDataCtrl.SubjectSessionData;
            logSession.UpdateSessionSubjectDatabase(tempSubjectSessionData);
        }

        logSession.SaveSessionData();
        Debug.Log("Saved data");

       
        
    }
}
