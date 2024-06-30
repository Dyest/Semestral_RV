using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GosthEvent : MonoBehaviour
{
    public GameObject objectToActivate; // Objeto que será ativado
    public AudioSource audioSource; // Componente AudioSource para reproduzir o som

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto que entrou no trigger é o jogador
        {
            objectToActivate.SetActive(true); // Ativa o objeto

            if (audioSource != null) // Verifica se o AudioSource foi atribuído
            {
                audioSource.Play(); // Reproduz o som
            }
        }
    }
}
