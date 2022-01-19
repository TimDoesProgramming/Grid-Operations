using System;
using System.Collections.Generic;
using System.Linq;
public class Cat : MobileObject
{
    private float torsoL, headL, tailL, legL, mass, totalL;

    

    public Cat(float torsoL, float headL, float tailL, float legL, float mass, string name, Position objPos) : base(name, objPos)
    {
        
        base.Name = name;
        base.ObjPos = objPos;

        TorsoL = torsoL;
        HeadL = headL;
        TailL = tailL;
        LegL = legL;
        Mass = mass;

        totalL = LengthCalc(torsoL, headL, legL);
        

        
    }

    //Not read only just because 
    public float TorsoL
    {
        get { return torsoL; }
        set { torsoL = value; }
    }
    public float HeadL
    {
        get { return headL; }
        set { headL = value; }
    }
    public float TailL
    {
        get { return tailL; }
        set { tailL = value; }
    }

    public float LegL
    {
        get { return legL; }
        set { legL = value; }
    }

    public float Mass
    {
        get { return mass; }
        set { mass = value; }
    }
    //except for this one because why would you be able to change the total length without changing the others
    public float TotalL
    {
        get { return totalL; }
    }
    //Calculates the total length of the cat
    private float LengthCalc(float torsoL, float headL, float legL)
    {
        return (torsoL + headL + legL);
    }
    //Overrides the ToString() method
    public override string ToString()
    {
        return ("Name:" + Name + " TorsoL:" + torsoL + " HeadL:" + headL+ " TailL:" + tailL+
                " Mass:"+ mass+ " Total Length:" + LengthCalc(torsoL,headL, legL) + "\n");
    }
    public string ToStringS()
    {
        string toString;

        toString = ("Name:" + Name + "Total Length" + LengthCalc(torsoL, headL, legL) + "\n");

        return toString;
    }

}
