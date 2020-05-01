using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    public int gunDamage = 1;
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;

    private LineRenderer laserLine; //dibujo una línea para ver la dirección
    public Camera fpsCam;
    private float nextFire;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > nextFire){
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            //seteamos el origen del láser al centro de la cámara
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3 (0.5f, 0.5f, 0));
            //obtenemos la posición del objeto que apuntamos con esta variable
            RaycastHit hit;
            laserLine.SetPosition(0, gunEnd.position);
            if(Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange)){
                laserLine.SetPosition(1, hit.point);

                //verificamos si el objeto golpeado era un objetivo
                ShootableBox health = hit.collider.GetComponent<ShootableBox>();
                if(health != null){
                    health.Damage(gunDamage);
                }
                if(hit.rigidbody != null){
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else{
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
    }

    private IEnumerator ShotEffect(){
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}
