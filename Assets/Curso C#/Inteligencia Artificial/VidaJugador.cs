using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : MonoBehaviour
{

    public int vidaMax;
    public int current;
    public bool isTrue = false;

    HealthBar healthBar;

    void Start()
    {
        healthBar = PlayerManager.instance.BarraVida;
        current = vidaMax;
        InvokeRepeating("DAMAGE", 0, 1);
        healthBar.SetMaxHealth(vidaMax);
    }

    // Update is called once per frame
    public void DAMAGE(){
        if(isTrue){
            current -= 1;
            healthBar.SetHealth(current);
        }
    }
}
