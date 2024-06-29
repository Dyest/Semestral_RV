using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportManager : MonoBehaviour
{
    public static TeleportManager Instance;

    private Vector3 teleportPosition;
    private bool shouldTeleport = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SetTeleportPosition(Vector3 position)
    {
        teleportPosition = position;
        shouldTeleport = true;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (shouldTeleport)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                Debug.Log("Player encontrado na cena.");
                player.transform.position = teleportPosition;
                Debug.Log("Posição do player definida para: " + player.transform.position);
                shouldTeleport = false; // Reset após o teletransporte
            }
            else
            {
                Debug.LogError("Player não encontrado na cena.");
            }
        }
    }
}
