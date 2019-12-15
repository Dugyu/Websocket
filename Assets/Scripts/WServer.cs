using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Server;

public class WServer : MonoBehaviour
{

    WebSocketServer wssv;
    // Start is called before the first frame update
    void Awake()
    {
        wssv = new WebSocketServer("ws://localhost:18081");
        wssv.AddWebSocketService<Echo>("/Echo");
        wssv.AddWebSocketService<Chat>("/Chat");
        wssv.Start();
    }

    private void OnApplicationQuit()
    {
        wssv.Stop();
    }

}
