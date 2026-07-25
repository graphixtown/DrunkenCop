using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    [SerializeField] private float moveForce;
    [SerializeField] private float jumpForce;
    [SerializeField] private float feetRadius;
    [SerializeField] private Balance balance;
    [SerializeField] private GameObject leftFeet, rightFeet;
    [SerializeField] private Vector3 feetOffset;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip footStep, jumpSound, grabbingSound;

    private Rigidbody2D hips;
    private Vector2 move;

    private bool _isLeftonGround, _leftwasonGround;
    private bool _isRightonGround, _rightwasonGround;
    private bool _isUponGround;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        hips = transform.Find("Hips").GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _isLeftonGround = Physics2D.OverlapCircle(leftFeet.transform.position + feetOffset, feetRadius, groundLayer);
        _isRightonGround = Physics2D.OverlapCircle(rightFeet.transform.position + feetOffset, feetRadius, groundLayer);
        _isUponGround = _isLeftonGround || _isRightonGround;

        if(!_leftwasonGround && _isLeftonGround)
        {
            audioSource.PlayOneShot(footStep);
        }
        _leftwasonGround = _isLeftonGround;
        if (!_rightwasonGround && _isRightonGround)
        {
            audioSource.PlayOneShot(footStep);
        }
        _rightwasonGround = _isRightonGround;
        move = InputManager.instance.move;
        hips.AddForce(move * moveForce * Time.deltaTime);

        var jumpButton = InputManager.instance.jump;
        if (jumpButton && _isUponGround && !balance.cannotJump)
        {
            audioSource.PlayOneShot(jumpSound);
            hips.AddRelativeForceY(jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }if(hips.linearVelocity.y > 12)
        {
            hips.linearVelocityY = 0;
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
    public void playGrabbing()
    {
        audioSource.PlayOneShot(grabbingSound);
    }
}
