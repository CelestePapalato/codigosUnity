using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPos : MonoBehaviour
{
    public Transform target;
    public Text txt;

    void Update()
    {
        txt.text = target.position.ToString();
    }
}
