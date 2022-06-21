using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollTimeCtrl : MonoBehaviour
{

    public GameObject SessionTimer;
    float sliderValue = 10;
    // Start is called before the first frame update
    void Start()
    {
        SessionTimer.GetComponent<StartTimer>().TimerLength = sliderValue * 60;
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue = transform.GetComponent<Slider>().value;
        if (!SessionTimer.GetComponent<StartTimer>().Iscounting)
        { 
            SessionTimer.GetComponent<StartTimer>().TimerLength = sliderValue * 60;
        }
    }

}
