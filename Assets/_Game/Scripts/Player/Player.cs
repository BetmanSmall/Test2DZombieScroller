using _Game.Scripts.Player.Weapons;
using UnityEngine;

namespace _Game.Scripts.Player {
    public class Player : MonoBehaviour {
        [SerializeField] private PlayerMover playerMover;
        [SerializeField] private PlayerShooter playerShooter;
        [SerializeField] private float burstDelayTime = 1f;
        private float _elapsedBurstDelayTime;

        private void Awake() {
            if (!playerMover) playerMover = GetComponent<PlayerMover>();
            if (!playerShooter) playerShooter = GetComponent<PlayerShooter>();
        }

        public void PlayerInputActions(float horizontalFloat, bool fireOnShot, bool fireBurst) {
            if (!fireOnShot && !fireBurst) {
                playerShooter.StopFireAnimation();
                PlayerHorizontalMove(horizontalFloat);
            } else {
                PlayerHorizontalMove(0);
                playerShooter.PlayerShootOneShot(fireOnShot);
                _elapsedBurstDelayTime += Time.deltaTime;
                if (_elapsedBurstDelayTime >= burstDelayTime) {
                    playerShooter.PlayerShootBurst(fireBurst);
                    _elapsedBurstDelayTime = 0f;
                }
            }
            if (!fireBurst) {
                _elapsedBurstDelayTime = 0f;
            }
        }

        private void PlayerHorizontalMove(float horizontalFloat) {
            playerMover.PlayerHorizontalMove(horizontalFloat);
        }
    }
}