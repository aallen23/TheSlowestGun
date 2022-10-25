using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lvl;
    public string currentlvl;

    public int mobCap;
    public float spawnInterval;

    public GameObject explosion;
    public GameObject player;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    public void UpdateCurrentLevel(int lvl)
    {
        currentlvl = "Level" + lvl;
    }

    public void IncreaseDifficulty()
    {
        spawnInterval -= 0.25f;
        mobCap += 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CreditsMenu()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    public void StartGame()
    {
        spawnInterval = 3.0f;
        mobCap = 3;
        lvl = 1;
        UpdateCurrentLevel(lvl);
        SceneManager.LoadScene(currentlvl);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentlvl);
    }

    public void Death()
    {
        SceneManager.LoadScene("DeathMenu");
    }

    public void EndLevel()
    {
        lvl++;
        player = GameObject.FindWithTag("Player");
        Instantiate(explosion, player.transform.position, explosion.transform.rotation);
        if(lvl <= 6)
        {
            UpdateCurrentLevel(lvl);
            IncreaseDifficulty();
            SceneManager.LoadScene(currentlvl);
        }
        else if (lvl > 6)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("EndMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
