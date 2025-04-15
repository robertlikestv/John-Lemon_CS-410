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
            if (!m_HasAudioPlayed)
            {
                alertedAudio.Play();
                m_HasAudioPlayed = true;
            }
            timeInSight += Time.deltaTime;
            float actualRotate = Mathf.Lerp(0, rotateSpeed, 0.1f * timeInSight);
            transform.Rotate(new Vector3 (0, actualRotate, 0) * Time.deltaTime);

            if (Mathf.Abs(transform.eulerAngles.y - startRotation) >= angleWidth/2){
                rotateSpeed *= -1;
            }

        }
        else{
            timeInSight = 0;
            m_HasAudioPlayed = false;
        }




    }
}
