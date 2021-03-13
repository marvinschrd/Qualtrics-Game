using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Use plugin namespace
using HybridWebSocket;

public class WebSocketDemo : MonoBehaviour
{
    private WebSocket ws;
	// Use this for initialization
	void Start () {

        // // Create WebSocket instance
        // ws = WebSocketFactory.CreateInstance("ws://localhost:9000/echo");
        // // Add OnOpen event listener
        // ws.OnOpen += () =>
        // {
        //     Debug.Log("WS connected!");
        //     Debug.Log("WS state: " + ws.GetState().ToString());
        //
        //     ws.Send(Encoding.UTF8.GetBytes("Hello from Unity 3D!"));
        // };
        //
        // // Add OnMessage event listener
        // ws.OnMessage += (byte[] msg) =>
        // {
        //     Debug.Log("WS received message: " + Encoding.UTF8.GetString(msg));
        //
        //    // ws.Close();
        // };
        //
        // // Add OnError event listener
        // ws.OnError += (string errMsg) =>
        // {
        //     Debug.Log("WS error: " + errMsg);
        // };
        //
        // // Add OnClose event listener
        // ws.OnClose += (WebSocketCloseCode code) =>
        // {
        //     Debug.Log("WS closed with code: " + code.ToString());
        // };
        //
        // // Connect to the server
        // ws.Connect();

    }

     public void Initialize()
    {
        // Create WebSocket instance
       // ws = WebSocketFactory.CreateInstance("ws://localhost:9000/echo");
        //ws = WebSocketFactory.CreateInstance("ws://localhost:8765");
        ws = WebSocketFactory.CreateInstance("ws://135.125.100.181:8765");
        // Add OnOpen event listener
        ws.OnOpen += () =>
        {
            Debug.Log("WS connected!");
            Debug.Log("WS state: " + ws.GetState().ToString());

            //ws.Send(Encoding.UTF8.GetBytes("Hello from Unity 3D!"));
        };

        // Add OnMessage event listener
        ws.OnMessage += (byte[] msg) =>
        {
            Debug.Log("WS received message: " + Encoding.UTF8.GetString(msg));

            // ws.Close();
        };

        // Add OnError event listener
        ws.OnError += (string errMsg) =>
        {
            Debug.Log("WS error: " + errMsg);
        };

        // Add OnClose event listener
        ws.OnClose += (WebSocketCloseCode code) =>
        {
            Debug.Log("WS closed with code: " + code.ToString());
        };

        // Connect to the server
        ws.Connect();
    }

    public void SendUserData(string dataJson)
    {
        ws.Send(Encoding.UTF8.GetBytes(dataJson));
        Debug.Log("sent data to server");
    }

    public WebSocketState GetSocketState()
    {
        return ws.GetState();
    }
	// Update is called once per frame
	void Update ()
    {
       // Debug.Log("?");
    }
}
