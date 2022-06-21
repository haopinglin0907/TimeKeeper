using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeStatus : MonoBehaviour
{
    private enum States {Training, Waiting, Helping};
    public TextMeshProUGUI ButtonTextGUI;
    public Button StateButton;
    public int CurrentStateIndex = 1;
    States CurrentState = States.Training;

    private void Start()
    {
        StateButton.GetComponent<Image>().color = Color.green;
    }

    public void ChangeState()
    {
        if (CurrentState == States.Training)
        {
            CurrentState = States.Waiting;
            // Change Button Color and Text
            
            ButtonTextGUI.text = "Waiting";
            StateButton.GetComponent<Image>().color = Color.blue;
            CurrentStateIndex = 2;
        }

        else if (CurrentState == States.Waiting)
        {
            CurrentState = States.Helping;
            // Change Button Color and Text
            
            ButtonTextGUI.text = "Helping";
            StateButton.GetComponent<Image>().color = Color.red;
            CurrentStateIndex = 3;
        }

        else if (CurrentState == States.Helping)
        {
            CurrentState = States.Training;
            // Change Button Color and Text
            
            ButtonTextGUI.text = "Training";
            StateButton.GetComponent<Image>().color = Color.green;
            CurrentStateIndex = 1;
        }
    }
}
