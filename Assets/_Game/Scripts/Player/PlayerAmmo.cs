using _Game.Scripts.Ui;
using UnityEngine;

namespace _Game.Scripts.Player {
    public class PlayerAmmo : MonoBehaviour {
        [SerializeField] private AmmoPanel ammoPanel;
        [SerializeField] private int startAmmoCount; 
        private int _currentAmmoCount;
        public int CurrentAmmoCount => _currentAmmoCount;

        private void Start() {
            _currentAmmoCount = startAmmoCount;
            ammoPanel.SetAmmo(_currentAmmoCount);
        }

        public void IncrementAmmoCount(int addAmmoCount) {
            if (addAmmoCount > 0) {
                _currentAmmoCount += addAmmoCount;
                ammoPanel.SetAmmo(_currentAmmoCount);
                AudioManager.Instance?.PlayRandomAmmoPickUp();
            }
        }

        public void DecrementAmmoCount(int ammoCount) {
            if (ammoCount > 0) {
                _currentAmmoCount -= ammoCount;
                ammoPanel.SetAmmo(_currentAmmoCount);
                if (_currentAmmoCount <= 0) {
                    GameOverPanel.Instance.ShowPanel();
                }
            }
        }
    }
}