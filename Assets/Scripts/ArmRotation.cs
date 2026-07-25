using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ArmRotation : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private Rigidbody2D currentBody;
    [SerializeField] private Camera cam;
    [SerializeField] private InputActionReference inputAction; 

    private void Update()
    {
        Vector3 playerPos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0);
        Vector3 difference = transform.position - playerPos;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            currentBody.MoveRotation(Mathf.LerpAngle(currentBody.rotation, rotationZ - 90, speed * Time.deltaTime));
        }
        else
        {
            if (inputAction.action.ReadValue<float>() > 0)
            {
                currentBody.MoveRotation(Mathf.LerpAngle(currentBody.rotation, rotationZ - 90, speed * Time.deltaTime));
            }
        }
    }
}
