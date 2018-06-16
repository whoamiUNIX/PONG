using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player01Control : MonoBehaviour
{
    Rigidbody2D player_1_obj;
    float speed = 15.0f;

    void Start()
    {
        player_1_obj = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player_1_obj.velocity = Vector2.up * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            player_1_obj.velocity = Vector2.down * speed;
        }
        else
        {
            player_1_obj.velocity = Vector2.down * 0.0f;
        }
    }
}