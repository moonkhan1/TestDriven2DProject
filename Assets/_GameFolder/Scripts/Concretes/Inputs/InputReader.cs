using System;
using UnityEngine.InputSystem;
using UnityEngine;

namespace TestDriven.Inputs
{
    public class InputReader : IInputReader
    {
        readonly GameInputActions _input;
        public float Horizontal { get; private set; }

        public bool Jump => _input.Player.Jump.WasPerformedThisFrame();

        public InputReader()
        {
            _input = new GameInputActions();

            _input.Enable();
            _input.Player.Move.performed += HandleMoveAction;
            _input.Player.Move.canceled += HandleMoveAction;
        }

        private void HandleMoveAction(InputAction.CallbackContext context)
        {
            Horizontal = context.ReadValue<Vector2>().x;
        }
    }
}