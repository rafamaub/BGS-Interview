using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInteractable : MonoBehaviour
{
    public bool near;

    Interactor interactor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactor = collision.GetComponentInParent<Interactor>();
        OnRange();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OffRange();        
    }

    public virtual void Interact()
    {
        if(!near)
        {
            return;
        }
    }

    public virtual void OnRange()
    {
        near = true;
        if(PlayerWorldCanvas.Instance)
        {
            PlayerWorldCanvas.Instance.ShowETip();
        }
        if(interactor)
        {
            interactor.SelectInteraction(this);
        }

    }

    public virtual void OffRange()
    {
        near = false;
        if (PlayerWorldCanvas.Instance)
        {
            PlayerWorldCanvas.Instance.HideETip();
        }
        if (interactor)
        {
            interactor.SelectInteraction(null);
        }
    }
}
