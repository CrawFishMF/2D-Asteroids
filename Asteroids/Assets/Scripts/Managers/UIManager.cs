using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIVisualElements
{
    public VisualElement RootUIVE;
    public VisualElement PauseScreen;
    public VisualElement WastedScreen;
    public Label CurrentScore;
    public Label FinalScore;
    public Label Coordinates;
    public Label Speed;
    public Label RotationAngle;
    public List<VisualElement> RayChargeBars;
}
[RequireComponent(typeof(LevelLoader))]
public class UIManager : MonoBehaviour
{

    public static UIManager Instance = null;
    public UICallback UICallback { get; private set; }
    public UIVisualElements UIVE { get; private set; }

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
        var levelLoader = gameObject.GetComponent<LevelLoader>();
        UICallback = new UICallback(levelLoader);
        SetUIVE();
    }

    private void SetUIVE()
    {
        UIVE = new UIVisualElements();

        UIVE.RootUIVE = GameObject.FindWithTag("RootUIObject").GetComponent<UIDocument>().rootVisualElement;

        UIVE.PauseScreen = UIVE.RootUIVE?.Q<VisualElement>("pause-screen");
        UIVE.WastedScreen = UIVE.RootUIVE?.Q<VisualElement>("wasted-screen");
        UIVE.CurrentScore = UIVE.RootUIVE?.Q<Label>("score-label");
        UIVE.FinalScore = UIVE.RootUIVE?.Q<Label>("final-score-label");
        UIVE.RayChargeBars = UIVE.RootUIVE?.Query<VisualElement>("ray-icon").Build().ToList();
        UIVE.Speed = UIVE.RootUIVE?.Q<Label>("speed-label");
        UIVE.Coordinates = UIVE.RootUIVE?.Q<Label>("coordinates-label");
        UIVE.RotationAngle = UIVE.RootUIVE?.Q<Label>("angle-label");
    }
    public void RayChargesUpdate(List<float> percentLoads)
    {
        for (int i = 0; i < percentLoads.Capacity; i++)
        {
            var newScale = new Vector3(1, percentLoads[i], 1);
            UIVE.RayChargeBars[i].transform.scale = newScale;
        }
    }

    public void UpdateUIInformation(string currentSpeed, string currentCoordinates, string currentRotationAngle, string currentScore)
    {
        SpeedLabelUpdate(currentSpeed);
        CoordinatesLabelUpdate(currentCoordinates);
        RotationAngleLabelUpdate(currentRotationAngle);
        ScoresLabelUpdate(currentScore);
    }

    private void SpeedLabelUpdate(string currentSpeed)
    {
        UIVE.Speed.text = currentSpeed;
    }

    private void CoordinatesLabelUpdate(string currentCoordinates)
    {
        UIVE.Coordinates.text = currentCoordinates;
    }

    private void RotationAngleLabelUpdate(string currentRotationAngle)
    {
        UIVE.RotationAngle.text = currentRotationAngle;
    }
    private void ScoresLabelUpdate(string currentScore)
    {
        UIVE.CurrentScore.text = currentScore;
        UIVE.FinalScore.text = currentScore;
    }
}
