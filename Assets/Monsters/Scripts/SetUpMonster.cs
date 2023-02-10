using System.Collections;
using System.Collections.Generic;
using Scenes.TestScene.Scripts.Services;
using Unity.VisualScripting;
using UnityEngine;

public class SetUpMonster : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] 
    private SpriteRenderer _spriteRenderer;
    
    [SerializeField] 
    private GameObject _listaMostri;
    
    [SerializeField] 
    private GameObject _elementoMostro;
    
    [SerializeField] 
    private GameObject _content;

    private MonsterService _monsterService = new MonsterService();
    
    // Update is called once per frame
    public void SetMonster(Monster monster)
    {
        _spriteRenderer.sprite = monster.Img;
        _spriteRenderer.color = Random.ColorHSV();
        gameObject.name = monster.Nome;
    }

    public void listaMostri(string address)
    {
        if (_listaMostri.activeSelf)
        {

            List<Transform> panelList= new List<Transform>();
            _listaMostri.SetActive(false);
            foreach (Transform panel in _content.transform)
            {
                panelList.Add(panel);
            }

            foreach (Transform panel2 in panelList)
            {
                Destroy(panel2.gameObject);
            }
        }
        else
        {
            _monsterService.GetMonsters(address, OnSuccessGetLista, s=>{});
            _listaMostri.SetActive(true);
        }
    }
    
    public void OnSuccessGetLista(List<int> lista)
    {
        foreach (var id in lista)
        {
            _monsterService.GetMonsterById(id, OnSuccessGetMostro, s=>{});
        }
    }

    public void OnSuccessGetMostro(Monster monster)
    {
        GameObject gameObject = Instantiate(_elementoMostro, _content.transform);
        gameObject.GetComponent<SetPanel>().Set(monster);
    }
}
