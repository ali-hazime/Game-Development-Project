using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [SerializeField] GameObject EastRed;
    [SerializeField] GameObject EastBlue;
    [SerializeField] GameObject EastOff;
    [SerializeField] GameObject WestRed;
    [SerializeField] GameObject WestBlue;
    [SerializeField] GameObject WestOff;
    [SerializeField] GameObject NorthRed;
    [SerializeField] GameObject NorthBlue;
    [SerializeField] GameObject NorthOff;
    [SerializeField] GameObject SouthRed;
    [SerializeField] GameObject SouthBlue;
    [SerializeField] GameObject SouthOff;
    [SerializeField] GameObject DN;
    [SerializeField] GameObject DS;
    [SerializeField] GameObject DE;
    [SerializeField] GameObject DW;

    public static int overallCount = 0;
    public int wheresGoodDoor;
    public int wheresBadDoor;
    // Start is called before the first frame update

    //0 = good door
    //1 = bad door
    //2 = null door
    private void Awake()
    {
        EastBlue.SetActive(false);
        EastRed.SetActive(false);
        EastOff.SetActive(false);
        NorthBlue.SetActive(false);
        NorthRed.SetActive(false);
        NorthOff.SetActive(false);
        WestBlue.SetActive(false);
        WestRed.SetActive(false);
        WestOff.SetActive(false);
        SouthBlue.SetActive(false);
        SouthRed.SetActive(false);
        SouthOff.SetActive(false);
    }
    void OnEnable()
    {
       wheresGoodDoor = Random.Range(0, 4);
       wheresBadDoor = Random.Range(0, 3);

        switch (wheresGoodDoor) 
        {
            case 0: //Good North
                DN.GetComponent<DoorNorth>().doorNumber = 0;
                NorthBlue.SetActive(true);
                switch (wheresBadDoor)
                {
                    case 0: //Bad East
                        DS.GetComponent<DoorSouth>().doorNumber = 2;
                        DE.GetComponent<DoorEast>().doorNumber = 1;
                        DW.GetComponent<DoorWest>().doorNumber = 2;
                        EastRed.SetActive(true);
                        WestOff.SetActive(true);
                        SouthOff.SetActive(true);
                        break;
                    case 1: //Bad West
                        DS.GetComponent<DoorSouth>().doorNumber = 2;
                        DE.GetComponent<DoorEast>().doorNumber = 2;
                        DW.GetComponent<DoorWest>().doorNumber = 1;
                        EastOff.SetActive(true);
                        WestRed.SetActive(true);
                        SouthOff.SetActive(true);
                        break;
                    case 2: //Bad South
                        DS.GetComponent<DoorSouth>().doorNumber = 1;
                        DE.GetComponent<DoorEast>().doorNumber = 2;
                        DW.GetComponent<DoorWest>().doorNumber = 2;
                        EastOff.SetActive(true);
                        WestOff.SetActive(true);
                        SouthRed.SetActive(true);
                        break;
                }
                break;
            case 1: //Good South
                DS.GetComponent<DoorSouth>().doorNumber = 0;
                SouthBlue.SetActive(true);
                switch (wheresBadDoor)
                {
                    case 0: //Bad East
                        DN.GetComponent<DoorNorth>().doorNumber = 2;
                        DE.GetComponent<DoorEast>().doorNumber = 1;
                        DW.GetComponent<DoorWest>().doorNumber = 2;
                        EastRed.SetActive(true);
                        WestOff.SetActive(true);
                        NorthOff.SetActive(true);
                        break;
                    case 1: //Bad West
                        DN.GetComponent<DoorNorth>().doorNumber = 2;
                        DE.GetComponent<DoorEast>().doorNumber = 2;
                        DW.GetComponent<DoorWest>().doorNumber = 1;
                        EastOff.SetActive(true);
                        WestRed.SetActive(true);
                        NorthOff.SetActive(true);
                        break;
                    case 2: //Bad North
                        DN.GetComponent<DoorNorth>().doorNumber = 1;
                        DE.GetComponent<DoorEast>().doorNumber = 2;
                        DW.GetComponent<DoorWest>().doorNumber = 2;
                        EastOff.SetActive(true);
                        WestOff.SetActive(true);
                        NorthRed.SetActive(true);
                        break;
                }
                break;
            case 2: //Good East
                DE.GetComponent<DoorEast>().doorNumber = 0;
                EastBlue.SetActive(true);
                switch (wheresBadDoor)
                {
                    case 0: //Bad North
                        DN.GetComponent<DoorNorth>().doorNumber = 1;
                        DS.GetComponent<DoorSouth>().doorNumber = 2;
                        DW.GetComponent<DoorWest>().doorNumber = 2;
                        SouthOff.SetActive(true);
                        WestOff.SetActive(true);
                        NorthRed.SetActive(true);
                        break;
                    case 1: //Bad West
                        DS.GetComponent<DoorSouth>().doorNumber = 2;
                        DN.GetComponent<DoorNorth>().doorNumber = 2;
                        DW.GetComponent<DoorWest>().doorNumber = 1;
                        SouthOff.SetActive(true);
                        WestRed.SetActive(true);
                        NorthOff.SetActive(true);
                        break;
                    case 2: //Bad South
                        DS.GetComponent<DoorSouth>().doorNumber = 1;
                        DN.GetComponent<DoorNorth>().doorNumber = 2;
                        DW.GetComponent<DoorWest>().doorNumber = 2;
                        SouthRed.SetActive(true);
                        WestOff.SetActive(true);
                        NorthOff.SetActive(true);
                        break;
                }
                break;
            case 3: //Good West
                DW.GetComponent<DoorWest>().doorNumber = 0;
                WestBlue.SetActive(true);
                switch (wheresBadDoor)
                {
                    case 0: //Bad East
                        DS.GetComponent<DoorSouth>().doorNumber = 2;
                        DE.GetComponent<DoorEast>().doorNumber = 1;
                        DN.GetComponent<DoorNorth>().doorNumber = 2;
                        SouthOff.SetActive(true);
                        EastRed.SetActive(true);
                        NorthOff.SetActive(true);
                        break;
                    case 1: //Bad North
                        DN.GetComponent<DoorNorth>().doorNumber = 1;
                        DE.GetComponent<DoorEast>().doorNumber = 2;
                        DS.GetComponent<DoorSouth>().doorNumber = 2;
                        SouthOff.SetActive(true);
                        EastOff.SetActive(true);
                        NorthRed.SetActive(true);
                        break;
                    case 2: //Bad South
                        DS.GetComponent<DoorSouth>().doorNumber = 1;
                        DE.GetComponent<DoorEast>().doorNumber = 2;
                        DN.GetComponent<DoorNorth>().doorNumber = 2;
                        SouthRed.SetActive(true);
                        EastOff.SetActive(true);
                        NorthOff.SetActive(true);
                        break;
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
