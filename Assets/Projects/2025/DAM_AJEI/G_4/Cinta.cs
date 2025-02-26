using EntilandVR.DosCinco.DAM_AJEI.G_Cuatro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI_G_Cuatro
{
    public class Cinta : MonoBehaviour
    {
        public Transform suitcasPositionA;
        public Transform suitcasPositionB;
        public Transform suitcasPositionC;

        private CheckInSystem objects;

        public GameObject suitcase;
        public float moveSpeed; 

        private bool isMoving = true;
        public  bool isCorrect = true;
        private bool isButtonPressed = false;

        private void Start()
        {
            objects = suitcase.GetComponent<CheckInSystem>();
        }

        private void Update()
        {
            if (isMoving)
            {
                if (Vector3.Distance(suitcase.transform.position, suitcasPositionB.position) > 2f)
                    suitcase.transform.localPosition += suitcasPositionB.position * moveSpeed * Time.deltaTime;
                else
                {
                    isMoving = false;
                    isButtonPressed = true;
                }
            }

            if (isButtonPressed)
            {
                if (!isCorrect)
                {
                    Destroy(suitcase);
                    Points.Instance.hp--;
                }
                else
                {
                    if (Vector3.Distance(suitcase.transform.position, suitcasPositionC.position) > 2f)
                        suitcase.transform.localPosition += suitcasPositionC.position * moveSpeed * Time.deltaTime;
                    else
                    {
                        isButtonPressed = false;
                        Destroy(suitcase, 2f);
                    }

                    Points.Instance.currentPoints += 10;
                }
            }

            if (objects.isOccupied == false && suitcase == null)
            {
                Vector3 initialPos = suitcasPositionA.transform.position;
                Instantiate(suitcase, initialPos, Quaternion.identity);
                objects = suitcase.GetComponent<CheckInSystem>();         
            }
        }

        public void SpawnSuitcase()
        {
            isButtonPressed = true;
            StartCoroutine(SuitcaseSpawnTime());
        }

        IEnumerator SuitcaseSpawnTime()
        {
            yield return new WaitForSeconds(2.5f);
            Instantiate(suitcase, suitcasPositionA.transform.position, Quaternion.identity);
            isMoving = true;
            objects = suitcase.GetComponent<CheckInSystem>();
        }
    }
}
