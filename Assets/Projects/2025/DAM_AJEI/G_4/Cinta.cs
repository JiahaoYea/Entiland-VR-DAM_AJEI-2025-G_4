using EntilandVR.DosCinco.DAM_AJEI.G_Cuatro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI_G_Cuatro
{
    public class Cinta : MonoBehaviour
    {
        public Transform suitcasPositionA;  // Punto de inicio
        public Transform suitcasPositionB;  // Punto intermedio
        public Transform suitcasPositionC;  // Punto final

        GameObject suitcase;
        public GameObject suitcasePrefab;
        positionObjects check;

        public float moveSpeed = 2f;

        public bool isMoving = false;
        bool isCorrect = true;
        bool isSpawning;
        public bool isButtonGreen;
        public bool isButtonPressed = false;

        private void Start()
        {

            SpawnSuitcase();
        }

        private void Update()
        {
            if (isMoving)
            {
                Debug.Log("Moviendo hacia B...");
                suitcase.transform.position = Vector3.MoveTowards(
                    suitcase.transform.position,
                    suitcasPositionB.position,
                    moveSpeed * Time.deltaTime
                );

                if (Vector3.Distance(suitcase.transform.position, suitcasPositionB.position) < 0.1f)
                {
                    Debug.Log("Llegó a B");
                    isMoving = false;
                }
            }

            if (isButtonPressed && !isMoving)
            {
                if (isButtonGreen != isCorrect)
                {
                    Debug.Log("Maleta incorrecta, destruyendo...");
                    Destroy(suitcase);
                    Points.Instance.hp--;
                    isButtonPressed = false;
                    SpawnSuitcase();

                }
                else
                {
                    Debug.Log("Moviendo hacia C...");
                    //Esto de vez en cuaando peta
                    //suitcase.transform.position = Vector3.MoveTowards(
                        //suitcase.transform.position,
                        //suitcasPositionC.position,
                        //moveSpeed * Time.deltaTime
                    //);

                    if (Vector3.Distance(suitcase.transform.position, suitcasPositionC.position) < 0.1f)
                    {
                        Debug.Log("Llegó a C, destruyendo...");
                        Destroy(suitcase);
                        Debug.Log("Destruido");

                        isButtonPressed = false;
                        Debug.Log("2");

                        SpawnSuitcase();
                        Debug.Log("Spawned");


                    }

                }
            }
        }

        public void SpawnSuitcase()
        {
            if (suitcase ==  null)
            {
                isButtonPressed = false;
                isSpawning = true;
                if (isSpawning)
                {
                    suitcase = Instantiate(suitcasePrefab, suitcasPositionA.position, Quaternion.Euler(0f, 90f, -90f));
                    suitcase.transform.parent = transform;
                    check = suitcase.GetComponent<positionObjects>();
                    isCorrect = check.isSuitcaseLegal;
                    isMoving = true;
                    isSpawning = false;

                }
            }
            else
            {
                Debug.Log("notnull");
            }
        }

    }
}
