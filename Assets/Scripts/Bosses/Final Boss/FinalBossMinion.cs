using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossMinion : MonoBehaviour
{
    private PlayerChar player;
    private Transform playerTarget;
    private Animator anim;
    public GameObject AbilitiesParent;
    public GameObject BoltPrefab;
    [Space]
    public float minRange = 10;
    public float speed = 0;
    [Space]
    public bool isNotInMinRange = false;
    public bool doingSomething = false;
    [Space]
    public bool boltOnCD = false;
    public float boltCD = 5f;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
        anim = GetComponent<Animator>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;

        if (AbilitiesParent == null)
        {
            AbilitiesParent = GameObject.FindWithTag("AbilityParent");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mathf.Abs(Vector3.Distance(transform.position, playerTarget.position)) > minRange)
        {
            isNotInMinRange = true;
            anim.SetBool("isMoving", true);
        }
        else
        {
            isNotInMinRange = false;
            anim.SetBool("isMoving", false);
        }

        if (isNotInMinRange && doingSomething == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, 2.5f * Time.deltaTime);
        }

        if (boltOnCD == false)
        {
            StartCoroutine(ShootBolt());
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
    }

    IEnumerator ShootBolt()
    {
        boltOnCD = true;
        GameObject Bolt = Instantiate(BoltPrefab, transform.position, Quaternion.Euler(0f, 0f, Quaternion.LookRotation(player.transform.position).x * 100));
        Bolt.transform.parent = AbilitiesParent.transform;
        Rigidbody2D rb = Bolt.GetComponent<Rigidbody2D>();
        rb.velocity = (playerTarget.position - transform.position).normalized * 5f;
        yield return new WaitForSeconds(boltCD);
        boltOnCD = false;
    }
}
