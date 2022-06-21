using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SessionData;
public class LogGeneric : MonoBehaviour
{

    public static BaseData InitialiseBaseData()
    {
        BaseData baseData = new BaseData();
        baseData.deviceName = new List<string>();
        baseData.timestamp = new List<string>();
        baseData.trainingState = new List<int>();

        return baseData;
    }
    public static UserData InitialiseUserData()
    {

        UserData userData = new UserData();
        userData.id = "None";
        userData.dateCreated = DateTime.Now.ToString("yyyyMMdd");

        return userData;
    }

    public static void UpdateBaseData(ref BaseData baseData, string timestamp, int trainingState, string deviceName)
    {
        baseData.timestamp.Add(timestamp);
        baseData.trainingState.Add(trainingState);
        baseData.deviceName.Add(deviceName);

    }
}
