using System.Collections;
using UnityEngine;

public class jogrginhoActivator : MonoBehaviour
{
    public GameObject Jorginho; // Objeto fantasma que será ativado
    public AudioSource audioSource; // Fonte de áudio para tocar o som

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            // Ativa o objeto fantasma
            Jorginho.SetActive(true);

            // Toca o som
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // Inicia a corrotina para desativar o objeto após 2.5 segundos
            StartCoroutine(DeactivateAfterTime(2.5f));
        }
    }

    // Corrotina para desativar o objeto após um tempo
    private IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time); // Espera o tempo especificado
        Jorginho.SetActive(false); // Desativa o objeto
    }
}
