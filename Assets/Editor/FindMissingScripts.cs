using UnityEngine;
using UnityEditor;

public class FindMissingScripts : MonoBehaviour
{
    [MenuItem("Tools/Find Missing Scripts in Scene")]
    public static void FindMissingScriptsInScene()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        int count = 0;

        foreach (GameObject obj in allObjects)
        {
            Component[] components = obj.GetComponents<Component>();

            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] == null)
                {
                    Debug.LogWarning($"Missing script in GameObject: '{obj.name}' in scene", obj);
                    count++;
                }
            }
        }

        Debug.Log($"Scan complete. Found {count} GameObject(s) with missing scripts.");
    }
}
