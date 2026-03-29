using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanGameLvA : MonoBehaviour
{
    public string sceneName;

    [SerializeField]
    private GameObject tartgetItem;

    [SerializeField]
    private PanFadeController fadeController;

    [SerializeField]
    private Button btnMenu; // Menu

    [SerializeField]
    private Button btnReSet; // Reset all parameters

    [SerializeField]
    private Button btnAdd; // Increase scale value

    [SerializeField]
    private Button btnDesc; // Decrease scale value

    [SerializeField]
    private Button btnL; // Rotate left around Y-axis

    [SerializeField]
    private Button btnR; // Rotate right around Y-axis

    [SerializeField]
    private Button btnMoveL; // Move left

    [SerializeField]
    private Button btnMoveR; // Move right

    [SerializeField]
    private Button btnMoveUp; // Move up

    [SerializeField]
    private Button btnMoveDown; // Move down

    private void Start()
    {
        // Add button listeners
        btnMenu.onClick.AddListener(BackToMenu);
        btnReSet.onClick.AddListener(ResetParameters);
        btnAdd.onClick.AddListener(IncreaseScale);
        btnDesc.onClick.AddListener(DecreaseScale);
        btnL.onClick.AddListener(RotateLeft);
        btnR.onClick.AddListener(RotateRight);
        btnMoveL.onClick.AddListener(MoveLeft);
        btnMoveR.onClick.AddListener(MoveRight);
        btnMoveUp.onClick.AddListener(MoveUp);
        btnMoveDown.onClick.AddListener(MoveDown);
        fadeController.FadeOut(3f); // Start with fade out effect
    }

    // Set the target item to manipulate
    private void BackToMenu()
    {
        fadeController.FadeIn(1f, () => SceneManager.LoadScene(sceneName));
    }

    /// <summary>
    /// Reset the target item to default position, rotation and scale
    /// </summary>
    private void ResetParameters()
    {
        if (tartgetItem != null)
        {
            tartgetItem.transform.position = Vector3.zero;
            tartgetItem.transform.rotation = Quaternion.identity;
            tartgetItem.transform.localScale = Vector3.one;
        }
    }

    /// <summary>
    /// Increase the scale of the target item
    /// </summary>
    private void IncreaseScale()
    {
        if (tartgetItem != null)
        {
            tartgetItem.transform.localScale *= 1.1f;
        }
    }

    /// <summary>
    /// Decrease the scale of the target item
    /// </summary>
    private void DecreaseScale()
    {
        if (tartgetItem != null)
        {
            tartgetItem.transform.localScale *= 0.9f;
        }
    }

    /// <summary>
    /// Rotate the target item left around Y-axis
    /// </summary>
    private void RotateLeft()
    {
        if (tartgetItem != null)
        {
            tartgetItem.transform.Rotate(0, 45, 0);
        }
    }

    /// <summary>
    /// Rotate the target item right around Y-axis
    /// </summary>
    private void RotateRight()
    {
        if (tartgetItem != null)
        {
            tartgetItem.transform.Rotate(0, -45, 0);
        }
    }

    /// <summary>
    /// Move the target item left
    /// </summary>
    private void MoveLeft()
    {
        if (tartgetItem != null)
        {
            tartgetItem.transform.Translate(-1, 0, 0);
        }
    }

    /// <summary>
    /// Move the target item right
    /// </summary>
    private void MoveRight()
    {
        if (tartgetItem != null)
        {
            tartgetItem.transform.Translate(1, 0, 0);
        }
    }

    /// <summary>
    /// Move the target item up
    /// </summary>
    private void MoveUp()
    {
        if (tartgetItem != null)
        {
            tartgetItem.transform.Translate(0, 1, 0);
        }
    }

    /// <summary>
    /// Move the target item down
    /// </summary>
    private void MoveDown()
    {
        if (tartgetItem != null)
        {
            tartgetItem.transform.Translate(0, -1, 0);
        }
    }
}
