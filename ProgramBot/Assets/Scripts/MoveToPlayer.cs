using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour {
    public float speed = 2.0f;
    public float accuracy = 0.01f;
    public Transform player;
    void Start() {
        this.transform.LookAt(player.position);
    }

    void LateUpdate() {
        Vector3 direction = player.position - this.transform.position;
        if(direction.magnitude > 0.2f)
            this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }
}