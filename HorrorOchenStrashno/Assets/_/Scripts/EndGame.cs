using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void Next()
    {
        GetComponent<Collider>().enabled = false;
        FindObjectOfType<CloneSpawner>().gameObject.SetActive(false);

        if (SceneManager.GetActiveScene().buildIndex < (SceneManager.sceneCountInBuildSettings - 1))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CloneSpawner>())
        {
            Next();
            
        }
    }
}
