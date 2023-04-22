using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3;

    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward, Space.World);
    }
}
