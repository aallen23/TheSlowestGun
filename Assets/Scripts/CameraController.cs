using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private float xBound;
    private float yBound;


    // Start is called before the first frame update
    void Start()
    {
        xBound = 4.5f;
        yBound = 4.0f;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, -xBound, xBound), Mathf.Clamp(player.transform.position.y, -yBound, yBound), transform.position.z);
    }
}
