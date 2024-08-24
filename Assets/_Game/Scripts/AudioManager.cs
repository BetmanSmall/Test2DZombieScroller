using UnityEngine;

namespace _Game.Scripts {
    public class AudioManager : MonoBehaviour {
        [SerializeField] private AudioSource audioSourceAmbient;
        [SerializeField] private AudioSource audioSourceOneShot;
        [SerializeField] private AudioClip[] ambientClips;
        [SerializeField] private AudioClip[] gameOverClips;
        [SerializeField] private AudioClip[] ammoPickUpClips;
        [SerializeField] private AudioClip[] playerDeathClips;
        [SerializeField] private AudioClip[] zombieDeathClips;
        [SerializeField] private AudioClip[] singleShotClips;
        [SerializeField] private AudioClip[] burstShotsClips;
        public static AudioManager Instance;

        private void Awake() {
            if (Instance == null) {
                Instance = this;
            }
            PlayRandomAmbientSounds();
        }

        public void PlayRandomAmbientSounds() {
            audioSourceAmbient.clip = ambientClips[Random.Range(0, ambientClips.Length)];
            audioSourceAmbient.Play();
        }

        public void PlayRandomGameOver() {
            audioSourceAmbient.clip = gameOverClips[Random.Range(0, gameOverClips.Length)];
            audioSourceAmbient.Play();
        }

        public void PlayRandomAmmoPickUp() {
            audioSourceOneShot.clip = ammoPickUpClips[Random.Range(0, ammoPickUpClips.Length)];
            audioSourceOneShot.Play();
        }

        public void PlayRandomPlayerDeath() {
            audioSourceOneShot.clip = playerDeathClips[Random.Range(0, playerDeathClips.Length)];
            audioSourceOneShot.Play();
        }

        public void PlayRandomZombieDeath() {
            audioSourceOneShot.clip = zombieDeathClips[Random.Range(0, zombieDeathClips.Length)];
            audioSourceOneShot.Play();
        }

        public void PlayRandomSingleShot() {
            audioSourceOneShot.clip = singleShotClips[Random.Range(0, singleShotClips.Length)];
            audioSourceOneShot.Play();
        }

        public void PlayRandomBurstShots() {
            audioSourceOneShot.clip = burstShotsClips[Random.Range(0, burstShotsClips.Length)];
            audioSourceOneShot.Play();
        }
    }
}