using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static Vector2 ShipPosition { get; set; }
    public static float ShipAngle { get; set; }
    public static float ShipSpeed { get; set; }
    public static int Score { get; set; }
    public static int LaserCount { get; set; }
    public static float LaserTime { get; set; }

    public static bool gameOver = false;
}
