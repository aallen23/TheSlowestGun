using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracking : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    public float moveSpeed;
    private Vector2 target;
    private Vector2 localScale;
    public int directional;
    private float xBound;
    private float yBound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        moveSpeed = 1.0f;
        localScale = transform.localScale;
        xBound = 12.0f;
        yBound = 8.0f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        if(transform.InverseTransformDirection(rb.velocity).x < 0)
        {
            directional = -1;
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 1.0f);
        }
        if (transform.InverseTransformDirection(rb.velocity).x > 0)
        {
            directional = 1;
            gameObject.transform.localScale = new Vector3(-0.3f, 0.3f, 1.0f);
        }
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -xBound, xBound), Mathf.Clamp(transform.position.y, -yBound, yBound - 2));
    }

    public void MoveEnemy()
    {
        target = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(target.x, target.y) * moveSpeed;
    }
}
