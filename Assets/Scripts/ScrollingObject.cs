using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    [SerializeField] enum MoveDirection{Left,Right,Up,Down}
    [SerializeField] MoveDirection direction = MoveDirection.Left;
    [SerializeField] float leftSpeed = 3f;

    void Update()
    {
        Vector2 move = Vector2.zero;

        switch (direction)
        {
            case MoveDirection.Left:
                move = Vector3.left;
                break;
            case MoveDirection.Right:
                move = Vector3.right;
                break;
            case MoveDirection.Up:
                move = Vector3.up;
                break;
            case MoveDirection.Down:
                move = Vector3.down;
                break;
        }

        transform.Translate(move * leftSpeed * Time.deltaTime);
    }
}
