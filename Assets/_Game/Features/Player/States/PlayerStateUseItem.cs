using Core.StateMachine;
using Features.Items.Behaviours;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.Player {
    public class PlayerStateUseItem : BaseState<PlayerStateMachine.PlayerState> {
        private PlayerStateMachine ctx;
        private GameObject item;

        public PlayerStateUseItem(PlayerStateMachine context) : base(PlayerStateMachine.PlayerState.UseItem) {
            ctx = context;
        }

        public override void EnterState() {
            item = ctx.SpawnItem(ctx.Inventory.SelectedSlot.Item.ItemPrefab);
            ItemBehaviour behaviour = item.GetComponent<ItemBehaviour>();

            behaviour.Setup(ctx, ctx.Inventory.SelectedSlot.Item);
            behaviour.OnUseDown();
        }

        public override void ExitState() {
            ItemBehaviour behaviour = item.GetComponent<ItemBehaviour>();

            behaviour.OnUseUp();
        }

        public override void FixedUpdateState() {
        }

        public override PlayerStateMachine.PlayerState GetNextState() {
            if (ctx.IsOwner) {
                HandleAim();
                // Problema aqui provavelmente é o uso do "WasReleasedThisFrame"
                if (ctx.Controller.UseItemAction.WasReleasedThisFrame()) {
                    ctx.Inventory.UseSelectedItem();
                    return PlayerStateMachine.PlayerState.Idle;
                }
            }
            return PlayerStateMachine.PlayerState.UseItem;
        }

        public override void UpdateState() {
            if (ctx.IsOwner) {
                ctx.InputDirection.Value = ctx.Controller.MoveAction.ReadValue<Vector2>();
            }
        }

        private void HandleAim() {
            Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
            mouseScreenPos.z = Camera.main.nearClipPlane;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            mouseWorldPos.z = 0f;

            ctx.AimDirection.Value = (mouseWorldPos - ctx.transform.position).normalized;
        }
    }
}