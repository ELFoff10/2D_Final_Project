using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyStats _enemy;
    private Transform player;

    private void Start()
    {
        _enemy = GetComponent<EnemyStats>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, player.transform.position, _enemy.currentMoveSpeed * Time.deltaTime);
    }
}
