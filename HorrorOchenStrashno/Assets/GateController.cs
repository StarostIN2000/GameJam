using UnityEngine;

public class GateController2D : MonoBehaviour
{
    public Transform gate; // ������, ������� ����� ����������
    public Vector3 openPosition; // ������� �������� �����
    public Vector3 closedPosition; // ������� �������� �����
    public float gateSpeed = 2f; // �������� ��������/�������� �����
    private bool playerInTrigger = false; // �������� �� ��, ��������� �� ����� � ���� ��������

    void FixedUpdate()
    {
        if (playerInTrigger)
        {
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
            Debug.Log("�� ������");
        }
    }

    // �����������, ����� ����� �������� ���������� ����
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false; // ����� ����� �� ���� ��������
        }
    }
}
