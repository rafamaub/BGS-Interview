using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private CharacterController2D movementController;
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
}
