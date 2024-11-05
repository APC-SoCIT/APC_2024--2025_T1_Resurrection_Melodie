using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using XNode;

public class SaveLoadManagerXNode : MonoBehaviour
{
    [System.Serializable]
    public class GameData
    {
        public string currentNodeID;
        public string currentSceneName;
        public string saveDate; // Add timestamp for each save
    }

    private string saveFilePrefix = "/xnode_savefile_";

    private void Awake()
    {
        // No longer need single saveFilePath since we'll have multiple
    }

    // Save to a specific slot
    public void SaveGame(Node currentNode, string[] choices, int relationshipScore, int saveSlot)
    {
        string saveFilePath = Application.persistentDataPath + saveFilePrefix + saveSlot + ".json";
        
        GameData data = new GameData
        {
            currentNodeID = currentNode != null ? currentNode.name : null,
            currentSceneName = SceneManager.GetActiveScene().name,
            saveDate = System.DateTime.Now.ToString()
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
        Debug.Log($"Game Saved to slot {saveSlot}!");
    }

    // Load from a specific slot
    public GameData LoadGame(int saveSlot)
    {
        string saveFilePath = Application.persistentDataPath + saveFilePrefix + saveSlot + ".json";
        
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            Debug.Log($"Game Loaded from slot {saveSlot}!");
            return data;
        }
        else
        {
            Debug.LogWarning($"Save file not found in slot {saveSlot}.");
            return null;
        }
    }

    // Get list of all available save files
    public string[] GetAllSaveFiles()
    {
        string[] files = Directory.GetFiles(Application.persistentDataPath, "xnode_savefile_*.json");
        return files;
    }

    internal void SaveGame(Node currentNode, object value, int v)
    {
        throw new NotImplementedException();
    }
}