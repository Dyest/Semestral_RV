using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArmaController : MonoBehaviour
{
    public int alcance = 10;
    private AudioSource som;
    public Camera fpsCamera;
    public Image mira;
    public bool pegouChave = false;
    public AlvosController alvosController;
    public GameObject arma;

    public Canvas interagir;
    public Canvas coleta;

    void Start()
    {
        som = GetComponent<AudioSource>();
        interagir.enabled = false;
        coleta.enabled = false;
        arma.SetActive(false);
    }

    void Update()
    {
        Vector3 origemRaio = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(origemRaio, 
                            fpsCamera.transform.forward, 
                            out hit, alcance)){
            if (hit.collider.CompareTag("Alvo") && alvosController.pegouArma == true){
                mira.material.color = Color.red;
            }else if(hit.collider.CompareTag("Arma") ||
                hit.collider.CompareTag("Key")){
                    mira.material.color = Color.red;
                    interagir.enabled = true;
            }else{
                mira.material.color = Color.white;
                interagir.enabled = false;;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && alvosController.pegouArma == true)
        {
            som.Play();
            Debug.Log("1");
            if (Physics.Raycast(origemRaio, 
                                fpsCamera.transform.forward, 
                                out hit, alcance)){
                if (hit.collider.CompareTag("Alvo")){
                    Destroy(hit.collider.gameObject, 0.5f);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E)){
            if (Physics.Raycast(origemRaio, 
                                fpsCamera.transform.forward, 
                                out hit, alcance)){
                if (hit.collider.CompareTag("Key")){
                    pegouChave = true;
                    coleta.enabled = true;
                    Destroy(hit.collider.gameObject);
                    ChavePortaoController.chavePortao = true;
                }
                if (hit.collider.CompareTag("Arma")){
                    alvosController.pegouArma = true;
                    arma.SetActive(true);
                    Destroy(hit.collider.gameObject); 
                }
            }
        }
    }
}
