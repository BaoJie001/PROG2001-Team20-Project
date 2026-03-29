using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Controller for managing fade transitions using CanvasGroup
/// </summary>
public class PanFadeController : MonoBehaviour
{
    /// <summary>
    /// Reference to the CanvasGroup component for controlling transparency
    /// </summary>
    public CanvasGroup canvasGroup;

    /// <summary>
    /// Called when the object is initialized
    /// </summary>
    void Awake()
    {
        // Get reference to CanvasGroup component on the same GameObject
        canvasGroup = GetComponent<CanvasGroup>();
    }

    /// <summary>
    /// Fades in (increases alpha from 0 to 1)
    /// </summary>
    /// <param name="duration">Duration of the fade in seconds</param>
    /// <param name="OnFinished">Callback to invoke when fade completes</param>
    public void FadeIn(float duration, UnityAction OnFinished = null)
    {
        StartCoroutine(FadeCoroutine(0f, 1f, duration, OnFinished));
    }

    /// <summary>
    /// Fades out (decreases alpha from 1 to 0)
    /// </summary>
    /// <param name="duration">Duration of the fade in seconds</param>
    /// <param name="OnFinished">Callback to invoke when fade completes</param>
    public void FadeOut(float duration, UnityAction OnFinished = null)
    {
        StartCoroutine(FadeCoroutine(1f, 0f, duration, OnFinished));
    }

    /// <summary>
    /// Coroutine that handles the fade animation
    /// </summary>
    /// <param name="startAlpha">Starting alpha value (0-1)</param>
    /// <param name="endAlpha">Ending alpha value (0-1)</param>
    /// <param name="duration">Duration of the fade in seconds</param>
    /// <param name="OnFinished">Callback to invoke when fade completes</param>
    /// <returns>IEnumerator for coroutine</returns>
    private IEnumerator FadeCoroutine(
        float startAlpha,
        float endAlpha,
        float duration,
        UnityAction OnFinished = null
    )
    {
        float elapsedTime = 0f;
        canvasGroup.alpha = startAlpha;

        // Loop until the fade duration is complete
        while (elapsedTime < duration)
        {
            // Calculate current alpha using linear interpolation
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            canvasGroup.alpha = alpha;
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for next frame
        }

        // Ensure final alpha value is set correctly
        canvasGroup.alpha = endAlpha;

        // Set final interaction state
        if (endAlpha > 0.1f)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        // Invoke callback if provided
        OnFinished?.Invoke();
    }
}
