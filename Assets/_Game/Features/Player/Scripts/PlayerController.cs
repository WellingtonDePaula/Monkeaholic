using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.Player {
    public class PlayerController {
        public readonly InputAction MoveAction;
        public readonly InputAction JumpAction;
        public readonly InputAction InventoryAction;

        public PlayerController() {
            MoveAction = InputSystem.actions.FindAction("Player/Move");
            JumpAction = InputSystem.actions.FindAction("Player/Jump");
            InventoryAction = InputSystem.actions.FindAction("Player/Inventory");

            EnableActions();
        }

        public void EnableActions() {
            MoveAction.Enable();
            JumpAction.Enable();
            InventoryAction.Enable();
        }

        public void DisableActions() {
            MoveAction.Disable();
            JumpAction.Disable();
            InventoryAction.Disable();
        }
    }
}