using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NadoSpin : MonoBehaviour
{
    public float spinLength;
    public PlayerChar player;
    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }
    void Start()
    {
        StartCoroutine(SpinTimer());
    }
    IEnumerator SpinTimer()
    {
        spinLength = (player.spinTime - 0.1f);
        yield return new WaitForSeconds(spinLength);
        Destroy(this.gameObject);
    }
}
