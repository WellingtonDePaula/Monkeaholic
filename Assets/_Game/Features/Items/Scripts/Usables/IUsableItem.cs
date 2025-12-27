using Features.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Features.Items.Usables {
    public interface IUsableItem {
        void OnEquip(PlayerStateMachine player);
        void OnUnequip();
        void OnStartUse();
        void OnUpdateUse();
        void OnEndUse();
    }
}
