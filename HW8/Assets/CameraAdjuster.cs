using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    // 設定你開發時的目標比例（例如 16:9 填 1.777f，4:3 填 1.333f）
    // 如果不確定，就填 16f/9f
    float targetAspect = 16f / 9f;

    void Start()
    {
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;
        Camera camera = GetComponent<Camera>();

        if (scaleHeight < 1.0f)
        {
            // 如果螢幕太窄，增加上下黑邊（Letterbox）
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            camera.rect = rect;
        }
        else
        {
            // 如果螢幕太寬，增加左右黑邊（Pillarbox）
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = camera.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            camera.rect = rect;
        }
    }
}