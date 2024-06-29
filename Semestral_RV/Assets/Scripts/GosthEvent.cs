using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GosthEvent : MonoBehaviour
{
     public GameObject objectToActivate; // Objeto que será ativado

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto que entrou no trigger é o jogador
        {
            objectToActivate.SetActive(true); // Ativa o objeto
        }
    }
}
