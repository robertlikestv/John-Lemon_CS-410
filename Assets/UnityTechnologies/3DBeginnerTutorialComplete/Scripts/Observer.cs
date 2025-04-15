using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    public GameEnding gameEnding;
    public float fieldOfViewAngle = 60f;
    public float viewDistance = 10f;

    //bool m_IsPlayerInRange;

    void Start()
    {
        enemy = transform;
    }

    void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, viewDistance);

            float halfFOV = fieldOfViewAngle / 2f;
            Quaternion leftRayRotation = Quaternion.Euler(0, -halfFOV, 0);
            Quaternion rightRayRotation = Quaternion.Euler(0, halfFOV, 0);

            Vector3 leftRay = leftRayRotation * transform.forward * viewDistance;
            Vector3 rightRay = rightRayRotation * transform.forward * viewDistance;

            Gizmos.color = Color.cyan;
            Gizmos.DrawRay(transform.position, leftRay);
            Gizmos.DrawRay(transform.position, rightRay);
        }

/*
    void OnTriggerEnter (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }
*/

    void Update ()
    {
        Vector3 toPlayer = player.position - enemy.position;
        float distToPlayer = toPlayer.magnitude;

        if (distToPlayer > viewDistance)
        {
            //player is out of range
            return;
        }

        Vector3 toPlayerNormalized = toPlayer.normalized;
        Vector3 enemyForward = enemy.forward;

        float dotProduct = Vector3.Dot(enemyForward, toPlayerNormalized);

        float halfFOV = fieldOfViewAngle / 2f;
        float cosFOV = Mathf.Cos(halfFOV * Mathf.Deg2Rad);

        //if (m_IsPlayerInRange)
        if (dotProduct > cosFOV)
        {
            //player is in eyesight and in range
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            
            if (Physics.Raycast (ray, out raycastHit, viewDistance))
            {
                if (raycastHit.collider.transform == player)
                {
                    //no wall or object in the way - player caught
                    gameEnding.CaughtPlayer ();
                }
            }
        }
        Debug.DrawRay(transform.position, toPlayerNormalized * viewDistance, Color.red);
        OnDrawGizmosSelected();
        
        
    }
}
