using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
    private Vector3 initialPosition;
    private Rigidbody rb;
    public float respawnDelay = 10f; 

    private Coroutine respawnCoroutine;
    private bool isGrabbed = false;

    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    public void OnGrab()
    {
        isGrabbed = true;
        if (respawnCoroutine != null)
        {
            StopCoroutine(respawnCoroutine);
            respawnCoroutine = null;
        }
    }

    public void OnRelease()
    {
        isGrabbed = false;
        if (respawnCoroutine == null)
        {
            respawnCoroutine = StartCoroutine(RespawnAfterDelay());
        }
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);
        if (!isGrabbed)
        {
            Respawn();
        }
        respawnCoroutine = null;
    }

    private void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = initialPosition;
    }
}