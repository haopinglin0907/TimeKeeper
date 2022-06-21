using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{
    public float TimerLength = 2400;
    public bool Iscounting = false;
    public Button SaveAndSync;
    public Button StartPause;

    private TextMeshProUGUI TimerText;
    LogSession logSession;
    GameObject appManager;
    

    public void Awake()
    {
        // get reference to data script from app manager
        appManager = GameObject.Find("AppManager");
        logSession = appManager.GetComponent<LogSession>();
        TimerText = transform.GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        // Timer update
        if (Iscounting)
        {
            TimerLength -= Time.deltaTime;
        }

        // Timer text display
        int remainder = ((int)TimerLength % 60);
        if (remainder < 10)
        {
            TimerText.text = ((int)(TimerLength / 60)).ToString() + ":0" + remainder.ToString();
        }
        else
        {
            TimerText.text = ((int)(TimerLength / 60)).ToString() + ":" + remainder.ToString();
        }
        SaveAndSync.GetComponent<Image>().enabled = false;
        SaveAndSync.GetComponentInChildren<Text>().text = "";

        // Save and Sync button display
        if (TimerLength <= 0)
        {
            SaveAndSync.GetComponent<SaveDataOnClick>().Save();
            StartPause.GetComponentInChildren<TextMeshProUGUI>().text = "Session Ended";
            Iscounting = false;
        }
        
        else if (!Iscounting && TimerLength > 0 && logSession.syncDone == false)
        {
            SaveAndSync.GetComponent<Image>().enabled = true;
            SaveAndSync.GetComponentInChildren<Text>().text = "Save and Sync";
        }

        else if (!Iscounting && TimerLength > 0 && logSession.syncDone == true)
        {
            SaveAndSync.GetComponent<Image>().enabled = true;
            SaveAndSync.GetComponentInChildren<Text>().text = "Done!";
        }
    }

}
