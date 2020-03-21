using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Dialogue : MonoBehaviour
{

    [SerializeField] GameObject[][] Boxes;
    [Space]
    [SerializeField] GameObject[] NPC0_TB;
    [SerializeField] GameObject[] NPC1_TB;
    [SerializeField] GameObject[] NPC2_TB;
    [SerializeField] GameObject[] NPC3_TB;
    [SerializeField] GameObject[] NPC4_TB;
    [SerializeField] GameObject[] NPC5_TB;
    [SerializeField] GameObject[] NPC6_TB;
    [SerializeField] GameObject[] NPC7_TB;
    [SerializeField] GameObject[] NPC8_TB;
    [SerializeField] GameObject[] NPC9_TB;
    [SerializeField] GameObject[] NPC10_TB;
    [SerializeField] GameObject[] NPC11_TB;
    [SerializeField] GameObject[] NPC12_TB;
    [SerializeField] GameObject[] NPC13_TB;
    [SerializeField] GameObject[] NPC14_TB;
    [SerializeField] GameObject[] NPC15_TB;
    [SerializeField] GameObject[] NPC16_TB;
    [SerializeField] GameObject[] NPC17_TB;
    [SerializeField] GameObject[] NPC18_TB;
    [SerializeField] GameObject[] NPC19_TB;
    [SerializeField] GameObject[] NPC20_TB;
    [SerializeField] GameObject[] NPC21_TB;
    [SerializeField] GameObject[] NPC22_TB;
    [SerializeField] GameObject[] NPC23_TB;
    [SerializeField] GameObject[] NPC24_TB;
    [SerializeField] GameObject[] NPC25_TB;
    [SerializeField] GameObject[] NPC26_TB;
    [SerializeField] GameObject[] NPC27_TB;
    [SerializeField] GameObject[] NPC28_TB;
    [SerializeField] GameObject[] NPC29_TB;
    [SerializeField] GameObject[] NPC30_TB;
    [SerializeField] GameObject[] NPC31_TB;
    [SerializeField] GameObject[] NPC32_TB;
    [SerializeField] GameObject[] NPC33_TB;
    [SerializeField] GameObject[] NPC34_TB;
    [SerializeField] GameObject[] NPC35_TB;
    [SerializeField] GameObject[] NPC36_TB;
    [SerializeField] GameObject[] NPC37_TB;
    [SerializeField] GameObject[] NPC38_TB;
    [SerializeField] GameObject[] NPC39_TB;
    [SerializeField] GameObject[] NPC40_TB;
    [SerializeField] GameObject[] NPC41_TB;
    [SerializeField] GameObject[] NPC42_TB;
    [SerializeField] GameObject[] NPC43_TB;
    [SerializeField] GameObject[] NPC44_TB;
    [SerializeField] GameObject[] NPC45_TB;
    [SerializeField] GameObject[] NPC46_TB;
    [SerializeField] GameObject[] NPC47_TB;
    [SerializeField] GameObject[] NPC48_TB;
    [SerializeField] GameObject[] NPC49_TB;
    [SerializeField] GameObject[] NPC50_TB;
    [SerializeField] GameObject[] NPC51_TB;
    [SerializeField] GameObject[] NPC52_TB;
    [SerializeField] GameObject[] NPC53_TB;
    [SerializeField] GameObject[] NPC54_TB;
    [SerializeField] GameObject[] NPC55_TB;
    [SerializeField] GameObject[] NPC56_TB;
    [SerializeField] GameObject[] NPC57_TB;
    [SerializeField] GameObject[] NPC58_TB;
    [SerializeField] GameObject[] NPC59_TB;
    [SerializeField] GameObject[] NPC60_TB;
    [SerializeField] GameObject[] NPC61_TB;
    [SerializeField] GameObject[] NPC62_TB;
    [SerializeField] GameObject[] NPC63_TB;
    [SerializeField] GameObject[] NPC64_TB;
    [SerializeField] GameObject[] NPC65_TB;
    [SerializeField] GameObject[] NPC66_TB;
    [SerializeField] GameObject[] NPC67_TB;
    [SerializeField] GameObject[] NPC68_TB;
    [SerializeField] GameObject[] NPC69_TB;
    [SerializeField] GameObject[] NPC70_TB;
    [SerializeField] GameObject[] NPC71_TB;
    [SerializeField] GameObject[] NPC72_TB;
    [SerializeField] GameObject[] NPC73_TB;
    [SerializeField] GameObject[] NPC74_TB;
    [SerializeField] GameObject[] NPC75_TB;
    [SerializeField] GameObject[] NPC76_TB;
    [SerializeField] GameObject[] NPC77_TB;
    [SerializeField] GameObject[] NPC78_TB;
    [SerializeField] GameObject[] NPC79_TB;
    [Space]
    public int pressed = 0;
    public int zCount = 0;
    private int NPC_N;
    private bool chatting = false;
    private bool nextBad = false;
    public bool once = false;

    private void Awake()
    {
        Boxes = new GameObject[80][]
        {
            new GameObject[2]{NPC0_TB[0], NPC0_TB[1]}, //Player Wife = 0 - DONE
            new GameObject[1]{NPC1_TB[0]}, //Player Wife = 1 - DONE
            new GameObject[1]{NPC2_TB[0]}, //ToolTip Interact = 2 - DONE
            new GameObject[2]{NPC3_TB[0], NPC3_TB[1]}, //ToolTip Inventory = 3 - DONE
            new GameObject[1]{NPC4_TB[0]}, //ToolTip Equip = 4 - DONE
            new GameObject[2]{NPC5_TB[0], NPC5_TB[1]}, //North Bridge Guard = 5 - DONE
            new GameObject[2]{NPC6_TB[0], NPC6_TB[1]}, //GL Elder = 6 - DONE
            new GameObject[2]{NPC7_TB[0], NPC7_TB[1]}, //GL Elder = 7 - DONE
            new GameObject[8]{NPC8_TB[0], NPC8_TB[1], NPC8_TB[2], NPC8_TB[3], NPC8_TB[4], NPC8_TB[5], NPC8_TB[6], NPC8_TB[7]}, //GL Elder = 8 - DONE
            new GameObject[2]{NPC9_TB[0], NPC9_TB[1]}, //South Bridge Guard = 9 - DONE
            new GameObject[2]{NPC10_TB[0], NPC10_TB[1]}, //South Bridge Guard = 10 - DONE
            new GameObject[1]{NPC11_TB[0]}, //South/North Bridge Guard = 11 - DONE
            new GameObject[3]{NPC12_TB[0], NPC12_TB[1], NPC12_TB[2]}, //GL Elder = 12 - DONE
            new GameObject[1]{NPC13_TB[0]}, //Guard in Elder house (called in elder script) = 13 - DONE
            new GameObject[1]{NPC14_TB[0]}, //GL Sign 1 = 14
            new GameObject[1]{NPC15_TB[0]}, //GL Sign 2 = 15
            new GameObject[1]{NPC16_TB[0]}, //GL Sign 3 = 16
            new GameObject[1]{NPC17_TB[0]}, //GL Sign 4 = 17
            new GameObject[1]{NPC18_TB[0]}, //GL Sign 5 = 18
            new GameObject[1]{NPC19_TB[0]}, //GL Sign 6 = 19
            new GameObject[1]{NPC20_TB[0]}, //GL Sign 7 = 20
            new GameObject[1]{NPC21_TB[0]}, //GL Sign 8 = 21
            new GameObject[2]{NPC22_TB[0], NPC22_TB[1]}, //TownFolk_1 = 22
            new GameObject[1]{NPC23_TB[0]}, //TownFolk_1 = 23
            new GameObject[2]{NPC24_TB[0], NPC24_TB[1]}, //TownFolk_2 = 24
            new GameObject[1]{NPC25_TB[0]}, //TownFolk_2 = 25
            new GameObject[1]{NPC26_TB[0]}, //TownFolk_3 = 26
            new GameObject[2]{NPC27_TB[0], NPC27_TB[1]}, //TownFolk_3 = 27
            new GameObject[2]{NPC28_TB[0],NPC28_TB[1]}, //TownFolk_4 = 28
            new GameObject[2]{NPC29_TB[0],NPC29_TB[1]}, //TownFolk_4 = 29
            new GameObject[1]{NPC30_TB[0]}, //TownFolk_5 = 30
            new GameObject[2]{NPC31_TB[0], NPC31_TB[1]}, //TownFolk_5 = 31
            new GameObject[2]{NPC32_TB[0], NPC32_TB[1]}, //TownFolk_6 = 32
            new GameObject[1]{NPC33_TB[0]}, //TownFolk_7 = 33
            new GameObject[4]{NPC34_TB[0], NPC34_TB[1], NPC34_TB[2], NPC34_TB[3]}, //TownFolk_8 = 34
            new GameObject[1]{NPC35_TB[0]}, //TownFolk_9 = 35
            new GameObject[1]{NPC36_TB[0]}, //TownFolk_10 = 36
            new GameObject[1]{NPC37_TB[0]}, //DesertTownFolk_1 = 37
            new GameObject[1]{NPC38_TB[0]}, //DesertTownFolk_1 = 38
            new GameObject[1]{NPC39_TB[0]}, //DesertTownFolk_3 = 39
            new GameObject[1]{NPC40_TB[0]}, //DesertTownFolk_3 = 40
            new GameObject[3]{NPC41_TB[0], NPC41_TB[1], NPC41_TB[2]}, //DesertTownFolk_2 = 41
            new GameObject[2]{NPC42_TB[0], NPC42_TB[1]}, //DesertTownFolk_2 = 42
            new GameObject[1]{NPC43_TB[0]}, //DesertTownFolk_2 = 43
            new GameObject[3]{NPC44_TB[0], NPC44_TB[1], NPC44_TB[2]}, //QuestFourDSC = 44
            new GameObject[2]{NPC45_TB[0], NPC45_TB[1]}, //DesertStranded_0 = 45
            new GameObject[2]{NPC46_TB[0], NPC46_TB[1]}, //DesertStranded_0 = 46
            new GameObject[1]{NPC47_TB[0]}, //DesertStranded_1 = 47
            new GameObject[9]{NPC48_TB[0], NPC48_TB[1], NPC48_TB[2], NPC48_TB[3], NPC48_TB[4], NPC48_TB[5], NPC48_TB[6], NPC48_TB[7], NPC48_TB[8]}, //GL Elder = 48
            new GameObject[14]{NPC49_TB[0], NPC49_TB[1], NPC49_TB[2], NPC49_TB[3], NPC49_TB[4], NPC49_TB[5], NPC49_TB[6], NPC49_TB[7], NPC49_TB[8], NPC49_TB[9], NPC49_TB[10], NPC49_TB[11], NPC49_TB[12], NPC49_TB[13]}, //Forest Shaman = 49
            new GameObject[2]{NPC50_TB[0], NPC50_TB[1]}, //Forest Shaman = 50
            new GameObject[2]{NPC51_TB[0], NPC51_TB[1]}, //Forest Shaman = 51
            new GameObject[2]{NPC52_TB[0], NPC52_TB[1]}, //Forest Shaman = 52
            new GameObject[1]{NPC53_TB[0]}, //Forest Shaman = 53
            new GameObject[2]{NPC54_TB[0], NPC54_TB[1]}, //Forest Shaman = 54
            new GameObject[1]{NPC55_TB[0]}, //Forest_Villager_1 = 55
            new GameObject[1]{NPC56_TB[0]}, //Forest_Villager_1 = 56
            new GameObject[1]{NPC57_TB[0]}, //Forest_Villager_2 = 57
            new GameObject[1]{NPC58_TB[0]}, //Forest_Villager_2 = 58
            new GameObject[1]{NPC59_TB[0]}, //Forest_Villager_3 = 59
            new GameObject[1]{NPC60_TB[0]}, //Forest_Villager_3 = 60
            new GameObject[1]{NPC61_TB[0]}, //Forest_Villager_4 = 61
            new GameObject[1]{NPC62_TB[0]}, //Forest_Villager_4 = 62
            new GameObject[1]{NPC63_TB[0]}, //Forest_Villager_5 = 63
            new GameObject[1]{NPC64_TB[0]}, //Forest_Villager_5 = 64
            new GameObject[5]{NPC65_TB[0], NPC65_TB[1], NPC65_TB[2], NPC65_TB[3], NPC65_TB[4]}, //The_Chief = 65
            new GameObject[1]{NPC66_TB[0]}, //The_Chief = 66
            new GameObject[1]{NPC67_TB[0]}, //Snow_Tribesman_1 = 67
            new GameObject[1]{NPC68_TB[0]}, //Snow_Tribesman_1 = 68
            new GameObject[1]{NPC69_TB[0]}, //Snow_Tribesman_2 = 69
            new GameObject[1]{NPC70_TB[0]}, //Snow_Tribesman_2 = 70
            new GameObject[1]{NPC71_TB[0]}, //Snow_Tribesman_3 = 71
            new GameObject[1]{NPC72_TB[0]}, //Snow_Tribesman_3 = 72
            new GameObject[1]{NPC73_TB[0]}, //Snow_Tribesman_4 = 73
            new GameObject[1]{NPC74_TB[0]}, //Snow_Tribesman_4 = 74
            new GameObject[1]{NPC75_TB[0]}, //Snow_Tribesman_5 = 75
            new GameObject[1]{NPC76_TB[0]}, // First Sh,aman Interaction = 76
            new GameObject[2]{NPC77_TB[0], NPC77_TB[1]}, //NPC_Explainer = 77
            new GameObject[1]{NPC78_TB[0]}, //NPC_Explainer = 78
            new GameObject[3]{NPC79_TB[0], NPC79_TB[1], NPC79_TB[2]} //Final Boss Text = 79

        };

        zCount = 0;
        pressed = 0;
        once = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        /*
        Boxes = new GameObject[14][]
        {
            new GameObject[2]{NPC0_TB[0], NPC0_TB[1]}, //Player Wife = 0 - DONE
            new GameObject[1]{NPC1_TB[0]}, //Player Wife = 1 - DONE
            new GameObject[1]{NPC2_TB[0]}, //ToolTip Interact = 2 - DONE
            new GameObject[2]{NPC3_TB[0], NPC3_TB[1]}, //ToolTip Inventory = 3 - DONE
            new GameObject[1]{NPC4_TB[0]}, //ToolTip Equip = 4 - DONE
            new GameObject[2]{NPC5_TB[0], NPC5_TB[1]}, //North Bridge Guard = 5 - DONE
            new GameObject[2]{NPC6_TB[0], NPC6_TB[1]}, //GL Elder = 6 - DONE
            new GameObject[2]{NPC7_TB[0], NPC7_TB[1]}, //GL Elder = 7 - DONE
            new GameObject[8]{NPC8_TB[0], NPC8_TB[1], NPC8_TB[2], NPC8_TB[3], NPC8_TB[4], NPC8_TB[5], NPC8_TB[6], NPC8_TB[7]}, //GL Elder = 8 - DONE
            new GameObject[2]{NPC9_TB[0], NPC9_TB[1]}, //South Bridge Guard = 9 - DONE
            new GameObject[2]{NPC10_TB[0], NPC10_TB[1]}, //South Bridge Guard = 10 - DONE
            new GameObject[1]{NPC11_TB[0]}, //South/North Bridge Guard = 11 - DONE
            new GameObject[3]{NPC12_TB[0], NPC12_TB[1], NPC12_TB[2]}, //GL Elder = 12 - DONE
            new GameObject[1]{NPC13_TB[0]} //Guard in Elder house (called in elder script) - DONE
        };
        */
        zCount = 0;
        pressed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (once == true)
        {
            Convo();
            if (pressed + 1 == Boxes[NPC_N].Length)
            {
                nextBad = true;
            }
            once = false;
        }
        else if (Input.GetKeyDown(KeyCode.Z) && chatting == true && nextBad == false)
        {
            zCount++;
            Boxes[NPC_N][pressed].SetActive(false);
            pressed++;
            if (pressed+1 == Boxes[NPC_N].Length)
            {
                nextBad = true;
            }

            Convo();
        }
        else if (Input.GetKeyDown(KeyCode.Z) && chatting == true && nextBad == true)
        {
            zCount++;
            Boxes[NPC_N][pressed].SetActive(false);
            //once = true;
            this.gameObject.SetActive(false);
        }
    }

    public void ConvoReset(int NPC_Number, int pressedReset)
    {
        if (pressedReset == 0)
        {
            zCount = 0;
            Boxes[NPC_N][pressed].SetActive(false);
            nextBad = false;
            pressed = 0;
            
        }
        chatting = true;
        NPC_N = NPC_Number;
    }

    public void Convo()
    {
        Boxes[NPC_N][pressed].SetActive(true);
    }
}
