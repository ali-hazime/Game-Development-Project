using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDataGenerator
{
    // generator params
    public float placementThreshold;    // chance of empty space

    public MazeDataGenerator()
    {
        placementThreshold = 0.1f;
    }

    public int[,] FromDimensions(int sizeRows, int sizeCols)
    {
        int[,] maze = new int[sizeRows, sizeCols];

        int rMaxLength = maze.GetUpperBound(0);
        int cMaxLength = maze.GetUpperBound(1);
        //Debug.Log("U0B = " + rMaxLength);
        //Debug.Log("U1B = " + cMaxLength);
        for (int i = 0; i <= rMaxLength; i++)
        {
            for (int j = 0; j <= cMaxLength; j++)
            {
                // outside wall
                if (i == 0 || j == 0 || i == rMaxLength || j == cMaxLength)
                {
                    maze[i, j] = 1;
                }

                // every other inside space
                else if (i % 2 == 0 && j % 2 == 0)
                {
                    if (Random.value > placementThreshold)
                    {
                        maze[i, j] = 1;

                        // in addition to this spot, randomly place adjacent
                        int a;
                        int b;
                        if (Random.value < 0.5f)
                        {
                            a = 0;
                        }
                        else if (Random.value < 0.5f)
                        {
                            a = -1;
                        }
                        else
                        {
                            a = 1;
                        }

                        if (a != 0)
                        {
                            b = 0;
                        }
                        else if (Random.value < 0.5f)
                        {
                            b = -1;
                        }
                        else
                        {
                            b = 1;
                        }
                        maze[i + a, j + b] = 1;
                    }
                }
            }
        }

        return maze;
    }
}
