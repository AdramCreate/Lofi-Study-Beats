using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnScript : MonoBehaviour {
    
    public float respawnTime = 2.0f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private float originalRespawnTime;
    private bool leftPlayArea = false;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        originalRespawnTime = respawnTime;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (leftPlayArea)
        {
            respawnTime -= Time.deltaTime;
            if(respawnTime <= 0)
            {
                resetObject();
            }
        }
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("playArea"))
        {
            leftPlayArea = true;
        }
    }

    private void resetObject()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        leftPlayArea = false;
        respawnTime = originalRespawnTime;
    }
}
