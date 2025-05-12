using UnityEngine;
using UnityEngine.UI;

public class BossEntrance : MonoBehaviour
{
    public float moveDuration = 2f;

    private Vector3 startPosition;
    private Vector3 targetPosition = new Vector3(5.5f, 0, 0);
    private float elapsedTime = 0f;
    private bool isMoving = false;
    [SerializeField] BossMovement movement;

    public GameManager gameManager;
    void OnEnable()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        startPosition = new Vector3(16.09f, 5.98f, 0);
        elapsedTime = 0f;
        isMoving = true;
        gameManager.SpawnBoss();
        Vector3 pos = transform.position;
        //Debug.Log("À§Ä¡ " +  pos + "48645645414895648944545645968458564564854");
    }

    void Update()
    {
        if (!isMoving) return;
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / moveDuration);
        transform.position = Vector3.Lerp(startPosition, targetPosition, t);

        if (t >= 1f)
        {
            movement.enabled = true;
            isMoving = false;
        }
    }
}
