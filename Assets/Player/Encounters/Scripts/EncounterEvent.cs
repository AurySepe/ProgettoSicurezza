using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class EncounterEvent : MonoBehaviour
{
    // Start is called before the first frame update

    [DllImport("__Internal")]
    private static extern int EncounterMonster();
    [SerializeField] private LayerMask GrassLayer;
    [SerializeField] private Sprite sprite;
    
    
    void Start()
    {
        if (TryGetComponent(out PlayerControllerMultiplayer playerController))
        {
            playerController.AddHasWalkedAction(RandomEncounterCheck);
        }
    }

    // Update is called once per frame
    private void RandomEncounterCheck()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, GrassLayer) != null)
        {
            if (Random.Range(0, 100) < 10)
            {
                RandomEncounter();
            }
        }
    }

    private void RandomEncounter()
    {
        int monsterId=EncounterMonster();
        Monster monster = new Monster(sprite, monsterId, "MonsterTest");
        BattleScene.Instance.StartBattle(monster);
        
    }
    
}
