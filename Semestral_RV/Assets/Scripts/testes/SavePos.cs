using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePos : MonoBehaviour
{
    private string NomeCenaAtual;

    void Awake()
    {
        NomeCenaAtual = SceneManager.GetActiveScene().name;
        CarregarPosicao(); // Carregar a posição ao iniciar a cena
    }

    public void SalvarLocalizacao()
    {
        PlayerPrefs.SetFloat(NomeCenaAtual + "X", transform.position.x);
        PlayerPrefs.SetFloat(NomeCenaAtual + "Y", transform.position.y);
        PlayerPrefs.SetFloat(NomeCenaAtual + "Z", transform.position.z);
    }

    private void CarregarPosicao()
    {
        if (PlayerPrefs.HasKey(NomeCenaAtual + "X") && 
            PlayerPrefs.HasKey(NomeCenaAtual + "Y") && 
            PlayerPrefs.HasKey(NomeCenaAtual + "Z"))
        {
            transform.position = new Vector3(
                PlayerPrefs.GetFloat(NomeCenaAtual + "X"), 
                PlayerPrefs.GetFloat(NomeCenaAtual + "Y"), 
                PlayerPrefs.GetFloat(NomeCenaAtual + "Z")
            );
        }
    }
}
