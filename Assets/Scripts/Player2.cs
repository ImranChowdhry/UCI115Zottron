using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private GameObject player1;

    public GameObject projectilePrefab;
    [HideInInspector]
    public List<GameObject> projectiles;
    [HideInInspector]
    public List<string> projectileFacing;
    public float projectileVelocity;

    public AudioClip footStep;
    public AudioClip jumpSound;
    public AudioClip bulletFire;
    public AudioClip bulletImpact;
    private bool playFootSound;

    public float accelSpeed;
    public float moveSpeed;
    public float jumpSpeed;
    public bool canJump;
    public bool facingRight;
    float tempSpeed, direction;

    [HideInInspector]
    public int playerHealth;
    [HideInInspector]
    public double hillTimer;

    //2D Functionality
    Rigidbody2D rb;

    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");

        //Creating the Rigidbody2D object
        rb = GetComponent<Rigidbody2D>();

        tempSpeed = moveSpeed;
        playerHealth = 100;
        hillTimer = 0.0;

        projectiles = new List<GameObject>();
        projectileFacing = new List<string>();

        playFootSound = true;
    }

    void flip(float direction)
    {
        if (direction < 0 && !facingRight || direction > 0 && facingRight)
        {
            {
                facingRight = !facingRight;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
    }

    private void Update()
    {
        direction = Input.GetAxis("Horizontal");
        flip(direction);
        {

        }
        if (Input.GetButton("Left"))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if (playFootSound && canJump)
            {
                StartCoroutine(FootStepSound());
            }
        }
        if (Input.GetButton("Right"))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if (playFootSound && canJump)
            {
                StartCoroutine(FootStepSound());
            }
        }
        //When the arrow keys are not being pressed, set moveSpeed to 0
        if (!Input.GetButton("Right") && !Input.GetButton("Left"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetButtonDown("Run") && canJump)
        {
            moveSpeed = accelSpeed;
        }
        //Not Running
        if (!Input.GetButton("Run"))
        {
            moveSpeed = tempSpeed;
        }

        //Assigning Space to Jump
        if (Input.GetButtonDown("Jump") && canJump)
        {
            GetComponent<AudioSource>().PlayOneShot(jumpSound);
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        if (InputManager.J_Fire())
        {
            GetComponent<AudioSource>().PlayOneShot(bulletFire);
            GameObject bullet = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectiles.Add(bullet);
            if (facingRight)
            {
                projectileFacing.Add("Right");
            }
            else
            {
                projectileFacing.Add("Left");
            }
        }

        for (int i = 0; i < projectiles.Count; ++i)
        {
            GameObject goBullet = projectiles[i];
            if (goBullet != null && projectileFacing[i] != null)
            {
                if (projectileFacing[i] == "Right")
                {
                    goBullet.GetComponent<SpriteRenderer>().flipX = true;
                    goBullet.transform.Translate(new Vector3(-1, 0) * Time.deltaTime * projectileVelocity);
                }
                else if (projectileFacing[i] == "Left")
                {
                    goBullet.transform.Translate(new Vector3(1, 0) * Time.deltaTime * projectileVelocity);
                }

                Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(goBullet.transform.position);
                if (bulletScreenPos.x >= Screen.width + 10 || bulletScreenPos.x <= -10)
                {
                    DestroyObject(goBullet);
                    projectiles.Remove(goBullet);
                    projectileFacing.Remove(projectileFacing[i]);
                }
            }
        }
        Vector3 PlayerPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        if (PlayerPos.x >= Screen.width + 10 || PlayerPos.x <= -10 || PlayerPos.y <= -10)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator FootStepSound()
    {
        playFootSound = false;
        GetComponent<AudioSource>().PlayOneShot(footStep);
        yield return new WaitForSeconds(footStep.length);
        playFootSound = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < player1.GetComponent<Player1>().projectiles.Count; ++i)
        {
            GameObject goBullet = player1.GetComponent<Player1>().projectiles[i];
            if (goBullet != null)
            {
                if (collision.tag == goBullet.tag)
                {
                    Destroy(collision.gameObject);
                    GetComponent<AudioSource>().PlayOneShot(bulletImpact);
                    playerHealth -= 5;
                }
            }
        }
    }
}