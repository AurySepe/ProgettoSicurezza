using System;
using MetaClass.UI.UnityReact.Scripts;
using Scenes.TestScene.Scripts.Model;
using Scenes.TestScene.Scripts.Services;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.UnityReact.Components.Scambi
{
    [PrefabPath("Assets/UI/UnityReact/Resources/Scambi/Trade.prefab")]
    public class TradeComponent : ComponentUI
    {
        [SerializeField] private Image MostroRichiesto;
        [SerializeField] private Image MostroProposto;
        [SerializeField] private Button BottoneScambio;

        private TradeService tradeService;
        
        public Trade ATrade { get; set; }
        public override void Init(params object[] initValues)
        {
            ATrade = (Trade)initValues[0];
            tradeService = new TradeService();
        }

        public override void Draw()
        {
            MostroProposto.sprite = ATrade.MonsterProposed.Img;
            MostroRichiesto.sprite = ATrade.MonsterRequired.Img;

            UnityAction actionOnClick = () =>
            {
                tradeService.AcceptTrade(ATrade.MonsterProposed.Id, ATrade.MonsterRequired.Id, GoHome, s => { });
            };

            BottoneScambio.onClick.AddListener(actionOnClick);


        }
        
        private void GoHome()
        {
            Action<string,object[]> changeRoute = (Action<string,object[]>)Enviroment["ChangeRoute"];
            changeRoute("Home", new object[0] );
        }
    }
}