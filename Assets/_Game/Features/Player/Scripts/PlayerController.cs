using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.Player {
    public class PlayerController {
        public readonly InputAction MoveAction;
        public readonly InputAction JumpAction;

        public PlayerController() {
            MoveAction = InputSystem.actions.FindAction("Player/Move");
            JumpAction = InputSystem.actions.FindAction("Player/Jump");
        }
    }
}