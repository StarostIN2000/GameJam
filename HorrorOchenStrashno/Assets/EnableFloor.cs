using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFloor : MonoBehaviour
{
    public GameObject gj; // ������, � �������� ����� ��������/��������� ���������

    // ����� ��� ���������� ����������
    public void DisableChild(GameObject gj)
    {
        Collider childCollider = gj.GetComponent<Collider>();
        if (childCollider != null)
        {
            childCollider.enabled = false; // ��������� ���������
        }
    }

    // ����� ��� ��������� ����������
    public void EnableChild(GameObject gj)
    {
        Collider childCollider = gj.GetComponent<Collider>();
        if (childCollider != null)
        {
            childCollider.enabled = true; // �������� ���������
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DisableChild(gj); // ��������� ���������, ����� ����� � ����
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnableChild(gj); // �������� ���������, ����� ����� ������
        }
    }
}
