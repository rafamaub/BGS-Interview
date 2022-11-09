using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public BasicInteractable nearInteractable;

    public void SelectInteraction(BasicInteractable interaction)
    {
        nearInteractable = interaction;
    }

    public void InteractWithClosest()
    {
        if(nearInteractable)
            nearInteractable.Interact();
    }
}
