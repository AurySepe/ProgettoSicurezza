using System;
using MetaClass.UI.UnityReact.Scripts;
using UI.UnityReact.Components.ComponentiDiBase;
using UnityEngine;
using UnityEngine.Events;

namespace UI.UnityReact.Components.Utenti
{
    [Route("ListaUtenti")]
    public class ListaUtentiPage : ComponentUI
    {
        public override void Init(params object[] initValues)
        {
            
        }

        public override void Draw()
        {
            AddChildComponent<Titolo>(new Vector3(0,430,0),1,$"Lista Utenti");

            AddChildComponent<ListaUtentiComponent>(Vector3.zero,1);
            UnityAction action = GoHome;
            AddChildComponent<ButtonComponent>(new Vector3(-864.1f,-450,0), 1,"Indietro",Color.white,action);
        }

        private void GoHome()
        {
            Action<string,object[]> changeRoute = (Action<string,object[]>)Enviroment["ChangeRoute"];
            changeRoute("Home", new object[0] );
        }
    }
}