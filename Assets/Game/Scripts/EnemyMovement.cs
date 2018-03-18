using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (!player) return;
        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(targetPosition);

        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
