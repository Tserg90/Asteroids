using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{

    Bullet bullet = new Bullet();

    private void Awake()
    {
        bullet.SetParams( GetComponent<Rigidbody2D>(), this.gameObject );
    }

    public void Shoot( Vector2 direction )
    {
        bullet.Direction = direction;
        bullet.Shoot();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        bullet.Destroy();
    }
}
