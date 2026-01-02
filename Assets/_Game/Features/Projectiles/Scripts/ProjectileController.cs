using Features.Items.Data;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
    [SerializeField] private Rigidbody2D body;
    public WeaponData WeaponData { get; private set; }
    public void Launch(float force, Vector3 direction, WeaponData data) {
        WeaponData = data;
        body.AddForce(direction.normalized * force, ForceMode2D.Impulse);

        if (TryGetComponent<ExplosionHandler>(out var explosionHandler)) {
            explosionHandler.Setup(this);
        }
    }
}
