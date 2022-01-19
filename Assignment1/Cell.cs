using System;
using System.Collections.Generic;

public class Cell
{
    private int cellID = 0;
    private const int WIDTH = 5, LENGTH = 5;
    private int[,] cellPos = new int[2, 2];
    private static int count = 0;

    
    private List<MobileObject> objList = new List<MobileObject>();


    public List<MobileObject> ObjList
    {
        get { return objList; }
        set { objList = value; }
    }
    public Cell(int xPos, int yPos) {

        cellPos[1, 0] = xPos;
        cellPos[0, 1] = yPos;

        
       

        count += 1;
        cellID = count;
    }
    //read only property as the size of the cell is constant
    public int Width
    {
        get { return WIDTH; }

    }
    public int Length
    {
        get { return LENGTH; }

    }
    public int[,] CellPos
    {
        get { return cellPos; }
        set { cellPos = value; }
    }
    public int CellID
    {
        get { return cellID; }
        
    }
    
}