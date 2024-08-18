using UnityEngine;
using UnityEngine.Pool;
namespace _Game.Scripts.Player.Weapons.Bullets {
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerBullet : MonoBehaviour {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        private ObjectPool<PlayerBullet> _objectPoolPlayerBullets;

        private void Awake() {
            if (!rigidbody2D) rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void SetPool(ObjectPool<PlayerBullet> pool) {
            _objectPoolPlayerBullets = pool;
        }

        public void AddForse(Vector2 forward) {
            rigidbody2D.AddForce(forward, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Zombie")) {
                // take damage
            }
            _objectPoolPlayerBullets.Release(this);
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.CompareTag("Zombie")) {
                // take damage
            }
            _objectPoolPlayerBullets.Release(this);
        }
    }
}