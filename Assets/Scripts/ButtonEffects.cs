using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Vector3 hoverScale;
    [SerializeField] private Vector3 hoverRotation;

    [SerializeField] private float speed;

    private Vector3 originalScale;
    private Quaternion originalRotation;

    private Vector3 targetScale;
    private Quaternion targetRotation;

    private void Start()
    {
        originalScale = transform.localScale;
        originalRotation = transform.localRotation;

        targetScale = originalScale;
        targetRotation = originalRotation;
    }
    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, speed * Time.deltaTime);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        MenuManager.Instance.buttonHover();
        targetScale = hoverScale;
        targetRotation = Quaternion.Euler(hoverRotation);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        targetScale = originalScale;
        targetRotation = originalRotation;
    }
}
