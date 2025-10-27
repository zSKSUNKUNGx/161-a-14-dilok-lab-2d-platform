﻿using UnityEngine;

public class Ant : Enemy
{

    [SerializeField]Vector2 velocity;
    public Transform[] Movepoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Intialize(20);

        DamageHit = 20;
        velocity = new Vector2(-1.0f,0.0f);
    }


    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (velocity.x < 0 && rb.position.x <= Movepoint[0].position.x)
        {
            Flip();
        }

        if (velocity.x > 0 && rb.position.x >= Movepoint[1].position.x)
        {
            Flip();
        }
    }
    public void Flip()
    {
        velocity.x *= -1; //change direction of movement
                          //Flip the image
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void FixedUpdate()
    {
        Behavior();

    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
