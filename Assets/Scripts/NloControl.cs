using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NloControl : MonoBehaviour
{
    Nlo nlo = new Nlo();

    private void Awake()
    {
        nlo.SetParams( transform, this.gameObject );
    }

    private void Update()
    {
        nlo.Move( GameData.ShipPosition, Time.deltaTime );
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if ( collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Laser" )
        {
            nlo.Destroy();
        }
    }
    
}
