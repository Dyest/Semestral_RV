using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveController : MonoBehaviour
{
    private Vector3 entradasJogador;
    private CharacterController characterController;
    private float velocidadeJogador = 4f;
    private float velocidadeCorrendo = 7f;
    private Transform myCamera;
    private bool estaNoChao;
    [SerializeField] private Transform verificadorChao;
    [SerializeField] private LayerMask cenarioMask;
    [SerializeField] private float alturaDoSalto = 1f;
    private float gravidade = -9.81f;
    private float velocidadeVertical;

    private void Awake()
    {
        myCamera = Camera.main.transform;
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

    }
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, myCamera.eulerAngles.y, transform.eulerAngles.z);
        entradasJogador = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        entradasJogador = transform.TransformDirection(entradasJogador);
        characterController.Move(entradasJogador * Time.deltaTime * velocidadeJogador);
        estaNoChao = Physics.CheckSphere(verificadorChao.position, 0.3f, cenarioMask);


        //pular
        if(Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            velocidadeVertical = (float)Math.Sqrt(alturaDoSalto * -2f * gravidade);
        }

        if(estaNoChao && velocidadeVertical < 0)
        {
            velocidadeVertical = -1f;
        }

        //correr
        if (Input.GetKey(KeyCode.LeftShift))
        {
            
            characterController.Move(entradasJogador * Time.deltaTime * velocidadeCorrendo);
        }  

        //gravidade
        velocidadeVertical += gravidade * Time.deltaTime;
        characterController.Move(new Vector3(0, velocidadeVertical, 0) * Time.deltaTime);


    }

}

