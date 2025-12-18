using Features.Items.Data;
using Features.Player;
using UnityEngine;

namespace Features.Items.Behaviours {
    public abstract class ItemBehaviour : MonoBehaviour {
        protected PlayerStateMachine owner;
        protected ItemData itemData;
        public virtual void Setup(PlayerStateMachine player, ItemData data) {
            owner = player;
            itemData = data;
        }

        public abstract void OnUseDown();
        public abstract void OnUseUp();
    }
}
