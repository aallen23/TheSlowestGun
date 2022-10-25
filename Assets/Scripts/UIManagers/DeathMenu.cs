using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{

    [SerializeField] GameManager gm;
    [SerializeField] AudioSource[] deathbarks;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        deathbarks = GetComponents<AudioSource>();
        int barkIndex = Random.Range(0, deathbarks.Length);
        deathbarks[barkIndex].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallMain()
    {
        gm.MainMenu();
    }

    public void Restart()
    {
        gm.RestartLevel();
    }
}
