using UnityEditor;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public GameManager GameManager;
    public enum MoveDirection { Left, Right, Up, Down, LeftUP, LeftDown }
    public MoveDirection direction = MoveDirection.Left;
    [SerializeField] float leftSpeed = 10.0f;

    public void UpdateSpeed(float newspeed)
    {
        leftSpeed = newspeed;
    }

    private void Start()
    {
       GameManager = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {   
        Vector2 move = Vector2.zero;

        switch (direction)
        {
            case MoveDirection.Left:
                move = Vector2.left;
                break;
            case MoveDirection.Right:
                move = Vector2.right;
                break;
            case MoveDirection.Up:
                move = Vector2.up;
                break;
            case MoveDirection.Down:
                move = Vector2.down;
                break;
            case MoveDirection.LeftUP:
                move = (Vector2.left + Vector2.up).normalized;
                break;
            case MoveDirection.LeftDown:
                move = (Vector2.left + Vector2.down).normalized;
                break;
        }

        transform.Translate(move * leftSpeed * Time.deltaTime);
    }
}