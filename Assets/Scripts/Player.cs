using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
    public bool canJump, facingRight;
    float tempSpeed, direction;

    [HideInInspector]
    public int playerHealth;
    [HideInInspector]
    public double hillTimer;

    //2D Functionality
    Rigidbody2D rb;

    void Start()
    {
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
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private void Update()
    {
        direction = Input.GetAxis("Horizontal");
        flip(direction);
        // Assigning Movement to arrow keys

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
                    goBullet.transform.Translate(new Vector3(-1, 0) * Time.deltaTime * projectileVelocity);
                }
                else if (projectileFacing[i] == "Left")
                {
                    goBullet.transform.Translate(new Vector3(1, 0) * Time.deltaTime * projectileVelocity);
                }

                Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(goBullet.transform.position);
                if(bulletScreenPos.x >= Screen.width + 10 || bulletScreenPos.x <= -10)
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
}