using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float targetAngle, rotateForce;
    private void FixedUpdate()
    {
        rb.MoveRotation(Mathf.Lerp(rb.rotation, targetAngle, rotateForce * Time.deltaTime));
    }
}
