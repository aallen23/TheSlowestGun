using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float timeRemaining;
    public bool timer;

    [SerializeField] GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        timeRemaining = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer = true;
        if (timer)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timer = false;
                gm.EndLevel();
            }
        }

    }
}
