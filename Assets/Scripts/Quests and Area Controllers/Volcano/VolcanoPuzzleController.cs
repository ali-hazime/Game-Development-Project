using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoPuzzleController : MonoBehaviour
{
    [SerializeField] GameObject shortcutBlock;
    [SerializeField] GameObject blockOne;
    [SerializeField] GameObject blockTwo;
    [SerializeField] GameObject blockThree;

    private void Start()
    {
        blockOne.SetActive(true);
        blockTwo.SetActive(true);
        blockThree.SetActive(true);
        QuestTracker.blocksWalked = 0;
    }

    private void Update()
    {
        if (QuestTracker.volcanoQuestCount > 2)
        {
            shortcutBlock.SetActive(false);
        }
        else
        {
            shortcutBlock.SetActive(true);
        }

        if (blockOne.activeSelf && QuestTracker.blocksWalked == 7)
        {
            blockOne.SetActive(false);
            QuestTracker.blocksWalked = 0;
        }
        
        if (blockTwo.activeSelf && QuestTracker.blocksWalked == 19)
        {
            blockTwo.SetActive(false);
            QuestTracker.blocksWalked = 0;
        }

        if (blockThree.activeSelf && QuestTracker.blocksWalked == 38)
        {
            blockThree.SetActive(false);
        }
    }


}
