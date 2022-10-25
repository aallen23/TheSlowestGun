using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float h;
    private float v;
    private Vector2 playerDirection;
    private float playerSpeed = 5.0f;
    private float xBound;
    private float yBound;

    [SerializeField] GameManager gm;

    public GameObject healthBar;

    private AudioSource[] dmgbarks;

    private bool poisoned;
    public float health;
    public int healthIndex;

    // Start is called before the first frame update
    void Awake()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        rb = gameObject.GetComponent<Rigidbody2D>();
        dmgbarks = GetComponents<AudioSource>();
    }

    void Start()
    {
        health = 10.0f;
        healthIndex = 10;
        poisoned = false;
        xBound = 12.0f;
        yBound = 8.0f;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(h,v);

        transform.Translate(playerDirection * playerSpeed * Time.deltaTime);

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -xBound, xBound), Mathf.Clamp(transform.position.y, -yBound, yBound - 2));

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        if(health <= 0)
        {
            gm.Death();
        }

    }

    void TakeDamage(float dmg)
    {
        int barkIndex = Random.Range(0, dmgbarks.Length);
        dmgbarks[barkIndex].Play();
        health -= dmg;
        DestroyHeart();
    }

    IEnumerator PoisonDamage()
    {
        for (int i = 0; i < 4; i++)
        {
            health -= 0.5f;
            int barkIndex = Random.Range(0, dmgbarks.Length);
            dmgbarks[barkIndex].Play();
            if(i == 1 || i == 3)
            {
                DestroyHeart();
            }
            yield return new WaitForSeconds(1);
        }
        poisoned = false;
    }

    public void DestroyHeart()
    {
        if(health > 0)
        {
            healthBar.transform.GetChild(healthIndex - 1).gameObject.SetActive(false);
            healthIndex--;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Goop" && !poisoned)
        {
            poisoned = true;
            StartCoroutine(PoisonDamage());
        }

        if(other.tag == "Bullet")
        {
            TakeDamage(1.0f);
        }
    }


}
