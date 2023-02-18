using System;
using MetaClass.UI.UnityReact.Scripts;
using UI.UnityReact.Components.ComponentiDiBase;
using UI.UnityReact.MonsterProject.Services;
using UnityEngine;
using UnityEngine.Events;

namespace UI.UnityReact.Components.Pagine
{
    [Route("ConfermaScambio")]
    public class ConfermaScambioPage : ComponentUI
    {


        private TradeMonsterService tradeMonsterService;
        public override void Init(params object[] initValues)
        {
            tradeMonsterService = GetFromEnviroment<TradeMonsterService>("TradeService");
            
        }

        public override void Draw()
        {
            UnityAction actionOk = Scambia;
            UnityAction goHome = GoHome;
            AddChildComponent<Titolo>(new Vector3(0,460,0),1,"Sei Sicuro di voler scambiare?");
            AddChildComponent<ButtonComponent>(new Vector3(100,0),1,"Ok",Color.white,actionOk);
            AddChildComponent<ButtonComponent>(new Vector3(-100,0),1,"No",Color.white,goHome);
        }



        private void Scambia()
        {
            if (tradeMonsterService.IsTradeProposalReady())
            {
                tradeMonsterService.ProposeTrade(GoHome,s => {});
            }
            
        }
        
        private void GoHome()
        {
            Action<string,object[]> changeRoute = (Action<string,object[]>)Enviroment["ChangeRoute"];
            changeRoute("Home", new object[0] );
        }
    }
}