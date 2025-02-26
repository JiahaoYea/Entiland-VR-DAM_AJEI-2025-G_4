using System.Diagnostics;
using UnityEngine;

public class Button : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Pressed()
    {
        UnityEngine.Debug.Log("pressed");
    }
    public void Released()
    {
        UnityEngine.Debug.Log("released");
    }
}
