using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossScript : MonoBehaviour
{
    private Transform playerTarget;
    private Animator anim;
    public Transform firePoint;
    public VolcanoBossHealth bossStats;
    public GameObject FireBallParent;
    [Space]
    public bool isStarted = false;
    public bool dead = false;
    public bool doingSomething = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
