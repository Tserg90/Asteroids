using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship
{
    private Rigidbody2D _shipRigidbody;
    private Transform _shipTransform;
    private GameObject _shipGameObject;
    private BulletControl _bulletPrefab;
    private LaserControl _laserPrefab;

    private float _shipSpeed = 2.0f;
    private int _maxLaserCount = 5;
    private int _laserCount = 0;
    private float _laserRate = 10.0f;
    private float _laserTime = 0.0f;
   
    public int LaserCount {
        set{
            if ( value <= _maxLaserCount )
            {
                _laserCount = value;
                GameData.LaserCount = value;
            }
        }
        get { return _laserCount; }
    }

    public void SetParams ( Rigidbody2D shipRigidbody, Transform shipTransform, GameObject gameObject, BulletControl bulletPrefab, LaserControl laserPrefab )
    {
        _shipRigidbody = shipRigidbody;
        _shipTransform = shipTransform;
        _shipGameObject = gameObject;
        _bulletPrefab = bulletPrefab;
        _laserPrefab = laserPrefab;

        LaserCount = _maxLaserCount;

    }

    public void ShipUp ()
    {
        _shipRigidbody.AddForce( _shipTransform.up*this._shipSpeed );
    }

    public void ShipTurnLeft ()
    {
        _shipRigidbody.AddTorque(0.5f);
    }

    public void ShipTurnRight ()
    {
        _shipRigidbody.AddTorque(-0.5f);
    }

    public void ShipShootBullet ()
    {
        BulletControl bullet = Object.Instantiate( _bulletPrefab, _shipTransform.position, _shipTransform.rotation );

        bullet.Shoot( _shipTransform.up );
    }

    public void ShipShootLaser ( )
    {
        if (LaserCount > 0)
        {
            LaserControl laser = Object.Instantiate( _laserPrefab, _shipTransform.position, _shipTransform.rotation );
            laser.Shoot();
            LaserCount--;
        }
    }

    public void LaserCheck( float time )
    {
        if (LaserCount < _maxLaserCount)
        {
            _laserTime += time;
            GameData.LaserTime = _laserRate - _laserTime;
            if (_laserTime >= _laserRate)
            {
                LaserCount++;
                _laserTime = 0.0f;
            }
        }
    }

    public void Destroy()
    {
        Object.Destroy(_shipGameObject);
        GameData.gameOver = true;
        
    }
}
