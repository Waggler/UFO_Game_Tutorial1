using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed; //set speed of UFO
    public Text countText; //create text for pickups
    public Text winText; //create win text
    public Text livesText; //create text for life count

    private Rigidbody2D rb2d;
    private int count; //set count to use integers
    private int lives; //set lives to use integers

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0; //set count to 0
        lives = 3; //set lives to 3
        winText.text = "";
        SetCountText (); //call method below
        SetLivesText ();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
            if (other.gameObject.CompareTag("PickUp")) //when a pickup is collected, add one to count and display it in count text
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        
            else if (other.gameObject.CompareTag("Enemy")) //when an enemy is collected, subtract a life and display it in lives text
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count == 12)
{
    transform.position = new Vector2(50.0f, 50.0f); //when 12 pickups are collected, teleport player to second map
}
        if (count >= 20) //if count is 20 or higher display win text
        {
            winText.text = "You Win! Game created by Kevin H. Davis!";
        }
    }
    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString(); //create text output for lives

        if (lives <= 0) //if lives are 0 or less, destroy player and display text
        {
            winText.text = "You Lose! Please Try Again!";
            Destroy(gameObject);
        }
    }
}
