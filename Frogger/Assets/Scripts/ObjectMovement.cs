using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    float speed = 2.0f;

    Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
    }
    int moveDirection;

    public void SetMoveDirectionAndSpeed(bool left, float speed)
    {
        moveDirection = left?-1:1;
        this.speed = speed;
    }

    private void Update()
    {
        myTransform.Translate(new Vector2(moveDirection, 0) * Time.deltaTime * speed);
    }
}
