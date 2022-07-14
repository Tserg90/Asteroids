using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    Laser laser = new Laser();

    private void Awake()
    {
        laser.SetParams( new Rigidbody2D(), this.gameObject );
    }

    public void Shoot()
    {
        laser.Shoot();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        //laser.Destroy();
    }
}
