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
            if (!cinta.isMoving) 
            { 
                cinta.isButtonPressed = true;
                cinta.isButtonGreen = true;
            }
           
        }
        public void redButtonPressed()
        {
            if (!cinta.isMoving)
            {
                cinta.isButtonPressed = true;
                cinta.isButtonGreen = false;
            }
        }

        public void blueButtonPressed()
        {
            //Inspect the suitcase
            Debug.Log("BlueButton");
        }
    }
}
