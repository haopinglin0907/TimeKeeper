using System.Collections;
using System.Collections.Generic;
using System;


namespace SessionData
{
    [Serializable]
    public class UserData
    {
        public string id;
        public string dateCreated;
    }

    [Serializable]
    public class BaseData
    {
        public List<string> timestamp;
        public List<int> trainingState;
        public List<string> deviceName;
    }

    [Serializable]
    public class SubjectSessionData
    {
        public UserData userData;
        public BaseData baseData;
    }

    [Serializable]
    public class AllSubjectSessionDatabase
    {
        public List<SubjectSessionData> AllSubjectSessionDataList;
    }

}
