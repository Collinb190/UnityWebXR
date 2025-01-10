using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

/// <summary>
/// Highlights specific objects in the Hierarchy with custom background and text colors.
/// </summary>
[InitializeOnLoad]
public class HierarchyObjectColor
{
    // Define the mapping of object names to their colors.
    private static readonly Dictionary<string, (Color backgroundColor, Color textColor)> ObjectColors = new Dictionary<string, (Color, Color)>()
    {
        { "UI", (new Color(0.15f, 0.4f, 0.8f), Color.white) },
        { "Gizmos", (new Color(0.15f, 0.5f, 0.08f), Color.white) },
        { "Environment", (new Color(0.35f, 0.25f, 0.6f), new Color(1f, 1f, 1f)) }
    };

    private static readonly Vector2 Offset = new Vector2(20, 1);

    static HierarchyObjectColor()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
    }

    private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        // Convert the instance ID to a GameObject.
        var obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (obj == null || !ObjectColors.ContainsKey(obj.name))
            return; // Skip if the object is null or not in the mapping.

        // Retrieve the colors for the object.
        var (backgroundColor, textColor) = ObjectColors[obj.name];

        // Draw the background rectangle.
        Rect bgRect = new Rect(selectionRect.x, selectionRect.y, selectionRect.width + 50, selectionRect.height);
        EditorGUI.DrawRect(bgRect, backgroundColor);

        // Draw the object's name with the custom text color.
        Rect textRect = new Rect(selectionRect.position + Offset, selectionRect.size);
        EditorGUI.LabelField(textRect, obj.name, new GUIStyle()
        {
            normal = new GUIStyleState() { textColor = textColor },
            fontStyle = FontStyle.Bold
        });
    }
}
#endif
