using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    private GameObject player;
    private Rigidbody rigidBd;

    // Start is called before the first frame update
    void Start()
    {
        rigidBd = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10) {
            Destroy(gameObject);
        }
        rigidBd.AddForce((player.transform.position - transform.position).normalized * speed);
    }
}
