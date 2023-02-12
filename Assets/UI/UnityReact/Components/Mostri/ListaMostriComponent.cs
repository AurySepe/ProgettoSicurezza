using System.Collections.Generic;
using MetaClass.UI.UnityReact.Scripts;
using Photon.Pun;
using Scenes.TestScene.Scripts.Services;
using UnityEngine;

namespace UI.UnityReact.Components.Mostri
{
    [PrefabPath("Assets/UI/UnityReact/Resources/Mostri/ListaMostri.prefab")]
    public class ListaMostriComponent : ScrollViewComponent
    {

        private List<Monster> Monsters;

        private string playerAddress;

        private MonsterService monsterService;

        public override void Init(params object[] initValues)
        {

            playerAddress = (string)initValues[0];
            Monsters = new List<Monster>();
            monsterService = new MonsterService();
            monsterService.GetMonsters(playerAddress,OnSuccessGetLista,s => {});

        }

        public override void Draw()
        {
            string myAddress = (string)PhotonNetwork.LocalPlayer.CustomProperties["indirizzo"];
            if (playerAddress.Equals(myAddress))
            {
                foreach (Monster monster in Monsters)
                {
                    AddChildComponent<MonsterComponent>(Vector3.zero,1,monster);
                }
            }
            else
            {
                foreach (Monster monster in Monsters)
                {
                    AddChildComponent<MonsterScambiaComponent>(Vector3.zero,1,monster);
                }
            }
        }


        private void AddMonster(Monster monster)
        {
            Monsters.Add(monster);
            InvokeStateChange();
        }
        
        
        public void OnSuccessGetLista(List<int> lista)
        {
            foreach (var id in lista)
            {
                monsterService.GetMonsterById(id, AddMonster, s=>{});
            }
        }
    }
}