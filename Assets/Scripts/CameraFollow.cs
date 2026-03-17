using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float followSpeed;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform player;

    private void LateUpdate()
    {
        Vector3 desiredPos = player.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, followSpeed + Time.deltaTime);
        transform.position = smoothPos; 
    }
}
