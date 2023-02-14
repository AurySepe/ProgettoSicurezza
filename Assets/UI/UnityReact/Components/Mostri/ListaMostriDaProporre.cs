using System.Collections.Generic;
using MetaClass.UI.UnityReact.Scripts;
using Photon.Pun;
using Scenes.TestScene.Scripts.Services;
using UnityEngine;

namespace UI.UnityReact.Components.Mostri
{
    [PrefabPath("Assets/UI/UnityReact/Resources/Mostri/ListaMostriDaProporre.prefab")]
    public class ListaMostriDaProporre : ScrollViewComponent
    {
        
        private List<Monster> Monsters;

        private string playerAddress;

        private MonsterService monsterService;
        
        public override void Init(params object[] initValues)
        {
            Monsters = new List<Monster>();
            monsterService = new MonsterService();
            string myAddress = (string)PhotonNetwork.LocalPlayer.CustomProperties["indirizzo"];
            monsterService.GetMonsters(myAddress,OnSuccessGetLista,s => {});
        }

        public override void Draw()
        {
            foreach (Monster monster in Monsters)
            {
                AddChildComponent<MonsterProposeComponent>(Vector3.zero,1,monster);
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