using UnityEngine;

public class DebugInfoPanel : MonoBehaviour
{
    void OnGUI()
    {
        if (!Debug.isDebugBuild)
        {
            return;
        }

        GUIStyle style = new GUIStyle();

        style.alignment = TextAnchor.MiddleLeft;
        style.fontSize = 20;
        style.normal.textColor = Color.white;

        Rect rect = CreateBox();

        float msec = Time.smoothDeltaTime * 1000.0f;
        float fps = 1.0f / Time.smoothDeltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);

        GUI.Box(rect, text, style);
    }

    private static Rect CreateBox()
    {
        float width = 200.0f;
        float height = 50.0f;
        float x = 16.0f;
        float y = Screen.height - height;
        Rect rect = new Rect(x, y, width, height);
        return rect;
    }
}
    