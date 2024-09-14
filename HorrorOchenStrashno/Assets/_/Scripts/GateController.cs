using System.Collections.Generic;
using UnityEngine;

public class GateController2D : MonoBehaviour
{
    public Transform gate; // Ворота, которые нужно перемещать
    public Vector3 openPosition; // Позиция открытых ворот
    public Vector3 closedPosition; // Позиция закрытых ворот
    public float gateSpeed = 2f; // Скорость открытия/закрытия ворот
    private bool playerInTrigger = false; // Проверка на то, находится ли игрок в зоне триггера

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
            inners.Add(other);
            Debug.Log("Оу дааааа");
        }
    }

    // Срабатывает, когда игрок покидает триггерную зону
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
