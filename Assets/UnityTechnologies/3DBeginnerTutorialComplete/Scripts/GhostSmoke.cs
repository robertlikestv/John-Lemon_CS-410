using UnityEngine;

public class GhostSmoke : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;

    public ParticleSystem ghostSmoke;

    public float playerSuspicionDistance;


    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if(distance <= playerSuspicionDistance)
        {
            Debug.Log("playing");
            ghostSmoke.Play();
        }
        else{
            Debug.Log("Stopping");
            ghostSmoke.Stop();
        }
        
    }
}
