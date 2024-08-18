using UnityEngine;

namespace _Game.Scripts.Player {
    [RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
    public class PlayerMover : MonoBehaviour {
        [SerializeField] private Animator animator;
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float speed = 10f;
        private float _horizontalFloat;
        private bool _rightDirection;
        private static readonly int IsMove = Animator.StringToHash("IsMove");

        private void Awake() {
            if (!animator) animator = GetComponent<Animator>();
            if (!rigidbody2D) rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate() {
            if (Mathf.Abs(_horizontalFloat) > 0.1f) {
                rigidbody2D.velocity = new Vector2(_horizontalFloat * speed, 0f);
            }
        }

        public void PlayerHorizontalMove(float horizontalFloat) {
            if (Mathf.Abs(horizontalFloat) > 0.01f) {
                if (horizontalFloat > 0f) {
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
                _horizontalFloat = horizontalFloat;
                animator.SetBool(IsMove, true);
            } else {
                _horizontalFloat = 0f;
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                animator.SetBool(IsMove, false);
            }
        }
    }
}