using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public float MoveSpeed;

    protected bool isMoving;

    private Vector2 input;

    private event Action hasWalked;

    [SerializeField] 
    private Animator animator;

    

    [SerializeField]
    private float collisionRadius;

    [SerializeField] private LayerMask SolidObjects;
    

    // Update is called once per frame
    protected virtual void Update()
    {
        MovementCheck();
    }

    protected void MovementCheck()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if (input.x != 0)
            {
                input.y = 0; 
            }
            if (!input.Equals(Vector2.zero))
            {
                animator.SetFloat("MoveX",input.x);
                animator.SetFloat("MoveY",input.y);
                Vector3 targetPosition = transform.position;
                targetPosition.x += input.x;
                targetPosition.y += input.y;
                if (IsWalkable(targetPosition))
                {
                    StartMoveTo(targetPosition);
                }
                

            }
            
        }
        
    }

    protected virtual void StartMoveTo(Vector3 positionToMove)
    {
        StartCoroutine(MoveTo(positionToMove));
    }


    protected virtual IEnumerator MoveTo(Vector3 targetPosition)
    {
        isMoving = true;
        animator.SetBool("isMoving",isMoving);
        while ((targetPosition - transform.position ).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position,targetPosition,MoveSpeed*Time.deltaTime);
            yield return null;
        }

        transform.position = targetPosition;
        hasWalked?.Invoke();
        isMoving = false;
        animator.SetBool("isMoving",isMoving);


    }

    public virtual void AddHasWalkedAction(Action action)
    {
        hasWalked += action;
    }
    
    protected virtual bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, collisionRadius, SolidObjects) != null)
        {
            return false;
        }

        return true;
    }
}
