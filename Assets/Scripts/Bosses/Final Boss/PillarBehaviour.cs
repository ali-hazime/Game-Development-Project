using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarBehaviour : MonoBehaviour
{
    private Transform playerTarget;
    public GameObject AbilitiesParent;
    private LineRenderer lineRenderer;
    public Transform laserHit;
    public GameObject shotPrefab;
    [Space]
    public bool laserOnCD = false;
    public float laserCD;
    public bool lockedOn = false;
    public Vector3 target;


    // Start is called before the first frame update
    void Start()
    {
        playerTarget = FindObjectOfType<PlayerChar>().transform;
        AbilitiesParent = GameObject.FindWithTag("AbilityParent");
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        //lineRenderer.useWorldSpace = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (lockedOn == false)
        {
            target = (playerTarget.position - transform.position).normalized * 35;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, playerTarget.position + (target));
        }

        if (laserOnCD == false)
        {
            StartCoroutine(FireLaser());
        }
    }

    IEnumerator FireLaser()
    {
        laserOnCD = true;
        lineRenderer.sortingLayerName = "Under Monster";
        lineRenderer.startColor = new Color(0, 212, 0);
        lineRenderer.endColor = new Color(0, 212, 0);
        lineRenderer.enabled = true;
        lockedOn = false;
        yield return new WaitForSeconds(2f);
        lockedOn = true;
        lineRenderer.sortingLayerName = "ABOVE PLAYER";
        lineRenderer.startColor = new Color(255, 0, 0);
        lineRenderer.endColor = new Color(255, 0, 0);
        yield return new WaitForSeconds(1f);
        GameObject shot = Instantiate(shotPrefab, transform.position, transform.rotation);
        shot.transform.parent = AbilitiesParent.transform;
        Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
        rb.velocity = target ;
        yield return new WaitForSeconds(1f);
        lineRenderer.enabled = false;
        lockedOn = false;
        yield return new WaitForSeconds(laserCD);
        laserOnCD = false;
    }
}
