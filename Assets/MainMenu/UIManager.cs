using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject infoPanel;

    // 显示面板
    public void ShowInfoPanel()
    {
        infoPanel.SetActive(true);
    }

    // 隐藏面板
    public void HideInfoPanel()
    {
        infoPanel.SetActive(false);
    }
}