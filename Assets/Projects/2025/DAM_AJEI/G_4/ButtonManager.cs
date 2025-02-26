using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void greenButtonPressed()
    {
        //Pass the suitcase as legal
        Debug.Log("GreenButton");
    }

    public void greenButtonReleased()
    {
        //Continues luggage carrusell
        Debug.Log("GreenButtonRel");
    }

    public void redButtonPressed()
    {
        //Pass the suitcase as ilegal
        Debug.Log("RedButton");
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
