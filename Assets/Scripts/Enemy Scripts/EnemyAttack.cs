using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject pro;
    [SerializeField] bool attack;
    public Transform spawn;
    [SerializeField] float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = 3.0f;
        attack = true;
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Attack()
    {
        while (attack)
        {
            if(pro.tag == "Goop")
            {
                Instantiate(pro, spawn.position, pro.transform.rotation, gameObject.transform);
            }
            else
            {
                Instantiate(pro, spawn.position, pro.transform.rotation);
            }
            
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
