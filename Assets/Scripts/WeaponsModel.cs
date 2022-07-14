using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapons
{
    protected Rigidbody2D _weaponRigitbody;
    protected GameObject _weaponGameobject;

    public void SetParams( Rigidbody2D rigitbody, GameObject gameObject )
    {
        _weaponRigitbody = rigitbody;
        _weaponGameobject = gameObject;
    }

    public abstract void Shoot();

    public Rigidbody2D Weapon { get; set; }
}

public class Bullet : Weapons
{
    public float speed = 500.0f;
    public float maxLifetime = 10.0f;

    public Vector2 Direction { get; set; }

    public override void Shoot ()
    {
        _weaponRigitbody.AddForce( Direction * this.speed );

        Object.Destroy( _weaponGameobject, maxLifetime );
    }

    public void Destroy ()
    {
        Object.Destroy( _weaponGameobject );
    }
}

public class Laser : Weapons
{
    public float maxLifetime = 0.5f;

    public override void Shoot () => Object.Destroy( _weaponGameobject, maxLifetime );
}
