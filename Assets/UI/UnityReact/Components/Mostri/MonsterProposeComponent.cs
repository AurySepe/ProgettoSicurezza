using System;
using MetaClass.UI.UnityReact.Scripts;
using UI.UnityReact.MonsterProject.Services;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.UnityReact.Components.Mostri
{
    [PrefabPath("Assets/UI/UnityReact/Resources/Mostri/MonstroPropose.prefab")]
    public class MonsterProposeComponent : MonsterComponent
    {
        [SerializeField] private Button _button;


        private TradeMonsterService tradeMonsterService;
    
        public override void Init(params object[] initValues)
        {
            base.Init(initValues);

            tradeMonsterService = GetFromEnviroment<TradeMonsterService>("TradeService");

        }

        public override void Draw()
        {
            base.Draw();
            UnityAction action = ProponiIlMostro;
            _button.onClick.AddListener(action);


        }


       

        private void ProponiIlMostro()
        {
            tradeMonsterService.SetProposedMonster(monster.Id);
            Action<string,object[]> changeRoute = (Action<string,object[]>)Enviroment["ChangeRoute"];
            changeRoute("ConfermaScambio",new object[0]);
        }
    }
}