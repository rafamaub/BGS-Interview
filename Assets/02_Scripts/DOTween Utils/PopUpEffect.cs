using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PopUpEffect : MonoBehaviour
{
    [SerializeField] private float time = 0.65f;

    bool open;
    public void Pop()
    {
        open = true;
        transform.DOComplete();
        transform.localScale = Vector3.zero;
        transform.DOScale(1f, time);
    }

    public void Unpop()
    {
        open = false;
        transform.DOComplete();
        transform.DOScale(0f, time);
    }


    public void DynamicPop()
    {
        if(open)
        {
            Unpop();
        }
        else
        {
            Pop();
        }
    }
}