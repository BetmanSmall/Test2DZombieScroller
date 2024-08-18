using System;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace _Game.Scripts.Enemies {
    public class ZombieEnemy : MonoBehaviour {
        [SerializeField] private float maxHp = 80f;
        [SerializeField] private float currentHp;
        [SerializeField] private Image imageHp;
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
                    }
                    return true;
                }
            }
            return false;
        }
    }
}