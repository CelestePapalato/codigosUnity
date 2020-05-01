using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Si el espacio se presiona
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Space Key");
        }

        //Si la E se mantiene presionada
        if(Input.GetKey(KeyCode.E)){
            Debug.Log("Holding E");
        }

        //Después de presionar la F
        if(Input.GetKeyUp(KeyCode.F)){
            Debug.Log("F");
        }
    }
}
