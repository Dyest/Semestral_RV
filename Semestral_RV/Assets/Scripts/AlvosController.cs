using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlvosController : MonoBehaviour
{
    public GameObject[] alvos; // Array de prefabs
    public GameObject[] paredes; // Array de paredes
    private bool pegouArma = true;

    void Update()
    {
        if(pegouArma){
            if (alvos.Length == paredes.Length && alvos.Length == 4)
            {
                for (int i = 0; i < paredes.Length; i++)
                {
                    Quaternion rotacao = Quaternion.Euler(0, 180, 0);
                    Instantiate(alvos[i], paredes[i].transform.position, rotacao);
                }
                pegouArma = false;
            }
        }  
    }
}
