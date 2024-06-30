using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class JorginhoController : MonoBehaviour
{
    public Transform pointX; // Ponto inicial
    public Transform pointY; // Ponto intermediário
    public Transform pointZ; // Ponto final
    public Transform pointX2; // Ponto inicial
    public Transform pointY2; 
    public float durationXY = 2.0f; // Duração da movimentação de X para Y
    public float durationYZ = 10.0f; // Duração da movimentação de Y para Z
    public float durationXY2 = 3.0f; // Duração da movimentação de X para Y
    public AudioSource scarySound;
    public AudioSource running;
    private NavMeshAgent navMeshAgent;
    private Transform playerTransform;
    private bool finishAnim = false;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Certifique-se que o player tenha a tag "Player"
        navMeshAgent.enabled = false; // Desabilitar o NavMeshAgent inicialmente
    }

    private void Start()
    {
        // Verifica se o MoveThroughPoints2 já foi ativado
        if (PlayerPrefs.GetInt("MoveThroughPoints2Activated", 0) == 1)
        {
            finishAnim = true;
            navMeshAgent.enabled = true;
        }
    }

    public void Collider1Scene()
    {
        StartCoroutine(MoveThroughPoints());
        scarySound.Play();
        running.Play();
    }

    public void Collider2Scene()
    {
        gameObject.SetActive(true);
        if (!finishAnim) // Verifica se já passou pela animação
        {
            StartCoroutine(MoveThroughPoints2());
        }
    }

    IEnumerator MoveThroughPoints()
    {
        // Mover de X para Y
        yield return StartCoroutine(MoveFromTo(pointX.position, pointY.position, pointX.rotation, pointY.rotation, durationXY));

        // Mover de Y para Z
        yield return StartCoroutine(MoveFromTo(pointY.position, pointZ.position, pointY.rotation, pointZ.rotation, durationYZ));

        scarySound.Stop();
        running.Stop();
        // Desativar o objeto ao chegar no ponto Z
        gameObject.SetActive(false);
    }

    IEnumerator MoveThroughPoints2()
    {
        yield return StartCoroutine(MoveFromTo(pointX2.position, pointY2.position, pointX2.rotation, pointY2.rotation, durationXY2));
        finishAnim = true;
        PlayerPrefs.SetInt("MoveThroughPoints2Activated", 1); // Salva o estado
    }

    IEnumerator MoveFromTo(Vector3 start, Vector3 end, Quaternion startRotation, Quaternion endRotation, float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(start, end, elapsedTime / duration);
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = end;
        transform.rotation = endRotation;
    }

    void Update()
    {
        if (ChavePortaoController.chavePortao && finishAnim)
        {
            navMeshAgent.enabled = true;
        }

        if (navMeshAgent.enabled)
        {
            navMeshAgent.SetDestination(playerTransform.position);
        }
    }

    void OnDestroy()
    {
        PlayerPrefs.DeleteKey("FirstColliderActivated"); // Limpa o estado do collider ao sair do jogo
 //       PlayerPrefs.DeleteKey("MoveThroughPoints2Activated"); // Limpa o estado do MoveThroughPoints2 ao sair do jogo
    }
}
