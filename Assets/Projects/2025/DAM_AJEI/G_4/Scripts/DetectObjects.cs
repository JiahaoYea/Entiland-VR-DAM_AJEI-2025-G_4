using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Cuatro
{
    public class DetectObjects : MonoBehaviour
    {
        public AudioSource beepAudio;

        public GameObject redButton;
        public GameObject blueButton;

        public Vector3 startPosition;
        public Image circleFill;
        private void Start()
        {
            startPosition = transform.position;
            circleFill.fillAmount = 0f;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Objective"))
            {
                beepAudio.Play();
                StopCoroutine("DecreaseFill");
                StartCoroutine("IncreaseFill");
                StartCoroutine(DestroyAfterTime(other.gameObject, 3f));
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Objective"))
            {
                beepAudio.Stop();
                StopCoroutine("IncreaseFill"); 
                StartCoroutine("DecreaseFill");
                StopAllCoroutines();
            }
        }
        private IEnumerator DestroyAfterTime(GameObject obj, float delay)
        {
            yield return new WaitForSeconds(delay);
            Destroy(obj);
            circleFill.fillAmount = 0f; 
        }

        private IEnumerator IncreaseFill()
        {
            while (circleFill.fillAmount < 1f)
            {
                circleFill.fillAmount += Time.deltaTime / 3f;
                yield return null;
            }
        }

        private IEnumerator DecreaseFill()
        {
            while (circleFill.fillAmount > 0f)
            {
                circleFill.fillAmount -= Time.deltaTime / 3f;
                yield return null;
            }
        }
        public void SpawnButtons()
        {
            redButton.SetActive(true);
        }

        public void HideButtons()
        {
            redButton.SetActive(false);
            blueButton.SetActive(false);
        }

        public void ResetPosition()
        {
            transform.position = startPosition;
        }
    }
}