using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject m_main;
    [SerializeField] GameObject m_levels;
    private void Start()
    {
        SwitchView(true);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void SwitchView(bool b)
    {
        m_main.SetActive(b);
        m_levels.SetActive(!b);
    }
    public void PlayLevel(int l)
    {
        SceneManager.LoadScene(l);
    }
}
