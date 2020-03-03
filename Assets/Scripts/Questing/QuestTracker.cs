using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestTracker
{
    // these values will need to be saved
    public static bool questInProgress = false;
    public static bool bossKilled = false;
    public static bool isKillQuest = false;
    public static bool isItemQuest = false;
    public static bool escortComplete = false;
    public static bool talkToComplete = false;

    public static int killCount = 0;
    public static int itemCount = 0;
    
    public static int grasslandsQuestCount = 0;
    public static int desertQuestCount = 0;
    public static int forestQuestCount = 0;
    public static int snowMountainQuestCount = 0;
    public static int volcanoQuestCount = 0;
}
