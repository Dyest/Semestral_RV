using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneToLoad; // Nome da cena para carregar
    public Vector3 teleportPosition; // Posição de teletransporte na cena de destino

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Salva a posição de teletransporte
            PlayerPrefs.SetFloat("TeleportX", teleportPosition.x);
            PlayerPrefs.SetFloat("TeleportY", teleportPosition.y);
            PlayerPrefs.SetFloat("TeleportZ", teleportPosition.z);

            Debug.Log("Salvando posição de teletransporte: " + teleportPosition);

            // Carrega a nova cena
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
