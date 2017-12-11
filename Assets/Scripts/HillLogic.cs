using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HillLogic : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;

    private Color player1OriginalColor;
    private Color player2OriginalColor;

    public Text hillTimer1Text;
    public Text hillTimer2Text;

    private Vector3 startingPos;
    private Vector3 mainPos;
    private Vector3 upperLeftPos;
    private Vector3 bottomLeftPos;
    private Vector3 upperRightPos;
    private Vector3 bottomRightPos;

    public float hillResetTime;
    private float hillMoveTimer;
    // Use this for initialization
    void Start ()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player1OriginalColor = player1.GetComponent<SpriteRenderer>().color;
        player2OriginalColor = player2.GetComponent<SpriteRenderer>().color;
        setPlayer1HillCountText();
        setPlayer2HillCountText();

        startingPos = transform.position;
        mainPos = new Vector3(0, -20, 0);
        upperLeftPos = new Vector3(-85, 8.8f, 0);
        bottomLeftPos = new Vector3(-85, -27, 0);
        upperRightPos = new Vector3(85, 8.8f, 0);
        bottomRightPos = new Vector3(85, -27, 0);

        hillMoveTimer = 0.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        hillMoveTimer += Time.deltaTime;
        if (hillMoveTimer >= hillResetTime)
        {
            GetComponent<AudioSource>().Play();
            float seed = Random.Range(0.0f, 1.2f);
            if (seed <= 0.2f)
            {
                transform.parent.position = startingPos;
            }
            else if (seed <= 0.21f && seed <= 0.4f)
            {
                transform.parent.position = mainPos;
            }
            else if (seed <= 0.41f && seed <= 0.6f)
            {
                transform.parent.position = upperLeftPos;
            }
            else if (seed <= 0.61f && seed <= 0.8f)
            {
                transform.parent.position = bottomLeftPos;
            }
            else if (seed <= 0.81f && seed <= 1.0f)
            {
                transform.parent.position = upperRightPos;
            }
            else if (seed <= 1.1f && seed <= 1.2f)
            {
                transform.parent.position = bottomRightPos;
            }
            hillMoveTimer = 0.0f;
        }
        timerDisplay();
    }

    private void timerDisplay()
    {
        setPlayer1HillCountText();
        setPlayer2HillCountText();
        if (player1.GetComponent<Player1>().hillTimer >= 100.0)
        {
            print("Hello player 1");
        }
        else if (player1.GetComponent<Player1>().hillTimer >= 100.0)
        {
            print("Hello player 2");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player1")
        {
            player1.GetComponent<Player1>().hillTimer += Time.deltaTime;
            setPlayer1HillCountText();
            player1.GetComponent<SpriteRenderer>().color = new Color(1f, 0.30196078f, 0.30196078f);
        }
        if (collision.tag == "Player2")
        {
            player2.GetComponent<Player2>().hillTimer += Time.deltaTime;
            setPlayer2HillCountText();
            player2.GetComponent<SpriteRenderer>().color = new Color(1f, 0.92f, 0.016f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            player1.GetComponent<Player1>().hillTimer += Time.deltaTime;
            setPlayer1HillCountText();
            player1.GetComponent<SpriteRenderer>().color = new Color(1f, 0.30196078f, 0.30196078f);
        }
        if (collision.tag == "Player2")
        {
            player2.GetComponent<Player2>().hillTimer += Time.deltaTime;
            setPlayer2HillCountText();
            player2.GetComponent<SpriteRenderer>().color = new Color(1f, 0.92f, 0.016f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            player1.GetComponent<SpriteRenderer>().color = player1OriginalColor;
        }
        if (collision.tag == "Player2")
        {
            player2.GetComponent<SpriteRenderer>().color = player2OriginalColor;
        }
    }

    void setPlayer1HillCountText()
    {
        hillTimer1Text.text = "Player 1 time in hill: " + player1.GetComponent<Player1>().hillTimer.ToString("F2");
    }

    void setPlayer2HillCountText()
    {
        hillTimer2Text.text = "Player 2 time in hill: " + player2.GetComponent<Player2>().hillTimer.ToString("F2");
    }
}
