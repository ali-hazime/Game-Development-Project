using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    private Transform player;
    public Vector3 panVector;
    public bool _panCamera;
    private void Start()
    {
        player = FindObjectOfType<PlayerChar>().transform;
    }
    private void LateUpdate()
    {
        if (_panCamera)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3 (panVector.x, panVector.y, -10), 10* Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(player.position.x + 0.01f, player.position.y, -10);
        }
    }

    public void PanCamera(Vector3 v3, bool panCamera)
    {
        panVector = v3;
        _panCamera = panCamera;
    }


}
