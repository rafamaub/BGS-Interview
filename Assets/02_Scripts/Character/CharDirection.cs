using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDirection : MonoBehaviour
{
    public Direction myDirection;
    [SerializeField] private Animator animator;

    private void Start()
    {
        //UpdateAnimation();
        //gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        //UpdateAnimation();
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
            animator.transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            animator.transform.localScale = Vector3.one;
        }
    }
}

public enum Direction
{
    UP, DOWN, LEFT, RIGHT
}


