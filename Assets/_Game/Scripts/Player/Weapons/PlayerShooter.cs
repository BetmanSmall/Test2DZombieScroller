using System.Collections;
using UnityEngine;

namespace _Game.Scripts.Player.Weapons {
    public class PlayerShooter : MonoBehaviour {
        private static readonly int IsFire = Animator.StringToHash("IsFire");
        [SerializeField] private Animator animator;
        [SerializeField] private PlayerBulletSpawner playerBulletSpawner;
        [Space] [Header(header:"Burst Shoots Params")]
        [SerializeField] private int burstBulletCount = 5;
        [SerializeField] private float timeBetweenBurstShots = 0.06f;
        private bool _burstShootCoroutineRunning;

        private void Awake() {
            if (!animator) animator = GetComponent<Animator>();
        }

        public void PlayerShootOneShot(bool shoot) {
            if (!_burstShootCoroutineRunning && shoot) {
                if (playerBulletSpawner.Shoot()) {
                    StartFireAnimation();
                }
            }
        }

        public void PlayerShootBurst(bool shoot) {
            if (!_burstShootCoroutineRunning && shoot) {
                StartCoroutine(BurstShoot());
            } else if (shoot == false) {
                _burstShootCoroutineRunning = false;
            }
        }

        private IEnumerator BurstShoot() {
            int curentShot = 0;
            _burstShootCoroutineRunning = true;
            while (curentShot++ < burstBulletCount && _burstShootCoroutineRunning) {
                if (playerBulletSpawner.Shoot()) {
                    StartFireAnimation();
                }
                yield return new WaitForSeconds(timeBetweenBurstShots);
            }
            _burstShootCoroutineRunning = false;
            StopFireAnimation();
        }

        private void StartFireAnimation() {
            animator.SetBool(IsFire, true);
        }

        public void StopFireAnimation() {
            animator.SetBool(IsFire, false);
        }
    }
}