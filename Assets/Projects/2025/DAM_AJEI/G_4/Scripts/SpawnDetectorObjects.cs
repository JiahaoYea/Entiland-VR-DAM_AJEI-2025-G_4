using EntilandVR.DosCinco.DAM_AJEI.G_Cuatro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDetectorObjects : MonoBehaviour
{
    public GameObject[] positions;

    public GameObject ilegalObject;

    private GameObject detectableObject;

    public Cinta cinta;

    public bool isMale;
    void Start()
    {
        cinta = FindAnyObjectByType<Cinta>();
        if (cinta != null & !cinta.isSuitCaseLegal())
            SpawnObjects();
    }
    void Update()
    {
        
    }

    void SpawnObjects()
    {
        for (int i = 0; i < positions.Length; i++)
        {
            int num = Random.Range(0, 2);
            if(num == 0)
            {
                detectableObject = Instantiate(ilegalObject, positions[i].transform.position, Quaternion.identity);
                detectableObject.transform.parent = transform;
            }
        }
    }
}
