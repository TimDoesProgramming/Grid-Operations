using System;
using System.Collections.Generic;

//This class makes an array of cells
public class Grid
{
    private Cell[,] gridCells;
    private int gridSize;

    public Grid(int gridSize)
    {
        int x = 0, y = 0;

        this.gridSize = gridSize;

        GridCells = new Cell[gridSize ,gridSize ];
        //makes the grid in row major
        while (y < gridSize) {

            for (int i = 0; i < gridSize; i++)
            {

                gridCells[x, y] = new Cell(x, y);
                x++;

            }
            x = 0;
            y++;
        }
        

    }
    //changing the gridsize could be problematic so it's read only
    public int GridSize
    {
        get { return gridSize; }
    }
   
    public Cell[,] GridCells
    {
        get { return gridCells; }
        set { gridCells = value; }
    }
    //This method checks if a valid cell location was input and then returns the integer id of the cell
    public int GetCellID(int x, int y)
    {
        if(x > gridSize || y > gridSize)
        {
            Console.WriteLine("There is no cell here");
            return (-1);
        }
        else if( x < 0 || y < 0)
        {
            Console.WriteLine("There is no cell here");
            return (-1);
        }
        else
        {
            return (GridCells[x, y].CellID);
        }

    }
            
}