using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Cuatro
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [Header("----- Audio Source -----")]
        public AudioSource musicSource;
        public AudioSource SFXSource;

        [Header("----- Audio Clip -----")]
        public AudioClip trackClip;
        public AudioClip bombClip;
        public AudioClip footstepsClip;
        public AudioClip fanClip;
        public AudioClip breatheClip;
        public AudioClip ExitSmoke;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            musicSource.clip = trackClip;
            musicSource.volume = 0.35f;
            musicSource.Play();
        }

        public void PlaySFX(AudioClip clip, float volumen = 1.0f)
        {
            SFXSource.volume = volumen;
            SFXSource.PlayOneShot(clip);
        }
    }
}
