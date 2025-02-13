using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dukeCaboom : MonoBehaviour
{
    public float myTimeScale = 1.0f;
    public GameObject target;
    public float force = 10f;
    Rigidbody rb;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        Time.timeScale = myTimeScale; // allow for slowing time to see what's happening
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Caboom");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            calculateFiringSolution fs = new calculateFiringSolution();
            Nullable<Vector3> aimVector = fs.Calculate(transform.position, target.transform.position, force, Physics.gravity);
            if (aimVector.HasValue)
            {
                rb.AddForce(aimVector.Value.normalized * force, ForceMode.VelocityChange);
            }
        }

        //reset position
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reset");
            rb.isKinematic = true;
            transform.position = startPosition;
            rb.isKinematic = false;
        }
    }
}