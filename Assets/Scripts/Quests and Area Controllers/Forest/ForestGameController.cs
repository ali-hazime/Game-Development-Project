using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestGameController : MonoBehaviour
{
    [SerializeField] UIToggle uiToggle;
    //[SerializeField] bool toggleOnce = true;
    [SerializeField] QuestController questController;
    [SerializeField] GameObject NPCsParent;
    [SerializeField] GameObject Corruption;
    [SerializeField] GameObject worldCorruption;

    [SerializeField] GameObject F_V_1;
    [SerializeField] GameObject F_V_2;
    [SerializeField] GameObject F_V_3;
    [SerializeField] GameObject F_V_4;
    [SerializeField] GameObject F_V_5;

    [SerializeField] GameObject F_NPC1;
    [SerializeField] GameObject F_NPC2;
    [SerializeField] GameObject F_NPC3;
    [SerializeField] GameObject F_NPC4;
    [SerializeField] GameObject F_NPC5;

    //[SerializeField] NPC_Script Script_Chief;
    [SerializeField] NPC_Script Script_NPC1;
    [SerializeField] NPC_Script Script_NPC2;
    [SerializeField] NPC_Script Script_NPC3;
    [SerializeField] NPC_Script Script_NPC4;
    [SerializeField] NPC_Script Script_NPC5;

    // Start is called before the first frame update
    void Awake()
    {
        F_NPC1 = Instantiate(F_V_1, new Vector3(30f, 83.5f, 0), transform.rotation);
        F_NPC1.transform.parent = NPCsParent.transform;

        F_NPC2 = Instantiate(F_V_2, new Vector3(49.5f, 81f, 0), transform.rotation);
        F_NPC2.transform.parent = NPCsParent.transform;

        F_NPC3 = Instantiate(F_V_3, new Vector3(53f, 63.5f, 0), transform.rotation);
        F_NPC3.transform.parent = NPCsParent.transform;

        F_NPC4 = Instantiate(F_V_4, new Vector3(60f, 75f, 0), transform.rotation);
        F_NPC4.transform.parent = NPCsParent.transform;

        F_NPC5 = Instantiate(F_V_5, new Vector3(62.5f, 87.25f, 0), transform.rotation);
        F_NPC5.transform.parent = NPCsParent.transform;

        if (questController == null)
        {
            questController = FindObjectOfType<QuestController>();
        }

        if (uiToggle == null)
        {
            uiToggle = FindObjectOfType<UIToggle>();
        }
    }

    private void Start()
    {
        Script_NPC1 = F_NPC1.GetComponent<NPC_Script>();
        Script_NPC2 = F_NPC2.GetComponent<NPC_Script>();
        Script_NPC3 = F_NPC3.GetComponent<NPC_Script>();
        Script_NPC4 = F_NPC4.GetComponent<NPC_Script>();
        Script_NPC5 = F_NPC5.GetComponent<NPC_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (QuestTracker.forestQuestCount > 3)
        {
            worldCorruption.SetActive(false);
            Corruption.SetActive(false);
            Script_NPC1.NPC_Number = 56;
            Script_NPC2.NPC_Number = 58;
            Script_NPC3.NPC_Number = 60;
            Script_NPC4.NPC_Number = 62;
            Script_NPC5.NPC_Number = 64;
        }
        else if (QuestTracker.forestQuestCount < 3)
        {
            worldCorruption.SetActive(false);
            Corruption.SetActive(true);
            Script_NPC1.NPC_Number = 55;
            Script_NPC2.NPC_Number = 57;
            Script_NPC3.NPC_Number = 59;
            Script_NPC4.NPC_Number = 61;
            Script_NPC5.NPC_Number = 63;
        }
    }
}
