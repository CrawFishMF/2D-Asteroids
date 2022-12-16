using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(MoveData))]
public class MovementSystem : MonoBehaviour
{
    private MoveData _moveData;
    private bool _accelerationStarted;
    private float _elapsedTime = 0;

    private void OnEnable()
    {
        if (!_moveData)
        {
            Start();
        }
    }

    public void Start()
    {
        _moveData = GetComponent<MoveData>();
    }

    public void FixedUpdate()
    {
        _moveData.Acceleration = GetAcceleration();
        _elapsedTime += Time.deltaTime;
        _moveData.CurrentSpeed = _moveData.Acceleration * _moveData.MoveSpeed;
        transform.position += transform.up * _moveData.CurrentSpeed * Time.deltaTime;
    }
    /// <summary>
    /// Getting acceleration calculated by curve
    /// </summary>
    /// <param name="accelerationStarted">increase or decrease acceleration</param>
    /// <param name="elapsedTime">elapsed time from start of process</param>
    /// <param name="moveData">getting Acceleration, Max/Min-Acceleration, AccelerationCurve, AccelerationTime</param>
    /// <returns>interpolated float</returns>
    private float GetAcceleration(bool accelerationStarted, float elapsedTime, MoveData moveData)
    {
        float accelerationEndpoint = accelerationStarted ? moveData.MaxAcceleration : moveData.MinAcceleration;

        return moveData.Acceleration = math.lerp(
            moveData.Acceleration,
            accelerationEndpoint,
            moveData.AccelerationCurve.Evaluate(elapsedTime / moveData.AccelerationTime));

    }
    /// <summary>
    /// Getting acceleration calculated by curve
    /// </summary>
    /// <remarks>using local data from this.gameObject</remarks>
    /// <returns>interpolated float</returns>
    private float GetAcceleration()
    {
        return GetAcceleration(
            _accelerationStarted,
            _elapsedTime,
            _moveData);
    }

    public void StartAccelerate()
    {
        _accelerationStarted = true;
        _elapsedTime = 0;
    }

    public void StopAccelerate()
    {
        _accelerationStarted = false;
        _elapsedTime = 0;
    }
}