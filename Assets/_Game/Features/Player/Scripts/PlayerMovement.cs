using UnityEngine;

namespace Features.Player {
    public class PlayerMovement {
        private readonly PlayerStateMachine ctx;
        public PlayerMovement(PlayerStateMachine context) {
            ctx = context;
        }
        public void Move(float xInput) {
            // Cliente andando mais rápido que o servidor
            //ctx.Body.linearVelocityX = xInput * ctx.Stats.BaseMoveSpeed;
            ctx.Body.linearVelocityX = Mathf.Lerp(ctx.Body.linearVelocityX, xInput * ctx.Stats.MoveSpeed, Time.deltaTime * 10f);
        }
        public void Jump() {
            //ctx.Body.AddForceY(ctx.Controller.JumpAction.ReadValue<Vector2>().y * ctx.JumpSpeed);
        }
    }
}