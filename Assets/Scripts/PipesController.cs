using UnityEngine;

public class PipesController : MonoBehaviour
{
    public float moveSpeed = 5;
    public int deadSpace = -45;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadSpace)
        {
            Debug.Log("Pipe deleted");
            Destroy(gameObject);
        }
    }

    // Set the move speed dynamically
    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
}
