using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static float moveSpeed = 5.5f;
    public static float leftRigthSpeed = moveSpeed - 1;
    static public bool canMoove = false;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;

    private void Start()
    {
        moveSpeed = 5.5f;
    }

    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward, Space.World);

        if (!canMoove)
            return;

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

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            if (!isJumping)
            {
                playerObject.GetComponent<Animator>().Play("Jump");
                isJumping = true;
                StartCoroutine(JumpSequence());
            }
        }

        if (isJumping)
        {
            if (!comingDown)
            {
                transform.Translate(3.5f * Time.deltaTime * Vector3.up, Space.World);
            }
            if (comingDown)
            {
                transform.Translate(-3.5f * Time.deltaTime * Vector3.up, Space.World);
            }
        }
    }

    IEnumerator JumpSequence()
    {
        float initialYPosition = transform.position.y; // Guardar la posición inicial en el eje Y
        float jumpHeight = 2f; // Altura del salto
        float timeToReachPeak = 0.2f; // Tiempo para alcanzar la altura máxima del salto

        float timeElapsed = 0f;
        float yOffset = 0f;

        while (timeElapsed < timeToReachPeak)
        {
            yOffset = Mathf.Lerp(0f, jumpHeight, timeElapsed / timeToReachPeak); // Calcular el desplazamiento vertical en función del tiempo
            transform.position = new Vector3(transform.position.x, initialYPosition + yOffset, transform.position.z);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        while (yOffset > 0f)
        {
            yOffset -= 3.5f * Time.deltaTime; // Descender gradualmente
            transform.position = new Vector3(transform.position.x, initialYPosition + yOffset, transform.position.z);
            yield return null;
        }

        transform.position = new Vector3(transform.position.x, initialYPosition, transform.position.z); // Establecer la posición Y en la original
        isJumping = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");
    }

}
