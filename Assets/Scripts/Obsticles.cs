using UnityEngine;

public class Obsticles : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(rb.linearVelocity.x > 2f || rb.linearVelocity.y > 2f)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
