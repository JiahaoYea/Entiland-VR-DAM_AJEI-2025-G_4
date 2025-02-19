using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EntilandVR.DosCinco.DAM_AJEI.G_Cuatro
{
    public class positionObjects : MonoBehaviour
    {
        [SerializeField]
        List<Vector3> objectPositions;
        [SerializeField]
        List<GameObject> objectsToSpawn;

        public bool canSpawn = false;

        private List<GameObject> spawnedObjects;

        public bool isSuitcaseLegal = true;
        int ilegalProps = 0;

        void Start()
        {
            SpawnObjectsAtRandomIndex();
        }

        void SpawnObjectsAtRandomIndex()
        {
            int randomIndex = Random.Range(0, objectsToSpawn.Count);

            for (int i = 0; i < objectPositions.Count; i++)
            {
                GameObject objectToInstantiate = objectsToSpawn[randomIndex];
                GameObject spawnedObject = Instantiate(objectToInstantiate, objectPositions[i], Quaternion.identity);
                spawnedObjects.Add(spawnedObject);
            }
        }
        public void CheckIfLegalSuitcase()
        {
            for (int i = 0; i < objectPositions.Count; i++)
            {
                ObjectBase obj = objectsToSpawn[i].GetComponent<ObjectBase>();
                if (!obj.isLegal)
                {
                    Debug.Log("Maleta Ilegal");
                    ilegalProps++;
                }
                else
                {
                    Debug.Log("Maleta Legal");
                }

            }
            if(ilegalProps == 1)
            {
                isSuitcaseLegal = false;
            }else if(ilegalProps >= 2)
            {
                isSuitcaseLegal = false;
                //no puede cachear.
            }
        }
        void Update()
        {
            if (canSpawn)
                SpawnObjectsAtRandomIndex();
        }
    }
}

