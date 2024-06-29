using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carregar : MonoBehaviour
{
    public GameObject Jogador;
    public string LoadScene;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Jogador) // Verifica se o jogador entrou no trigger
        {
            Jogador.GetComponent<SavePos>().SalvarLocalizacao(); // Salva a posição do jogador
            SceneManager.LoadScene(LoadScene); // Carrega a nova cena
        }
    }
}
