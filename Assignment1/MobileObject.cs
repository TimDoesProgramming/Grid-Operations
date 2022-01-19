using System;
using System.Collections.Generic;

public class MobileObject 
{
    private string name;
    private static int count = 0;
    private int id;
    private Position objPos;

    //Constructor creates the mobile object with a name, an id and a random location in space
    public MobileObject(string name, Position objPos)
    {     
        ObjPos = objPos;
        Name = name;
        id = count;
        count++;        
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    //It could get confusing if ID could be changed, so it's read only
    public int ID
    {
        get { return id; }
    }
    public Position ObjPos
    {
        get { return objPos; }
        set { objPos = value; }
    }
       
    //Basic method to move objects
    public void Move( int dx, int dy, int dz)
    {

        objPos.XPos += dx;
        objPos.YPos += dy;
        objPos.ZPos += dz;
    }
    //Moves an animal by a random amount
    public void MoveAndUpdate(MobileObject catOrSnek)
    {
        int x, y, z;

        Random random = new System.Random();
        object syncLock = new Object();

        lock (syncLock)
        {
            x = random.Next(10);
            y = random.Next(10);
            z = random.Next(10);
        }
        catOrSnek.ObjPos.XPos += x;
        catOrSnek.ObjPos.YPos += y;
        catOrSnek.ObjPos.ZPos += z;
    }
    //moves an animal by a certain amount, to make it so that all animals are moved by the same amount
    //I made this method very basic so it would work with a list
    public void MoveOrigin( float x, float y, float z, MobileObject catOrSnek)
    {
        catOrSnek.ObjPos.XPos -= x;
        catOrSnek.ObjPos.YPos -= y;
        catOrSnek.ObjPos.ZPos -= z;
    }

    //Checks if objects are within a certain distance of the origin using pothagorean theorem
    public string FindWithinDistance(float distance, MobileObject catOrSnek)
    {
        if (distance >= (float)(Math.Sqrt((Math.Pow(catOrSnek.ObjPos.XPos, 2) + Math.Pow(catOrSnek.ObjPos.YPos, 2) +
            Math.Pow(catOrSnek.ObjPos.ZPos, 2)))))

            return (catOrSnek.Name + " is in range and their id is: " + catOrSnek.ID + "\n");

        else
            return ("");
        
    }

    
}