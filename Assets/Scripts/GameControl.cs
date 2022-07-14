using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    private void Update ()
    {
        if ( GameData.gameOver )
        {
            if (Input.GetKey(KeyCode.R))
            {
                GameData.gameOver = false;
                GameData.Score = 0;
                SceneManager.LoadScene( "main", LoadSceneMode.Single );
            }
        }
    }
}
