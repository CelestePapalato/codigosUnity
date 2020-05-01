using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puntuacion : MonoBehaviour
{
    private static int score;

    [SerializeField]
    private int meta = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        score = subir_puntos.punt;
        if( score == meta){
            Debug.Log("YOU WIN");
            Time.timeScale = 0;
            enabled = false;
        }
    }
}
