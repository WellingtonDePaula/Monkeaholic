using Features.Player;
using UnityEngine;

public class PlayerStats {
    private PlayerStateMachine ctx;
    private float health;
    public float Health { 
        get { return health; } 
        set {
            health -= value; 
            if (health <= 0) { ctx.Die(); } 
        } 
    }
    public PlayerStats(PlayerStateMachine context) {
        ctx = context;
        Health = ctx.Data.MaxHealth;
    }
}
