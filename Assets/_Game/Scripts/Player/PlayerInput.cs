using UnityEngine;

namespace _Game.Scripts.Player {
    public class PlayerInput : MonoBehaviour {
        private const string HorizontalString = "Horizontal";
        private const string fireString = "Fire1";
        [SerializeField] private PlayerMover playerMover;

        private void Update() {
            float horizontalFloat = Input.GetAxis(HorizontalString);
            // if (Mathf.Abs(horizontalFloat) > 0.01f) {
            playerMover.Move(horizontalFloat);
            // }
        }
    }
}