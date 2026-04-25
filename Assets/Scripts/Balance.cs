using System;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float targetAngle, rotateForce;
    private void FixedUpdate()
    {
        if (InputManager.instance.dead)
        {
            if (gameObject.CompareTag("Player"))
            {
                rb.MoveRotation(Mathf.Lerp(rb.rotation, targetAngle, 0 * Time.deltaTime));
            }
        }
        else
        {
            rb.MoveRotation(Mathf.Lerp(rb.rotation, targetAngle, rotateForce * Time.deltaTime));
        }
    }
}


