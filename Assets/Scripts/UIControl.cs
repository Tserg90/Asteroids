using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{

    [SerializeField] private Text scoreText;
    [SerializeField] private Text shipInfo;
    [SerializeField] private Text laserInfo;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text restertText;

    private void Awake ()
    {
        gameOverText.text = "Game Over!";
        gameOverText.enabled = false;
        restertText.text = "Press 'R' for restart";
        restertText.enabled = false;
    }

    private void FixedUpdate()
    {
        scoreText.text = "Score: "+GameData.Score;
        shipInfo.text = "Pos: "+System.Math.Round(GameData.ShipPosition.x, 2)+" : "+System.Math.Round(GameData.ShipPosition.y, 2)+"\nAngel: "+GameData.ShipAngle+"\nSpeed: "+GameData.ShipSpeed;
        laserInfo.text = "Laser count: "+GameData.LaserCount+"\nNew laser: "+System.Math.Round(GameData.LaserTime, 2);
        if (GameData.gameOver)
        {
            gameOverText.enabled = true;
            restertText.enabled = true;
        }
    }
}
