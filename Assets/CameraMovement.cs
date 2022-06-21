using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Rigidbody2D player;

    void Start()
    {

    }

    void Update()
    {
        this.transform.position = new Vector3(
            player.position.x,
            player.position.y,
            this.transform.position.z
        );
    }
}
