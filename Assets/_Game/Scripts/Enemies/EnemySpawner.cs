using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace _Game.Scripts.Enemies {
    public class EnemySpawner : MonoBehaviour {
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private ZombieEnemy[] zombiePrefabs;
        [SerializeField] private float maxRandomSpawnTime = 10f;
        [SerializeField] private Player.Player targetPlayer;
        private ObjectPool<ZombieEnemy> _objectPoolZombieEnemys;

        private void Awake() {
            if (!targetPlayer) targetPlayer = FindObjectOfType<Player.Player>();
            _objectPoolZombieEnemys = new ObjectPool<ZombieEnemy>(ObjectPollCreateFunc, ObjectPoolActionOnGet, ActionOnRelease, ObjectPoolActionOnDestroy);
            StartCoroutine(SpawnEnemys());
        }

        private Transform GetRandomSpawnPosition() {
            return spawnPoints[Random.Range(0, spawnPoints.Length)];
        }

        private ZombieEnemy ObjectPollCreateFunc() {
            ZombieEnemy randomPrefab = zombiePrefabs[Random.Range(0, zombiePrefabs.Length)];
            Transform randomSpawnPoint = GetRandomSpawnPosition();
            ZombieEnemy newZombieEnemy = Instantiate(randomPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation, gameObject.transform);
            newZombieEnemy.SetPool(_objectPoolZombieEnemys);
            EnemyMover enemyMover = newZombieEnemy.GetComponent<EnemyMover>();
            enemyMover.SetTargetPlayer(targetPlayer);
            return newZombieEnemy;
        }

        private void ObjectPoolActionOnGet(ZombieEnemy zombieEnemy) {
            Transform randomSpawnPoint = GetRandomSpawnPosition();
            zombieEnemy.transform.position = randomSpawnPoint.position;
            zombieEnemy.gameObject.SetActive(true);
        }

        private void ActionOnRelease(ZombieEnemy zombieEnemy) {
            zombieEnemy.gameObject.SetActive(false);
        }

        private void ObjectPoolActionOnDestroy(ZombieEnemy zombieEnemy) {
            Destroy(zombieEnemy.gameObject);
        }

        public IEnumerator SpawnEnemys() {
            while (true) {
                ZombieEnemy zombieEnemy = _objectPoolZombieEnemys.Get();
                Debug.Log("EnemySpawner::SpawnEnemys(); -- zombieEnemy:" + JsonUtility.ToJson(zombieEnemy));
                yield return new WaitForSecondsRealtime(Random.Range(1f, maxRandomSpawnTime));
            }
        }
    }
}