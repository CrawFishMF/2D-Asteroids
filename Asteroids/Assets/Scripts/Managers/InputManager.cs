using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance = null;

    public PlayerControls PlayerControls;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);

        InitializeManager();
    }
    private void InitializeManager()
    {
        PlayerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        PlayerControls.Player.Enable();
        PlayerControls.UI.Disable();

        PlayerControls.Player.Pause.started += PauseGame;
        PlayerControls.UI.Escape.started += UnPauseGame;
        PlayerControls.Player.AltShoot.started += AltShootStarted;
        PlayerControls.Player.Shoot.started += ShootStarted;
        PlayerControls.Player.Shoot.canceled += ShootCanceled;
        PlayerControls.Player.Acceleration.started += StartAccelerate;
        PlayerControls.Player.Acceleration.canceled += StopAccelerate;
        PlayerControls.Player.Rotate.started += StartRotate;
        PlayerControls.Player.Rotate.canceled += StopRotate;
    }
    private void OnDisable()
    {
        PlayerControls.Player.Disable();
        PlayerControls.UI.Disable();

        PlayerControls.Player.Pause.started -= PauseGame;
        PlayerControls.UI.Escape.started -= UnPauseGame;
        PlayerControls.Player.AltShoot.started -= AltShootStarted;
        PlayerControls.Player.Shoot.started -= ShootStarted;
        PlayerControls.Player.Shoot.canceled -= ShootCanceled;
        PlayerControls.Player.Acceleration.started -= StartAccelerate;
        PlayerControls.Player.Acceleration.canceled -= StopAccelerate;
        PlayerControls.Player.Rotate.started -= StartRotate;
        PlayerControls.Player.Rotate.canceled -= StopRotate;

    }

    private void PauseGame(InputAction.CallbackContext context)
    {
        UIManager.Instance.UICallback.PauseGame();
    }
    private void UnPauseGame(InputAction.CallbackContext context)
    {
        UIManager.Instance.UICallback.UnPauseGame();
    }
    private void StartAccelerate(InputAction.CallbackContext context)
    {
        PlayerManager.Instance.MovementSystem.StartAccelerate();
    }
    private void StopAccelerate(InputAction.CallbackContext context)
    {
        PlayerManager.Instance.MovementSystem.StopAccelerate();
    }
    private void StartRotate(InputAction.CallbackContext context)
    {
        PlayerManager.Instance.RotationSystem.StartRotate(context);
    }
    private void StopRotate(InputAction.CallbackContext context)
    {
        PlayerManager.Instance.RotationSystem.StopRotate();
    }
    private void ShootStarted(InputAction.CallbackContext context)
    {
        PlayerManager.Instance.ShootingSystem.StartShoot();
    }
    private void AltShootStarted(InputAction.CallbackContext context)
    { 
        PlayerManager.Instance.ShootingSystem.RayShoot();
    }
    private void ShootCanceled(InputAction.CallbackContext context)
    {
        PlayerManager.Instance.ShootingSystem.StopShoot();
    }
}