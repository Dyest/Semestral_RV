using System.Collections;
using UnityEngine;

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

    public void Collider1Scene()
    {
        StartCoroutine(MoveThroughPoints());
        scarySound.Play();
        running.Play();
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
        gameObject.SetActive(false);
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

    void OnDestroy()
    {
        PlayerPrefs.DeleteKey("FirstColliderActivated"); // Limpa o estado do collider ao sair do jogo
    }
}
