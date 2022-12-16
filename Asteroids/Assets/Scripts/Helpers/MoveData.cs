using Unity.Mathematics;
using UnityEngine;

public class MoveData : MonoBehaviour
{
    public float3 MoveDirection = float3.zero;
    public float MaxAcceleration = 2;
    public float MinAcceleration = 1;
    public float AccelerationTime = 2f;
    public float Acceleration = 1;
    public AnimationCurve AccelerationCurve;
    public float MoveSpeed = 0;
    public float CurrentSpeed = 0;
    public float RotationDirection = 0;
    public float RotationSpeed = 0;
    public void SetMoveData(MoveData newMoveData)
    {
        MoveDirection = newMoveData.MoveDirection;
        MaxAcceleration = newMoveData.MaxAcceleration;
        AccelerationTime = newMoveData.AccelerationTime;
        Acceleration = newMoveData.Acceleration;
        MoveSpeed = newMoveData.MoveSpeed;
        RotationDirection = newMoveData.RotationDirection;
        RotationSpeed = newMoveData.RotationSpeed;
    }

}