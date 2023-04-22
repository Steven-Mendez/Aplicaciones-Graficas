using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftSide = -3.5f;
    public static float rigthSide = 3.5f;
    public float internalLeft;
    public float internalRigth;

    void Update()
    {
        internalLeft = leftSide;
        internalRigth = rigthSide;
    }
}
