using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace EntilandVR.DosCinco.DAM_AJEI.G_Cuatro
{
    public class Points : MonoBehaviour
    {
        public static Points Instance;

        public int currentPoints;
        public int hp;
        public TextMeshProUGUI hp_text;
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
            hp_text.SetText("Efficiency points: " + hp);
            if (hp <= 0)
            {
                Application.Quit();
            }
            else if(hp >= 10)
            {
                Application.Quit();
            }

        }
    }
}