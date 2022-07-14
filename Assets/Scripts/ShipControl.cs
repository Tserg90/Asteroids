using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{

    public BulletControl bulletPrefab;
    public LaserControl laserPrefab;

    private Vector3 vector_end = Vector3.zero;

    Ship player = new Ship();
    private void Awake()
    {
        player.SetParams( GetComponent<Rigidbody2D>(), transform, gameObject, bulletPrefab, laserPrefab );
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.ShipUp();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.ShipTurnLeft();
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.ShipTurnRight();
        }

        if (Input.GetMouseButtonDown(0))
        {
            player.ShipShootBullet();
        } else if (Input.GetMouseButtonDown(1))
        {
            player.ShipShootLaser();
        }

        player.LaserCheck( Time.deltaTime );

    }

    private void FixedUpdate()
    {
        GameData.ShipPosition = transform.position;
        GameData.ShipAngle = transform.rotation.z*180.0f;
        GameData.ShipSpeed = (transform.position - vector_end).magnitude/Time.deltaTime;
        vector_end = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Boundary1" )
        {
            transform.position = new Vector2( transform.position.x, -(transform.position.y-0.3f) );
        } 
        else if ( collision.gameObject.tag == "Boundary2" )
        {
            transform.position = new Vector2( transform.position.x, -(transform.position.y+0.3f) );
        } 
        else if ( collision.gameObject.tag == "Boundary3" )
        {
            transform.position = new Vector2( -(transform.position.x+0.3f), transform.position.y );
        }
        else if ( collision.gameObject.tag == "Boundary4" )
        {
            transform.position = new Vector2( -(transform.position.x-0.3f), transform.position.y );
        }
        else
        {
            player.Destroy();
        }
    }
}
