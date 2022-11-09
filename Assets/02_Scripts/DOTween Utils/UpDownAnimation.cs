using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UpDownAnimation : MonoBehaviour
{
    [SerializeField] private float range = 0.3f;
    [SerializeField] private float duration = 1f;
    // Start is called before the first frame update
    void Awake()
    {
        transform.DOLocalMoveY(transform.localPosition.y + range, duration).SetLoops(-1, LoopType.Yoyo);
    }

}
