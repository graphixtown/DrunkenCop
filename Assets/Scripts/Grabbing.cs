using UnityEngine;
using UnityEngine.InputSystem;

public class Grabbing : MonoBehaviour
{
    [SerializeField] private InputActionReference inputAction;
    private bool isHolding;
    private void Update()
    {
        if(inputAction.action.ReadValue<float>() > 0f)
        {
            isHolding = true;
        }
        else
        {
            isHolding = false;
            Destroy(gameObject.GetComponent<FixedJoint2D>());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if(isHolding)
        {
            if(rb != null)
            {
                PlayerMovement.Instance.playGrabbing();
                FixedJoint2D FJ = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                FJ.connectedBody = rb;
            }
            else
            {
                FixedJoint2D FJ = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
            }
        }
    }
}
