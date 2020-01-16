using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This is all the stats for the player's character
public class PlayerChar : MonoBehaviour
{


    //Game objects
    public GameObject player;

    //player sprite and movement
    private Rigidbody2D rb;
    private Vector2 move;
    public Animator animator;
    private float attackTime = 0.3f;
    private float attackCounter = 0.3f;
    public bool isAttacking;
    public bool swordEquipped;
    public bool staffEquipped;

    //Players main stats
    public int playerCurrentHealth;
    public int playerMaxHealth;
    public float playerMovementSpeed;
    public int playerAttackDamage;
    public int playerAbilityPower;
    public float playerAttackSpeed;
    public int playerArmour;

    public int playerDamage;

    public float timer = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (playerCurrentHealth > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }

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

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * playerMovementSpeed * Time.fixedDeltaTime);
    }

    public void takeDamage(int damageTaken)
    {
        playerCurrentHealth -= damageTaken;
        if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}