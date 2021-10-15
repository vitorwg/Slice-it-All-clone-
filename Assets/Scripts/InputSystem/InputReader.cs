using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    private InputPlayerActions _inputActions;

    public event UnityAction OnJumpEvent;

    private void Awake()
    {
        _inputActions = new InputPlayerActions();

        _inputActions.PC.Jump.performed += OnJump;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnJumpEvent?.Invoke();
        }

    }

    private void OnEnable()
    {
        _inputActions.PC.Enable();
        _inputActions.SmartPhone.Enable();
    }

    private void OnDisable()
    {
        _inputActions.PC.Disable();
        _inputActions.SmartPhone.Disable();
    }
}
