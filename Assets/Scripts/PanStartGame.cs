using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Handles the start game functionality with fade transitions
/// </summary>
public class PanStartGame : MonoBehaviour
{
    /// <summary>
    /// Name of the scene to load when start button is clicked
    /// </summary>
    public string sceneName;

    /// <summary>
    /// Duration of the fade transition in seconds
    /// </summary>
    public float fadeDuration = 2f;

    /// <summary>
    /// Reference to the start button
    /// </summary>
    public Button btnStart;

    /// <summary>
    /// Reference to the fade controller for managing screen transitions
    /// </summary>
    public PanFadeController fadeController;

    /// <summary>
    /// Called when the script is first loaded
    /// </summary>
    void Start()
    {
        // Start with a fade out effect to show the start screen
        fadeController.FadeOut(fadeDuration);

        // Add click listener to start button
        btnStart.onClick.AddListener(() =>
        {
            // Fade in (black screen) and load the specified scene when fade completes
            fadeController.FadeIn(fadeDuration, () => SceneManager.LoadScene(sceneName));
        });
    }
}
