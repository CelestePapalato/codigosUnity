using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class acádeberíair_PLAYER : MonoBehaviour
{
    //Declaro una nueva variable. Al no darle valor alguno, puedo hacerlo desde la ventana Inspector.
    public Vector3 StartPosition;
    // Start is called before the first frame update
    void Start()
    {
        //seteo una nueva posición
        transform.position = StartPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
