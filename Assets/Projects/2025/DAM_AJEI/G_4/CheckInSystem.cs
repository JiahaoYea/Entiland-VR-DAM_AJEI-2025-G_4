using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Cuatro
{
    public class CheckInSystem : MonoBehaviour
    {
        public bool isOccupied = false;
        bool isSuitcaseInfront = false;
        public GameObject cacheoPosRef;
        public GameObject player;
        public Image blackTransitionImg;

        void Start()
        {
                isOccupied = true;
                Debug.Log("Entrando Persona");
            StartCoroutine(WaitForSuitcase());
                Debug.Log("Decidir que haces");
        }

        void Update()
        {
        }



        public void Approved()
        {
            if (isOccupied && isSuitcaseInfront)
            {
                Debug.Log("Maleta buena");
                isOccupied = false;
            }
        }
        public void Denied()
        {
            if (isOccupied && isSuitcaseInfront)
            {
                Debug.Log("Maleta mala");
                isOccupied = false;
            }
        }
        public void Cacheo()
        {
            if (isOccupied && isSuitcaseInfront)
            {
                Debug.Log("Cachau");
                StartCoroutine(FadeOutTransition());
                player.transform.position = cacheoPosRef.transform.position;
                isOccupied = false;
            }
        }

        public IEnumerator WaitForSuitcase()
        {
            yield return new WaitForSeconds(5.0f);
            Debug.Log("MaletaDelante");
            isSuitcaseInfront = true;
        }
        public IEnumerator FadeOutTransition()
        {
            float timeElapsed = 0f;
            Color startColor = blackTransitionImg.color;
            blackTransitionImg.color = new Color(startColor.r, startColor.g, startColor.b, 1f);

            while (timeElapsed < 1f)
            {
                timeElapsed += Time.deltaTime;
                float alpha = Mathf.Lerp(1f, 0f, timeElapsed / 1f);
                blackTransitionImg.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
                yield return null;
            }

            blackTransitionImg.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        }
    }


}
