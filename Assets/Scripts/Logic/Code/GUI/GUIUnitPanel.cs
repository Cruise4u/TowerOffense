using System;
using UnityEngine;

public class GUIUnitPanel : MonoBehaviour
{
    public Action<string> SpawnRequest;

    public void SendRequestBasedOnButtonID(int unitButtonID)
    {
        switch(unitButtonID)
        {
            case 0:
                SpawnRequest.Invoke("Basic");
                break;
            case 1:
                SpawnRequest.Invoke("Super");
                break;
        }
    }
}
