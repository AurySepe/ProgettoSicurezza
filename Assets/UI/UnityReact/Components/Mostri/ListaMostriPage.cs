using System;
using MetaClass.UI.UnityReact.Scripts;
using UI.UnityReact.Components.ComponentiDiBase;
using UnityEngine;
using UnityEngine.Events;

namespace UI.UnityReact.Components.Mostri
{
    [Route("ListaMostri")]
    public class ListaMostriPage : ComponentUI
    {

        private string playerAddress;
        public override void Init(params object[] initValues)
        {
            playerAddress = (string)initValues[0];

        }

        public override void Draw()
        {
            AddChildComponent<Titolo>(new Vector3(0,430,0),1,$"Mostri di {playerAddress.Substring(0,10)}...");
            AddChildComponent<ListaMostriComponent>(Vector3.zero, 1,playerAddress);
            UnityAction action = GoToPlayerList;
            AddChildComponent<ButtonComponent>(new Vector3(-864.1f,-450,0), 1,"Lista Utenti",Color.white,action);

            
            
        }
        
        public void GoToPlayerList()
        {
            Action<string, object[]> changeRoute = GetFromEnviroment<Action<string, object[]>>("ChangeRoute");
            changeRoute("ListaUtenti",new object[0]);
        }
    }
}