using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JorginhoController : MonoBehaviour
{
    public Transform pointX; // Ponto inicial
    public Transform pointY; // Ponto intermediário
    public Transform pointZ; // Ponto final
    public float durationXY = 3.0f; // Duração da movimentação de X para Y
    public float durationYZ = 3.0f; // Duração da movimentação de Y para Z
    public AudioSource scarySound;
    public AudioSource running;
    

    public void Collider1Scene()
    {
            StartCoroutine(MoveThroughPoints());
            scarySound.Play();
            running.Play();
    }

    IEnumerator MoveThroughPoints()
    {
        // Mover de X para Y
        yield return StartCoroutine(MoveFromTo(pointX.position, pointY.position, durationXY));

        // Mover de Y para Z
        yield return StartCoroutine(MoveFromTo(pointY.position, pointZ.position, durationYZ));

        scarySound.Stop();
        running.Stop();
        // Desativar o objeto ao chegar no ponto Z
        gameObject.SetActive(false);
    }

    IEnumerator MoveFromTo(Vector3 start, Vector3 end, float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(start, end, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = end;
    }
}
