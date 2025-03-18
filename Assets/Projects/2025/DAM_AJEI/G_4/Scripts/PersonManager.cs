using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Cuatro
{
    public class PersonManager : MonoBehaviour
    {
        public Transform suitcasPositionA;  // Punto de inicio
        public Transform suitcasPositionB;  // Punto intermedio
        public Transform suitcasPositionC;  // Punto final
        public Transform suitcasPositionD;  // Punto final

        public GameObject person;
        public GameObject[] personPrefab;

        public float moveSpeed = 2f;
        public float rotationSpeed = 5f; // Velocidad de rotación

        public bool isMoving = false;
        bool isMovingToC = false;

        private Animator animator;

        public bool isButtonBlue;

        public GameObject player;
        public GameObject searchPos;
        public Vector3 startPos;
        public AlarmClock alarm;

        public bool isMale_person;

        private SpawnDetectorObjects spawnDetectorObjects;
        void Start()
        {
            startPos = player.transform.position;
            SpawnPerson();

        }

        void Update()
        {
            if (isMoving)
            {
                animator.SetBool("walk", true);
                animator.SetBool("search", false);
                Transform target = isMovingToC ? suitcasPositionC : suitcasPositionB;

                Vector3 direction = (target.position - person.transform.position).normalized;
                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    person.transform.rotation = Quaternion.Slerp(
                        person.transform.rotation,
                        targetRotation,
                        rotationSpeed * Time.deltaTime
                    );
                }

                person.transform.position = Vector3.MoveTowards(
                    person.transform.position,
                    target.position,
                    moveSpeed * Time.deltaTime
                );

                if (!isMovingToC && Vector3.Distance(person.transform.position, suitcasPositionB.position) < 0.1f)
                {
                    isMovingToC = true;
                }

                if (isMovingToC && Vector3.Distance(person.transform.position, suitcasPositionC.position) < 0.1f)
                {
                    Debug.Log("Lleg?a C");
                    animator.SetBool("walk", false);
                    if (isMale_person)
                        AudioManager.Instance.PlaySFX(AudioManager.Instance.hiMan);
                    else
                        AudioManager.Instance.PlaySFX(AudioManager.Instance.hiWoman);
                    isMoving = false;
                }
            }

            if(isButtonBlue && !isMoving)
            {
                animator.SetBool("walk", true);
                Quaternion targetRotation = Quaternion.LookRotation(suitcasPositionD.transform.position - person.transform.position).normalized;
              person.transform.rotation = Quaternion.Slerp(
                        person.transform.rotation,
                        targetRotation,
                        rotationSpeed * Time.deltaTime
                    );

                person.transform.position = Vector3.MoveTowards(
                    person.transform.position,
                    suitcasPositionD.position,
                    moveSpeed * Time.deltaTime
                );
                if (isMovingToC && Vector3.Distance(person.transform.position, suitcasPositionD.position) < 0.1f)
                {
                    animator.SetBool("walk", false);
                    animator.SetBool("search", true);
                    if (isMale_person)
                        AudioManager.Instance.PlaySFX(AudioManager.Instance.cach_ManClip);
                    else
                        AudioManager.Instance.PlaySFX(AudioManager.Instance.cach_WomanClip);
                }
            }
        }

        public void SpawnPerson()
        {
            if (person == null)
            {
                person = Instantiate(personPrefab[(int)Random.Range(0f, personPrefab.Length)], suitcasPositionA.position, Quaternion.identity);
                person.transform.parent = transform;
                animator = person.GetComponent<Animator>();
                spawnDetectorObjects = person.GetComponent<SpawnDetectorObjects>();
                isMale_person = spawnDetectorObjects.isMale;
                isMoving = true;
                isMovingToC = false;
                isButtonBlue = false;
            }
            else
            {
                Debug.Log("Ya hay un personaje en escena.");
            }
        }
        public void TeleportPlayerToSearch()
        {
            player.transform.position = searchPos.transform.position;
            player.transform.rotation = Quaternion.Euler(0,-90,0);
            alarm.StopAlarm();
            alarm.pauseAlarm = true;
        }
        public void TeleportPlayerToStartPos()
        {
            player.transform.position = startPos;
            player.transform.rotation = Quaternion.Euler(0, -90, 0);
            alarm.pauseAlarm = false;
        }

        public void LegalSearch()
        {

        }

        public void IlegalSearch()
        {

        }
    }
}
