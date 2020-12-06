using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerIcon : MonoBehaviour
{
    [SerializeField] GameObject PlayerIconGL;
    [SerializeField] GameObject PlayerIconD;
    [SerializeField] GameObject PlayerIconF;
    [SerializeField] GameObject PlayerIconS;
    [SerializeField] GameObject PlayerIconV;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameSavingInformation.whereAmI == "Cereloth Grasslands" || GameSavingInformation.whereAmI == "Elder House" || GameSavingInformation.whereAmI == "GrasslandsBoss" || GameSavingInformation.whereAmI == "Inside Castle" || GameSavingInformation.whereAmI == "Player House" || GameSavingInformation.whereAmI == "Vendor House")
        {
            PlayerIconGL.SetActive(true);
            PlayerIconD.SetActive(false);
            PlayerIconF.SetActive(false);
            PlayerIconS.SetActive(false);
            PlayerIconV.SetActive(false);
        }
        else if (GameSavingInformation.whereAmI == "Jeralehar Desert" || GameSavingInformation.whereAmI == "Desert Vendor House" || GameSavingInformation.whereAmI == "DesertBoss")
        {
            PlayerIconGL.SetActive(false);
            PlayerIconD.SetActive(true);
            PlayerIconF.SetActive(false);
            PlayerIconS.SetActive(false);
            PlayerIconV.SetActive(false);
        }
        else if (GameSavingInformation.whereAmI == "Thillan Forest" || GameSavingInformation.whereAmI == "ForestBoss" || GameSavingInformation.whereAmI == "ForestVendor")
        {
            PlayerIconGL.SetActive(false);
            PlayerIconD.SetActive(false);
            PlayerIconF.SetActive(true);
            PlayerIconS.SetActive(false);
            PlayerIconV.SetActive(false);
        }
        else if (GameSavingInformation.whereAmI == "Mount Herraweth" || GameSavingInformation.whereAmI == "Snow Vendor" || GameSavingInformation.whereAmI == "SnowCave" || GameSavingInformation.whereAmI == "The Great Tower Boss" || GameSavingInformation.whereAmI == "The Great Tower Puzzle")
        {
            PlayerIconGL.SetActive(false);
            PlayerIconD.SetActive(false);
            PlayerIconF.SetActive(false);
            PlayerIconS.SetActive(true);
            PlayerIconV.SetActive(false);
        }
        else if (GameSavingInformation.whereAmI == "Mount Mortae" || GameSavingInformation.whereAmI == "Volcanic Boss Area" || GameSavingInformation.whereAmI == "Volcanic Caves 1")
        {
            PlayerIconGL.SetActive(false);
            PlayerIconD.SetActive(false);
            PlayerIconF.SetActive(false);
            PlayerIconS.SetActive(false);
            PlayerIconV.SetActive(true);
        }
    }
}
