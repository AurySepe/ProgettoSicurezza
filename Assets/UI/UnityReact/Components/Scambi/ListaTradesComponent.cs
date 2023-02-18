using System.Collections.Generic;
using MetaClass.UI.UnityReact.Scripts;
using Scenes.TestScene.Scripts.Model;
using Scenes.TestScene.Scripts.Services;
using UnityEngine;

namespace UI.UnityReact.Components.Scambi
{
    [PrefabPath("Assets/UI/UnityReact/Resources/Scambi/Lista Scambi.prefab")]
    public class ListaTradesComponent : ScrollViewComponent
    {

        public List<Trade> MyTrades;
        
        public override void Init(params object[] initValues)
        {
            MyTrades = new List<Trade>();
            TradeService tradeService = new TradeService();
            tradeService.GetMyTrades(SetMyTrades,s => {});

        }

        public override void Draw()
        {
            foreach (Trade trade in MyTrades)
            {
                AddChildComponent<TradeComponent>(Vector3.zero, 1,trade);

            }
        }


        public void SetMyTrades(List<Trade> trades)
        {
            MyTrades = trades;
            InvokeStateChange();
        }
        
        
    }
}