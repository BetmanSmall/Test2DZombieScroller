using _Game.Scripts.Player.Weapons.Bullets;
using UnityEngine;
using UnityEngine.Pool;

namespace _Game.Scripts.Player.Weapons {
    public class PlayerBulletSpawner : MonoBehaviour {
        [SerializeField] private PlayerBullet playerBulletPrefab;
        [SerializeField] private float bulletSpeed = 5f;
        [SerializeField] private Transform shootingPoint;
        [SerializeField] private Transform bulletsContainer;
        private ObjectPool<PlayerBullet> _objectPoolPlayerBullets;

        private void Awake() {
            _objectPoolPlayerBullets = new ObjectPool<PlayerBullet>(ObjectPollCreateFunc, ObjectPoolActionOnGet, ActionOnRelease, ObjectPoolActionOnDestroy);
            bulletsContainer.SetParent(null);
        }

        private PlayerBullet ObjectPollCreateFunc() {
            PlayerBullet newPlayerBullet = Instantiate(playerBulletPrefab, shootingPoint.position, shootingPoint.rotation, bulletsContainer);
            newPlayerBullet.SetPool(_objectPoolPlayerBullets);
            return newPlayerBullet;
        }

        private void ObjectPoolActionOnGet(PlayerBullet playerBullet) {
            playerBullet.transform.position = shootingPoint.position;
            playerBullet.transform.rotation = shootingPoint.rotation;
            playerBullet.gameObject.SetActive(true);
        }

        private void ActionOnRelease(PlayerBullet playerBullet) {
            playerBullet.gameObject.SetActive(false);
        }

        private void ObjectPoolActionOnDestroy(PlayerBullet playerBullet) {
            Destroy(playerBullet.gameObject);
        }

        public void Shoot() {
            PlayerBullet playerBullet = _objectPoolPlayerBullets.Get();
            if (playerBullet != null) {
                playerBullet.AddForse(shootingPoint.right * bulletSpeed);
            }
        }
    }
}