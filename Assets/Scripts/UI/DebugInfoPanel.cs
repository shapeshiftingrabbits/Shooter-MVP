using UnityEngine;

public class DebugInfoPanel : MonoBehaviour
{
  

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();

        style.alignment = TextAnchor.MiddleLeft;
        style.fontSize = 20;
        style.normal.textColor = Color.white;

        Rect rect = new Rect(0, Screen.height - 50, 200, 50);

        float msec = Time.smoothDeltaTime * 1000.0f;
        float fps = 1.0f / Time.smoothDeltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);

        GUI.Box(rect, text, style);
    }

}
    