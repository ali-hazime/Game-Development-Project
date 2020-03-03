using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This is all the stats for the player's character
public class PlayerChar : MonoBehaviour
{
    //Game objects
    public GameObject stunIndicator;
    public GameObject poisonIndicator;
    public GameObject nadoSpin;
    public GameObject fireNadoSpin;
    public GameObject fearInd;
    public GameObject slowIndicator;
    public GameObject burnIndicator;
    public Transform statusIndicatorPoint;
    
    [Space]
    //player sprite and movement
    private Rigidbody2D rb;
    private Vector2 move;
    public Animator animator;
    private float attackTime = 0.3f;
    private float attackCounter = 0.3f;
    public bool isAttacking;
    public bool swordEquipped;
    public bool staffEquipped;
    [Space]
    //Players main stats
    public int playerCurrentHealth;
    public int playerMaxHealth;
    public float playerMovementSpeed;
    public int playerAttackDamage;
    public int playerAbilityPower;
    public float playerAttackSpeed;
    public int playerArmour;
    public int playerDamage;
    public float playerMagicFind;
    private float tempSpeed;
    [Space]
    public float timer = 0;
    public bool walkLeft = false;
    public bool walkRight = false;
    public bool walkSouth = false;
    public bool walkNorth = false;
    public bool cancel = false;
    public bool isFeared = false;
    [Space]
    public float stunTime;
    public float spinTime;
    public bool isSpin;
    public float slowTime;
    public float _slowFactor;
    [Space]
    public float burnTime;
    public int _burnDamage;
    public bool isBurning;
    public float burnCounter;
    [Space]
    //Debuffs
    public float poisonTimer = 0;
    public float poisonDOTclock = 0;
    public bool isPoisoned = false;
    public bool isSlowed = false;
    public bool _isPinned = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        poisonIndicator.SetActive(false);
        slowIndicator.SetActive(false);
        burnIndicator.SetActive(false);
}


    private void Update()
    {
        
        if (playerCurrentHealth > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }

        if (isPoisoned)
        {
            poisonTimer -= Time.deltaTime;
            if (poisonTimer <= 0)
            {
                isPoisoned = false;
            }

            poisonDOTclock += Time.deltaTime;
            if (poisonDOTclock > 1)
            {
                TakeDotDamage(1);
                poisonDOTclock = 0;
            }
        }

        if (isBurning)
        {
            burnCounter -= Time.deltaTime;
        }

        
        FearIndicator();

        timer += Time.deltaTime;
        if (timer > 15)
        {
            if (playerCurrentHealth < playerMaxHealth)
            {
                playerCurrentHealth++;
                timer = 0;
            }

        }

        if (!isAttacking)
        {//get input for player movement
            move.x = Input.GetAxisRaw("Horizontal");
            move.y = Input.GetAxisRaw("Vertical");
        }

        //restricts diagonal movement 
        if (Mathf.Abs(move.x) > Mathf.Abs(move.y))
            move.y = 0;
        else
            move.x = 0;

        //paramaters for movement animation
        animator.SetFloat("Horizontal", move.x);
        animator.SetFloat("Vertical", move.y);
        animator.SetFloat("Speed", move.sqrMagnitude);
        animator.SetFloat("Attack Speed", playerAttackSpeed);

        if (isAttacking)
        {
            move.x = 0f;
            move.y = 0f;
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                animator.SetBool("isAttacking", false);

                isAttacking = false;
            }
        }

        if (swordEquipped)
        {
            animator.SetBool("swordEquipped", true);
            animator.SetBool("staffEquipped", false);
            playerDamage = playerAttackDamage;
        }

        if (staffEquipped)
        {
            animator.SetBool("swordEquipped", false);
            animator.SetBool("staffEquipped", true);
            playerDamage = playerAbilityPower;
        }

        if (!staffEquipped && !swordEquipped)
        {
            animator.SetBool("swordEquipped", false);
            animator.SetBool("staffEquipped", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attackCounter = attackTime;
            animator.SetBool("isAttacking", true);
            isAttacking = true;
        }


        //walkLeft
        if (walkLeft)
        {
            animator.SetFloat("Horizontal", -1.0f);
            animator.SetFloat("Speed", 1.0f);
        }
        if (walkRight)
        {
            animator.SetFloat("Horizontal", 1.0f);
            animator.SetFloat("Speed", 1.0f);
        }
        if (walkNorth)
        {
            animator.SetFloat("Vertical", 1.0f);
            animator.SetFloat("Speed", 1.0f);
        }
        if (walkSouth)
        {
            animator.SetFloat("Vertical", -1.0f);
            animator.SetFloat("Speed", 1.0f);
        }
        if (cancel)
        {
            animator.SetFloat("Speed", 1.0f);
            cancel = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * playerMovementSpeed * Time.fixedDeltaTime);
    }

    public void TakeDotDamage(int damageTaken)
    {
        playerCurrentHealth -= damageTaken;

        if (playerCurrentHealth <= 0)
        {
            PlayerDie();
        }
    }
    public void TakeDamage(int damageTaken)
    {
        float dmgTaken = damageTaken;
        float playerArm = playerArmour;
        float actualDmg = dmgTaken * (1 - ((playerArm / 2) / 100));
        int _actualDmg = (int)actualDmg;

        playerCurrentHealth -= _actualDmg;
        if (playerCurrentHealth <= 0)
        {
            PlayerDie();
        }
    }
    
    public void PlayerDie()
    {
        gameObject.SetActive(false);
    }

    public void PoisonPlayer(float poisonTime)
    {
        isPoisoned = true;
        poisonTimer = poisonTime;
        StartCoroutine(PoisonIndicator());
    }

    IEnumerator PoisonIndicator()
    {
        poisonIndicator.SetActive(true);
        GetComponent<SpriteRenderer>().color = new Color(75f / 255f, 0f / 255f, 130f / 255f, 255f);
        yield return new WaitForSeconds(poisonTimer);
        poisonIndicator.SetActive(false);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

    }
    void FearIndicator() 
    {
        if (isFeared)
        {
            fearInd.SetActive(true);
        }
        else 
        {
            fearInd.SetActive(false);
        }
    }

    public void BurnPlayer(bool isBurned, float burnLength, int burnDamage)
    {
        if (isBurned)
        {
            burnCounter = burnLength;
            isBurning = true; 
            burnTime = burnLength;
            _burnDamage = burnDamage;
            StartCoroutine(Burn());
        }
    }
    IEnumerator Burn()
    {
        InvokeRepeating("BurnDoT", 1f, 1f);
        burnIndicator.SetActive(true);
        GetComponent<SpriteRenderer>().color = new Color(200f / 255f, 40f / 255f, 0f / 255f, 215f / 255f);
        yield return new WaitForSeconds(burnTime);
        
        if (burnCounter <= 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            isBurning = false;
            burnIndicator.SetActive(false);
            CancelInvoke();
        }
        
    }

    public void BurnDoT()
    {
        TakeDotDamage(_burnDamage);
    }

    public void SlowPlayer(bool isSlowed, float slowLength, float slowFactor)
    {
        if (isSlowed)
        {
            StartCoroutine(Slow());
            slowTime = slowLength;
            _slowFactor = slowFactor;
        } 
    }
    IEnumerator Slow()
    {
        tempSpeed = playerMovementSpeed;
        yield return new WaitForSeconds(0.1f);
        slowIndicator.SetActive(true);
        playerMovementSpeed = playerMovementSpeed / _slowFactor;
        GetComponent<SpriteRenderer>().color = new Color(0/255f, 0/255f, 200f/255f, 215f/255f);
        yield return new WaitForSeconds(slowTime);
        slowIndicator.SetActive(false);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        playerMovementSpeed = tempSpeed;

    }

    public void StunPlayer(bool isStunned, float stunLength)
    {
        if (isStunned)
        {
            StartCoroutine(Stun());
            stunTime = stunLength;
        }
    }
    
    IEnumerator Stun()
    {
        yield return new WaitForSeconds(0.1f);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.enabled = false;
        GameObject stunInd = Instantiate(stunIndicator, statusIndicatorPoint.position, statusIndicatorPoint.rotation);
        yield return new WaitForSeconds(stunTime);
        rb.constraints &= ~RigidbodyConstraints2D.FreezePosition;
        animator.enabled = true;
    }
    public void FireSpinPlayer(bool isSpinning, float spinLength)
    {
        if (isSpinning)
        {
            StartCoroutine(FireSpin());
            spinTime = spinLength;
            isSpin = isSpinning;
        }
    }

    IEnumerator FireSpin()
    {
        yield return new WaitForSeconds(0.1f);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.enabled = false;
        GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 0f / 255f);
        GameObject spinInd = Instantiate(fireNadoSpin, transform.position, transform.rotation);

        yield return new WaitForSeconds(spinTime);
        rb.constraints &= ~RigidbodyConstraints2D.FreezePosition;
        animator.enabled = true;
        GetComponent<SpriteRenderer>().color = new Color(200/255f, 40/255f, 0/255f, 215/255f);
    }

    public void SpinPlayer(bool isSpinning, float spinLength)
    {
        if (isSpinning)
        {
            StartCoroutine(Spin());
            spinTime = spinLength;
            isSpin = isSpinning;
        }
    }

    IEnumerator Spin()
    {
        yield return new WaitForSeconds(0.1f);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.enabled = false;
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0 / 255);
        GameObject spinInd = Instantiate(nadoSpin, transform.position, transform.rotation);

        yield return new WaitForSeconds(spinTime);
        rb.constraints &= ~RigidbodyConstraints2D.FreezePosition;
        animator.enabled = true;
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
    }
    public void WalkingLeft(float fearTime)
    {
        StartCoroutine(Feared(fearTime));
        walkLeft = true;
    }
    public void WalkingRight(float fearTime)
    {
        StartCoroutine(Feared(fearTime));
        walkRight = true;
    }
    public void WalkingNorth(float fearTime)
    {
        StartCoroutine(Feared(fearTime));
        walkNorth = true;
    }
    public void WalkingSouth(float fearTime)
    {
        StartCoroutine(Feared(fearTime));
        walkSouth = true;
    }
    public void CancelWalks()
    {
        walkLeft = false;
        walkRight = false;
        walkNorth = false;
        walkSouth = false;
        cancel = true;
    }

    public void playerPinned(bool isPinned)
    {
        if (isPinned)
        {
            _isPinned = true;
        }
        else
        {
            _isPinned = false;
        }
        
    }

    IEnumerator Feared(float fearTime)
    {
        isFeared = true;
        yield return new WaitForSeconds(fearTime);
        isFeared = false;
    }
}