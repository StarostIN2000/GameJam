using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFloor : MonoBehaviour
{
    public GameObject gj; // Объект, у которого будем включать/выключать коллайдер

    // Метод для отключения коллайдера
    public void DisableChild(GameObject gj)
    {
        Collider childCollider = gj.GetComponent<Collider>();
        if (childCollider != null)
        {
            childCollider.enabled = false; // Отключаем коллайдер
        }
    }

    // Метод для включения коллайдера
    public void EnableChild(GameObject gj)
    {
        Collider childCollider = gj.GetComponent<Collider>();
        if (childCollider != null)
        {
            childCollider.enabled = true; // Включаем коллайдер
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DisableChild(gj); // Отключаем коллайдер, когда игрок в зоне
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnableChild(gj); // Включаем коллайдер, когда игрок уходит
        }
    }
}
