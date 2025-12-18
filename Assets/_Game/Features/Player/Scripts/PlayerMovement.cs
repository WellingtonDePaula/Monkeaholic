using UnityEngine;

namespace Features.Player {
    public class PlayerMovement {
        private readonly PlayerStateMachine ctx;
        public PlayerMovement(PlayerStateMachine context) {
            ctx = context;
        }
        public void Move(float xInput) {
            ctx.Body.AddForceX(xInput * ctx.Data.MoveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
        }
        public void Jump() {
            //ctx.Body.AddForceY(ctx.Controller.JumpAction.ReadValue<Vector2>().y * ctx.JumpSpeed);
        }
    }
}