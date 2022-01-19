using System;

//really basic class which has 3 variables that are meant to represent a position in 3d space
public class Position
{
    private float xPos, yPos, zPos;

    public Position()
    {

    }
    public Position(float x, float y, float z) //, Position position
    {
        XPos = x;
        YPos = y;
        ZPos = z;
    }

    public float XPos
    {
        get { return xPos; }
        set { xPos = value; }
    }
    public float YPos
    {
        get { return yPos; }
        set { yPos = value; }
    }
    public float ZPos
    {
        get { return zPos; }
        set { zPos = value; }
    }

}