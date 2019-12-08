using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Animator anim;

    private bool facingRight = true;
    private bool isJumping = false;

    private Rigidbody2D rd2d;

    public float speed;

    public Text score;
    public Text livesText;

    public Text winText;
    public Text winText2;
    public Text loseText;

    public AudioClip musicClipone;
    public AudioClip musicCliptwo;
    public AudioSource musicSource;

    public CountdownScript Timer;

    private int scoreValue;
    private int lives;

    void Start()
    {
        scoreValue = 0;
        lives = 3;

        winText.text = "";
        winText2.text = "";
        loseText.text = "";

        rd2d = GetComponent<Rigidbody2D>();
        PrintWinText();
        SetLivesText();
        musicSource.clip = musicClipone;
        musicSource.Play();
        anim = GetComponent<Animator>();
        gameObject.GetComponent<Renderer>().enabled = true;
        //Timer = Timer.GetComponent<CountdownScript.startingTime>();
    }

    void Update()
    {
        float hozMovement = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.A) && isJumping == false)
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.A) && isJumping == false)
        {
            anim.SetInteger("State", 0);
        }
        if (Input.GetKey(KeyCode.D) && isJumping == false)
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.D) && isJumping == false)
        {
            anim.SetInteger("State", 0);
        }

        if (facingRight == false && hozMovement > 0)
        {
            Flip();
        }
        else if (facingRight == true && hozMovement < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Gem")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            PrintWinText();
        }

        if (collision.collider.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
            lives--;
            SetLivesText();

        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                isJumping = true;
                anim.SetInteger("State", 2);
                rd2d.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
            }
            else
            {
                isJumping = false;
                anim.SetInteger("State", 0);
            }
        }

    }

    void SetLivesText()
    {
        //CountdownScript.startingTime;
        livesText.text = "Lives: " + lives.ToString();

        if (lives < 1 /*|| CountdownScript.startingTime == 0*/)
        {
            loseText.text = "You have lost the game! Better luck next time!";
            gameObject.GetComponent<Renderer>().enabled = false;
            rd2d.bodyType = RigidbodyType2D.Static;
        }
    }

    void PrintWinText()
    {
        score.text = "Score: " + scoreValue.ToString();

        if (lives >= 1 && scoreValue == 11)
        {
            musicSource.clip = musicCliptwo;
            musicSource.Play();
            winText.text = "Congratulations! You Win!";
            winText2.text = "Game created by";
            gameObject.GetComponent<Renderer>().enabled = false;
            rd2d.bodyType = RigidbodyType2D.Static;
        }
        else if (lives >= 1 && scoreValue == 6)
        {
            lives = 3;
            SetLivesText();
            transform.position = new Vector2(93f, 22f);
        }
        else
        {
            SetLivesText();
        }
    }
}
