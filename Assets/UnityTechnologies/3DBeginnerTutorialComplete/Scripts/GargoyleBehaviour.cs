using UnityEngine;

public class GargoyleBehaviour : MonoBehaviour
{
    public float angleWidth;

    public float rotateSpeed;

    public float playerSuspicionDistance;

    public Transform player;

    private float startRotation;



    void Start ()
    {
        startRotation = transform.eulerAngles.y;
    }
    void Update ()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if(distance <= playerSuspicionDistance)
        {

            transform.Rotate(new Vector3 (0, rotateSpeed, 0) * Time.deltaTime);

            if (Mathf.Abs(transform.eulerAngles.y - startRotation) >= angleWidth/2){
                rotateSpeed *= -1;
            }

        }




    }
}
