﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Dialogue : MonoBehaviour
{
    public GameObject ThisObject;
    
    public GameObject TestNPC;
    public GameObject TestNPCTB1;
    public GameObject TestNPCTB2;
    public GameObject TestNPCTB3;
    public int NPCnumber;
    public NPC_Movement npcMoveScript;
    public int pressed = 0;

    public bool once = false;

    // Start is called before the first frame update
    void Start()
    {
        pressed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (npcMoveScript.touchingPlayer == true)
        {

            switch (NPCnumber)
            {
                //Test NPC
                case 1:
                    switch (pressed)
                    {
                        case 0:
                            TestNPCTB1.SetActive(true);
                            break;
                        case 1:
                            TestNPCTB1.SetActive(false);
                            TestNPCTB2.SetActive(true);
                            break;
                        case 2:
                            TestNPCTB2.SetActive(false);
                            TestNPCTB3.SetActive(true);
                            break;
                        case 3:
                            TestNPCTB3.SetActive(false);
                            pressed = 0;
                            NPCnumber = 0;
                            once = false;
                            ThisObject.SetActive(false);
                            break;
                    }
                    break;
            }
        }
        else
        {
            ThisObject.SetActive(false);
            TestNPCTB1.SetActive(false);
            TestNPCTB2.SetActive(false);
            TestNPCTB3.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            pressed++;
        }
    }
}
