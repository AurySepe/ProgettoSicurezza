using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectAction : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private List<GameObject> arrows;

    private int currentActiveArrow = 0;

    void Start()
    {
        foreach (GameObject arrow in arrows)
        {
            arrow.SetActive(false);
        }
        arrows[currentActiveArrow].SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeArrow();
        CheckAction();
    }

    private void CheckAction()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            UnityEvent action = GetActionFromArrow(arrows[currentActiveArrow]);
            action.Invoke();
        }
    }

    void ChangeArrow()
    {
        int newIndex;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            newIndex = (currentActiveArrow + 1) % arrows.Count;
            
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            

            newIndex = currentActiveArrow - 1 == -1 ? arrows.Count - 1 : currentActiveArrow - 1;
        }
        else
        {
            newIndex = currentActiveArrow;
        }
        arrows[currentActiveArrow].SetActive(false);
        arrows[newIndex].SetActive(true);
        currentActiveArrow = newIndex;
    }

    private UnityEvent GetActionFromArrow(GameObject gameObject)
    {
        ArrowAction arrowAction = gameObject.GetComponent<ArrowAction>();
        return arrowAction.GetArrowAction();
    }
}
