using System;
using System.Collections;
using System.Collections.Generic;
using MetaClass.UI.UnityReact.Scripts;
using UI.UnityReact.Components;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Route("Home")]
public class HomePage : ComponentUI
{
    

    public override void Init(params object[] initValues)
    {
       
        
        
    }

    public override void Draw()
    {
        UnityAction actionUtenti = GoToPlayerList;
        UnityAction actionScambi = GoToTradeList;
        AddChildComponent<ButtonComponent>(new Vector3(-864.1f,-450,0), 1,"Lista Utenti",Color.white,actionUtenti);
        AddChildComponent<ButtonComponent>(new Vector3(864.1f,-450,0), 1,"Scambi Ricevuti",Color.white,actionScambi);

        
    }


    public void GoToPlayerList()
    {
        Action<string,object[]> changeRoute = (Action<string,object[]>)Enviroment["ChangeRoute"];
        changeRoute("ListaUtenti",new object[0]);
    }
    
    public void GoToTradeList()
    {
        Action<string,object[]> changeRoute = (Action<string,object[]>)Enviroment["ChangeRoute"];
        changeRoute("PaginaTrades",new object[0]);
    }
    
    
    

    
}
