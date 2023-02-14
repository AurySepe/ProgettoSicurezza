using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Scenes.TestScene.Scripts.Model;

namespace Scenes.TestScene.Scripts.Services
{
    public class TradeService
    {
        public void ProposeTrade(int mostroProposto, int mostroRichiesto, Action onSuccess, Action<string> onFail)
        {
            Action<Response> responseAction = response =>
            {
                if (!response.Ok)
                {
                    onFail(response.Result);
                    return;
                }

                onSuccess();
            };
            (int proposed, int required ) input = (mostroProposto, mostroRichiesto);
            RequestHandler.Instance.MakeRequest("/ProposeTrade",input,responseAction);
        }


        public void GetAllTrades(Action<List<Trade>> OnSuccess, Action<string> OnFail)
        {
            MonsterService monsterService  = new MonsterService();
            Action<Response> responseAction = response =>
            {
                if (!response.Ok)
                {
                    OnFail(response.Result);
                    return;
                }

                List<TradeTuple> tradeTuplesImperfect = JsonConvert.DeserializeObject<List<TradeTuple>>(response.Result);
                List<TradeTuple> tradeTuples = new List<TradeTuple>();
                foreach (TradeTuple tradeTuple in tradeTuplesImperfect)
                {
                    if (!(tradeTuple.MonsterProposed == 0 && tradeTuple.MonsterRequired == 0))
                    {
                        tradeTuples.Add(tradeTuple);
                    }
                }
                List<Trade> trades = new List<Trade>();

                int i = 0;
                Action<Trade> onEnd = t =>
                {
                    trades.Add(t);
                    i++;

                    if (i == tradeTuples.Count)
                    {
                        OnSuccess(trades);
                    }
                };

                foreach (TradeTuple tuple in tradeTuples)
                {


                    int requiredMonster = tuple.MonsterRequired;
                    int mosterProposed = tuple.MonsterProposed;
                    
                    Action<Monster> monster1Action = monster1 =>
                    {
                        
                        
                        Action<Monster> monster2Action = monster2 =>
                        {
                            Trade trade = new Trade(monster1, monster2);
                            onEnd(trade);
                        };
                        monsterService.GetMonsterById(requiredMonster,monster2Action,OnFail);
                    };

                    monsterService.GetMonsterById(mosterProposed,monster1Action,OnFail);


                }

            };
            RequestHandler.Instance.MakeRequest("/GetAllTrades",null,responseAction);
            
        }

        public void GetMyTrades(Action<List<Trade>> onSuccess, Action<string> onFail)
        {
            MonsterService monsterService  = new MonsterService();

            Action<List<int>> onGetToken = listaMieiTokens =>
            {
                Action<List<Trade>> onAlltrades = trades =>
                {
                    List<Trade> result = new List<Trade>();

                    foreach (Trade trade in trades)
                    {
                        if (listaMieiTokens.Contains(trade.MonsterRequired.Id))
                        {
                            result.Add(trade);
                        }
                    }

                    onSuccess(result);
                };
                this.GetAllTrades(onAlltrades,onFail);
            };

            monsterService.GetMyMonsters(onGetToken,onFail);

            
        }

        public void AcceptTrade(int mostroProposto, int mostroRichiesto, Action onSuccess, Action<string> onFail)
        {
            Action<Response> responseAction = response =>
            {
                if (!response.Ok)
                {
                    onFail(response.Result);
                    return;
                }

                onSuccess();
            };
            (int proposed, int required ) input = (mostroProposto, mostroRichiesto);
            RequestHandler.Instance.MakeRequest("/AcceptTrade",input,responseAction);
        }
    }
}