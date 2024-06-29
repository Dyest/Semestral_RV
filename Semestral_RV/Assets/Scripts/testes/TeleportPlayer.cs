using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    void OnEnable()
    {
        if (PlayerPrefs.HasKey("TeleportX"))
        {
            float x = PlayerPrefs.GetFloat("TeleportX");
            float y = PlayerPrefs.GetFloat("TeleportY");
            float z = PlayerPrefs.GetFloat("TeleportZ");

            Vector3 teleportPosition = new Vector3(x, y, z);
            Debug.Log("Carregando posição de teletransporte: " + teleportPosition);

            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                Debug.Log("Player encontrado na cena.");
                player.transform.position = teleportPosition;
                Debug.Log("Posição do player definida para: " + player.transform.position);
            }
            else
            {
                Debug.LogError("Player não encontrado na cena.");
            }

            // Remove os valores para evitar reposicionamentos incorretos
            PlayerPrefs.DeleteKey("TeleportX");
            PlayerPrefs.DeleteKey("TeleportY");
            PlayerPrefs.DeleteKey("TeleportZ");
        }
        else
        {
            Debug.LogWarning("Nenhuma posição de teletransporte encontrada.");
        }
    }
}
