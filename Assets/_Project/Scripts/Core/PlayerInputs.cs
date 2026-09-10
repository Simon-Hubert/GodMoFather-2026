using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private PlayerInputManager _inputManager;
    [SerializeField] private HookControllerHorizontal _horizontal;
    [SerializeField] private HookControllerVertical _vertical;

    private void OnEnable() {
        _inputManager.onPlayerJoined += Register;
    }

    private void Register(PlayerInput obj) {
        Debug.Log(obj.playerIndex);
        if (obj.playerIndex == 0) {
            obj.actions.FindAction("Horizontal").performed += _horizontal.Move;
            obj.actions.FindAction("Horizontal").canceled += _horizontal.Move;
        }
        else {
            obj.actions.FindAction("Vertical").performed += _vertical.Move;
            obj.actions.FindAction("Vertical").canceled += _vertical.Move;
        }

    }
}