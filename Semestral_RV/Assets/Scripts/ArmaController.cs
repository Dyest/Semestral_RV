using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmaController : MonoBehaviour
{
    public int alcance = 40;
    public Transform inicioTiro;
    private AudioSource som;
    private LineRenderer laser;
    private Camera fpsCamera;
    public Image mira;

    void Start()
    {
        laser = GetComponent<LineRenderer>();
        som = GetComponent<AudioSource>();
        fpsCamera = GetComponentInParent<Camera>();
        som.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0)){
            som.enabled = true;

            Vector3 origemRaio = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            laser.SetPosition(0, inicioTiro.transform.position);

            if(Physics.Raycast(origemRaio, fpsCamera.transform.forward, out hit, alcance)){
                laser.SetPosition(1, hit.point);
                if (hit.collider.CompareTag("Alvo"))
                {
                    mira.color = Color.red;
                }else{
                    mira.color = Color.white;
                }
            }else{
                laser.SetPosition(1, origemRaio + (fpsCamera.transform.forward * alcance));
            }
        }
    }
}
