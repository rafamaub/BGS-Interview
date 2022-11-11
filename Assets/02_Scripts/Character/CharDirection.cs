using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDirection : MonoBehaviour
{
    public Direction myDirection;
    [SerializeField] private Animator animator;
    Vector2 cacheScale;
    bool invert;
    private void Start()
    {
        cacheScale = animator.transform.localScale;
        //UpdateAnimation();
        //gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        //UpdateAnimation();
        //Debug.Log(animator.transform.localScale);
    }

    private void Update()
    {
        //THERE WAS A WEIRD BUG THAT THE RIG WAS SCALING ITSELF TO 0 AFTER BUILDING
        //THIS IS FORCING TO STAY ON ONE
        if(invert)
        {
            animator.transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            animator.transform.localScale = Vector3.one;
        }
        
    }
    public void UpdateAnimation(float speed = 0) //OTHER STATS CAN BE PASSED HERE
    {
        if(animator)
        {
            animator.SetFloat("velocity", speed);
        }

    }

    public void InvertAnimation(bool toRight)
    {
        if(toRight)
        {
            animator.transform.localScale = new Vector3(-cacheScale.x, cacheScale.y, 1);
            invert = true;
        }
        else
        {
            animator.transform.localScale = cacheScale;
            invert = false;
        }
    }
}

public enum Direction
{
    UP, DOWN, LEFT, RIGHT
}


