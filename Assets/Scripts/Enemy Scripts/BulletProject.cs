using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProject : MonoBehaviour
{
    public GameObject player;
    public Vector3 spawn;
    [SerializeField] float speed;
    [SerializeField] bool left;
    private float xBound;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2.5f;
        xBound = 20.0f;

        player = GameObject.FindWithTag("Player");
        spawn = transform.position;

        if(spawn.x > player.transform.position.x)
        {
            left = true;
        }
        else if (spawn.x < player.transform.position.x)
        {
            left = false;
            gameObject.transform.localScale = new Vector3(-0.5f, 0.5f, 1.0f);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if(left)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }
        else if(!left)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        }

        if(transform.position.x > xBound || transform.position.x < -xBound)
        {
            Destroy(gameObject);
        }
    }

}
