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

    public event Action<PropostaScambio> PropostaScambioEvents;
    
    public event Action<ScambioAccettato> ScambioAccettatoEvents;


    #endregion

    public void ReceiveEvent(string eventJson)
    {
        BlockChainEvent chainEvent = JsonConvert.DeserializeObject<BlockChainEvent>(eventJson);
        switch (chainEvent.Name)
        {
                case "PropostaScambio":
                    PropostaScambioEvents?.Invoke(JsonConvert.DeserializeObject<PropostaScambio>(chainEvent.ReturnValue));
                    break;
                case "ScambioAccettato":
                    ScambioAccettatoEvents?.Invoke(JsonConvert.DeserializeObject<ScambioAccettato>(chainEvent.ReturnValue));
                    break;
                default:
                    Debug.Log($"Nessun Listner implementato per l'evento {chainEvent.Name}");
                    break;
                
        }
    }

}
