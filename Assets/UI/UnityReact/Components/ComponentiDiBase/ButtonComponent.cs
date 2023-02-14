using System;
using MetaClass.UI.UnityReact.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[PrefabPath("Assets/UI/UnityReact/Resources/ComponentiDiBase/ButtonComponent.prefab")]
public class ButtonComponent : ComponentUI
{
    // Start is called before the first frame update

    [SerializeField] 
    private Button buttonComponent;

    [SerializeField] 
    private TextMeshProUGUI textOfButtonComponent;

    [SerializeField] 
    private Image background;


    private String textOfButton;

    private UnityAction action;

    private Color backgroundColor;

    public override void Init(params object[] initValues)
    {
        textOfButton = (String)initValues[0];
        backgroundColor = (Color)initValues[1]; 
        action = (UnityAction)initValues[2];
    }

    public override void Draw()
    {
        textOfButtonComponent.text = textOfButton;
        background.color = backgroundColor;
        buttonComponent.onClick.AddListener(action);
    }
}
