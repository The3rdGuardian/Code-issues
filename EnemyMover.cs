using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    public Transform startMarker;
    public Transform endMarker;

    public float speed = 1.0F;

    private float startTime;

    private float journeyLength;

    private bool facingRight = true;

    void Start()
    {
        startTime = Time.time;

        journeyLength = Vector2.Distance(startMarker.position, endMarker.position);
    }

    void Update()
    {

        float distCovered = (Time.time - startTime) * speed;

        float fracJourney = distCovered / journeyLength;

        transform.position = Vector2.Lerp(startMarker.position, endMarker.position, Mathf.PingPong(fracJourney, 1));

        if (facingRight == false && transform.position == Vector2.Distance(startMarker.position.x, startMarker.position.y)) 
        {
            Flip();
        }
        else if (facingRight == true && transform.position == Vector2.Distance(4,-2))
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


}

