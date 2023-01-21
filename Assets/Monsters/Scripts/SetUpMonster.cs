using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetUpMonster : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] 
    private SpriteRenderer _spriteRenderer;
    
   

    // Update is called once per frame
    public void SetMonster(Monster monster)
    {
        _spriteRenderer.sprite = monster.Img;
        _spriteRenderer.color = Random.ColorHSV();
        gameObject.name = monster.Nome;
    }
}
