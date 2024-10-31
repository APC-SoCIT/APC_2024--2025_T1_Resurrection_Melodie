using System.IO;
using UnityEngine;
using XNode;

public class SaveLoadManagerXNode : MonoBehaviour
{
    [System.Serializable]
    public class GameData
    {
        public string currentNodeID; // ID of the current node
        public string[] playerChoices; // Array of choices made by the player
        public int relationshipScore; // Example variable for story branching
        // Add other data as needed
    }

    private string saveFilePath;

    private void Awake()
    {
        saveFilePath = Application.persistentDataPath + "/xnode_savefile.json";
    }

    // Save the current state
    public void SaveGame(Node currentNode, string[] choices, int relationshipScore)
    {
        GameData data = new GameData
        {
            currentNodeID = currentNode != null ? currentNode.name : null, // Using node name or unique ID
            playerChoices = choices,
            relationshipScore = relationshipScore
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Game Saved!");
    }

    // Load the saved state
    public GameData LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            Debug.Log("Game Loaded!");
            return data;
        }
        else
        {
            Debug.LogWarning("Save file not found.");
            return null;
        }
    }
}
