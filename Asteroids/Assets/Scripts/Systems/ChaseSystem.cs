using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(MoveData))]
public class ChaseSystem : MonoBehaviour
{
    private MoveData _moveData;

    private void OnEnable()
    {
        _moveData = GetComponent<MoveData>();
    }
    private void FixedUpdate()
    {
        _moveData.MoveDirection = PlayerManager.Instance.Player.transform.position - transform.position;
        var endPoint = quaternion.LookRotationSafe(math.forward(), _moveData.MoveDirection);
        transform.rotation = math.slerp(transform.rotation, endPoint, _moveData.RotationSpeed * Time.deltaTime);
    }
}