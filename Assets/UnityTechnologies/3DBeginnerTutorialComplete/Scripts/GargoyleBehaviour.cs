using UnityEngine;

public class GargoyleBehaviour : MonoBehaviour
{
    public float angleWidth;

    public float playerSuspicionDistance;

    public Transform player;

    private float lerpSpeed = 0.1f;
    private float leftRotateBound;
    private  float rightRotateBound;

    void Start ()
    {
            float leftRotateBound = -angleWidth/2;

            float rightRotateBound = angleWidth/2;
    }
    void Update ()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        float lerping = 0;
        while(distance <= playerSuspicionDistance)
        {
            if (lerping >= 1 || lerping <= 0)
            {
                lerpSpeed *= -1;
            }

            lerping += lerpSpeed;
            
            float rotationValue = Mathf.Lerp(leftRotateBound, rightRotateBound, lerping);

            transform.Rotate(new Vector3 (0, rotationValue, 0) * Time.deltaTime);
        }


    }
}
