using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour {
    public float speed = 2.0f;
    public float accuracy = 0.0f;
    public Transform player;
    void Start() {

    }

    void Update() {
        Vector3 direction = (player.position - this.transform.position) * 0.5f;
        if(direction.magnitude < accuracy)
            this.transform.Translate(direction.normalized * speed * Time.deltaTime);
    }
}