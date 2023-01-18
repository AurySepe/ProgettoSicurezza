using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScene : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] 
    private Text textDialog;

    [SerializeField] 
    private GameObject NormalScene;

    [SerializeField] 
    private GameObject battleScene;

    public bool IsBattle { get; protected set; }
    
    public static BattleScene Instance { get; private set; }
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    
    void Start()
    {
        
    }

    public void StartBattle(PokeChain pokeChain)
    {
        IsBattle = true;
        battleScene.SetActive(true);
        NormalScene.SetActive(false);
        textDialog.text = $"Hai incontrato {pokeChain.Data.Name}!\nCosa vuoi fare?";
    }

    public void EndBattle()
    {
        IsBattle = false;
        NormalScene.SetActive(true);
        battleScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
