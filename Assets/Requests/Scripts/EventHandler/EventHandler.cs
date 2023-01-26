using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Scenes.TestScene.Scripts.EventHandler;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static EventHandler Instance { get; private set; }
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

    #region EventsCallback

    public event Action<RisultatoEvent> RisultatoEvents;


    #endregion

    public void ReciveEvent(string eventJson)
    {
        BlockChainEvent chainEvent = JsonConvert.DeserializeObject<BlockChainEvent>(eventJson);
        switch (chainEvent.Name)
        {
                case "Risultato":
                    RisultatoEvents.Invoke(JsonConvert.DeserializeObject<RisultatoEvent>(chainEvent.ReturnValue));
                    break;
                default:
                    Debug.Log($"Nessun Listner implementato per l'evento {chainEvent.Name}");
                    break;
                
        }
    }

}
