using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Cuatro
{
    public class Cinta : MonoBehaviour
    {
        public Transform suitcasPositionA;  // Punto de inicio
        public Transform suitcasPositionB;  // Punto intermedio
        public Transform suitcasPositionC;  // Punto final
        public Transform suitcasPositionD;  // Punto final

        GameObject suitcase;
        public GameObject blueButton;
        public GameObject suitcasePrefab;
        positionObjects check;

        public float moveSpeed = 2f;

        public bool isMoving = false;
        bool isLegal = true;
        bool isSpawning;
        public bool isButtonGreen;
        public bool isButtonPressed = false;
        bool isMovingToC = false;

        public PersonManager personManager;
        private void Start()
        {
            SpawnSuitcase();
            blueButton.SetActive(false);
        }

        private void Update()
        {
            
            if (isMoving)
            {
                if (!isMovingToC)
                {
                    suitcase.transform.position = Vector3.MoveTowards(
                        suitcase.transform.position,
                        suitcasPositionB.position,
                        moveSpeed * Time.deltaTime
                    );
                }
                else
                {
                    suitcase.transform.position = Vector3.MoveTowards(
                    suitcase.transform.position,
                    suitcasPositionC.position,
                    moveSpeed * Time.deltaTime
                   );

                }
                if (Vector3.Distance(suitcase.transform.position, suitcasPositionB.position) < 0.1f)
                {
                    isMovingToC = true;

                }
                if (Vector3.Distance(suitcase.transform.position, suitcasPositionC.position) < 0.1f)
                {
                    Debug.Log("Llega B");
                    isMoving = false;
                }
            }

            if (isButtonPressed && !isMoving)
            {
                if (!isButtonGreen) //boton rojo
                {
                    if (!isLegal) // Maleta ilegal
                    {
                        Points.Instance.hp++; // Ganas 1 punto solo una vez
                        blueButton.SetActive(true);
                        isButtonPressed = false;
                        Debug.Log("Maleta incorrecta, ganando puntos...");
                        Destroy(suitcase.gameObject);
                        if(personManager.isMale_person)
                            AudioManager.Instance.PlaySFX(AudioManager.Instance.noTrespass_ManClip);
                        else
                            AudioManager.Instance.PlaySFX(AudioManager.Instance.noTrespass_WomanClip);
                    }
                    else // Maleta legal
                    {
                        Points.Instance.hp--; // Pierdes 1 punto solo una vez
                        Debug.Log("Maleta correcta, perdiendo puntos...");
                        Debug.Log("Destruyendo maleta...");
                        if (personManager.isMale_person)
                            AudioManager.Instance.PlaySFX(AudioManager.Instance.);
                        else
                            AudioManager.Instance.PlaySFX(AudioManager.Instance.);
                        DestroyPerson();
                        Destroy(suitcase.gameObject);
                        isButtonPressed = false;
                        suitcase = null;
                        SpawnSuitcase();
                    }
                }
                else // boton verde
                {
                    if (suitcase != null)
                    {
                        Debug.Log("Moviendo maleta hacia C...");
                        suitcase.transform.position = Vector3.MoveTowards(
                            suitcase.transform.position,
                            suitcasPositionD.position,
                            moveSpeed * Time.deltaTime
                        );

                        if (Vector3.Distance(suitcase.transform.position, suitcasPositionD.position) < 0.1f)
                        {
                            if (isLegal)
                            {
                                Points.Instance.hp++; // Ganas 1 punto solo una vez
                                if (personManager.isMale_person)
                                    AudioManager.Instance.PlaySFX(AudioManager.Instance.thanks_ManClip);
                                else
                                    AudioManager.Instance.PlaySFX(AudioManager.Instance.thanks_WomanClip);
                                Debug.Log("Maleta legal, ganando puntos...");
                            }
                            // Si la maleta es incorrecta
                            else
                            {
                                Points.Instance.hp--; // Pierdes 1 punto solo una vez
                                Debug.Log("Maleta incorrecta, perdiendo puntos...");
                                if (personManager.isMale_person)
                                    AudioManager.Instance.PlaySFX(AudioManager.Instance.);
                                else
                                    AudioManager.Instance.PlaySFX(AudioManager.Instance.);
                            }
                            DestroyPerson();
                            Debug.Log("Lleg?a C, destruyendo...");
                            Destroy(suitcase.gameObject);
                            Debug.Log("Destruido");
                            isButtonPressed = false;
                            suitcase = null;
                            SpawnSuitcase();
                            Debug.Log("Spawned");
                        }
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
                    check.CheckIfLegalSuitcase();
                    isLegal = check.isSuitcaseLegal;
                    isMoving = true;
                    isSpawning = false;
                    isMovingToC = false;
                    Debug.Log(isLegal);
                }
            }
            else
            {
                Debug.Log("notnull");
            }
        }
        public bool isSuitCaseLegal()
        {
            return isLegal;
        }
        public void DestroyPerson()
        {
            Destroy(personManager.person);
            personManager.person = null;
            personManager.SpawnPerson();

        }
    }
}
