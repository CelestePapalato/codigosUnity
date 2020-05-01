using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableBox : MonoBehaviour
{
    public int currentHealth = 3;

    public void Damage(int damageAmount){
            currentHealth -= damageAmount;
            if(currentHealth <= 0){
                subir_puntos.punt++;
                Debug.Log("Uno menos");
                gameObject.SetActive(false);
            }
    }
}
