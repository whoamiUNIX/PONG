using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player02Control : MonoBehaviour
{
    Rigidbody2D player_2_obj;
    float speed = 15.0f;

    void Start()
    {
        player_2_obj = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player_2_obj.velocity = Vector2.up * speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            player_2_obj.velocity = Vector2.down * speed;
        }
        else
        {
            player_2_obj.velocity = Vector2.down * 0.0f;
        }
    }
}