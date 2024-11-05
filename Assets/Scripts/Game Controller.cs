using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XNode;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject loadSlotsPanel;
    [SerializeField] private GameObject saveSlotsPanel;
    [SerializeField] private Text notificationText;
    [SerializeField] private float notificationDuration = 2f;
    [SerializeField] private Button[] slotButtons; // Array of your 4 slot buttons
    [SerializeField] private Color emptySlotColor = Color.gray; // Color for empty slots
    [SerializeField] private Color usedSlotColor = Color.white; // Color for slots with saves

    private SaveLoadManagerXNode saveLoadManager;
    private Node currentNode;

    public bool IsMenuOpen { get; private set; }

    void Start()
    {
        saveLoadManager = FindObjectOfType<SaveLoadManagerXNode>();
        saveSlotsPanel.SetActive(false);
        loadSlotsPanel.SetActive(false);
        IsMenuOpen = false;
        UpdateSlotButtonColors();
    }

    private void UpdateSlotButtonColors()
    {
        for (int i = 0; i < slotButtons.Length; i++)
        {
            string savePath = Application.persistentDataPath + "/xnode_savefile_" + (i + 1) + ".json";
            bool saveExists = File.Exists(savePath);
            slotButtons[i].image.color = saveExists ? usedSlotColor : emptySlotColor;
        }
    }
    public void OnSaveButtonClick()
    {
        OpenSaveMenu();
        Event.current?.Use();
    }
    public void OpenSaveMenu()
    {
        Time.timeScale = 0f;
        saveSlotsPanel.SetActive(true);
        IsMenuOpen = true;
    }

    public void CloseSaveMenu()
    {
        Time.timeScale = 1f;
        saveSlotsPanel.SetActive(false);
        IsMenuOpen = false;
    }

    public void SaveGameToSlot(int slotNumber)
    {
        string savePath = Application.persistentDataPath + "/xnode_savefile_" + slotNumber + ".json";
        bool saveExists = File.Exists(savePath);
        saveLoadManager.SaveGame(currentNode, null, 0, slotNumber);
        if (saveExists)
            ShowNotification("Save file overwritten!");
        else
            ShowNotification("Game saved!");
        UpdateSlotButtonColors(); // Updates the visual feedback
    }

    public void OnLoadButtonClick()
    {
        OpenLoadMenu();
        Event.current?.Use();
    }

    public void SaveGameState()
    {
        saveLoadManager.SaveGame(currentNode, null, 0);
    }

    public void OpenLoadMenu()
    {
        loadSlotsPanel.SetActive(true);
        Time.timeScale = 0f;
        UpdateSlotButtonColors();
    }
    public void LoadGameFromSlot(int slotNumber)
    {
        SaveLoadManagerXNode.GameData loadedData = saveLoadManager.LoadGame(slotNumber);
        if (loadedData != null)
        {
            ShowNotification("Save file loaded!");
            SceneManager.LoadScene(loadedData.currentSceneName);
            CloseLoadMenu();
        }
    }
    
    public void CloseLoadMenu()
    {
        Time.timeScale = 1f; // Resumes the game
        loadSlotsPanel.SetActive(false);
    }
    private void ShowNotification(string message)
    {
        notificationText.text = message;
        StartCoroutine(HideNotification());
    }

    private IEnumerator HideNotification()
    {
        yield return new WaitForSeconds(notificationDuration);
        notificationText.text = "";
    }
}