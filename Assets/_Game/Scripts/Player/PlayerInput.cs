using UnityEngine;

namespace _Game.Scripts.Player {
    public class PlayerInput : MonoBehaviour {
        private const string HorizontalString = "Horizontal";
        private const string FireString = "Fire1";
        [SerializeField] private Player player;

        private void Awake() {
            if (!player) player = GetComponent<Player>();
        }

        private void Update() {
            float horizontalFloat = Input.GetAxis(HorizontalString);
            bool fireOnShot = Input.GetButtonDown(FireString);
            bool fireBurst = Input.GetButton(FireString);
            player.PlayerInputActions(horizontalFloat, fireOnShot, fireBurst);
        }
    }
}