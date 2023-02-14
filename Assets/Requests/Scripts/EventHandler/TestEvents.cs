using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventHandler.Instance.PropostaScambioEvents += scambio =>
        {
            Debug.Log($"scambio proposto fra il token {scambio.mostroProposto} e il token {scambio.mostroRichiesto}");
        };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
