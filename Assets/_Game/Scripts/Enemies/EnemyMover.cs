using UnityEngine;
namespace _Game.Scripts.Enemies {
    public class EnemyMover : MonoBehaviour {
        [SerializeField] private Animator animator;
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float speed = 10f;
        [SerializeField] private Player.Player targetPlayer;
        private bool _rightDirection = true;

        private void Awake() {
            if (!animator) animator = GetComponent<Animator>();
            if (!rigidbody2D) rigidbody2D = GetComponent<Rigidbody2D>();
            if (!targetPlayer) targetPlayer = FindObjectOfType<Player.Player>();
        }

        private void OnEnable() {
            _rightDirection = true;
            gameObject.transform.rotation = Quaternion.identity;
        }

        public void SetTargetPlayer(Player.Player targetPlayer) {
            this.targetPlayer = targetPlayer;
        }

        private void FixedUpdate() {
            rigidbody2D.velocity = new Vector2(speed * ((_rightDirection) ? 1f : -1f), 0f);
        }

        private void Update() {
            MoveEnemyX();
        }

        private void MoveEnemyX() {
            float moveDirection = targetPlayer.transform.position.x - gameObject.transform.position.x;
            if (Mathf.Abs(moveDirection) > 0.01f) {
                if (moveDirection > 0f) {
                    if (!_rightDirection) {
                        gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
                        _rightDirection = true;
                    }
                } else {
                    if (_rightDirection) {
                        gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                        _rightDirection = false;
                    }
                }
            }
        }
    }
}