using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Scenes.TestScene.Scripts;
using TMPro;
using UnityEngine;

public class TestExternalFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    
    [DllImport("__Internal")]
    private static extern void Test();

    [SerializeField] private TextMeshProUGUI FromJavascript;

    [SerializeField] private TextMeshProUGUI ToJavascript;


    private void Start()
    {
        
    }


    private void SetText()
    {
        FromJavascript.text = "prova";
    }

    private void Prova(string result)
    {
        Debug.Log(result);
    }

    public void StartTest()
    {
        Action<Response> onResponse = response =>
        {
            if (response.Ok)
            {
                
                ToJavascript.text = response.Result;
            }
            else
            {

                ToJavascript.text = response.Result;
            }
        };
        RequestHandler.Instance.MakeRequest("/EncounterMonster",100,onResponse);
    }
}