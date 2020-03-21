using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGameController : MonoBehaviour
{
    [SerializeField] GameObject SnowBlock;
    [SerializeField] GameObject DoorIntoTower;
    [SerializeField] GameObject The_Chief;
    [SerializeField] GameObject S_TF_1;
    [SerializeField] GameObject S_TF_2;
    [SerializeField] GameObject S_TF_3;
    [SerializeField] GameObject S_TF_4;
    [SerializeField] GameObject S_TF_5;
    [SerializeField] UIToggle uiToggle;
    //[SerializeField] bool toggleOnce = true;
    [SerializeField] QuestController questController;
    [SerializeField] GameObject NPCsParent;
    [SerializeField] GameObject Corruption;

    [SerializeField] GameObject S_Chief;
    [SerializeField] GameObject S_NPC1;
    [SerializeField] GameObject S_NPC2;
    [SerializeField] GameObject S_NPC3;
    [SerializeField] GameObject S_NPC4;
    [SerializeField] GameObject S_NPC5;

    [SerializeField] NPC_Chief theChief;
    [SerializeField] NPC_Script Script_NPC1;
    [SerializeField] NPC_Script Script_NPC2;
    [SerializeField] NPC_Script Script_NPC3;
    [SerializeField] NPC_Script Script_NPC4;
    [SerializeField] NPC_Script Script_NPC5;

    void Awake()
    {
        S_Chief = Instantiate(The_Chief, new Vector3(145, 53, 0), transform.rotation);
        S_Chief.transform.parent = NPCsParent.transform;

        S_NPC1 = Instantiate(S_TF_1, new Vector3(230.25f, 37.75f, 0), transform.rotation);
        S_NPC1.transform.parent = NPCsParent.transform;

        S_NPC2 = Instantiate(S_TF_2, new Vector3(230.5f, 24.25f, 0), transform.rotation);
        S_NPC2.transform.parent = NPCsParent.transform;

        S_NPC3 = Instantiate(S_TF_3, new Vector3(240.25f, 28.5f, 0), transform.rotation);
        S_NPC3.transform.parent = NPCsParent.transform;

        S_NPC4 = Instantiate(S_TF_4, new Vector3(208.25f, 13.5f, 0), transform.rotation);
        S_NPC4.transform.parent = NPCsParent.transform;

        S_NPC5 = Instantiate(S_TF_5, new Vector3(232.5f, 50.75f, 0), transform.rotation);
        S_NPC5.transform.parent = NPCsParent.transform;

        if (questController == null)
        {
            questController = FindObjectOfType<QuestController>();
        }

        if (uiToggle == null)
        {
            uiToggle = FindObjectOfType<UIToggle>();
        }
    }

    // Update is called once per frame
    private void Start()
    {
        theChief = S_Chief.GetComponent<NPC_Chief>();
        Script_NPC1 = S_NPC1.GetComponent<NPC_Script>();
        Script_NPC2 = S_NPC2.GetComponent<NPC_Script>();
        Script_NPC3 = S_NPC3.GetComponent<NPC_Script>();
        Script_NPC4 = S_NPC4.GetComponent<NPC_Script>();
        Script_NPC5 = S_NPC5.GetComponent<NPC_Script>();
    }
    void Update()
    {
        if (QuestTracker.snowMountainQuestCount > 2)
        {
            Corruption.SetActive(false);
            DoorIntoTower.SetActive(true);
            SnowBlock.SetActive(false);
            theChief.NPC_Number = 66;
            Script_NPC1.NPC_Number = 68;
            Script_NPC2.NPC_Number = 70;
            Script_NPC3.NPC_Number = 72;
            Script_NPC4.NPC_Number = 74;
            Script_NPC5.NPC_Number = 75;
        }
        else if (QuestTracker.snowMountainQuestCount == 2)
        {
            Corruption.SetActive(true);
            DoorIntoTower.SetActive(true);
            SnowBlock.SetActive(false);
            theChief.NPC_Number = 65;
            Script_NPC1.NPC_Number = 67;
            Script_NPC2.NPC_Number = 69;
            Script_NPC3.NPC_Number = 71;
            Script_NPC4.NPC_Number = 73;
            Script_NPC5.NPC_Number = 75; 
        }
        else if (QuestTracker.snowMountainQuestCount == 1)
        {
            Corruption.SetActive(true);
            DoorIntoTower.SetActive(true);
            SnowBlock.SetActive(false);
            theChief.NPC_Number = 65;
            Script_NPC1.NPC_Number = 67;
            Script_NPC2.NPC_Number = 69;
            Script_NPC3.NPC_Number = 71;
            Script_NPC4.NPC_Number = 73;
            Script_NPC5.NPC_Number = 75;
        }
        else if (QuestTracker.snowMountainQuestCount == 0)
        {
            Corruption.SetActive(true);
            DoorIntoTower.SetActive(false);
            SnowBlock.SetActive(true);
            theChief.NPC_Number = 65;
            Script_NPC1.NPC_Number = 67;
            Script_NPC2.NPC_Number = 69;
            Script_NPC3.NPC_Number = 71;
            Script_NPC4.NPC_Number = 73;
            Script_NPC5.NPC_Number = 75;
        }
    }
}
