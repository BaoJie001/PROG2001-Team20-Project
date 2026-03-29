using UnityEngine;

public class DeerController : MonoBehaviour
{
    [Header("移动距离（每次点击）")]
    public float forwardDistance = 0.5f;
    public float backwardDistance = 0.5f;
    public float runDistance = 0.8f;

    [Header("旋转角度（度）")]
    public float turnAngle = 10f;

    [Header("方向设置（根据你的模型调整）")]
    // 因为你的红色箭头指向后，前进方向是红色箭头的反方向，即局部 -X 轴
    public Vector3 forwardDirectionLocal = Vector3.left;

    [Header("缩放参数")]
    public float minScale = 0.5f;
    public float maxScale = 2.0f;
    public float scaleStep = 0.2f;

    private CharacterController controller;
    private float originalHeight;   // 初始 CharacterController 高度

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("请为小鹿添加 CharacterController 组件！");
            return;
        }
        originalHeight = controller.height;
    }

    // 获取世界空间的前方向
    private Vector3 WorldForward => transform.TransformDirection(forwardDirectionLocal);

    // 移动
    public void MoveForward() => controller?.Move(WorldForward * forwardDistance);
    public void MoveBackward() => controller?.Move(-WorldForward * backwardDistance);
    public void Run() => controller?.Move(WorldForward * runDistance);

    // 旋转（原地）
    public void TurnLeft() => transform.Rotate(Vector3.up, -turnAngle);
    public void TurnRight() => transform.Rotate(Vector3.up, turnAngle);

    // 缩放（保持位置不变）
    public void Grow() => Scale(Vector3.one * scaleStep);
    public void Shrink() => Scale(-Vector3.one * scaleStep);

    private void Scale(Vector3 delta)
    {
        if (controller == null) return;

        // 记录当前物体位置（完全不变）
        Vector3 originalPosition = transform.position;

        // 计算新缩放
        Vector3 newScale = transform.localScale + delta;
        newScale = Vector3.Min(newScale, Vector3.one * maxScale);
        newScale = Vector3.Max(newScale, Vector3.one * minScale);
        transform.localScale = newScale;

        // 更新 CharacterController 的高度和中心
        float newHeight = originalHeight * newScale.y;
        controller.height = newHeight;
        controller.center = new Vector3(0, newHeight / 2f, 0);

        // 恢复位置（强制使 Transform 的 Position 不变）
        transform.position = originalPosition;
    }
}