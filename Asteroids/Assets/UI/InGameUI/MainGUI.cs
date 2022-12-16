using System.Collections.Generic;
using UnityEngine.UIElements;

public class MainGUI : VisualElement
{
    private Button _resumeGameButton;
    private List<Button> _exitButtons;
    private Button _reloadGameButton;
    public new class UxmlFactory : UxmlFactory<MainGUI, UxmlTraits>
    {
    }

    public MainGUI()
    {
        this.RegisterCallback<GeometryChangedEvent>(OnGeometryChange);
    }

    private void OnGeometryChange(GeometryChangedEvent evt)
    {
        var pauseScreen = this.Q<VisualElement>("pause-screen");
        var wastedScreen = this.Q<VisualElement>("wasted-screen");
        _resumeGameButton = pauseScreen?.Q<Button>("resume-button");
        _reloadGameButton = wastedScreen?.Q<Button>("reload-game-button");
        _resumeGameButton?.RegisterCallback<ClickEvent>(ev => UIManager.Instance.UICallback.UnPauseGame());
        _reloadGameButton?.RegisterCallback<ClickEvent>(ev => UIManager.Instance.UICallback.ReloadScene());

        _exitButtons = this.Query<Button>("exit-button").Build().ToList();
        foreach (var button in _exitButtons)
        {
            button?.RegisterCallback<ClickEvent>(ev => UIManager.Instance.UICallback.CloseGame());
        }


        this.UnregisterCallback<GeometryChangedEvent>(OnGeometryChange);
    }
}