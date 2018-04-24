using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitateStone : MonoBehaviour
{

    public float Strength;
    public float Distance;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 downwardForce;
        float distancePercentage;

        if (Physics.Raycast(transform.position, transform.up * -1, out hit, Distance))
        {
            distancePercentage = 1 - (hit.distance / Distance);

            downwardForce = transform.up * Strength * distancePercentage;

            downwardForce = downwardForce * Time.deltaTime * rb.mass;

            rb.AddForceAtPosition(downwardForce, transform.position);
        }

    }
}

