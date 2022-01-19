using System;
using System.Collections.Generic;
using System.Linq;

//A child of the MobileObject's class
// creates snakes
public class Snake : MobileObject
{
    private float length, radius, mass, volume;
    private int vertibrae;

    public Snake(float length, float radius, float mass, float vertibrae, string name, Position objPos) : base(name, objPos)
    {
        
        Random rand = new Random();
        base.Name = name;
        base.ObjPos = objPos;
        this.length = length;
        this.radius = radius;
        this.mass = mass;

        volume = VolumeCalc(length, radius);

       

       
    }
    //read only as a user shouldn't be able to change the snake
    public float Length
    {
        get { return length; }
  
    }
    public float Radius
    {
        get { return radius; }
    }
    public float Mass
    {
        get { return mass; }
    }
    public int Vertibrae
    {
        get { return vertibrae; }
    }
    public float Volume
    {
        get { return volume; }
    }
    //calculates the volume of the snake, assuming it's a perfect cylinder
    private float VolumeCalc(float length, float radius)
    {
        return ((float)(Math.PI * Math.Pow(radius, 2) * length));
    }
    //overrides the ToString method to print out all the information aabout the snake
    public override string ToString()
    {
        return ("Name:"+ Name + " Length:" + length + " Radius:" + Radius + " Mass:" + mass +
            " Volume:"+ VolumeCalc( length, radius) + "\n");
    }
}