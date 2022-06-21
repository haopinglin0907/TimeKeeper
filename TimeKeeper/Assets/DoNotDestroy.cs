using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    public GameObject appManager;

    void Awake()
    {
        DontDestroyOnLoad(appManager);
    }
}
