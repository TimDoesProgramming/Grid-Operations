using System;
using System.Collections.Generic;
using System.Linq;

public class Assignment1
{
    public static void Main()
    {
        //Various variable declarations
        int count = 0, gridSize =0, nameChooser;
        
        bool isNum = false;

        //Creating the Randomness
        Random random = new System.Random();
        Object syncLock = new Object();


        Grid theGrid;
      
        //creating a list for cats and snakes during the initial creation of the mixed list
        List<Cat> catList = new List<Cat>();
        List<Snake> snakeList = new List<Snake>();

        //Mixed list 
        List<MobileObject> catSnake = new List<MobileObject>();

        //Generic path by putting the snake and cat text files in the bin
        string tempPath = "..\\csNames\\snakenames.txt";
        string outPath = System.IO.Path.GetFullPath(tempPath);
        string[] snakeNames = System.IO.File.ReadAllLines(outPath);
        tempPath = "..\\csNames\\catnames.txt";
        outPath = System.IO.Path.GetFullPath(tempPath);
        string[] catNames = new string[100];
        string[] catNamesSuck = System.IO.File.ReadAllLines(outPath);

        //Parsing the cat string array to grab the names
        foreach (string catName in catNamesSuck)
        {

            string[] namesHolder = catName.Split(' ');
            catNames[count] = namesHolder[2];
            count++;

        }



        // getting the inital size of the grid
        do
        {
            Console.WriteLine("How big would you like your grid to be?");
            var input = Console.ReadLine();

            if (Int32.TryParse(input, out int num))
            {
                if (0 <= num && num <= 100) {
                    gridSize = num;
                    isNum = true;
                } else
                    Console.WriteLine("Common, let's be reasonable here. Try something from 0 - 100");

            }

        } while (isNum == false);
        
        //defining the grid
        theGrid = new Grid(gridSize);
        

        while (catSnake.Count != 5)
        {
            lock (syncLock)
            {
                
                nameChooser = random.Next(99);
                
            }
            catSnake.Add(new Cat((float)random.Next(10), (float)random.Next(10),
                    (float)random.Next(10), (float)random.Next(10), (float)random.Next(10), catNames[nameChooser], CreatePosition(random)));
        }

        while(catSnake.Count != 10)
        {
            lock (syncLock) {nameChooser = random.Next(snakeNames.Length - 1); }
            
            catSnake.Add(new Snake((float)random.Next(10), (float)random.Next(10),
                (float)random.Next(10), (float)random.Next(10), snakeNames[nameChooser], CreatePosition(random)));
        }

        //Makes sure to check if each object is on the grid or not.
        foreach (MobileObject catOrSnek in catSnake)
        {
            InitializeTracking(catOrSnek, theGrid);
        }

        
        bool loop = true;
        //main Loop in a switch
        do
        {

            Console.WriteLine("Type the number of the command you'd like to proceed with.");
            Console.WriteLine("1. Add a snake \n2. Add a Cat\n3. Move a specific cat or snake by ID" +
                            "\n4. Move all animals\n5. Move the origin \n6. Check if an object is within range of a certain distance" +
                            "\n7. Print all the properties of each item \n8. Print all cells and objects inside of Them" +
                            "\n9. If you'd like to quit. \n0. Randomize and print the list");

            //restricting user input
            int caseTemp;
            while (true)
            {

                string caseInput = Console.ReadLine();
                if (int.TryParse(caseInput, out caseTemp) && Convert.ToInt32(caseInput) >= 0 && Convert.ToInt32(caseInput) <= 9)
                    break;
                else
                    Console.WriteLine("Please enter a case number between 0 and 9");
            }

            //Switch for deciding on what you'd like to do
            switch (caseTemp)
            {
                //Allows you to add a snek to the list
                case 1:
                    {
                        float lengthS, radiusS, massS, vertibraeS;
                        int temp1;
                        string nameS, uInput1;

                        while (true)
                        {
                            Console.WriteLine("Please enter the length of the snake 0 - 15");
                            uInput1 = Console.ReadLine();

                            if (int.TryParse(uInput1, out temp1) && Convert.ToInt32(uInput1) > 0 && Convert.ToInt32(uInput1) <= 15)
                            {
                                lengthS = (float)temp1;
                                break;
                            }

                        }

                        while (true)
                        {
                            Console.WriteLine("Please enter the radius of the snake 0 - 15");
                            uInput1 = Console.ReadLine();

                            if (int.TryParse(uInput1, out temp1) && Convert.ToInt32(uInput1) > 0 && Convert.ToInt32(uInput1) <= 15)
                            {
                                radiusS = (float)temp1;
                                break;
                            }

                        }
                        while (true)
                        {
                            Console.WriteLine("Please enter the mass of the snake 0 -15 ");
                            uInput1 = Console.ReadLine();

                            if (int.TryParse(uInput1, out temp1) && Convert.ToInt32(uInput1) > 0 && Convert.ToInt32(uInput1) <= 15)
                            {
                                massS = (float)temp1;
                                break;
                            }
                        }
                        while (true)
                        {
                            Console.WriteLine("Please enter a number 200-300 for the vertibrae of the snake");
                            uInput1 = Console.ReadLine();
                            if (int.TryParse(uInput1, out temp1) && Convert.ToInt32(uInput1) >= 200 && Convert.ToInt32(uInput1) <= 300)
                            {
                                vertibraeS = (float)temp1;
                                break;
                            }
                        }

                        Console.WriteLine("Please give the snake a name.");
                        nameS = Console.ReadLine();

                        catSnake.Add(new Snake(lengthS, radiusS, massS, vertibraeS, nameS, CreatePosition(random)));

                        InitializeTracking(catSnake.Last(), theGrid);


                        break;
                    }
                //allows you to add a cat to the list
                case 2:
                    int temp;
                    float torsoL, headL, tailL, legL, mass;
                    string name, uInput;

                    while (true)
                    {
                        Console.WriteLine("Please enter the torso Length of the cat 0 - 15");
                        uInput = Console.ReadLine();
                        if (int.TryParse(uInput, out temp) && Convert.ToInt32(uInput) > 0 && Convert.ToInt32(uInput) <= 15)
                        {
                            torsoL = (float)temp;
                            break;
                        }

                    }
                    while (true)
                    {
                        Console.WriteLine("Please enter the head length of the cat 0 - 15");
                        uInput = Console.ReadLine();
                        if (int.TryParse(uInput, out temp) && Convert.ToInt32(uInput) > 0 && Convert.ToInt32(uInput) <= 15)
                        {
                            headL = (float)temp;
                            break;
                        }

                    }
                    while (true)
                    {
                        Console.WriteLine("Please enter a leg length for the cat 0 - 15");
                        uInput = Console.ReadLine();
                        if (int.TryParse(uInput, out temp) && Convert.ToInt32(uInput) > 0 && Convert.ToInt32(uInput) <= 15)
                        {
                            legL = (float)temp;
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("Please enter the mass of the cat");
                        uInput = Console.ReadLine();
                        if (int.TryParse(uInput, out temp) && Convert.ToInt32(uInput) > 0 && Convert.ToInt32(uInput) <= 15)
                        {
                            mass = (float)temp;
                            break;

                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("Please enter a tail length for the cat 0 -15");
                        uInput = Console.ReadLine();
                        if (int.TryParse(uInput, out temp) && Convert.ToInt32(uInput) > 0 && Convert.ToInt32(uInput) <= 15)
                        {
                            tailL = (float)temp;
                            break;
                        }

                    }


                    Console.WriteLine("Please give the cat a name");
                    name = Console.ReadLine();

                    catSnake.Add(new Cat(torsoL, headL, tailL, legL, mass, name, CreatePosition(random)));
                    InitializeTracking(catSnake.Last(), theGrid);

                    break;

                //Allows you to move a specific cat or snake by id
                case 3:
                    int id, x, y, z, temp3;
                    string uInput2;
                    bool exists = false;

                    while (true)
                    {
                        Console.WriteLine("please enter the snake or cat ID");
                        uInput2 = Console.ReadLine();

                        if (int.TryParse(uInput2, out temp3) && Convert.ToInt32(uInput2) > 0)
                        {
                            id = temp3;
                            break;
                        }
                    }


                    foreach (MobileObject catOrSnek in catSnake)
                    {
                        if (catOrSnek.ID == id)
                        {
                            exists = true;

                            while (true)
                            {
                                Console.WriteLine("Please enter the x change");
                                uInput2 = Console.ReadLine();
                                if (int.TryParse(uInput2, out x))
                                {
                                    break;
                                }
                            }
                            while (true)
                            {
                                Console.WriteLine("Now the y");
                                uInput2 = Console.ReadLine();
                                if (int.TryParse(uInput2, out y))
                                {
                                    break;
                                }
                            }
                            while (true)
                            {
                                Console.WriteLine("Now the z");
                                uInput2 = Console.ReadLine();
                                if (int.TryParse(uInput2, out z))
                                {
                                    break;
                                }
                            }

                            cleanList(catOrSnek, theGrid);
                            catOrSnek.Move(x, y, z);
                            InitializeTracking(catOrSnek, theGrid);
                        }

                    }
                    if (exists == false)
                        Console.WriteLine("No Cat or snake exists with that id");

                    break;
                //Moves every object, and reformats the cell lists
                case 4:
                    foreach (MobileObject catOrSnek in catSnake)
                    {
                        cleanList(catOrSnek, theGrid);
                        catOrSnek.MoveAndUpdate(catOrSnek);
                        InitializeTracking(catOrSnek, theGrid);

                    }
                    Console.WriteLine("All the objects have been moved!");
                    break;
                //moves origin and reformats the cell list
                case 5:

                    int xOg, yOg, zOg;

                    while (true)
                    {
                        Console.WriteLine("Please enter the x change");
                        uInput = Console.ReadLine();
                        if (int.TryParse(uInput, out xOg))
                        {
                            break;
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Now the y");
                        uInput = Console.ReadLine();

                        if (int.TryParse(uInput, out yOg))
                        {
                            break;
                        }

                    }

                    while (true)
                    {
                        Console.WriteLine("Now the z");
                        uInput = Console.ReadLine();
                        if (int.TryParse(uInput, out zOg))
                        {
                            break;
                        }
                    }


                    foreach (MobileObject catOrSnek in catSnake)
                    {
                        cleanList(catOrSnek, theGrid);
                        catOrSnek.MoveOrigin(xOg, yOg, zOg, catOrSnek);
                        InitializeTracking(catOrSnek, theGrid);

                    }
                    Console.WriteLine("The origin has been moved!");
                    break;
                //checks if an object is withing a certain distance of the origin
                case 6:
                    float dist;
                    int temp2;
                    while (true)
                    {
                        Console.WriteLine("Enter a distance you'd like to check");
                        uInput = Console.ReadLine();
                        if (int.TryParse(uInput, out temp2) && Convert.ToInt32(uInput) > 0)
                        {
                            dist = (float)temp2;
                            break;

                        }

                    }
                    foreach (MobileObject catOrSnek in catSnake)
                    {
                        Console.Write(catOrSnek.FindWithinDistance(dist, catOrSnek));
                    }

                    break;
                // prints out the information of all the animals, ToString has been overloaded
                case 7:


                    foreach (MobileObject catOrSnake in catSnake)
                    {
                        Console.WriteLine(catOrSnake.ToString());
                    }

                    break;
                //prints out the name specific cell and the name of the animals in that cell
                case 8:
                    foreach (Cell cell in theGrid.GridCells)
                    {
                        if (cell.ObjList.Count > 0)
                        {
                            Console.WriteLine("The cell id is " + cell.CellID + " and the objects are:");
                            foreach (MobileObject catOrSnek in cell.ObjList)
                            {
                                Console.WriteLine(" " + catOrSnek.Name);
                            }
                        }

                    }
                    break;
                //terminates the program
                case 9:
                    loop = false;
                    break;
                //randomizes the list 
                case 0:
                    List<MobileObject> catSnake2 = new List<MobileObject>();

                    foreach (MobileObject catOrSnek in catSnake)
                    {
                        catSnake2.Add(catOrSnek);
                    }

                    MobileObject[] randomMB = new MobileObject[catSnake.Count];
                    int oChooser;

                    for (int i = 0; i < catSnake.Count; i++)
                    {
                        lock (syncLock)
                        {
                            oChooser = random.Next(catSnake2.Count - 1);
                        }

                        randomMB[i] = catSnake2[oChooser];
                        catSnake2.RemoveAt(oChooser);

                    }
                    for (int i = 0; i < catSnake.Count; i++)
                    {
                        Console.Write(catSnake[i].Name + " vs " + randomMB[i].Name + "\n");
                    }

                    break;
            }
        } while (loop);

    }
    //This method keeps track of which animal is in what cell
    public static void InitializeTracking(MobileObject catOrSnek, Grid aGrid)
    {
        if (catOrSnek.ObjPos.XPos < aGrid.GridSize && catOrSnek.ObjPos.XPos >= 0 &&
            catOrSnek.ObjPos.YPos < aGrid.GridSize && catOrSnek.ObjPos.YPos >= 0)
        {
            aGrid.GridCells[(int)catOrSnek.ObjPos.XPos, (int)catOrSnek.ObjPos.YPos].ObjList.Add(catOrSnek);
        }

    }
    //This method removes a cat or snake from the cell
    public static void cleanList(MobileObject catOrSnek, Grid aGrid)
    {
        if(catOrSnek.ObjPos.XPos >= 0 && catOrSnek.ObjPos.XPos < aGrid.GridSize &&
            catOrSnek.ObjPos.YPos >= 0 && catOrSnek.ObjPos.YPos < aGrid.GridSize)
        if (aGrid.GridCells[(int)catOrSnek.ObjPos.XPos, (int)catOrSnek.ObjPos.YPos].ObjList.Contains(catOrSnek))
            aGrid.GridCells[(int)catOrSnek.ObjPos.XPos, (int)catOrSnek.ObjPos.YPos].ObjList.Remove(catOrSnek);
    }
    public static Position CreatePosition( Random random)
    {

        int x, y, z;
        //Random random = new System.Random();
        Object syncLock = new Object();
        lock (syncLock)
        {
            x = random.Next(10);
            y = random.Next(10);
            z = random.Next(10);
        }

        Position instancePos = new Position((float)x, (float)y, (float)z);

        return instancePos;
    }
}