using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHARACTERPOSITIONS : MonoBehaviour
{
    public static Vector2 stay = new Vector2(0, 0);
    public static Vector2 bottomLeft = new Vector2(0, 0);
    public static Vector2 topRight = new Vector2(1f, 1f);
    public static Vector2 center = new Vector2(0.5f, 0.5f);
    public static Vector2 bottomRight = new Vector2(1f, 0);
    public static Vector2 topLeft = new Vector2(0, 1f);

    public static List<Vector2> characterPositionsList = new List<Vector2>() // Make sure we copy the order in LocationEnum
    { stay, bottomLeft, bottomRight, center, topLeft, topRight };
    //We only included stay so we didn't have to subtract every time we wanted to reference this list

    public static CHARACTERPOSITIONS characterPositions; // = new CHARACTERPOSITIONS();

    public enum LocationEnum // Will control where sprite goes, stay will leave it where it already is.
    {
        Stay = 0,
        BottomLeft,
        BottomRight,
        Center,
        TopLeft,
        TopRight
    }

    public enum AnimationEnum // Will control sprite animations, stay will leave it as is.
    {
        Stay = 0,
        Bounce
        // The rest
    }
}
