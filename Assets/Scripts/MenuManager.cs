using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonHoverSound;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        Cursor.visible = false;
        
    }
    public void buttonHover()
    {
        audioSource.PlayOneShot(buttonHoverSound);
    }
    public void PlayButton()
    {
        LevelLoader.Instance.sceneTransition();
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void InstagramLink()
    {
        Application.OpenURL("https://www.instagram.com/seroneem_/");
    }
    public void YoutubeLink()
    {
        Application.OpenURL("https://www.youtube.com/@seroneem");
    }
    public void DiscordLink()
    {
        Application.OpenURL("https://discord.gg/GmZMkqupfr");
    }
}
