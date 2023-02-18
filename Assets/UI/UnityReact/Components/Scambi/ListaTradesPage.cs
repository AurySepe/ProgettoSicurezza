using System.Collections;
using System.Collections.Generic;
using MetaClass.UI.UnityReact.Scripts;
using UI.UnityReact.Components;
using UI.UnityReact.Components.ComponentiDiBase;
using UI.UnityReact.Components.Scambi;
using UnityEngine;

[Route("PaginaTrades")]
public class ListaTradesPage : ComponentUI
{
    public override void Init(params object[] initValues)
    {
        
    }

    public override void Draw()
    {
        AddChildComponent<Titolo>(new Vector3(0,460,0),1,"Lista Scambi proposti");
        AddChildComponent<ListaTradesComponent>(Vector3.zero, 1);
    }
}
