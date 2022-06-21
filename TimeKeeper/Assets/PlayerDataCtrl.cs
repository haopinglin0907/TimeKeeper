using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using SessionData;
using UnityEngine.UI;

public class PlayerDataCtrl : MonoBehaviour
{
    public GameObject SessionTimer;

    public string deviceName;
    public string subjectID;
    public int trainingState;
    public TextMeshProUGUI ButtonTextGUI;

    Dropdown dropdownText;
    TMP_InputField inputField;
    GameObject appManager;
    LogSession logSession;

    public SubjectSessionData SubjectSessionData; 

    public void Awake()
    {
        // get reference to data script from app manager
        appManager = GameObject.Find("AppManager");
        logSession = appManager.GetComponent<LogSession>();
    }

    // Start is called before the first frame update
    public void Start()
    {
        dropdownText = transform.GetComponentInChildren<Dropdown>();
        inputField = transform.GetComponentInChildren<TMP_InputField>();
        
        SubjectSessionData = new SubjectSessionData();
        SubjectSessionData = logSession.InitialiseSessionSubject();
        Debug.Log("Created subject");
    }

    public void Update()
    {
        deviceName = dropdownText.options[dropdownText.value].text;
        trainingState = transform.GetComponentInChildren<ChangeStatus>().CurrentStateIndex;
        subjectID = inputField.text;
        SubjectSessionData.userData.id = subjectID;
    }

}
