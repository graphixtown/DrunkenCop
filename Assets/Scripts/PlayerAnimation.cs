using Unity.Mathematics;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Transform footPos;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float aroundRadius;
    [SerializeField] private LayerMask groundMask;
    private Animator animator;

    private string MOVE_FORWARD = "moveForward",
                   MOVE_BACKWARD = "moveBackward",
                   JUMPING = "jumping";

    private bool isCrouching;
    private bool awayFromGround;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        awayFromGround = Physics2D.OverlapCircle(footPos.position + offset, aroundRadius, groundMask);
    }
    private void LateUpdate()
    {

        if (!InputManager.instance.dead)
        {
            if (InputManager.instance.move.x > 0)
            {
                animator.SetBool(MOVE_FORWARD, true);
                animator.SetBool(MOVE_BACKWARD, false);
            }
            else if (InputManager.instance.move.x < 0)
            {
                animator.SetBool(MOVE_BACKWARD, true);
                animator.SetBool(MOVE_FORWARD, false);
            }
            else
            {
                animator.SetBool(MOVE_FORWARD, false);
                animator.SetBool(MOVE_BACKWARD, false);
            }

            if (!awayFromGround)
            {
                animator.SetBool(JUMPING, true);
                animator.SetBool(MOVE_FORWARD, false);
                animator.SetBool(MOVE_BACKWARD, false);
            }
            else if (awayFromGround)
            {
                animator.SetBool(JUMPING, false);
            }
        }
    }
    private void OnDrawGizmos()
    {
        if(groundMask > 0)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(footPos.position + offset, aroundRadius);
        }
    }
}
