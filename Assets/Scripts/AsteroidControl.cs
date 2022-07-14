using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControl : MonoBehaviour
{
    Asteroid asteroid = new Asteroid();

    private void Awake()
    {
        asteroid.SetParams( GetComponent<Rigidbody2D>(), transform, this.gameObject );
    }

    public void SetAsteroidLevel( int level )
    {
        asteroid.AsteroidLevel = level;
    }

    public void CreatAsteroid()
    {
        asteroid.Creat();
    }

    public void MoveAsteroid( Vector2 direction )
    {
        asteroid.Move( direction );
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if ( collision.gameObject.tag == "Bullet" )
        {
            if (asteroid.AsteroidLevel < 2)
            {
                Spawner.SpawnSplit( asteroid.AsteroidLevel+1, transform.position );
            }
            asteroid.Destroy();
        }
        else if ( collision.gameObject.tag == "Laser" )
        {
            asteroid.Destroy();
        }
    }

}
