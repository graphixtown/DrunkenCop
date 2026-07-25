using System;
using UnityEngine;

public class Obsticles : MonoBehaviour
{
    public bool collided, wasCollided, inSpeed;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    private void FixedUpdate()
    {
        if (body.linearVelocity.x > 4f || body.linearVelocity.x < -4f || body.linearVelocity.y > 4f || body.linearVelocity.y < -4f) inSpeed = true;
        else inSpeed = false;

        if (!wasCollided && collided && inSpeed)
        {
            audioSource.PlayOneShot(clip);
        }
        wasCollided = collided;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            collided = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            collided = false;
        }
    }
}

