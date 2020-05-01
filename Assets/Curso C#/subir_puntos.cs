using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subir_puntos : MonoBehaviour
{
    public static int punt = 0;
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            Debug.Log("+1");
            punt++;
            Destroy(this.gameObject);
        }
    }
}
