using System;
using System.Collections;
using System.Collections.Generic;
using MetaClass.UI.UnityReact.Scripts;
using TMPro;
using UI.UnityReact.Components.Mostri;
using UI.UnityReact.MonsterProject.Services;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[PrefabPath("Assets/UI/UnityReact/Resources/Mostri/MostroScambia.prefab")]
public class MonsterScambiaComponent : MonsterComponent
{

    [SerializeField] private Button _button;


    private TradeMonsterService tradeMonsterService;
    
    public override void Init(params object[] initValues)
    {
        base.Init(initValues);

        tradeMonsterService = GetFromEnviroment<TradeMonsterService>("TradeService");

    }

    public override void Draw()
    {
        base.Draw();
        UnityAction action = GoToListaMostriDaProporre;
        _button.onClick.AddListener(action);


    }


    private void GoToListaMostriDaProporre()
    {
        tradeMonsterService.SetRequestedMonster(monster.Id);
        Action<string,object[]> changeRoute = (Action<string,object[]>)Enviroment["ChangeRoute"];
        changeRoute("MostroDaScambiare",new object[0]);
    }
}
