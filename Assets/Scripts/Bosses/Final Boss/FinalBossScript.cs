using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBossScript : MonoBehaviour
{
    private PlayerChar player;
    [SerializeField] ItemSaveManager itemSaveManager;
    [SerializeField] InventoryManager inventoryManager;
    private Transform playerTarget;
    private Animator anim;
    public Transform firePoint;
    public FinalBossHealth bossStats;
    public GameObject ShadowBoltPrefab;
    public GameObject VoidOrbPrefab;
    public GameObject AbilitiesParent;
    [Space]
    public bool isStarted = false;
    public bool dead = false;
    public bool doingSomething = false;
    [Space]
    public float speed = 0;
    public float phase2Start = 0.2f;
    public float phase3Start = 0.5f;
    [Space]
    //Basic Attacks
    public bool shadowBoltOnCD = false;
    public float shadowBoltCD;
    [Space]
    public bool phase2 = false;
    [Space]
    public bool phase3 = false;
    [Space]
    public bool isPinned = false;
    private Vector3 dir;
    private Vector3 offsetPos;
    // Start is called before the first frame update
    void Start()
    {
        if (itemSaveManager == null)
        {
            itemSaveManager = FindObjectOfType<ItemSaveManager>();
        }

        if (inventoryManager == null)
        {
            inventoryManager = FindObjectOfType<InventoryManager>();
        }
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
        if (playerTarget == null)
        {
            playerTarget = FindObjectOfType<PlayerChar>().transform;
        }
        anim = GetComponent<Animator>();

        bossStats = GetComponent<FinalBossHealth>();
    }

    private void Update()
    {
        dir = (playerTarget.position - transform.position).normalized;
        offsetPos = playerTarget.position + (dir * 1.5f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStarted)
        {
            if (doingSomething == false && isPinned == false)
            {
                anim.SetBool("isMoving", true);
                transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, 2.5f * Time.deltaTime);
            }

            if (phase2 == false && (float)bossStats.currentHealth / (float)bossStats.maxHealth < phase2Start)
            {
                phase2 = true;
                bossStats.maxHealth = 500;
                bossStats.currentHealth = 500;
                GameSavingInformation.whereAmI = "Void Realm";
                GameSavingInformation.whereWasI = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("Void Realm");
                GameSavingInformation.playerX = 21.5f;
                GameSavingInformation.playerY = -19f;
                SaveSystem.SavePlayer(player);
                SaveSystem.SaveGameInfo();
                SaveSystem.SaveQuestInfo();
                itemSaveManager.SaveEquipment(inventoryManager);
                itemSaveManager.SaveInventory(inventoryManager);
            }
            else if (phase2 && phase3 == false && (float)bossStats.currentHealth / (float)bossStats.maxHealth < phase3Start)
            {
                phase3 = true;
            }

            anim.SetFloat("speed", speed);

            if (Mathf.Abs(playerTarget.position.y - transform.position.y) > Mathf.Abs(playerTarget.position.x - transform.position.x))
            {
                anim.SetFloat("moveX", 0f);
                anim.SetFloat("moveY", (playerTarget.position.y - transform.position.y));
                anim.SetBool("moveVert", true);
                speed = playerTarget.position.y - transform.position.y;
            }
            else
            {
                anim.SetFloat("moveX", (playerTarget.position.x - transform.position.x));
                anim.SetFloat("moveY", 0f);
                anim.SetBool("moveVert", false);
                speed = playerTarget.position.x - transform.position.x;
            }

            if (shadowBoltOnCD == false)
            {
                StartCoroutine(FireShadowBolt());
            }
        }

        RaycastHit2D wallCheck = Physics2D.Linecast(transform.position, offsetPos, 1 << 15);
        RaycastHit2D playerCheck = Physics2D.Linecast(transform.position, offsetPos, 1 << 8);

        if (wallCheck.collider != null && playerCheck.collider != null && Vector3.Distance(playerTarget.position, transform.position) < 3)
        {
            isPinned = true;
            anim.SetBool("isMoving", false);
            player.PlayerPinned(true);
            Debug.DrawLine(transform.position, offsetPos, Color.yellow);
        }
        else
        {
            isPinned = false;
            player.PlayerPinned(false);
            Debug.DrawLine(transform.position, offsetPos, Color.cyan);
        }

    }

    IEnumerator FireShadowBolt()
    {
        shadowBoltOnCD = true;
        GameObject ShadowBolt = Instantiate(ShadowBoltPrefab, transform.position, transform.rotation);
        ShadowBolt.transform.parent = AbilitiesParent.transform;
        Rigidbody2D rb = ShadowBolt.GetComponent<Rigidbody2D>();
        rb.velocity = (playerTarget.position - transform.position).normalized * 5f;
        yield return new WaitForSeconds(shadowBoltCD);
        shadowBoltOnCD = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            anim.SetBool("isMoving", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("isMoving", true);
    }
}
