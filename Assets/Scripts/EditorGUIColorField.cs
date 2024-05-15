using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Change The color of the selected Game Objects
class EditorGUIColorField : EditorWindow
{
    Color matColor = Color.white;

    [MenuItem("Examples/Mass Color Change")]

    static void Init()
    {
        var window = GetWindow<EditorGUIColorField>();
        window.position = new Rect(0, 0, 170, 60);
        window.Show();
    }

    void OnGUI()
    {
        matColor = EditorGUI.ColorField(new Rect(3, 3, position.width - 6, 15),
            "New Color:",
            matColor);
        if (GUI.Button(new Rect(3, 25, position.width - 6, 30), "Change!"))
        {
            ChangeColors();
        }
    }

    void ChangeColors()
    {
        if (Selection.activeGameObject)
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                Renderer rend = obj.GetComponent<Renderer>();

                if (rend != null)
                {
                    rend.sharedMaterial.color = matColor;
                }
            }
        }
    }
}