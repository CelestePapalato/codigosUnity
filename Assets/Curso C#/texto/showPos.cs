using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showPos : MonoBehaviour
{
    public Transform objeto;
    private Text txt;
    void Start(){
        txt = GetComponent<UnityEngine.UI.Text>();
    }
    void Update(){
        txt.text = objeto.position.ToString();
    }
}
