using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;

public class FindMissingScriptsInProject
{
    [MenuItem("Tools/Find Missing Scripts/In Scene")]
    static void FindMissingInScene()
    {
        int count = 0;
        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject go in objects)
        {
            Component[] components = go.GetComponents<Component>();
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] == null)
                {
                    Debug.LogWarning($"[Scene] Missing script in GameObject: '{go.name}'", go);
                    count++;
                }
            }
        }

        Debug.Log($"[Scene Scan Complete] Found {count} GameObject(s) with missing scripts.");
    }

    [MenuItem("Tools/Find Missing Scripts/In Project Prefabs")]
    static void FindMissingInPrefabs()
    {
        string[] allPrefabs = AssetDatabase.FindAssets("t:Prefab");
        int count = 0;

        foreach (string guid in allPrefabs)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (prefab == null) continue;

            Component[] components = prefab.GetComponentsInChildren<Component>(true);
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] == null)
                {
                    Debug.LogWarning($"[Prefab] Missing script in '{prefab.name}' at path: {path}", prefab);
                    count++;
                    break;
                }
            }
        }

        Debug.Log($"[Prefab Scan Complete] Found {count} prefab(s) with missing scripts.");
    }
}