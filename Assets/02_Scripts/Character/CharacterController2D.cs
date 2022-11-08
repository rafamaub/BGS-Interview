using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [Header("Character Movement Settings")]
    [SerializeField] private float speed;
    [Header("Debug")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private DirectionResolver dirResolver;
    [SerializeField] private Vector2 direction;

    bool moving;
    private void Awake()
    {
        if(!rb)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(direction * speed * 1000f * Time.deltaTime, ForceMode2D.Force);
        if(dirResolver && dirResolver.actualDirection)
        {
            if(moving)
                dirResolver.actualDirection.UpdateAnimation(rb.velocity.magnitude);
            else
                dirResolver.actualDirection.UpdateAnimation(0);

        }
        
    }
    public void MoveCharacter(Vector2 dir)
    {
        direction = dir.normalized;

        if (dirResolver)
        {
            dirResolver.ChangeDirection(dir);
        }
        moving = true;
    }

    public void StopCharacter()
    {
        direction = Vector2.zero;
        if (dirResolver)
        {
            dirResolver.ChangeDirection(Vector2.zero);
        }
        moving = false;
    }


    

}

public enum CharacterState
{
    Idle, Walking
}

