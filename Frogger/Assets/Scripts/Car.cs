using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.Death();
    }
}
