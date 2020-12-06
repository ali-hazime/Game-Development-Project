using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBossEnounter : MonoBehaviour
{
    private GameObject player;
    private PlayerChar PlayerScript;
    public GameObject blockUp;
    public GameObject blockDown;
    //public GameObject soul;
    //public FrostKingSoulOne bossScriptSoulOne;
   // public FrostKingSoulTwo bossScriptSoulTwo;
    public GameObject theBossSoulOne;
    public GameObject theBossSoulTwo;
    public bool SoulOneDead = false;
    public bool SoulTwoDead = false;
    public bool soulGone = false;
    public bool sStart = false;
    public bool sEnd = false;
    public bool sSoulTwoStart = false;
    [Space]
    [SerializeField] QuestController questController;
    [SerializeField] UIToggle uiToggle;
    [SerializeField] bool toggleOnce = true;
    [SerializeField] GameObject venkarsCrown;
    public KillBoss killBoss;
    public AudioSource Music;

   
    void Start()
    {
        if (GameSavingInformation.snowBossDefeated == true)
        {
            theBossSoulOne.SetActive(false);
            theBossSoulTwo.SetActive(false);
        }
        else
        {
            theBossSoulOne.SetActive(true);
            theBossSoulTwo.SetActive(true);
        }

        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>().gameObject;
        }
        
        if (uiToggle == null)
        {
            uiToggle = FindObjectOfType<UIToggle>();
        }

        if (!GameSavingInformation.snowBossDefeated && QuestTracker.snowMountainQuestCount > 2)
        {
            QuestTracker.allObjCompleted = false;
        }
        
    }

    private void OnEnable()
    {
        if (PlayerScript == null)
        {
            PlayerScript = FindObjectOfType<PlayerChar>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (sStart == false && sEnd == false)
        {
            if (player.transform.position.y > 62 && !GameSavingInformation.snowBossDefeated)
            {
                StartSBossFight();
            }
        }
        else if (SoulOneDead && sSoulTwoStart == false && soulGone)
        {
            
            StartSBossTwo();

        } else if (SoulTwoDead)
        {
            EndSBossFight();
        }
    }

    void StartSBossFight()
    {
        Music.Play();
        sStart = true;
        blockDown.SetActive(true);
        blockUp.SetActive(false);
        theBossSoulOne.GetComponent<FrostKingSoulOne>().started = true;
    }

    void StartSBossTwo()
    {
        theBossSoulTwo.GetComponent<FrostKingSoulTwo>().started = true;
        sSoulTwoStart = true;

    }

    public void StartSOD()
    {
        StartCoroutine(EndSBossSoulOne());
    }

    IEnumerator EndSBossSoulOne()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(theBossSoulOne);
    }

    void EndSBossFight()
    {
        
        blockDown.SetActive(false);
        Destroy(theBossSoulTwo);
        GameSavingInformation.snowBossDefeated = true;
        StartCoroutine(EndBossQuest());
    }

    IEnumerator EndBossQuest()
    {
        yield return new WaitForSeconds(0.1f);
        if (toggleOnce)
        {
            PlayerScript.playerCurrentHealth += PlayerScript.playerMaxHealth;
            killBoss.UpdateBossStatus();
            yield return new WaitForSeconds(1f);
            uiToggle.ToggleQuestLog();
            toggleOnce = false;
            venkarsCrown.SetActive(true);
        }
    }
}
