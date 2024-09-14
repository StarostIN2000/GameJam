using UnityEngine;

public class GateController2D : MonoBehaviour
{
    public Transform gate; // Ворота, которые нужно перемещать
    public Vector3 openPosition; // Позиция открытых ворот
    public Vector3 closedPosition; // Позиция закрытых ворот
    public float gateSpeed = 2f; // Скорость открытия/закрытия ворот
    private bool playerInTrigger = false; // Проверка на то, находится ли игрок в зоне триггера

    void FixedUpdate()
    {
        if (playerInTrigger)
        {
            OpenGate(); // Если игрок в зоне — ворота открываются
        }
        else
        {
            CloseGate(); // Если игрок покинул зону — ворота закрываются
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

    // Срабатывает, когда игрок входит в триггерную зону
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true; // Игрок в зоне триггера
            Debug.Log("Оу дааааа");
        }
    }

    // Срабатывает, когда игрок покидает триггерную зону
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false; // Игрок вышел из зоны триггера
        }
    }
}
