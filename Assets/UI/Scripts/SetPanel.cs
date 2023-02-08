using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetPanel : MonoBehaviour
{
    
    [SerializeField] 
    private TextMeshProUGUI _nomeMostro;
    
    [SerializeField] 
    private TextMeshProUGUI _idMostro;
    
    [SerializeField] 
    private Image _imgMostro;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set(Monster monster)
    {
        _nomeMostro.text=monster.Nome;
        _idMostro.text=""+monster.Id;
        _imgMostro.sprite=monster.Img;
        
    }
}
