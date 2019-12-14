using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

using WebSocketSharp;
using WebSocketSharp.Server;

public class Chat: WebSocketBehavior
{
    private string _suffix;

    public Chat()
      : this(null)
    {
    }

    public Chat(string suffix)
    {
        _suffix = suffix ?? string.Empty;
    }

    protected override void OnMessage(MessageEventArgs e)
    {
        Sessions.Broadcast(e.Data + _suffix);
        var msg = e.Data == "BALUS"
            ? "I've been balused already..."
            : "I'm not available now.";
        Send(msg);
    }

}
