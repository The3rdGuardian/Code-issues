using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

    public float speed;

    public Text livesText;
    public Text countText;


    public Text winText;
    public Text winText2;
    public Text loseText;

    private Rigidbody2D rb2d;      
    private int count;
    private int lives;

 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        count = 0;
        lives = 3;

        winText.text = "";
        winText2.text = "";
        loseText.text = "";

        SetLivesText();
    
        SetCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

        
        SetLivesText();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Pentagon"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives--;
            SetLivesText();

        }
        if (count == 6 && lives >= 1)
        {
            transform.position = new Vector2(66f, 0f);
        }

    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
       
        if (lives < 1)
        {
            loseText.text = "You have lost the game! Better luck next time!";
            StopGameObject();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        

        if (lives >= 1 && count == 14)
        {
            winText.text = "Congragulations! You Win!";
            winText2.text = "Game created by Edward Powers";
        }
        else
        {
            SetLivesText();
        }

       
    }

    void StopGameObject()
    {
        //Destroy(gameObject);
        float moveHorizontal = 0;
        float moveVertical = 0;
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

    }

}

