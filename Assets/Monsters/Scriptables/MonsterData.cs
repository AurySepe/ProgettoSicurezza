using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenuAttribute(fileName = "MonsterEditor",menuName = "MonsterEditor/Create new Monster")]
public class MonsterData : ScriptableObject
{

    [SerializeField]
    private String _name;

    [SerializeField] 
    private Sprite _sprite;
    
    [SerializeField]
    private float _maxHp;
    
    [SerializeField]
    private float _attack;
    
    [SerializeField]
    private float _defense;


    public string Name => _name;

    public Sprite Sprite => _sprite;

    public float MaxHp => _maxHp;

    public float Attack => _attack;

    public float Defense => _defense;
}
