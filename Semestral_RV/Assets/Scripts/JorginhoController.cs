using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
    public AudioSource running_2;
    private NavMeshAgent navMeshAgent;
    private Transform playerTransform;
    private bool isRunningSoundPlaying = false;
    private bool finishAnim = false;
    private Animator animator;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Certifique-se que o player tenha a tag "Player"
        navMeshAgent.enabled = false; // Desabilitar o NavMeshAgent inicialmente
        animator = GetComponent<Animator>();
    }


    public void Collider1Scene()
    {
        if (!ChavePortaoController.chavePortao && PlayerPrefs.GetInt("Collider1SceneActivated", 0) == 0)
        {
            PlayerPrefs.SetInt("Collider1SceneActivated", 1); // Salva o estado para garantir que só execute uma vez
            StartCoroutine(MoveThroughPoints());
            scarySound.Play();
            running.Play();
        }
    }

    public void Collider2Scene()
    {
        gameObject.SetActive(true);
        StartCoroutine(MoveThroughPoints2());
    
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

        if (PlayerPrefs.GetInt("MoveThroughPoints2Activated", 0) == 1 && ChavePortaoController.chaveSala)
        {
            
            finishAnim = true;
            navMeshAgent.enabled = true;
        }



        if (navMeshAgent.enabled)
        {
            if (!isRunningSoundPlaying)
            {
                running.Play();
                isRunningSoundPlaying = true;
                Debug.Log("Som de corrida tocando.");
            }

            navMeshAgent.SetDestination(playerTransform.position);

            // Calcula a distância até o jogador
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            // Se a distância ao jogador for menor ou igual a 1 unidade, inicia a animação de ataque
            if (distanceToPlayer <= 2.3f)
            {
                animator.SetBool("Atacando", true);
                Invoke("ExecuteAfterDelay", 0.5f);
                

            }else{
                animator.SetBool("Atacando", false);
            }
        }
        else
        {
            if (isRunningSoundPlaying)
            {
                running.Stop();
                isRunningSoundPlaying = false;
                Debug.Log("Som de corrida parado.");
            }
        }
    }

    void OnDestroy()
    {
        PlayerPrefs.DeleteKey("FirstColliderActivated"); // Limpa o estado do collider ao sair do jogo
        // Não limpar MoveThroughPoints2Activated para manter o estado entre cenas
    }

    void ExecuteAfterDelay()
    {
        // Espera pelo tempo especificado
        SceneManager.LoadScene("GameOver");
    }


    
}