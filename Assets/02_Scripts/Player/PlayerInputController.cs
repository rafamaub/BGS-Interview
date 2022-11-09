using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private CharacterController2D movementController;
    [SerializeField] private InventoryManager inventory;
    [SerializeField] private Interactor interactor;
    public void MovePlayer(InputAction.CallbackContext ctx)
    {
        Vector2 dir = ctx.ReadValue<Vector2>();
        if(ctx.performed)
        {
            movementController.MoveCharacter(dir);
        }
        else if(ctx.canceled)
        {
            movementController.StopCharacter();
        }
    }

    public void OpenInventory(InputAction.CallbackContext ctx)
    {
        if(!inventory)
        {
            inventory = FindObjectOfType<InventoryManager>();
        }

        if(ctx.performed)
        {
            inventory.ShowInventory();
        }
    }

    public void Interact(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            interactor.InteractWithClosest();
        }
    }
}
