using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveForce;
    [SerializeField] private float jumpForce;
    [SerializeField] private float feetRadius;

    [SerializeField] private GameObject leftFeet, rightFeet;
    [SerializeField] private Vector3 feetOffset;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D hips;
    private Vector2 move;

    private bool _isLeftonGround;
    private bool _isRightonGround;
    private bool _isUponGround;
    private void Start()
    {
        hips = transform.Find("Hips").GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _isLeftonGround = Physics2D.OverlapCircle(leftFeet.transform.position + feetOffset, feetRadius, groundLayer);
        _isRightonGround = Physics2D.OverlapCircle(rightFeet.transform.position + feetOffset, feetRadius, groundLayer);
        _isUponGround = _isLeftonGround || _isRightonGround;

        move = InputManager.instance.move;
        hips.AddForce(move * moveForce * Time.deltaTime);

        var jumpButton = InputManager.instance.jump;
        if (jumpButton && _isUponGround)
        {
            hips.AddRelativeForceY(jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
    private void OnDrawGizmos()
    {
        if(groundLayer > 0)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(leftFeet.transform.position + feetOffset, feetRadius);
            Gizmos.DrawWireSphere(rightFeet.transform.position + feetOffset, feetRadius);
        }
    }
}
