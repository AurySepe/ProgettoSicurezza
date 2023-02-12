using System;
using Newtonsoft.Json;

namespace Scenes.TestScene.Scripts.Services
{
    public class TradeService
    {
        public void ProposeTrade(int mostroProposto, int mostroRichiesto, Action onSuccess, Action onFail)
        {
            Action<Response> responseAction = response =>
            {
                if (!response.Ok)
                {
                    onFail();
                    return;
                }

                onSuccess();
            };
            (int proposed, int required ) input = (mostroProposto, mostroRichiesto);
            RequestHandler.Instance.MakeRequest("/ProposeTrade",input,responseAction);
        }
    }
}