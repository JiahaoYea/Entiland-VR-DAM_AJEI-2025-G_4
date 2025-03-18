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
        public AudioClip buttonClip;
        public AudioClip paperClip;
        public AudioClip hiMan;
        public AudioClip hiWoman;
        public AudioClip hiWoman01;
        public AudioClip hiWoman02;
        public AudioClip hiWoman03;
        public AudioClip thanks_ManClip;
        public AudioClip thanks_WomanClip;
        public AudioClip noTrespass_WomanClip;
        public AudioClip noTrespass_ManClip;
        public AudioClip cach_ManClip;
        public AudioClip cach_WomanClip;
        public AudioClip angry_ManClip;
        public AudioClip angry_WomanClip;

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
            musicSource.Play();
        }

        public void PlaySFX(AudioClip clip, float volumen = 1.0f)
        {
            SFXSource.volume = volumen;
            SFXSource.PlayOneShot(clip);
        }
    }
}
