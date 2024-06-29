using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carregar : MonoBehaviour
{
    public GameObject Jogador;
    public string LoadScene;
    bool podeInteragir = false;

    void Update()
    {
        if (podeInteragir && Input.GetKeyDown(KeyCode.E))
        {
            Jogador.GetComponent<SavePos>().SalvarLocalizacao();
            SceneManager.LoadScene(LoadScene);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            podeInteragir = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            podeInteragir = false;
        }
    }
}
