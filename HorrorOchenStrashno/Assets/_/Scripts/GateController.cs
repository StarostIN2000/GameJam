using System.Collections.Generic;
using UnityEngine;

public class GateController2D : MonoBehaviour
{
    public Transform gate; // ������, ������� ����� ����������
    public Vector3 openPosition; // ������� �������� �����
    public Vector3 closedPosition; // ������� �������� �����
    public float gateSpeed = 2f; // �������� ��������/�������� �����
    private bool playerInTrigger = false; // �������� �� ��, ��������� �� ����� � ���� ��������

    List<Collider> inners;

    private void Start()
    {
        inners = new List<Collider>();
    }
    void FixedUpdate()
    {
        if (playerInTrigger)
        {
            foreach(var i in inners)
                if (i == null)
                    inners.Remove(i);

            if (inners.Count == 0)
                playerInTrigger = false;

            OpenGate(); // ���� ����� � ���� � ������ �����������
        }
        else
        {
            CloseGate(); // ���� ����� ������� ���� � ������ �����������
        }
    }

    void OpenGate()
    {
        gate.position = Vector3.MoveTowards(gate.position, openPosition, gateSpeed * Time.deltaTime);
    }

    void CloseGate()
    {
        gate.position = Vector3.MoveTowards(gate.position, closedPosition, gateSpeed * Time.deltaTime);
    }

    // �����������, ����� ����� ������ � ���������� ����
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true; // ����� � ���� ��������
            inners.Add(other);
            Debug.Log("�� ������");
        }
    }

    // �����������, ����� ����� �������� ���������� ����
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(inners.Contains(other))
                inners.Remove(other);
            if (inners.Count == 0)
                playerInTrigger = false;
        }
    }
    
}
