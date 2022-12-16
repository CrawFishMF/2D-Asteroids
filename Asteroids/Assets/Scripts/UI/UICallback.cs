using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UICallback
{
    private LevelLoader _levelLoader;
    public UICallback(LevelLoader levelLoader)
    {
        _levelLoader = levelLoader;
    }
    /// <summary>
    /// Reloading <b>current</b> scene
    /// </summary>
    public void ReloadScene()
    {
        OpenScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void OpenScene(int sceneIndex)
    {
        _levelLoader.LoadLevel(sceneIndex);
    }

    public void CloseGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void PauseGame(VisualElement pauseScreen)
    {
        if (Time.timeScale == 0) return;
        InputManager.Instance.PlayerControls.UI.Enable();
        InputManager.Instance.PlayerControls.Player.Disable();
        ToggleScreen(pauseScreen);
        Time.timeScale = 0;
    }
    public void PauseGame()
    {
        PauseGame(UIManager.Instance.UIVE.PauseScreen);
    }

    public void UnPauseGame(VisualElement pauseScreen)
    {
        if (Time.timeScale == 1) return;
        InputManager.Instance.PlayerControls.Player.Enable();
        InputManager.Instance.PlayerControls.UI.Disable();
        ToggleScreen(pauseScreen);
        Time.timeScale = 1;
    }
    public void UnPauseGame()
    {
        UnPauseGame(UIManager.Instance.UIVE.PauseScreen);
    }
    /// <summary>
    /// Stopping game and show specific death screen
    /// </summary>
    /// <param name="wastedScreen">death screen to show</param>
    public void PlayerWasted(VisualElement wastedScreen)
    {
        if (Time.timeScale == 0) return;
        InputManager.Instance.PlayerControls.UI.Enable();
        InputManager.Instance.PlayerControls.Player.Disable();
        ToggleScreen(wastedScreen);
        Time.timeScale = 0;
    }
    /// <summary>
    /// Stopping game and show standard death screen
    /// </summary>
    public void PlayerWasted()
    {
        PlayerWasted(UIManager.Instance.UIVE.WastedScreen);
    }
    /// <summary>
    /// toggling visibility of specific screen
    /// </summary>
    /// <remarks> especially toggling Opacity and Display parameters</remarks>
    /// <param name="screen">screen which will be shown</param>
    public void ToggleScreen(VisualElement screen)
    {
        screen.ToggleInClassList("opacity-0");
        screen.ToggleInClassList("display-0");
    }
}
