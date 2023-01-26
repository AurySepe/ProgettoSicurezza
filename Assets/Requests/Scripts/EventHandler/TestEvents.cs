using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventHandler.Instance.RisultatoEvents += evento => Debug.Log($"il valore di result è {evento.Value}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
