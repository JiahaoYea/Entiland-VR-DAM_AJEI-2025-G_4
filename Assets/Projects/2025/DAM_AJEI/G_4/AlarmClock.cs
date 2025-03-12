using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Cuatro
{
    public class AlarmClock : MonoBehaviour
    {
        [SerializeField] private float minTime = 10f;
        [SerializeField] private float maxTime = 20f;

        public AudioSource alarmAudioSource;

        private float timer = 0f;
        private float nextAlarmTime;
        private bool alarmIsPlaying = false;

        private void Start()
        {
            SetRandomAlarmTime();
        }

        private void Update()
        {
            if (!alarmIsPlaying)
            {
                timer += Time.deltaTime;

                if (timer >= nextAlarmTime)
                {
                    StartAlarm();
                }
            }
        }

        private void StartAlarm()
        {
            alarmIsPlaying = true;
            alarmAudioSource.Play();
            Debug.Log("¡Alarma sonando!");
        }

        public void StopAlarm()
        {
            if (alarmIsPlaying)
            {
                alarmAudioSource.Stop();
                alarmIsPlaying = false;

                SetRandomAlarmTime();
                Debug.Log("Alarma detenida. Se reinicia el contador.");
            }
        }

        private void SetRandomAlarmTime()
        {
            timer = 0f;
            nextAlarmTime = Random.Range(minTime, maxTime);
        }
    }
}
