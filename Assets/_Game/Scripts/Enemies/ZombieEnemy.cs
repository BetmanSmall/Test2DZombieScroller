using System;
using _Game.Scripts.Player.Weapons;
using _Game.Scripts.Ui;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace _Game.Scripts.Enemies {
    public class ZombieEnemy : MonoBehaviour {
        [SerializeField] private float maxHp = 80f;
        [SerializeField] private float currentHp;
        [SerializeField] private Image imageHp;
        [SerializeField] private PickupbleAmmo pickupbleAmmo;
        private ObjectPool<ZombieEnemy> _objectPoolZombieEnemys;

        public Action OnDie;

        private void Awake() {
            ObjectPoolReset();
        }

        private void OnEnable() {
            ObjectPoolReset();
        }

        public void ObjectPoolReset() {
            currentHp = maxHp;
            imageHp.fillAmount = 1f;
        }

        public void SetPool(ObjectPool<ZombieEnemy> pool) {
            _objectPoolZombieEnemys = pool;
        }

        public bool TakeDamage(float damage) {
            if (damage > 0f) {
                if (currentHp > 0f) {
                    currentHp -= damage;
                    imageHp.fillAmount = currentHp / maxHp;
                    if (currentHp <= 0f) {
                        currentHp = 0f;
                        OnDie?.Invoke();
                        _objectPoolZombieEnemys.Release(this);
                        Instantiate(pickupbleAmmo, gameObject.transform.position + Vector3.up*1.5f, Quaternion.identity);
                        AudioManager.Instance?.PlayRandomZombieDeath();
                    }
                    return true;
                }
            }
            return false;
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.CompareTag("Player")) {
                GameOverPanel.Instance.ShowPanel();
                AudioManager.Instance?.PlayRandomPlayerDeath();
            }
        }
    }
}