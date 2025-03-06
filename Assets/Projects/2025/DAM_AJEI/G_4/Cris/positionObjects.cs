using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EntilandVR.DosCinco.DAM_AJEI.G_Cuatro
{
    public class positionObjects : MonoBehaviour
    {
        [SerializeField]
        List<GameObject> objectPositions;
        [SerializeField]
        List<GameObject> objectsToSpawn;

        public bool canSpawn = false;

        public List<GameObject> spawnedObjects;

        public bool isSuitcaseLegal = true;
        int ilegalProps = 0;

        void Start()
        {
            ilegalProps = 0;

        }

        public float illegalObjectPercentage = 0f;
        void SpawnObjectsAtRandomIndex()
        {
            List<GameObject> selectedObjects = new List<GameObject>();
            List<GameObject> legalObjects = new List<GameObject>();
            List<GameObject> illegalObjects = new List<GameObject>();

            foreach (var obj in objectsToSpawn)
            {
                ObjectBase objectBaseScript = obj.GetComponent<ObjectBase>();
                if (objectBaseScript != null)
                {
                    if (objectBaseScript.isLegal)
                        legalObjects.Add(obj);
                    else
                        illegalObjects.Add(obj);
                }
            }

            if (legalObjects.Count == 0 && illegalObjectPercentage < 100)
            {
                Debug.LogWarning("No hay objetos legales disponibles, pero se requiere al menos uno.");
                return;
            }
            if (illegalObjects.Count == 0 && illegalObjectPercentage > 0)
            {
                Debug.LogWarning("No hay objetos ilegales disponibles, pero se requiere al menos uno.");
                return;
            }

            bool forcedIllegalSpawn = false;

            for (int i = 0; i < objectPositions.Count; i++)
            {
                GameObject objectToInstantiate;

                if (illegalObjectPercentage == 100 && !forcedIllegalSpawn)
                {
                    objectToInstantiate = illegalObjects[Random.Range(0, illegalObjects.Count)];
                    forcedIllegalSpawn = true;
                }
                else if (illegalObjectPercentage == 0)
                {
                    objectToInstantiate = legalObjects[Random.Range(0, legalObjects.Count)];
                }
                else
                {
                    int randomPercentage = Random.Range(0, 100);
                    if (randomPercentage < illegalObjectPercentage && illegalObjects.Count > 0)
                    {
                        objectToInstantiate = illegalObjects[Random.Range(0, illegalObjects.Count)];
                    }
                    else
                    {
                        objectToInstantiate = legalObjects[Random.Range(0, legalObjects.Count)];
                    }
                }

                selectedObjects.Add(objectToInstantiate);
            }

            for (int i = 0; i < selectedObjects.Count; i++)
            {
                GameObject spawnedObject = Instantiate(selectedObjects[i], objectPositions[i].transform.position, Quaternion.identity);
                spawnedObject.transform.parent = objectPositions[i].transform;
                spawnedObjects.Add(spawnedObject);
            }
        }



        public void CheckIfLegalSuitcase()
        {
            SpawnObjectsAtRandomIndex();
            ilegalProps = 0;
            for (int i = 0; i < spawnedObjects.Count; i++)
            {
                ObjectBase obj = spawnedObjects[i].GetComponent<ObjectBase>();
                if (!obj.isLegal)
                {
                    Debug.Log("Objeto ilegal");
                    ilegalProps++;
                }
                else
                {
                    Debug.Log("Objeto Legal");
                }

            }
            Debug.Log(ilegalProps);
            if (ilegalProps > 0)
            {
                isSuitcaseLegal = false;
            }
            else
            {
                isSuitcaseLegal = true;
            }
        }
    }
}

