using _Game.Scripts.Enemies;
using UnityEngine;
using UnityEngine.Pool;

namespace _Game.Scripts.Player.Weapons.Bullets {
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerBullet : MonoBehaviour {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float damage = 7.5f;
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
                if (other.gameObject.TryGetComponent(out ZombieEnemy zombieEnemy)) {
                    zombieEnemy.TakeDamage(damage);
                }
            }
            _objectPoolPlayerBullets.Release(this);
        }
    }
}