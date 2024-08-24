using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Scripts.Player.Weapons {
    public class PickupbleAmmo : MonoBehaviour {
        [SerializeField] private TMP_Text tmpText;
        [SerializeField] private int minRandomValue = 10;
        [SerializeField] private int maxRandomValue = 30;
        private int _addAmmoCount = 30;

        private void Start() {
            _addAmmoCount = Random.Range(minRandomValue, maxRandomValue);
            tmpText.text = _addAmmoCount.ToString("00");
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.transform.parent.parent.TryGetComponent(out PlayerAmmo playerAmmo)) {
                playerAmmo.IncrementAmmoCount(_addAmmoCount);
                Destroy(gameObject);
            }
        }
    }
}