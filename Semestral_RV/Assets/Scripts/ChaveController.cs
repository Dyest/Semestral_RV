using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaveController : MonoBehaviour
{
    public GameObject chave; // Referência ao objeto chave

    void Start()
    {
        //chave.SetActive(false); // Inicialmente, a chave está escondida
    }

    void Update()
    {
        // Verifica o número de objetos com a tag "Inimigo_01"
        if (GameObject.FindGameObjectsWithTag("Alvo").Length == 0)
        {
            //chave.SetActive(true); // Exibe a chave
        }
    }
}
