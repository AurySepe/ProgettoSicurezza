using System;
using MetaClass.UI.UnityReact.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UnityReact.Components.Mostri
{
    [PrefabPath("Assets/UI/UnityReact/Resources/Mostri/Mostro.prefab")]
    public class MonsterComponent : ComponentUI
    {
        public Monster monster;
        
        [SerializeField] 
        private TextMeshProUGUI _nomeMostro;
    
        [SerializeField] 
        private TextMeshProUGUI _idMostro;
    
        [SerializeField] 
        private Image _imgMostro;
        
        public override void Init(params object[] initValues)
        {
            monster = (Monster)initValues[0];
            
        }

        public override void Draw()
        {
            _nomeMostro.text = monster.Nome;
            _idMostro.text = $"{monster.Id}";
            _imgMostro.sprite = monster.Img;
        }
    }
}