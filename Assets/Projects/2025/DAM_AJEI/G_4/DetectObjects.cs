using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjects : MonoBehaviour
{
    public AudioSource beepAudio;

    public GameObject greenButton;
    public GameObject redButton;
    public GameObject blueButton;

    public Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Objective"))
            beepAudio.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        beepAudio.Stop();
    }

    public void SpawnButtons()
    {
        greenButton.SetActive(true);
        redButton.SetActive(true);
    }

    public void HideButtons()
    {
        greenButton.SetActive(false);
        redButton.SetActive(false);
        blueButton.SetActive(false);
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
    }
}

