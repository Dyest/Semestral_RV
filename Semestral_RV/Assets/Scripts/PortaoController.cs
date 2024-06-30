using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortaoController : MonoBehaviour
{
    public Canvas canvasPortao;

    void Start(){
        canvasPortao.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(ChavePortaoController.chavePortao == true){
            //felicidade abre o portão ganhou
        }else{
            //canvas precisa da chave 
            //Não sei como vc estao fazendo para identificar as coisas poer isso deixei assim
            //canvasPortao.enabled = true;
        }
    }
}
