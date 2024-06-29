using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlvosController : MonoBehaviour
{
    public GameObject[] alvos; 
    public bool alvosCriados = false;
    public GameObject chave;
    public bool pegouArma = false;

    private Vector3[] posicoes1 = {
        new Vector3(8.46000004f, 0.0700000003f, 29.4400005f),
        new Vector3(14.5900002f, 4.3499999f, 29.4400005f),
        new Vector3(22.3600006f, -0.25999999f, 29.4400005f),
        new Vector3(26.3700008f, 3.07999992f, 29.4400005f)
    };
    private Vector3[] posicoes2 = {
        new Vector3(0.300000012f, 4.35400009f, 28.7700005f),
        new Vector3(0.300000012f, -0.479999989f, 15.8400002f),
        new Vector3(0.300000012f, 3.16000009f, 4.26000023f),
        new Vector3(0.300000012f, 1.73000002f, 10.6899996f)
    };
    private Vector3[] posicoes3 = {
        new Vector3(2.54999995f, 2.3900001f, 0.189999998f),
        new Vector3(7.48999977f, -0.569999993f, 0.189999998f),
        new Vector3(16.8999996f, -0.569999993f, 0.189999998f),
        new Vector3(27.3199997f, 4.17000008f, 0.189999998f)
    };
    private Vector3[] posicoes4 = {
        new Vector3(29.7000008f, 4.17000008f, 1.12100005f),
        new Vector3(29.7000008f, -0.449999988f, 6.63000011f),
        new Vector3(29.7000008f, 2.63000011f, 17.8500004f),
        new Vector3(29.7000008f, 0.800000012f, 27.1000004f)
    };

    private Quaternion[] rotacoes = {
        Quaternion.Euler(270, 180, 0),
        Quaternion.Euler(270, 90, 0),
        Quaternion.Euler(270, 0, 0),
        Quaternion.Euler(270, 270, 0)
    };

    void Start(){
        chave.SetActive(false);
    }


    void Update()
    {
        if (!alvosCriados)
        {
            chave.SetActive(true);
            alvosCriados = true;

            for (int i = 0; i < alvos.Length; i++)
            {
                Vector3[] posicoes;
                switch (i)
                {
                    case 0:
                        posicoes = posicoes1;
                        break;
                    case 1:
                        posicoes = posicoes2;
                        break;
                    case 2:
                        posicoes = posicoes3;
                        break;
                    case 3:
                        posicoes = posicoes4;
                        break;
                    default:
                        posicoes = posicoes1; 
                        break;
                }

                Vector3 posicaoAleatoria = posicoes[Random.Range(0, posicoes.Length)];
                Quaternion rotacaoDesejada = rotacoes[i];
                
                Instantiate(alvos[i], posicaoAleatoria, rotacaoDesejada);
            }
        }
    }
}
