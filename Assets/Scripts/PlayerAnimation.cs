using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private string MOVE_FORWARD = "moveForward", MOVE_BACKWARD = "moveBackward";
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void LateUpdate()
    {
        if(InputManager.instance.move.x > 0) animator.SetBool(MOVE_FORWARD, true);
        else if (InputManager.instance.move.x < 0) animator.SetBool(MOVE_BACKWARD, true);
        else{
            animator.SetBool (MOVE_FORWARD, false);
            animator.SetBool (MOVE_BACKWARD, false);
        }
    }
}
