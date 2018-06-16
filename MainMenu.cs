using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenLink()
    {
        Application.OpenURL("https://www.linkedin.com/in/michal-va%C5%A1ko-490331aa?trk=hp-identity-name");
    }
}
