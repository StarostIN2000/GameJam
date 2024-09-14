using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject m_pauseMenu;

    bool isPaused = false;
    void Start()
    {
        Resume();
    }

    public void Timerun(bool b)
    {
        Time.timeScale = b ? 1f : 0f;
    }
    public void ActivateMenu(bool b)
    {
        m_pauseMenu.SetActive(b);
    }

    public void Pause()
    {
        Timerun(false);
        ActivateMenu(true);
    }
    public void Resume()
    {
        Timerun(true);
        ActivateMenu(false);
    }
    public void Quit()
    {
        Resume();
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Skip()
    {
        Resume();
        if(SceneManager.GetActiveScene().buildIndex < (SceneManager.sceneCountInBuildSettings - 1))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
