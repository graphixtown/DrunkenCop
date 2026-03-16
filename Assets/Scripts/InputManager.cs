using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance {  get; private set; }

    [SerializeField] private InputActionAsset inputAsset;
    [SerializeField] private string _actionMap;
    [SerializeField] private string _move;
    [SerializeField] private string _jump;

    private UnityEngine.InputSystem.InputAction moveAction;
    private UnityEngine.InputSystem.InputAction jumpAction;

    public Vector2 move {  get; private set; }
    public bool jump { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        var map = inputAsset.FindActionMap(_actionMap);

        moveAction = map.FindAction(_move);
        jumpAction = map.FindAction(_jump);

        moveAction.performed += ctx => move = ctx.ReadValue<Vector2>();
        moveAction.canceled += ctx => move = Vector2.zero;

        jumpAction.performed += ctx => jump = true;
        jumpAction.canceled += ctx => jump = false;
    }
    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
    }
}
