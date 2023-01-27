using System;
using System.Collections;
using System.Collections.Generic;
using Scenes.TestScene.Scripts.Services;
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
    
    [SerializeField] 
    private Image monsterImage;

    public bool IsBattle { get; protected set; }
    
    public Monster CurrentMonster { get; protected set; }
    
    public static BattleScene Instance { get; private set; }

    private MonsterService _monsterService = new MonsterService();
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(gameObject); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    
    void Start()
    {
        
    }

    #region Transitions

        private void StartEncounterTransition()
        {
            battleScene.SetActive(true);
            NormalScene.SetActive(false);
            textDialog.text = $"In attesa del mostro";
        }

        private void MonsterFoundTransition(Monster monster)
        {
            Debug.Log("Mostro trovato");
            CurrentMonster = monster;
            monsterImage.sprite = monster.Img;
            textDialog.text = $"hai incontrato {monster.Nome}! Cosa vuoi fare?";

        }

        private void MonsterNotFoundTransition(string s)
        {
            textDialog.text = $"Mannaggia alla miseria, il mostro è scappato poichè {s}!";
        }
        
        private void EndBattleTransition()
        {
            monsterImage.sprite = null;
            NormalScene.SetActive(true);
            battleScene.SetActive(false);
        }

    #endregion



    public void StartBattle()
    {
        IsBattle = true;
        StartEncounterTransition();
        Action<int> OnSuccess = i => _monsterService.GetMonsterById(i,MonsterFoundTransition,MonsterNotFoundTransition);
        _monsterService.GetRandomMonsterById(OnSuccess,MonsterNotFoundTransition);
        
    }

    public void EndBattle()
    {
        IsBattle = false;
        EndBattleTransition();
    }

    
}
