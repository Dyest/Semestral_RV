using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmaController : MonoBehaviour
{
    public int alcance = 40;
    //public Transform inicioTiro;
    private AudioSource som;
    //private LineRenderer laser;
    private Camera fpsCamera;
    public Image mira;

    void Start()
    {
        //laser = GetComponent<LineRenderer>();
        som = GetComponent<AudioSource>();
        fpsCamera = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Verificação do Raycast para mudar a cor da mira
        Vector3 origemRaio = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(origemRaio, fpsCamera.transform.forward, out hit, alcance))
        {
            if (hit.collider.CompareTag("Alvo"))
            {
                mira.material.color = Color.red;
            }
            else
            {
                mira.material.color = Color.white;
            }
        }

        // Disparo
        if (Input.GetKey(KeyCode.Mouse0))
        {
            som.Play();
            //laser.SetPosition(0, inicioTiro.transform.position);

            if (Physics.Raycast(origemRaio, fpsCamera.transform.forward, out hit, alcance))
            {
                //laser.SetPosition(1, hit.point);
                if (hit.collider.CompareTag("Alvo"))
                {
                    Destroy(hit.collider.gameObject, 0.5f);
                }
            }
        }
    }
}
