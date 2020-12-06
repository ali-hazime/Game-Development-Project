using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{

    public Transform[] startingPositions;
    public GameObject[] rooms; // index 0 --> LR, index 1 --> LRB, index 2 --> LRT, index 3 --> LRBT

    public GameObject[] pathRooms; // index 0 --> Start, index 1 --> End, index 2 --> Top, index 3 --> TopRight, index 4 --> Left, index 5 --> Right, index 6 --> BotLeft, index 7 --> Bot

    public GameObject[] randRooms;

    private int direction;
    public float moveAmount;

    private float timeBtwRoom;
    public float startTimeBtwRoom = 0.25f;

    public float minX;
    public float maxX;
    public float minY;
    public bool stopGeneration;

    public LayerMask room;

    public int downCounter;

    private void Start()
    {
        // int randStartingPos = Random.Range(0, startingPositions.Length);
        //transform.position = startingPositions[randStartingPos].position;

        transform.position = startingPositions[1].position;
        Instantiate(pathRooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6); // 6 is included

    
    }

    private void FixedUpdate()
    {
        if (timeBtwRoom <= 0 && stopGeneration == false)
        {
            Move();
            timeBtwRoom = startTimeBtwRoom;
        }
        else 
        {
            timeBtwRoom -= Time.deltaTime;
        }
    }

    private void Move() 
    {

        if (direction == 1 || direction == 2) // MOVE RIGHT!
        {
            if (transform.position.x < maxX)
            {
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;

                // NEW: TLELING THE PATH WHICH LIST OF ROOMS IT CAN CHOOSE FROM
                if (transform.position.x == -5 && transform.position.y == 35) // TOP
                {
                    Instantiate(pathRooms[2], transform.position, Quaternion.identity);

                }
                else if (transform.position.x == 5 && transform.position.y == 35) // TOP
                {
                    Instantiate(pathRooms[2], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == 15 && transform.position.y == 25) // RIGHT
                {
                    Instantiate(pathRooms[5], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == 15 && transform.position.y == 15) // RIGHT
                {
                    Instantiate(pathRooms[5], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == -15 && transform.position.y == 25) // LEFT
                {
                    Instantiate(pathRooms[4], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == -15 && transform.position.y == 15) // LEFT
                {
                    Instantiate(pathRooms[4], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == -5 && transform.position.y == 5) // BOT
                {
                    Instantiate(pathRooms[7], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == 5 && transform.position.y == 5) // BOT
                {
                    Instantiate(pathRooms[7], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == -15 && transform.position.y == 5) // BotLeft
                {
                    Instantiate(pathRooms[6], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == 15 && transform.position.y == 35) // TopRight
                {
                    Instantiate(pathRooms[3], transform.position, Quaternion.identity);
                }
                else // END
                {
                    if (transform.position.x == 15 && transform.position.y == 5) // End block
                    {
                        Instantiate(pathRooms[1], transform.position, Quaternion.identity);
                    }
                    else // Random Room
                    {
                        int rand = Random.Range(2, 4);
                        Instantiate(rooms[rand], transform.position, Quaternion.identity);
                    }
                }






                //int rand = Random.Range(0, rooms.Length);
                //Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
                if (direction == 3)
                {
                    direction = 2;
                } else if (direction == 4)
                {
                    direction = 5;
                }
            }
            else 
            {
                direction = 5;
            }

        }
        else if (direction == 3 || direction == 4) // MOVE LEFT!
        {
            if (transform.position.x > minX)
            {

                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;


                // NEW: TEELING THE PATH WHICH LIST OF ROOMS IT CAN CHOOSE FROM
                if (transform.position.x == -5 && transform.position.y == 35) // TOP
                {
                    Instantiate(pathRooms[2], transform.position, Quaternion.identity);

                }
                else if (transform.position.x == 5 && transform.position.y == 35) // TOP
                {
                    Instantiate(pathRooms[2], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == 15 && transform.position.y == 25) // RIGHT
                {
                    Instantiate(pathRooms[5], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == 15 && transform.position.y == 15) // RIGHT
                {
                    Instantiate(pathRooms[5], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == -15 && transform.position.y == 25) // LEFT
                {
                    Instantiate(pathRooms[4], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == -15 && transform.position.y == 15) // LEFT
                {
                    Instantiate(pathRooms[4], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == -5 && transform.position.y == 5) // BOT
                {
                    Instantiate(pathRooms[7], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == 5 && transform.position.y == 5) // BOT
                {
                    Instantiate(pathRooms[7], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == -15 && transform.position.y == 5) // BotLeft
                {
                    Instantiate(pathRooms[6], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == 15 && transform.position.y == 35) // TopRight
                {
                    Instantiate(pathRooms[3], transform.position, Quaternion.identity);
                }
                else // END
                {
                    if (transform.position.x == 15 && transform.position.y == 5) // End block
                    {
                        Instantiate(pathRooms[1], transform.position, Quaternion.identity);
                    }
                    else // Random Room
                    {
                        int rand = Random.Range(2, 4);
                        Instantiate(rooms[rand], transform.position, Quaternion.identity);
                    }
                }

                //int rand = Random.Range(0, rooms.Length);
                //Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 6);
            }
            else 
            {
                direction = 5;
            }

        }
        else if (direction == 5) // MOVE DOWN!
        {

            downCounter++;

            if (transform.position.y > minY) 
            {

                    // Makes a circle collider that can detect other objects with the physical layer "room" around this spawn point 
                    Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room); // (in this position, 1 unit, anything with room physical layer)
                    if (roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 3) // if the 4 way room not nearby 
                        {

                        if (downCounter >= 2)
                        {
                            roomDetection.GetComponent<RoomType>().RoomDestruction();
                        //Instantiate(rooms[3], transform.position, Quaternion.identity); // room with all directions


                        if (transform.position.x == 15 && transform.position.y == 25) // RIGHT
                        {
                            Instantiate(pathRooms[5], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == 15 && transform.position.y == 15) // RIGHT
                        {
                            Instantiate(pathRooms[5], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == -15 && transform.position.y == 25) // LEFT
                        {
                            Instantiate(pathRooms[4], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == -15 && transform.position.y == 15) // LEFT
                        {
                            Instantiate(pathRooms[4], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == -5 && transform.position.y == 5) // BOT
                        {
                            Instantiate(pathRooms[7], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == 5 && transform.position.y == 5) // BOT
                        {
                            Instantiate(pathRooms[7], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == -15 && transform.position.y == 5) // BotLeft
                        {
                            Instantiate(pathRooms[6], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == 15 && transform.position.y == 35) // TopRight
                        {
                            Instantiate(pathRooms[3], transform.position, Quaternion.identity);
                        }
                        else // END
                        {
                            if (transform.position.x == 15 && transform.position.y == 5) // End block
                            {
                                Instantiate(pathRooms[1], transform.position, Quaternion.identity);
                            }
                            else // Random Room
                            {
                                int rand = Random.Range(2, 4);
                                Instantiate(rooms[rand], transform.position, Quaternion.identity);
                            }
                        }



                    }
                        else 
                        {
                            roomDetection.GetComponent<RoomType>().RoomDestruction();


                            int randBottomRoom = Random.Range(1, 4);
                            if (randBottomRoom == 2)
                            {
                                randBottomRoom = 1;
                            }
                        //Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);

                        if (transform.position.x == 15 && transform.position.y == 25) // RIGHT
                        {
                            Instantiate(pathRooms[5], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == 15 && transform.position.y == 15) // RIGHT
                        {
                            Instantiate(pathRooms[5], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == -15 && transform.position.y == 25) // LEFT
                        {
                            Instantiate(pathRooms[4], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == -15 && transform.position.y == 15) // LEFT
                        {
                            Instantiate(pathRooms[4], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == -5 && transform.position.y == 5) // BOT
                        {
                            Instantiate(pathRooms[7], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == 5 && transform.position.y == 5) // BOT
                        {
                            Instantiate(pathRooms[7], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == -15 && transform.position.y == 5) // BotLeft
                        {
                            Instantiate(pathRooms[6], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == 15 && transform.position.y == 35) // TopRight
                        {
                            Instantiate(pathRooms[3], transform.position, Quaternion.identity);
                        }
                        else 
                        {
                            if (transform.position.x == 15 && transform.position.y == 5) // End block
                            {
                                Instantiate(pathRooms[1], transform.position, Quaternion.identity);
                            }
                            else // Random Room
                            {
                                int rand = Random.Range(2, 4);
                                Instantiate(rooms[rand], transform.position, Quaternion.identity);
                            }
                        }



                    }


                        }


                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;

                //int rand = Random.Range(2, 4);
                //Instantiate(rooms[rand], transform.position, Quaternion.identity);

                if (transform.position.x == 15 && transform.position.y == 25) // RIGHT
                {
                    Instantiate(pathRooms[5], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == 15 && transform.position.y == 15) // RIGHT
                {
                    Instantiate(pathRooms[5], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == -15 && transform.position.y == 25) // LEFT
                {
                    Instantiate(pathRooms[4], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == -15 && transform.position.y == 15) // LEFT
                {
                    Instantiate(pathRooms[4], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == -5 && transform.position.y == 5) // BOT
                {
                    Instantiate(pathRooms[7], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == 5 && transform.position.y == 5) // BOT
                {
                    Instantiate(pathRooms[7], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == -15 && transform.position.y == 5) // BotLeft
                {
                    Instantiate(pathRooms[6], transform.position, Quaternion.identity);
                }
                else if (transform.position.x == 15 && transform.position.y == 35) // TopRight
                {
                    Instantiate(pathRooms[3], transform.position, Quaternion.identity);
                }
                else // END
                {
                    Instantiate(pathRooms[1], transform.position, Quaternion.identity);
                }

                direction = Random.Range(1, 6);
            }
            else
            {
                if (transform.position.x < maxX) // If not at the bottom corner
                {
                    do
                    {
                        downCounter = 0;
                        Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                        transform.position = newPos;

                        //int rand = Random.Range(0, rooms.Length);
                        //Instantiate(rooms[rand], transform.position, Quaternion.identity);

                        // NEW: TEELING THE PATH WHICH LIST OF ROOMS IT CAN CHOOSE FROM
                        if (transform.position.x == -5 && transform.position.y == 35) // TOP
                        {
                            Instantiate(pathRooms[2], transform.position, Quaternion.identity);

                        }
                        else if (transform.position.x == 5 && transform.position.y == 35) // TOP
                        {
                            Instantiate(pathRooms[2], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == 15 && transform.position.y == 25) // RIGHT
                        {
                            Instantiate(pathRooms[5], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == 15 && transform.position.y == 15) // RIGHT
                        {
                            Instantiate(pathRooms[5], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == -15 && transform.position.y == 25) // LEFT
                        {
                            Instantiate(pathRooms[4], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == -15 && transform.position.y == 15) // LEFT
                        {
                            Instantiate(pathRooms[4], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == -5 && transform.position.y == 5) // BOT
                        {
                            Instantiate(pathRooms[7], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == 5 && transform.position.y == 5) // BOT
                        {
                            Instantiate(pathRooms[7], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == -15 && transform.position.y == 5) // BotLeft
                        {
                            Instantiate(pathRooms[6], transform.position, Quaternion.identity);
                        }
                        else if (transform.position.x == 15 && transform.position.y == 35) // TopRight
                        {
                            Instantiate(pathRooms[3], transform.position, Quaternion.identity);
                        }
                        else // END
                        {
                            Instantiate(pathRooms[1], transform.position, Quaternion.identity);
                        }

                        direction = Random.Range(1, 6);
                        if (direction == 3)
                        {
                            direction = 2;
                        }
                        else if (direction == 4)
                        {
                            direction = 5;
                        }
                    } while (transform.position.x < maxX);

                }
                
                // STOP LEVEL GENERATION
                stopGeneration = true;
            }

        }

       // Instantiate(rooms[0], transform.position, Quaternion.identity);
        

    }
}