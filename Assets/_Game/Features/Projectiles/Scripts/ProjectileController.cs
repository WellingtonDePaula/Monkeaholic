using UnityEngine;

public class ProjectileController : MonoBehaviour {
    [SerializeField] private Rigidbody2D body;
    private float damage;
    public void Launch(float force, Vector3 direction, float damage) {
        this.damage = damage;
        body.AddForce(direction.normalized * force, ForceMode2D.Impulse);
        Debug.Log("Throwed");
    }
}
