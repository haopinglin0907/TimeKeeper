using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SessionData;
using UnityEngine.UI;

public class StartSession : MonoBehaviour
{

    public GameObject SessionTimer;
    LogSession logSession;
    GameObject appManager;
    GameObject[] playerList;

    PlayerDataCtrl PlayerDataCtrl;
    SubjectSessionData tempSubjectSessionData;
    string tempDeviceName;
    int tempTrainingStateIndex;

    private enum SessionState {Idle, Timing, Pause}
    SessionState sessionState = SessionState.Idle;
    public TextMeshProUGUI ButtonTextGUI;
    public Button StateButton;
    public Slider TimerSlider;

    public void Awake()
    {
        // get reference to data script from app manager
        appManager = GameObject.Find("AppManager");
        logSession = appManager.GetComponent<LogSession>();
    }

    public void Start()
    {
        StateButton.GetComponent<Image>().color = Color.blue;
    }

    public void ActivateTimer()
    {

        if (sessionState == SessionState.Idle)
        {
            SessionTimer.GetComponent<StartTimer>().Iscounting = true;
            TimerSlider.gameObject.SetActive(false);
            playerList = GameObject.FindGameObjectsWithTag("Player");
            StartCoroutine(onCoroutineUpdateData());
            ButtonTextGUI.text = "Recording";
            sessionState = SessionState.Timing;
        }
        else if (sessionState == SessionState.Timing)
        {
            logSession.syncDone = false;
            ButtonTextGUI.text = "Session paused";
            SessionTimer.GetComponent<StartTimer>().Iscounting = false;
            StateButton.GetComponent<Image>().color = Color.red;
            sessionState = SessionState.Pause;
        }

        else if (sessionState == SessionState.Pause)
        {
            SessionTimer.GetComponent<StartTimer>().Iscounting = true;
            ButtonTextGUI.text = "Recording";
            StateButton.GetComponent<Image>().color = Color.blue;
            sessionState = SessionState.Timing;
        }
    }

    private IEnumerator onCoroutineUpdateData()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (SessionTimer.GetComponent<StartTimer>().Iscounting == true)
            { 
                playerList = GameObject.FindGameObjectsWithTag("Player");
                foreach (GameObject player in playerList)
                {
                    PlayerDataCtrl = player.GetComponent<PlayerDataCtrl>();
                    tempSubjectSessionData = PlayerDataCtrl.SubjectSessionData;
                    tempDeviceName = PlayerDataCtrl.deviceName;
                    tempTrainingStateIndex = PlayerDataCtrl.trainingState;
                    logSession.UpdateSessionSubjectData(tempSubjectSessionData, tempTrainingStateIndex, tempDeviceName);
                }
            }

        }
    }
}
