using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosCheck : MonoBehaviour
{
    public Transform playerTarget;
    public Vector3 targetPos;
    public float offset = 10f;

    private Vector3 direction;
    public void OnEnable()
    {
        playerTarget = FindObjectOfType<PlayerChar>().transform;
        direction = (playerTarget.transform.position - transform.position).normalized;
        targetPos = playerTarget.transform.position + (direction * offset);

    }
}
