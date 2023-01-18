using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArrowAction : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private UnityEvent arrowAction;

    public UnityEvent GetArrowAction()
    {
        return arrowAction;
    }
}
