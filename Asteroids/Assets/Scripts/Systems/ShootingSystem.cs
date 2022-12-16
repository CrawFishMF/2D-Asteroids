using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField] private GameObject _rayGun;
    private GunState _rayGunState;
    private ObjectSpawnSystem _raySpawnSystem;
    private List<GameObject> _rayGunPointers;

    [SerializeField] private GameObject _bulletGun;
    private GunState _bulletGunState;
    private ObjectSpawnSystem _bulletSpawnSystem;
    private List<GameObject> _bulletGunPointers;

    private bool _shootingStarted;
    private void Start()
    {
        _rayGunState = _rayGun.GetComponent<GunState>();
        _raySpawnSystem = _rayGun.GetComponent<ObjectSpawnSystem>();
        _rayGunPointers = GameObject.FindGameObjectsWithTag("RayPointer").ToList();

        _bulletGunState = _bulletGun.GetComponent<GunState>();
        _bulletSpawnSystem = _bulletGun.GetComponent<ObjectSpawnSystem>();
        _bulletGunPointers = GameObject.FindGameObjectsWithTag("GunPointer").ToList();
    }

    private void Update()
    {
        if (_shootingStarted)
        {
            BulletShoot();
        }
    }
    private void LateUpdate()
    {
        UIManager.Instance.RayChargesUpdate(_rayGunState.GetChargesList());
    }

    private void Shoot(GunState gunState, List<GameObject> gunPointers, ObjectSpawnSystem spawnSystem)
    {
        if (!gunState.ReadyToShoot) return;
        foreach (var gun in gunPointers)
        {
            var bullet = spawnSystem.GetEntity();
            bullet.transform.position = gun.transform.position;
            bullet.transform.rotation = gun.transform.rotation;
        }
        gunState.UseCharge();
    }

    private void BulletShoot()
    {
        Shoot(_bulletGunState,_bulletGunPointers, _bulletSpawnSystem);
    }
    public void RayShoot()
    {
        Shoot(_rayGunState, _rayGunPointers, _raySpawnSystem);
    }

    public void StartShoot()
    {
        _shootingStarted = true;
    }
    public void StopShoot()
    {
        _shootingStarted = false;
    }
}
