using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopDestroy : MonoBehaviour
{
    public float timeRemaining;
    public bool timer;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = 10.0f;
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
                Destroy(gameObject);
            }
        }
    }
}
