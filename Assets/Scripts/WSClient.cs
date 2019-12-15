using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using WebSocketSharp;

public class WSClient : MonoBehaviour
{
    WebSocket ws;

    private void Start()
    {
        //ws = new WebSocket("ws://echo.websocket.org");
        ws = new WebSocket("ws://localhost:18081/Chat");
        ws.OnOpen += OnOpenHandler;
        ws.OnMessage += OnMessageHandler;
        ws.OnClose += OnCloseHandler;
        ws.OnError += OnErrorHandler;
        ws.Connect();
    }

    private void OnOpenHandler(object sender, EventArgs e)
    {
        Debug.Log("WebSocket connected!");
        ws.Send("hihi");
    }

    private void OnMessageHandler(object sender, MessageEventArgs e)
    {
        Debug.Log("Message is " + e.Data);
    }

    private void OnErrorHandler(object sender, ErrorEventArgs e)
    {
        Debug.Log("Error");
    }

    private void OnCloseHandler(object sender, CloseEventArgs e)
    {
        Debug.Log("Close");
    }
}
