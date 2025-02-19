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

        public GameObject suitcase;
        public float moveSpeed; 

        private bool isMoving = true;
        public  bool isCorrect = true;
        private bool isButtonPressed = false;

        private void Start()
        {
            
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
        }
        public void SpawnSuitcase()
        {
            Instantiate(suitcase, suitcasPositionA.transform.position, Quaternion.identity);
            isMoving = true;
            isButtonPressed = false;

        }
    }
}
