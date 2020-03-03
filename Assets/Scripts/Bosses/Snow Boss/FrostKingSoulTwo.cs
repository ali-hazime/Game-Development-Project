using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrostKingSoulTwo : MonoBehaviour
{
    private GameObject playerTarget;
    private Animator anim;
    public GameObject currentHP;
    public GameObject maxHP;
    public GameObject EyeLeft;
    public GameObject EyeRight;
    [Space]
    public bool dead = false;
    public bool started = false;
    public bool starting = true;
    [Space]
    public float direction = 1.0f;
    public bool doingSomething = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerTarget = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    [System.Obsolete]
    void FixedUpdate()
    {

        if (started)
        {
            if (starting)
            {
                anim.SetBool("moveVert", true);
                anim.SetInteger("speed", -1);
                anim.SetBool("isMoving", true);

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(46f, 63f, 0f), 1 * Time.fixedDeltaTime);
                currentHP.GetComponent<Image>().color = new Color(255, 255, 255, (Mathf.Abs(((((transform.position.y - 63f) * 2.5f) / 10f) * 255) - 255)) / 255);
                maxHP.GetComponent<Image>().color = new Color(255, 255, 255, (Mathf.Abs(((((transform.position.y - 63f) * 2.5f) / 10f) * 255) - 255)) / 255);

                if (transform.position.y == 63f)
                {
                    EyeLeft.SetActive(true);
                    EyeRight.SetActive(true);
                    starting = false;
                }
            }
            else
            {
                if (doingSomething == false)
                {
                    anim.SetBool("isMoving", true);
                    transform.position = Vector3.MoveTowards(transform.position, playerTarget.transform.position, 1 * Time.fixedDeltaTime);
                }

                if (Mathf.Abs(playerTarget.transform.position.y - transform.position.y) > Mathf.Abs(playerTarget.transform.position.x - transform.position.x))
                {
                    anim.SetFloat("moveX", 0f);
                    anim.SetFloat("moveY", (playerTarget.transform.position.y - transform.position.y));
                    anim.SetBool("moveVert", true);
                    direction = playerTarget.transform.position.y - transform.position.y;

                    if (playerTarget.transform.position.y - transform.position.y > 0)
                    {
                        EyeLeft.SetActive(false);
                        EyeRight.SetActive(false);
                    }
                    else
                    {
                        EyeLeft.SetActive(true);
                        EyeRight.SetActive(true);
                    }
                }
                else
                {
                    anim.SetFloat("moveX", (playerTarget.transform.position.x - transform.position.x));
                    anim.SetFloat("moveY", 0f);
                    anim.SetBool("moveVert", false);
                    direction = playerTarget.transform.position.x - transform.position.x;

                    if (playerTarget.transform.position.x - transform.position.x > 0)
                    {
                        EyeLeft.SetActive(true);
                        EyeRight.SetActive(false);
                    }
                    else
                    {
                        EyeLeft.SetActive(false);
                        EyeRight.SetActive(true);
                    }
                }

                anim.SetFloat("speed", direction);

            }
        }
    }
}
