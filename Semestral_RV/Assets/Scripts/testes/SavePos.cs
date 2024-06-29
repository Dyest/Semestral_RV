using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePos : MonoBehaviour
{
    string NomeCenaAtual;

    void Awake()
    {
        NomeCenaAtual = SceneManager.GetActiveScene().name;
    }

    void Start()
    {
        if (GameManager.Instance != null)
        {
            transform.position = GameManager.Instance.playerPosition;
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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (GameManager.Instance != null)
        {
            transform.position = GameManager.Instance.playerPosition;
        }
    }

    public void SalvarLocalizacao()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.playerPosition = transform.position;
        }
    }
}
