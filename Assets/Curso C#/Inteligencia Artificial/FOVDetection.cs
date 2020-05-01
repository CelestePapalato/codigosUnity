using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FOVDetection : MonoBehaviour
{
    GameObject PLAYER;
    Transform player;
    public float maxAngle;
    public float maxRadius;

    public static bool isInFov = false;

    NavMeshAgent agent;

    void Start(){
        PLAYER = PlayerManager.instance.player;
        player = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmos(){
        //dibujamos el radio de detección
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);

        //Determinamos el ángulo de visión
        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up)  * transform.forward * maxRadius;
        //Dibujamos el ángulo de visión
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        //Dibujamos una línea que une al jugador con el objeto
        if(!isInFov) Gizmos.color = Color.red;
        else Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * maxRadius);

        //Dibujamos la dirección en la que mira el objeto
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * maxRadius);
    }

    public static bool inFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius){
        Collider[] overlaps = new Collider[10];
        int count = Physics.OverlapSphereNonAlloc(checkingObject.position, maxRadius, overlaps);

        for(int i = 0; i < count + 1; i++){
            if(overlaps[i] != null){
                if(overlaps[i].transform == target){
                    Vector3 directionBetween = (target.position - checkingObject.position).normalized;
                    directionBetween.y *= 0;

                    float angle = Vector3.Angle(checkingObject.forward, directionBetween);

                    if(angle <= maxAngle){
                        Ray ray = new Ray(checkingObject.position, target.position - checkingObject.position);
                        RaycastHit hit;

                        if(Physics.Raycast(ray, out hit, maxRadius)){
                            if(hit.transform == target)
                                return true;
                        }
                    }
                }
            }
        }

        return false;
    }

    void FaceTarget(){
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void Update(){
        isInFov = inFOV(transform, player, maxAngle, maxRadius);
        VidaJugador vida = PLAYER.GetComponent<VidaJugador>();
        if(isInFov){
            FaceTarget();
            vida.isTrue = true;
            agent.SetDestination(player.position);
        }
        else vida.isTrue = false;
    }
}
