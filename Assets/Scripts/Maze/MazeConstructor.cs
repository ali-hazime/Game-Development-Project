using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MazeConstructor : MonoBehaviour
{
    public GameObject GlobyGlob;
    public GameObject Mino;
    public GameObject Raptor;
    public GameObject Turt;
    public GameObject PathU0D0L0R0; //All Open
    public GameObject PathU0D1L1R1; //Up Open
    public GameObject PathU1D0L1R1; //Down Open
    public GameObject PathU1D1L0R1; //Left Open 
    public GameObject PathU1D1L1R0; //Right Open
    public GameObject PathU0D0L1R1; //Up & Down Open
    public GameObject PathU0D1L0R1; //Up & Left Open
    public GameObject PathU0D1L1R0; //Up & Right Open
    public GameObject PathU1D0L0R1; //Down & Left Open
    public GameObject PathU1D0L1R0; //Down & Right Open
    public GameObject PathU1D1L0R0; //Left & Right Open
    public GameObject PathU0D0L0R1; //Up & Down & Left 
    public GameObject PathU0D0L1R0; //Up & Down & Right Open
    public GameObject PathU1D0L0R0; //Down & Right & Left Open
    public GameObject PathU0D1L0R0; //Up & Right & Left Open
    public GameObject theGoal;
    public GameObject wall;
    public int goalI = 0;
    public int goalJ = 0;
    public bool goalFound = false;
    public int startRow;
    public int startCol;
    public int goalRow;
    public int goalCol;
    public int[,] data;
    private MazeDataGenerator dataGenerator;

    void Awake()
    {
        dataGenerator = new MazeDataGenerator();

        // default to walls surrounding a single empty cell
        data = new int[,]
        {
            {1, 1, 1},
            {1, 0, 1},
            {1, 1, 1}
        };
    }

    public void GenerateMaze(int sizeRows, int sizeCols)
    {

        data = dataGenerator.FromDimensions(sizeRows, sizeCols);
        FindStartPosition();
        FindGoalPosition();
    }

    private void FindStartPosition()
    {
        int[,] maze = data;
        int rMax = maze.GetUpperBound(0);
        int cMax = maze.GetUpperBound(1);

        for (int i = 0; i <= rMax; i ++)
        {
            for (int j = 0; j <= cMax; j ++)
            {
                if (maze[i, j] == 0)
                {
                    startRow = i;
                    startCol = j;

                    //SpawnMazeGraphics
                    SpawnMazeGraphics(i, j, maze);


                    //SpawnFire 
                    if (maze[i, j + 1] != 1 || maze[i, j - 1] != 1 || maze[i + 1, j] != 1 || maze[i - 1, j] != 1)
                    {
                        if (Random.Range(0, 1000) < 15 && i != 39 && j != 47)
                        {
                            SpawnMonsters(i, j);
                        
                        }
                        
                    }
                }
                else
                {
                    GameObject edge = Instantiate(wall, new Vector3(i*5, j*5, 0), new Quaternion(0, 0, 0, 0));
                }
            }
        }
    }

    public void SpawnMazeGraphics(int i, int j, int[,] maze)
    {
        if (maze[i, j + 1] == 0 && maze[i, j - 1] == 0 && maze[i + 1, j] == 0 && maze[i - 1, j] == 0) //open
        {
            GameObject space = Instantiate(PathU0D0L0R0, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
        }
        else if (maze[i, j + 1] == 0 && maze[i, j - 1] == 1 && maze[i + 1, j] == 1 && maze[i - 1, j] == 1) //up
        {
            GameObject space = Instantiate(PathU0D1L1R1, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
        }
        else if (maze[i, j + 1] == 1 && maze[i, j - 1] == 0 && maze[i + 1, j] == 1 && maze[i - 1, j] == 1) //down
        {
            GameObject space = Instantiate(PathU1D0L1R1, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
        }
        else if (maze[i, j + 1] == 1 && maze[i, j - 1] == 1 && maze[i + 1, j] == 1 && maze[i - 1, j] == 0) //left
        {
            GameObject space = Instantiate(PathU1D1L0R1, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
        }
        else if (maze[i, j + 1] == 1 && maze[i, j - 1] == 1 && maze[i + 1, j] == 0 && maze[i - 1, j] == 1) //right
        {
            GameObject space = Instantiate(PathU1D1L1R0, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
        }
        else if (maze[i, j + 1] == 0 && maze[i, j - 1] == 0 && maze[i + 1, j] == 1 && maze[i - 1, j] == 1) //Up Down
        {
            GameObject space = Instantiate(PathU0D0L1R1, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
        }
        else if (maze[i, j + 1] == 0 && maze[i, j - 1] == 1 && maze[i + 1, j] == 1 && maze[i - 1, j] == 0) //Up Left
        {
            GameObject space = Instantiate(PathU0D1L0R1, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
        }
        else if (maze[i, j + 1] == 0 && maze[i, j - 1] == 1 && maze[i + 1, j] == 0 && maze[i - 1, j] == 1) //Up Right
        {
            GameObject space = Instantiate(PathU0D1L1R0, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
        }
        else if (maze[i, j + 1] == 1 && maze[i, j - 1] == 0 && maze[i + 1, j] == 1 && maze[i - 1, j] == 0) //Down Left
        {
            GameObject space = Instantiate(PathU1D0L0R1, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
        }
        else if (maze[i, j + 1] == 1 && maze[i, j - 1] == 0 && maze[i + 1, j] == 0 && maze[i - 1, j] == 1) //Down Right
        {
            GameObject space = Instantiate(PathU1D0L1R0, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
        }
        else if (maze[i, j + 1] == 1 && maze[i, j - 1] == 1 && maze[i + 1, j] == 0 && maze[i - 1, j] == 0) //Right Left
        {
            GameObject space = Instantiate(PathU1D1L0R0, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
        }
        else if (maze[i, j + 1] == 0 && maze[i, j - 1] == 0 && maze[i + 1, j] == 1 && maze[i - 1, j] == 0) //Up Down Left
        {
            GameObject space = Instantiate(PathU0D0L0R1, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
        }
        else if (maze[i, j + 1] == 0 && maze[i, j - 1] == 0 && maze[i + 1, j] == 0 && maze[i - 1, j] == 1) //Up Down Right
        {
            GameObject space = Instantiate(PathU0D0L1R0, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
        }
        else if (maze[i, j + 1] == 1 && maze[i, j - 1] == 0 && maze[i + 1, j] == 0 && maze[i - 1, j] == 0) //Down Right Left
        {
            GameObject space = Instantiate(PathU1D0L0R0, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
        }
        else if (maze[i, j + 1] == 0 && maze[i, j - 1] == 1 && maze[i + 1, j] == 0 && maze[i - 1, j] == 0) //Up Right Left
        {
            GameObject space = Instantiate(PathU0D1L0R0, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
        }
        else if (maze[i, j + 1] == 1 && maze[i, j - 1] == 1 && maze[i + 1, j] == 1 && maze[i - 1, j] == 1)
        {
            GameObject edge = Instantiate(wall, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
        }
    }

    public void SpawnMonsters(int i, int j) 
    {
        int num = Random.Range(0, 4);

        switch (num)
        {
            case 0:
                GameObject Bloby = Instantiate(GlobyGlob, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
                break;
            case 1:
                GameObject Min = Instantiate(Mino, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
                break;
            case 2:
                GameObject RaptorBoi = Instantiate(Raptor, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
                break;
            case 3:
                GameObject Spike = Instantiate(Turt, new Vector3(i * 5, j * 5, 0), new Quaternion(0, 0, 0, 0));
                break;
        }
    }

    private void FindGoalPosition()
    {
        int[,] maze = data;
        int rMax = maze.GetUpperBound(0);
        int cMax = maze.GetUpperBound(1);

        // loop top to bottom, right to left
        for (int i = rMax; i >= 0; i--)
        {
            for (int j = cMax; j >= 0; j--)
            {
                if (maze[i, j] == 0)
                {
                    goalRow = i;
                    goalCol = j;

                    if (j == 1)
                    {
                        if (Random.Range(0, 100) < 7 && goalFound == false)
                        {
                            goalI = i;
                            goalJ = j;
                            goalFound = true;
                        }
                    }
                }
            }
        }

        if (goalI == 0)
        {
            goalI = 1;
            goalJ = 1;
        }

        GameObject GOAL = Instantiate(theGoal, new Vector3(goalI * 5, goalJ * 5, 0), new Quaternion(0, 0, 0, 0));
    }
}
