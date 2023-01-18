using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EncounterEvent : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private LayerMask GrassLayer;
    [SerializeField] private GameObject Poke;
    [SerializeField] private List<PokeChainData> PokeChainDatas;
    
    
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
        BattleScene.Instance.StartBattle(GetRandomPokeChain());
        
    }


    private PokeChain GetRandomPokeChain()
    {
        System.Random random = new System.Random();
        int index = random.Next(PokeChainDatas.Count);
        PokeChainData randomItem = PokeChainDatas[index];
        PokeChain result = new PokeChain(randomItem,random.Next(2) == 0);
        return result;
    }
}
