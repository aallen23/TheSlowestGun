using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitSlerp : MonoBehaviour
{

    public EnemyTracking tracking;

    public Vector3 spawn;
    public Vector3 splat;

    // Time to move from sunrise to sunset position, in seconds.
    public float journeyTime = 1.0f;

    // The time at which the animation started.
    private float startTime;

    [SerializeField] int directional;

    private bool slerp;

    public GameObject goopPuddle;

    // Start is called before the first frame update
    void Start()
    {

        startTime = Time.time;
        tracking = gameObject.transform.parent.transform.GetComponent<EnemyTracking>();
        directional = tracking.directional;
        spawn = gameObject.transform.parent.transform.Find("Spawn").position;
        splat = new Vector3(spawn.x + (Random.Range(5.0f, 10.0f) * directional), spawn.y, spawn.z);
        slerp = true;
    }

    // Update is called once per frame
    void Update()
    {
        // The center of the arc
        Vector3 center = (spawn + splat) * 0.5F;

        // move the center a bit downwards to make the arc vertical
        center -= new Vector3(0, 1, 0);

        // Interpolate over the arc relative to center
        Vector3 spitCenter = spawn - center;
        Vector3 splatCenter = splat - center;

        // The fraction of the animation that has happened so far is
        // equal to the elapsed time divided by the desired time for
        // the total journey.
        float totalTime = (Time.time - startTime) / journeyTime;

        transform.position = Vector3.Slerp(spitCenter, splatCenter, totalTime);
        transform.position += center;

        if(transform.position == splat && slerp)
        {
            slerp = false;
            Splat();
        }
    }

    public void Splat()
    {
        Instantiate(goopPuddle, transform.position, goopPuddle.transform.rotation);
        Destroy(gameObject);
    }
}
