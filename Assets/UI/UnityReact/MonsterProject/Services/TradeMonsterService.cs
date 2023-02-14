using System;
using Scenes.TestScene.Scripts.Services;

namespace UI.UnityReact.MonsterProject.Services
{
    public class TradeMonsterService
    {
        public int MonsterRequired { get; set; }
        
        public int MonsterProposed { get; set; }


        public TradeMonsterService()
        {
            MonsterProposed = -1;
            MonsterRequired = -1;
        }


        public void SetRequestedMonster(int id)
        {
            MonsterRequired = id;
            MonsterProposed = -1;
        }

        public void SetProposedMonster(int id)
        {
            if (MonsterRequired == -1)
            {
                throw new Exception("non hai ancora richiesto un mostro");
            }

            MonsterProposed = id;
        }


        public bool IsTradeProposalReady()
        {
            return MonsterProposed != -1 && MonsterRequired != -1;
        }

        public void ProposeTrade(Action onSuccess, Action<string> onFail)
        {
            TradeService tradeService = new TradeService();
            tradeService.ProposeTrade(MonsterProposed,MonsterRequired,onSuccess,onFail);
        }
        
    }
}