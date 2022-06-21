using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeStatus_v2 : MonoBehaviour
{
    private enum States { Training, Waiting, Helping };
    public Button TrainingButton;
    public Button WaitingButton;
    public Button HelpingButton;
    Color lightblue = new Color(0, 0, 1, 0.7f);
    //public int CurrentStateIndex = 2;

    private void Start()
    {
        // Default as waiting state
        TrainingButton.GetComponent<Image>().color = Color.white;
        WaitingButton.GetComponent<Image>().color = Color.yellow;
        HelpingButton.GetComponent<Image>().color = Color.white;
    }

    public void ChangeStateTraining()
    {
        transform.GetComponentInParent<PlayerDataCtrl>().trainingState = 1;
        TrainingButton.GetComponent<Image>().color = lightblue;
        WaitingButton.GetComponent<Image>().color = Color.white;
        HelpingButton.GetComponent<Image>().color = Color.white;

    }

    public void ChangeStateWaiting()
    {
        transform.GetComponentInParent<PlayerDataCtrl>().trainingState = 2;
        TrainingButton.GetComponent<Image>().color = Color.white;
        WaitingButton.GetComponent<Image>().color = Color.yellow;
        HelpingButton.GetComponent<Image>().color = Color.white;

    }

    public void ChangeStateHelping()
    {
        transform.GetComponentInParent<PlayerDataCtrl>().trainingState = 3;
        TrainingButton.GetComponent<Image>().color = Color.white;
        WaitingButton.GetComponent<Image>().color = Color.white;
        HelpingButton.GetComponent<Image>().color = Color.red;
    }
}
