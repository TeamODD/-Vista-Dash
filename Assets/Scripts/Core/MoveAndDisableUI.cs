using UnityEngine;
using UnityEngine.UI;

public class MoveAndDisableUI : MonoBehaviour
{
    public float moveDistance = 200f;       // 이동할 거리 (픽셀)
    public float moveDuration = 0.5f;   
       // 이동 시간 (초)
    public float waitDuration = 0.2f;
    private RectTransform rectTransform;
    private Vector2 originalPosition;

    void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;

        // 이동 시작
        StartCoroutine(MoveAndDisable());
    }

    System.Collections.IEnumerator MoveAndDisable()
    {
        Vector2 targetPosition = originalPosition + new Vector2(moveDistance, 0);
        float elapsed = 0f;

        // 1단계: 오른쪽으로 이동
        while (elapsed < moveDuration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(originalPosition, targetPosition, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = targetPosition;

        // 2단계: 잠시 대기 (선택 사항)
        yield return new WaitForSeconds(waitDuration);

        // 3단계: 다시 원위치로 이동
        elapsed = 0f;
        while (elapsed < moveDuration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(targetPosition, originalPosition, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = originalPosition;

        // 4단계: 비활성화
        gameObject.SetActive(false);
    }

}