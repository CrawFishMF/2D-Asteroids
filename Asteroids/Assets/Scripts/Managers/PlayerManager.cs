using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance = null;

    public GameObject Player;
    public MoveData MoveData;
    public Rigidbody2D RigidBody;
    public ShootingSystem ShootingSystem;
    public RotationSystem RotationSystem;
    public MovementSystem MovementSystem;
    public UnityEvent<int> ScoreIncrease;
    private int _playerScore = 0;
    private void Awake()
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
        Player = GameObject.FindWithTag("Player");
        MoveData = Player.GetComponent<MoveData>();
        RigidBody = Player.GetComponent<Rigidbody2D>();
        ShootingSystem = Player.GetComponent<ShootingSystem>();
        RotationSystem = Player.GetComponent<RotationSystem>();
        MovementSystem = Player.GetComponent<MovementSystem>();
        ScoreIncrease.AddListener(ScoreUpdate);
    }
    private void ScoreUpdate(int addScore)
    {
        _playerScore += addScore;
    }

    private void FixedUpdate()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        string currentSpeed = MoveData.CurrentSpeed.ToString("##.00");
        string currentCoordinates = ((Vector2)Player.transform.position).ToString("0.0");
        string currentRotationAngle =
            (RigidBody.angularVelocity * -1 / (57 * MoveData.RotationSpeed / RigidBody.angularDrag) * 10)
            .ToString("00");
        string currentScore = _playerScore.ToString();
        UIManager.Instance.UpdateUIInformation(currentSpeed, currentCoordinates, currentRotationAngle, currentScore);
    }
}
