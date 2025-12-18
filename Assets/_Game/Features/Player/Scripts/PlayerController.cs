using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.Player {
    public class PlayerController {
        public readonly InputAction MoveAction;
        public readonly InputAction JumpAction;
        public readonly InputAction InventoryAction;
        public readonly InputAction UseItemAction;

        public PlayerController() {
            MoveAction = InputSystem.actions.FindAction("Player/Move");
            JumpAction = InputSystem.actions.FindAction("Player/Jump");
            InventoryAction = InputSystem.actions.FindAction("Player/Inventory");
            UseItemAction = InputSystem.actions.FindAction("Player/UseItem");

            EnableActions();
        }

        public void EnableActions() {
            MoveAction.Enable();
            JumpAction.Enable();
            InventoryAction.Enable();
            UseItemAction.Enable();
        }

        public void DisableActions() {
            MoveAction.Disable();
            JumpAction.Disable();
            InventoryAction.Disable();
            UseItemAction.Disable();
        }
    }
}