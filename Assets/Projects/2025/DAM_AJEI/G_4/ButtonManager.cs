using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EntilandVR.DosCinco.DAM_AJEI_G_Cuatro
{
    public class ButtonManager : MonoBehaviour
    {
        public Cinta cinta;
        public void greenButtonPressed()
        {
            cinta.isButtonPressed = true;
            cinta.isButtonGreen = true;
        }

        public void greenButtonReleased()
        {
            //Continues luggage carrusell
            Debug.Log("GreenButtonRel");
        }

        public void redButtonPressed()
        {
            cinta.isButtonPressed = true;
            cinta.isButtonGreen = false;
        }

        public void redButtonReleased()
        {
            //Continues luggage carrusell
            Debug.Log("RedButtonRel");
        }

        public void blueButtonPressed()
        {
            //Inspect the suitcase
            Debug.Log("BlueButton");
        }

        public void blueButtonReleased()
        {
            //Continues luggage carrusell
            Debug.Log("BlueButtonRel");
        }
    }
}
