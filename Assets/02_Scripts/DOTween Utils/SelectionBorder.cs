using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
public class SelectionBorder : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image border;

    [SerializeField] private float fadeSpeed = 0.15f;
    [SerializeField] private float loopSpeed = 0.6f;
    [SerializeField] private float fadeOnMouseOver = 0.3f;
    [SerializeField] private float maxFadeOnClick = 0.75f;

    bool selected;
    public void MouseIsOver()
    {
        if (selected)
        { return; }
        border.DOComplete();
        border.DOFade(fadeOnMouseOver, fadeSpeed);
    }

    public void MouseLeft()
    {
        if(selected)
        { return; }
        border.DOComplete();
        border.DOFade(0f, fadeSpeed);
    }

    public void Clicked()
    {

        selected = true;
        border.DOComplete();
        border.DOFade(fadeOnMouseOver, 0f);
        border.DOFade(maxFadeOnClick, loopSpeed).SetLoops(-1, LoopType.Yoyo);
    }

    public void Unselect()
    {
        selected = false;
        border.DOKill();
        MouseLeft();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseIsOver();
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        MouseLeft();
    }
}
