using System.Collections;
using System.Collections.Generic;
using GameJolt.API;
using UnityEngine;

public class GameJoltTest : MonoBehaviour
{
    private string key = "10";

    private string data = "test";

    private bool global = false;

    private System.Action<string> callback;
    private System.Action<bool> callback2;
    // Start is called before the first frame update
    void Start()
    {
        GameJolt.API.DataStore.Set(key,data,global,callback2);
        //GameJolt.API.DataStore.Get(key,false,callback);
        
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log("sucess =" + callback2);
        GameJolt.API.DataStore.Get(key,false,callback);
        Debug.Log("callback = " + callback);
    }
}
