using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    public Vector2 movementInput;
    public Vector2 aimInput;
    
    public bool isShooting;
    public bool isReloading;
    
    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 input = ctx.ReadValue<Vector2>();
        movementInput = input;
    }

    public void OnAim(InputAction.CallbackContext ctx)
    {
        Vector2 input = ctx.ReadValue<Vector2>();
        aimInput = input;
    }

    public void OnShoot(InputAction.CallbackContext ctx)
    {
        isShooting = ctx.ReadValueAsButton();
    }
    
    public void OnReload(InputAction.CallbackContext ctx)
    {
        isReloading = ctx.ReadValueAsButton();
    }
}
