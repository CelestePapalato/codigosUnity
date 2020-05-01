using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHealth : MonoBehaviour
{
    public VidaJugador vida;
    private Text txt;
    void Start(){
        txt = GetComponent<UnityEngine.UI.Text>();
    }
    void Update(){
        txt.text = vida.current.ToString();
    }
}
