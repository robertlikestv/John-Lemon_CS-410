using UnityEngine;

public class GargoyleBehaviour : MonoBehaviour
{
    public float angleWidth;

    public float rotateSpeed;

    public float playerSuspicionDistance;

    public Transform player;

    private float startRotation;

    private float timeInSight = 0;
    public AudioSource alertedAudio;
    bool m_HasAudioPlayed;



    void Start ()
    {
        startRotation = transform.eulerAngles.y;
    }
    void Update ()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if(distance <= playerSuspicionDistance)
        {
            Debug.Log("in distance");
            //player is in eyesight and in range

            Vector3 eyes = transform.position + Vector3.up;
            Vector3 playerPos = player.position + Vector3.up;
            Vector3 vectorDirection = playerPos - eyes;
            //Ray ray = new Ray(transform.position, vectorDirection);
            RaycastHit raycastHit;
            
            if (Physics.Raycast (transform.position, vectorDirection, out raycastHit, distance + 1))
            {
                                    Debug.Log("Ray Cast hit");
                if (raycastHit.collider.transform == player.transform)
                {
                    Debug.Log("in sight");
                    if (!m_HasAudioPlayed)
                    {
                        alertedAudio.Play();
                        m_HasAudioPlayed = true;
                    }
                    timeInSight += Time.deltaTime;
                    float actualRotate = Mathf.Lerp(0, rotateSpeed, 0.1f * timeInSight);
                    transform.Rotate(new Vector3 (0, actualRotate, 0) * Time.deltaTime);

                    if (Mathf.Abs(transform.eulerAngles.y - startRotation) >= angleWidth/2)
                    {
                        rotateSpeed *= -1;
                    }
                }
                else
                {
                Debug.Log("out of sight");

                timeInSight = 0;
                m_HasAudioPlayed = false;
            }   
            }

        }
        else{
            timeInSight = 0;
            m_HasAudioPlayed = false;
        }
    }
}
