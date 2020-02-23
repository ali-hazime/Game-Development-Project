using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Enemy4_Behaviour : MonoBehaviour
{
    private Transform playerTarget;
    private Animator anim;
    public Transform firePoint;
    public GameObject poisonPlant;
    [Space]
    public float aggroMaxRange = 7;
    public float aggroMinRange = 0;
    public float plantSpawnCD;
    public bool isAggro;
    public bool spawnOnCD = false;
    [Space]
    public int plantDamage;
    public float poisonTime;



    void Start()
    {
        anim = GetComponent<Animator>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(playerTarget.position, transform.position) <= aggroMaxRange && Vector3.Distance(playerTarget.position, transform.position) >= aggroMinRange)
        {
            isAggro = true;
        }
        else
        {
            isAggro = false;
        }

        if (isAggro)
        {
            if (Mathf.Abs(playerTarget.position.y - transform.position.y) > Mathf.Abs(playerTarget.position.x - transform.position.x))
            {
                anim.SetFloat("moveX", 0f);
                anim.SetFloat("moveY", (playerTarget.position.y - transform.position.y));
            }
            else
            {
                anim.SetFloat("moveX", (playerTarget.position.x - transform.position.x));
                anim.SetFloat("moveY", 0f);
            }

            if (spawnOnCD == false)
            {
                StartCoroutine(SpawnPlant());
            }
        }
    }

    IEnumerator SpawnPlant()
    {
        GameObject plantProjctile = Instantiate(poisonPlant, playerTarget.position, playerTarget.rotation);
        spawnOnCD = true;
        yield return new WaitForSeconds(plantSpawnCD);
        spawnOnCD = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerChar>().TakeDamage(plantDamage);
            other.gameObject.GetComponent<PlayerChar>().PoisonPlayer(poisonTime);
        }
    }

}
