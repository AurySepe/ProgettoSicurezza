using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Scenes.TestScene.Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RequestHandler : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SendRequest(string requestJson);
    public static RequestHandler Instance { get; private set; }
    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(gameObject); 
        } 
        else 
        { 
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
    }


    
    private Dictionary<uint, Action<Response>> requests = new Dictionary<uint, Action<Response>>();

    private Queue<uint> idPool = new Queue<uint>();

    private uint maxId = 0;


    public void MakeRequest(string uri,object input,Action<Response> action)
    {
        Request request = new Request();
        request.Uri = uri;
        request.Data = JsonConvert.SerializeObject(input);
        
        if (idPool.TryDequeue(out uint result))
        {
            request.RequestId = result;
            requests.Add(result,action);
        }
        else
        {
            request.RequestId = maxId;
            requests.Add(maxId,action);
            maxId++;
        }

        String requestJson = JsonConvert.SerializeObject(request);
        SendRequest(requestJson);
    }


    public void ReciveResponse(string result)
    {
        Debug.Log($"la risposta è {result}");
        Response response = JsonConvert.DeserializeObject<Response>(result);
        if (requests.TryGetValue(response.RequestId, out Action<Response> action))
        {
            action(response);
            requests.Remove(response.RequestId);
            idPool.Enqueue(response.RequestId);
        }
        
    }
    
}
