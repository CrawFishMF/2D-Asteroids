using UnityEngine;
using UnityEngine.InputSystem;

public class RotationSystem : MonoBehaviour
{

    private MoveData _moveData;
    private Rigidbody2D _rigidBody;

    private void Start()
    {
        _moveData = GetComponent<MoveData>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidBody.AddTorque(_moveData.RotationDirection * _moveData.RotationSpeed);
    }
    public void StartRotate(InputAction.CallbackContext context)
    {
        var rotation = context.ReadValue<Vector2>();
        _moveData.RotationDirection = rotation.x * -1 + rotation.y;
    }
    public void StopRotate()
    {
        _moveData.RotationDirection = 0;
    }
}
