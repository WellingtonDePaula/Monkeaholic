using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.Player {
    public class PlayerController {
        public readonly InputAction MoveAction;
        public readonly InputAction JumpAction;
        public readonly InputAction InventoryAction;
        public readonly InputAction UseItemAction;

        private Camera _mainCamera;

        public PlayerController() {
            var map = InputSystem.actions.FindActionMap("Player");

            MoveAction = map.FindAction("Move");
            JumpAction = map.FindAction("Jump");
            InventoryAction = map.FindAction("Inventory");
            UseItemAction = map.FindAction("UseItem");

            _mainCamera = Camera.main;

            EnableActions();
        }

        /// <summary>
        /// Retorna a posição do mouse já convertida para coordenadas do mundo 2D.
        /// </summary>
        public Vector2 GetMouseWorldPosition() {
            if (Mouse.current == null)
                return Vector2.zero;

            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

            Vector3 screenPoint = new Vector3(mouseScreenPos.x, mouseScreenPos.y, -_mainCamera.transform.position.z);

            return _mainCamera.ScreenToWorldPoint(screenPoint);
        }

        public Vector2 GetAimDirection(Vector2 originPosition) {
            Vector2 mousePos = GetMouseWorldPosition();
            return (mousePos - originPosition).normalized;
        }

        public bool GetUseItemPressed() {
            return UseItemAction.WasPressedThisFrame();
        }

        public bool GetUseItemReleased() {
            return UseItemAction.WasReleasedThisFrame();
        }

        public bool IsUseItemHeld() {
            return UseItemAction.IsPressed();
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