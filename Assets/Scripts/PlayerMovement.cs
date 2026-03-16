using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveForce;
    private Rigidbody2D hips;
    private Vector2 move;
    private void Start()
    {
        hips = transform.Find("Hips").GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        move = InputManager.instance.move;
        hips.AddForce(move * moveForce * Time.deltaTime);
    }
}
