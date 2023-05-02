using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5;
    public float leftRigthSpeed = 4;

    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(leftRigthSpeed * Time.deltaTime * Vector3.left, Space.World);
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (gameObject.transform.position.x < LevelBoundary.rigthSide)
            {
                transform.Translate(leftRigthSpeed * Time.deltaTime * Vector3.right, Space.World);
            }
        }
    }
}
