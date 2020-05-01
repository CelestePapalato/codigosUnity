using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        Debug.Log("aaa");
        if(other.tag == "Player"){
            Debug.Log("sgfrf");
            Destroy(this.gameObject);
        }
    }
}
