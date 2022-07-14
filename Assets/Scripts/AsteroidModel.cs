using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid
{
    private Rigidbody2D _asterodRigidbody;
    private Transform _asterodTransform;
    private GameObject _asterodGameObject;

    private float _speedMax = 10.0f;
    private float _speedMin = 5.0f;

    private float _size = 1.0f;
    private float _minSize = 1.0f;
    private float _maxSize = 1.5f;

    private int _asteroidLevel = 1;

    private float _maxLifetime = 30.0f;

    public int AsteroidLevel {
        get
        {
            return _asteroidLevel;
        }
        set
        {
            if (value > 0 && value < 4)
            {
                _asteroidLevel = value;
            }
        }
    }

    public void SetParams ( Rigidbody2D rigitbody, Transform transform, GameObject gameObject )
    {
        _asterodRigidbody = rigitbody;
        _asterodTransform = transform;
        _asterodGameObject = gameObject;
    }

    public void Creat ()
    {
        _size = Random.Range( this._minSize, this._maxSize );

        _asterodTransform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        _asterodTransform.localScale = Vector3.one * _size/AsteroidLevel;

        _asterodRigidbody.mass = _size/AsteroidLevel;
    }

    public void Move ( Vector2 direction )
    {
        float speed = Random.Range(this._speedMin, this._speedMax);
        _asterodRigidbody.AddForce(direction*speed);

        Object.Destroy( _asterodGameObject, _maxLifetime );
    }

    public void Destroy ()
    {
        Object.Destroy( _asterodGameObject );
        GameData.Score += 50;
    }

}
