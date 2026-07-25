using UnityEngine;

public class KnobCursor : MonoBehaviour
{
    [SerializeField] private float knobfollowSpeed;

    private Vector3 velocity;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.x = Mathf.Clamp(mousePos.x, 0, Screen.width);
        mousePos.y = Mathf.Clamp(mousePos.y, 0, Screen.height);

        transform.position = Vector3.SmoothDamp(transform.position, mousePos, ref velocity, knobfollowSpeed);
    }
}
