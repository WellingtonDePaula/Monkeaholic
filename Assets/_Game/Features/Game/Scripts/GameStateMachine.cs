using Core.StateMachine;

namespace Features.Game {
    public class GameStateMachine : StateManager<GameStateMachine.GameState> {
        public enum GameState {
            MainMenu,
            Playing,
            Paused,
            GameOver
        }

        private void Awake() {
        }

        protected override void Update() {
            base.Update();
        }

        protected override void FixedUpdate() {
            base.FixedUpdate();
        }
    }
}