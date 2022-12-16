using UnityEngine.UIElements;

public sealed class TitleScreen : VisualElement
{
    private Button _playGameButton;
    private Button _exitButton;

    public new class UxmlFactory : UxmlFactory<TitleScreen, UxmlTraits> { }

    public TitleScreen()
    {
        this.RegisterCallback<GeometryChangedEvent>(OnGeometryChange);
    }

    private void OnGeometryChange(GeometryChangedEvent evt)
    {
        _playGameButton = this.Q<Button>("play-button");
        _exitButton = this.Q<Button>("exit-button");

        _playGameButton?.RegisterCallback<ClickEvent>(ev => UIManager.Instance.UICallback.OpenScene(1));
        _exitButton?.RegisterCallback<ClickEvent>(ev => UIManager.Instance.UICallback.CloseGame());


        this.UnregisterCallback<GeometryChangedEvent>(OnGeometryChange);
    }


}
