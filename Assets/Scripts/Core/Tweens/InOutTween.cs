using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Debug/InOutTween")]
public class InOutTween : MonoBehaviour
{
    [SerializeField] private RectTransform window;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector2 endPosition;
    [SerializeField] private float animationDuration;
    [SerializeField] private AnimationCurve easingCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private Vector2 _currentPosition;

    public void MoveIn()
    {
        StartCoroutine(AnimateWindow());
    }

    public void SaveAsStart()
    {
        startPosition = window.anchoredPosition;
    }

    public void SaveAsEnd()
    {
        endPosition = window.anchoredPosition;
    }

    private IEnumerator AnimateWindow()
    {
        _currentPosition = startPosition;

        float elapsedTime = 0;
        Vector2 targetPosition = endPosition;

        while (elapsedTime < animationDuration)
        {
            float evaluationAtTime = easingCurve.Evaluate(elapsedTime / animationDuration);

            window.anchoredPosition = Vector2.Lerp(_currentPosition, targetPosition, evaluationAtTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        window.anchoredPosition = targetPosition;
    }
}
