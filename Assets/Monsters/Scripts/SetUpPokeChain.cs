using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetUpPokeChain : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] 
    private SpriteRenderer _spriteRenderer;
    
   

    // Update is called once per frame
    public void SetPokeChain(PokeChain pokeChain)
    {
        _spriteRenderer.sprite = pokeChain.Data.Sprite;
        _spriteRenderer.color = Random.ColorHSV();
        gameObject.name = pokeChain.Data.Name;
    }
}
