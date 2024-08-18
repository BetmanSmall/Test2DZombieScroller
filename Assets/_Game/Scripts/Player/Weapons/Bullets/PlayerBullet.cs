using UnityEngine;

namespace _Game.Scripts.Player.Weapons.Bullets {
    public class PlayerBullet : MonoBehaviour {
        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Zombie")) {
                // take damage
            }
            Destroy(gameObject);
        }
    }
}