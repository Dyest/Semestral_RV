// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class ChaveController : MonoBehaviour
// {
//     public GameObject chave; 
//     public Text txtColeta;
//     public bool pegouChave = false;

//     public int alcance = 5;
//     //public Transform inicio;
//     //private LineRenderer laser;
//     private Camera fpsCamera;
//     public Image mira;

//     void Start()
//     {
//         chave.SetActive(false); 
//         fpsCamera = GetComponentInParent<Camera>();
//     }

//     void Update()
//     {
//         if (GameObject.FindGameObjectsWithTag("Alvo").Length == 0)
//         {
//             chave.SetActive(true);
//         }

//         Vector3 origemRaio = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
//         RaycastHit hit;

//         if (Physics.Raycast(origemRaio, fpsCamera.transform.forward, out hit, alcance))
//         {
//             if (hit.collider.CompareTag("Chave"))
//             {
//                 mira.material.color = Color.red;
//             }
//             else
//             {
//                 mira.material.color = Color.white;
//             }
//         }

//         // Coleta Chave
//         if (Input.GetKeyDown(KeyCode.E))
//         {
//             if (Physics.Raycast(origemRaio, fpsCamera.transform.forward, out hit, alcance))
//             {
//                 if (hit.collider.CompareTag("Chave"))
//                 {
//                     pegouChave = true;
//                     Destroy(hit.collider.gameObject);
//                 }
//             }
//         }
//     }
// }
