using UnityEngine;
public class ignoreCollider : MonoBehaviour
{
    void Start()
    {
        Collider2D[] collider = transform.GetComponentsInChildren<Collider2D>();
        for(int i = 0; i < collider.Length; i++)
        {
            for(int j = i; j < collider.Length; j++)
            {
                Physics2D.IgnoreCollision(collider[i], collider[j]);
            }
        }
    }
}
