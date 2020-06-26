using UnityEditor;
using UnityEngine;
using System.Collections;

// Shows the Assets menu when you right click on the contextRect Rectangle.
public class PopupEditorTest : MonoBehaviour
{
    void OnGUI()
    {
        Event evt = Event.current;
        Rect contextRect = new Rect(10, 10, 100, 100);
        if (evt.type == EventType.ContextClick)
        {
            Vector2 mousePos = evt.mousePosition;
            if (contextRect.Contains(mousePos))
            {
                EditorUtility.DisplayPopupMenu(new Rect(mousePos.x, mousePos.y, 0, 0), "Assets/", null);
                evt.Use();
            }
        }
    }
}