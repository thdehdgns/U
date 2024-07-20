using UnityEditor;
using UnityEngine;

public class DataEditor : EditorWindow
{
    [MenuItem("Editor/DataEditor")]
    static void Open()
    {
        GetWindow<DataEditor>();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Best Score Clear"))
        {
            Debug.Log("PlayerPrefs�� BestScore �����Ͱ� �����Ǿ����ϴ�.");
            PlayerPrefs.SetFloat(GameData.BestScore, 0);
        }

        
    }
}