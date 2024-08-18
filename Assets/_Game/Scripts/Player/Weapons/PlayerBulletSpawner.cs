using UnityEngine;

namespace _Game.Scripts.Player.Weapons {
    public class PlayerBulletSpawner : MonoBehaviour {
        [SerializeField] private GameObject playerBullet;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private Transform shootingPoint;

        public void Shoot() {
            // GameObject newBullet = Instantiate()
        }
    }
}