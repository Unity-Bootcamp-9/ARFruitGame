using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class PlayerInputManager : MonoBehaviour
{
    //public delegate void StartTouch(Vector2 position);
    //public event StartTouch OnStartTouch;
    //public delegate void EndTouch(Vector2 position);
    //public event EndTouch OnEndTouch;
    //public static PlayerInputManager Instance { get; private set; }

    ////private PlayerInputAction playerInput;
    //private Camera mainCamera;

    //private void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //    }

    //    //playerInput = new PlayerInputAction();
    //    mainCamera = Camera.main;
    //}

    //private void OnEnable()
    //{
    //    playerInput.Enable();
    //}

    //private void OnDisable()
    //{
    //    playerInput.Disable();
    //}

    //private void Start()
    //{
    //    playerInput.Player.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
    //    playerInput.Player.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    //}

    //private void StartTouchPrimary(InputAction.CallbackContext context)
    //{
    //    if (OnStartTouch != null)
    //    {
    //        OnStartTouch(playerInput.Player.PrimaryPosition.ReadValue<Vector2>());
    //    }
    //}

    //private void EndTouchPrimary(InputAction.CallbackContext context)
    //{
    //    if (OnEndTouch != null)
    //    {
    //        OnEndTouch(playerInput.Player.PrimaryPosition.ReadValue<Vector2>());
    //    }
    //}

    //public Vector2 PrimaryPosition()
    //{
    //    return playerInput.Player.PrimaryPosition.ReadValue<Vector2>();
    //}
}
