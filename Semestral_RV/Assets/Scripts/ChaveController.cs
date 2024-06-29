using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChaveController : MonoBehaviour
{
    public GameObject chave; 

    void Start(){
       chave.SetActive(false); 
    }

    void Update(){
        if (GameObject.FindGameObjectsWithTag("Alvo").Length == 0){
            chave.SetActive(true);
        }
    }
}
