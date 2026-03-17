using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance {  get; private set; }

    [SerializeField] private InputActionAsset inputAsset;
    [SerializeField] private string _actionMap;
    [SerializeField] private string _move;
    [SerializeField] private string _jump;
    [SerializeField] private string _leftMouse;
    [SerializeField] private string _rightMouse;

    private UnityEngine.InputSystem.InputAction moveAction;
    private UnityEngine.InputSystem.InputAction jumpAction;
    private UnityEngine.InputSystem.InputAction leftMouseAction;
    private UnityEngine.InputSystem.InputAction rightMouseAction;

    public Vector2 move {  get; private set; }
    public bool jump { get; private set; }
    public bool leftMouse { get; private set; }
    public bool rightMouse { get; private set; }

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
        leftMouseAction = map.FindAction(_leftMouse);
        rightMouseAction = map.FindAction(_rightMouse);

        moveAction.performed += ctx => move = ctx.ReadValue<Vector2>();
        moveAction.canceled += ctx => move = Vector2.zero;

        jumpAction.performed += ctx => jump = true;
        jumpAction.canceled += ctx => jump = false;

        leftMouseAction.performed += ctx => leftMouse = true;
        leftMouseAction.canceled += ctx => leftMouse = false;

        rightMouseAction.performed += ctx => rightMouse = true;
        rightMouseAction.canceled += ctx => rightMouse = false;
    }
    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        leftMouseAction?.Enable();
        rightMouseAction?.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        leftMouseAction?.Disable();
        rightMouseAction?.Disable();
    }
}
