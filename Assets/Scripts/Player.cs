using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;

    public GameObject projectilePrefab;
    private List<GameObject> projectiles;
    private List<string> projectileFacing;
    public float projectileVelocity;

    public AudioClip footStep;
    public AudioClip jumpSound;
    public AudioClip bulletFire;
    private bool playFootSound;

    public float accelSpeed;
    public float moveSpeed;
    public float jumpSpeed;
    public bool canJump, player1facingRight, player2facingright;
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
        player2 = GameObject.FindGameObjectWithTag("Player2");

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
        if (gameObject.tag == player1.tag)
        {
            if (direction < 0 && !player1facingRight || direction > 0 && player1facingRight)
            {
                player1facingRight = !player1facingRight;
                Vector3 scale = player1.transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
        if (gameObject.tag == player2.tag)
        {
            if (direction > 0 && !player2facingright || direction < 0 && player2facingright)
            {
                player2facingright = !player2facingright;
                Vector3 scale = player2.transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }

    }

    private void Update()
    {
        // Player 1
        if(gameObject.tag == player1.tag)
        {
            direction = Input.GetAxis("Horizontal");
            flip(direction);

            if (InputManager.MainJoystick().x < 0.0)
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                if (playFootSound && canJump)
                {
                    StartCoroutine(FootStepSound());
                }
            }
            if (InputManager.MainJoystick().x > 0.0)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                if (playFootSound && canJump)
                {
                    StartCoroutine(FootStepSound());
                }
            }
            //When the arrow keys are not being pressed, set moveSpeed to 0
            if (InputManager.MainJoystick() == Vector3.zero)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            if (InputManager.RunButton() && canJump)
            {
                moveSpeed = accelSpeed;
            }
            //Not Running
            if (!InputManager.RunButton())
            {
                moveSpeed = tempSpeed;
            }

            //Assigning Space to Jump
            if (InputManager.AButton() && canJump)
            {
                GetComponent<AudioSource>().PlayOneShot(jumpSound);
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }

            if (InputManager.Fire2())
            {
                GetComponent<AudioSource>().PlayOneShot(bulletFire);
                GameObject bullet = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                projectiles.Add(bullet);
                if (player1facingRight)
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

        // Player 2
        if (gameObject.tag == player2.tag)
        {
            direction = Input.GetAxis("Horizontal2");
            flip(direction);

            if (InputManager.MainJoystick2().x < 0.0)
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                if (playFootSound && canJump)
                {
                    StartCoroutine(FootStepSound());
                }
            }
            if (InputManager.MainJoystick2().x > 0.0)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                if (playFootSound && canJump)
                {
                    StartCoroutine(FootStepSound());
                }
            }
            //When the arrow keys are not being pressed, set moveSpeed to 0
            if (InputManager.MainJoystick2() == Vector3.zero)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            if (InputManager.Run2Button() && canJump)
            {
                moveSpeed = accelSpeed;
            }
            //Not Running
            if (!InputManager.Run2Button())
            {
                moveSpeed = tempSpeed;
            }

            //Assigning Space to Jump
            if (InputManager.XButton() && canJump)
            {
                GetComponent<AudioSource>().PlayOneShot(jumpSound);
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }

            if (InputManager.Fire())
            {
                GetComponent<AudioSource>().PlayOneShot(bulletFire);
                GameObject bullet = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                projectiles.Add(bullet);
                if (player2facingright)
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
    }

    IEnumerator FootStepSound()
    {
        playFootSound = false;
        GetComponent<AudioSource>().PlayOneShot(footStep);
        yield return new WaitForSeconds(footStep.length);
        playFootSound = true;
    }
}