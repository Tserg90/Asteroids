using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nlo
{
    private Transform _nloTransform;
    private GameObject _nloGameObject;

    private float _speed = 2.0f;

    public void SetParams( Transform nloTransform, GameObject nloGameObject )
    {
        _nloTransform = nloTransform;
        _nloGameObject = nloGameObject;
    }

    public void Move ( Vector2 targetPosition, float deltaTime )
    {
        float step = this._speed * deltaTime;
        _nloTransform.position = Vector2.MoveTowards(_nloTransform.position, targetPosition, step);
    }

    public void Destroy ()
    {
        Object.Destroy( _nloGameObject );
        GameData.Score += 100;
    }
}
