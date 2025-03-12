using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EntilandVR.DosCinco.DAM_AJEI_G_Cuatro
{
    public class ButtonManager : MonoBehaviour
    {
        public Cinta cinta;
        public PersonManager personManager;
        public DetectObjects detectObjects;
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
            if (!personManager.isMoving)
            {
                personManager.isButtonBlue = true;
                personManager.TeleportPlayerToSearch();
                detectObjects.ResetPosition();
            }
        }

        public void GreenSearchButton()
        {
            personManager.TeleportPlayerToStartPos();
            cinta.SpawnSuitcase();
            cinta.DestroyPerson();
            detectObjects.HideButtons();
        }
        public void RedSearchButton()
        {
            personManager.TeleportPlayerToStartPos();
            cinta.SpawnSuitcase();
            cinta.DestroyPerson();
            detectObjects.HideButtons();
        }
    }
}
