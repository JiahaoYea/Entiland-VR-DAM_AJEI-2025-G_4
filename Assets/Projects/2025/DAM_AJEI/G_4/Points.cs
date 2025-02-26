using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public static Points Instance;

    public int currentPoints;
    public int hp;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        hp = 3;
    }

    void Update()
    {
        if (hp <= 0)
        {
            Application.Quit();
            //Que te lleve a una UI de restart game
        }

    }
}
