using System;
using UnityEngine.InputSystem;
using UnityEngine;

namespace TestDriven.Inputs
{
    public class InputReader : IInputReader
    {
        public float Horizontal { get; private set; }

        public InputReader()
        {
            GameInputActions input = new GameInputActions();

            input.Enable();
            input.Player.Move.performed += HandleMoveAction;
            input.Player.Move.canceled += HandleMoveAction;
        }

        private void HandleMoveAction(InputAction.CallbackContext context)
        {
            Horizontal = context.ReadValue<Vector2>().x;
        }
    }
}