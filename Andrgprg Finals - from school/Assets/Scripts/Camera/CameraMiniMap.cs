using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMiniMap : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private float offsetY;

    private void LateUpdate()
    {
        Vector3 newPos = player.position;
        newPos.y += offsetY;
        transform.position = newPos;
    }
}
