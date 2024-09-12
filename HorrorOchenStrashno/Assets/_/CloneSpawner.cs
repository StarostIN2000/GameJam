using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSpawner : MonoBehaviour
{
    [SerializeField] GameObject clonePrefab;

    bool ableToSpawn = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ableToSpawn)
            {
                SpawnClone();
            }
        }
    }
    public bool SpawnClone()
    {
        if (ableToSpawn)
        {
            Instantiate(clonePrefab, transform.position + Vector3.up*2, Quaternion.identity);
            ableToSpawn = false;
            return true;
        }
        return false;
    }

    public void KillClone()
    {
        ableToSpawn = true;
    }
}
