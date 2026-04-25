using UnityEngine;

public class TriggerCollider : MonoBehaviour
{
    [SerializeField] private GameObject triggerCollider;

    private void Start()
    {
        triggerCollider.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(triggerCollider != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                triggerCollider.gameObject.SetActive(true);
            }
        }
    }
}
