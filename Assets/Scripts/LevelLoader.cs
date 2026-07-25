using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    public void sceneTransition()
    {
        StartCoroutine(transition(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator transition(int sceneIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneIndex);
    }
}
