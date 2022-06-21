using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelSubject : MonoBehaviour
{
    public GameObject CurrentSubject;


    public void CancelCurrentSubject()
    {
        Destroy(CurrentSubject);
    }
}
