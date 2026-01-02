using UnityEngine;

public class ExplosionHandler : MonoBehaviour {
    private ProjectileController controller;
    private float currentTime = 0f;
    public void Explode() {
        Debug.Log("BOOOOOOOMMMMMMM!!!!!!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(controller.WeaponData.DelayOnThrow) {
            return;
        }

        if (collision.CompareTag("Ground")) {
            // Implement explosion logic here
        }

        // Tests

        currentTime = controller.WeaponData.ExplosionDelay;
    }

    public void Setup(ProjectileController controller) {
        this.controller = controller;
        if (controller.WeaponData.DelayOnThrow) {
            currentTime = controller.WeaponData.ExplosionDelay;
        }
    }

    private void Update() {
        if(currentTime > 0f) {
            currentTime -= Time.deltaTime;
            return;
        }
        Explode();
    }
}
