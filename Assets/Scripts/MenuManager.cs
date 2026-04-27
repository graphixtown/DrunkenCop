using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
