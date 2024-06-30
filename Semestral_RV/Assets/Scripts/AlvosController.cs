using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlvosController : MonoBehaviour
{
    public GameObject[] alvos; 
    public bool alvosCriados = false;
    public GameObject chave;

    private Vector3[] posicoes1 = {
        new Vector3(54.7700005f,4.63999987f,143.460007f),
        new Vector3(59.5299988f,8.68999958f,143.460007f),
        new Vector3(68.5100021f,4.78000021f,143.460007f),
        new Vector3(74.6999969f,9.25f,143.460007f)
    };
    private Vector3[] posicoes2 = {
        new Vector3(46.6199989f,8.97000027f,119.010002f),
        new Vector3(46.6199989f,4.84000015f,124.209999f),
        new Vector3(46.6199989f,7.51999998f,131.850006f),
        new Vector3(46.6199989f,4.65999985f,141.770004f)
    };
    private Vector3[] posicoes3 = {
        new Vector3(71.0400009f,8.89000034f,114.010002f),
        new Vector3(62.9900017f,4.23000002f,114.010002f),
        new Vector3(55.0800018f,5.23000002f,114.010002f),
        new Vector3(47.8100014f,8.97000027f,114.010002f)
    };
    private Vector3[] posicoes4 = {
        new Vector3(75.9800034f,5.61000013f,142.809998f),
        new Vector3(75.9800034f,4.38999987f,128.429993f),
        new Vector3(75.9800034f,8.72999954f,115.940002f),
        new Vector3(75.9800034f,5.90999985f,134.690002f)
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
        if(ChavePortaoController.arma == true){
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
}
