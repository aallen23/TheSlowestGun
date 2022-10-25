using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndMenu : MonoBehaviour
{
    [SerializeField] GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
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
        gm.StartGame();
    }
}
