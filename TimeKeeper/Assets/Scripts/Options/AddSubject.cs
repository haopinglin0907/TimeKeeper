using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSubject : MonoBehaviour
{
    public GameObject SubjectStatus;
    public GameObject SubjectPanel;
    GameObject NewSubject;
    private GameObject[] getCount;
    int count;

    public void AddNewSubject()
    {
        getCount = GameObject.FindGameObjectsWithTag("Player");
        count = getCount.Length;
        if (count <5)
        { 
            NewSubject = Instantiate(SubjectStatus, Vector3.zero, Quaternion.identity);
            NewSubject.transform.parent = SubjectPanel.transform;
            NewSubject.GetComponent<RectTransform>().sizeDelta = new Vector2(170, 170);
            NewSubject.transform.localScale = new Vector3(2, 2, 2);
        }


    }
}
