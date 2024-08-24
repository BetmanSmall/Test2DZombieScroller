using TMPro;
using UnityEngine;
namespace _Game.Scripts.Ui {
    public class AmmoPanel : MonoBehaviour {
        [SerializeField] private TMP_Text tmpText;

        public void SetAmmo(int ammo) {
            tmpText.text = ammo.ToString("000");
        }
    }
}