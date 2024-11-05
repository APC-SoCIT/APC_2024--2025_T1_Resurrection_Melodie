using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using XNode;
using System;

public class DialogueNode : BaseNode 
{
    [Input] public int entry;
    [Output] public int exit;
    public String speakerName;
    public String dialogueLine;
    public Sprite sprite;
    public Sprite background;
    public GameObject cameraEffectPrefab;
    public GameObject visualFX; 
    public AudioClip soundEffect;
    public AudioClip musicClip;

    public override string GetString()
    {
        //Debug.Log("Full Dialogue Line: " + dialogueLine);
        //Debug.Log("Dialogue Line Length: " + dialogueLine.Length);
        string backgroundInfo = background != null ? background.name : "none";
        return "DialogueNode/" + speakerName + "/" + dialogueLine + "/" + backgroundInfo; //Prints the full dialogue line
    }
    
    public override Sprite GetSprite()
    {
        return sprite;
    }

public void TriggerEffects()
{
    
    BackgroundDisplay backgroundDisplay = FindObjectOfType<BackgroundDisplay>();
    if (backgroundDisplay != null && background != null)
    {
        backgroundDisplay.SetBackground(background);
    }

    // Debug.Log("TriggerEffects called");
    CameraEffectsManager cameraEffectsManager = FindObjectOfType<CameraEffectsManager>();

    if (cameraEffectsManager != null)
    {
        if (cameraEffectPrefab != null)
        {
            // Debug.Log($"DialogueNode: Found manager and prefab: {cameraEffectPrefab.name}");
            cameraEffectsManager.ApplyEffect(cameraEffectPrefab);
        }
    }
    else
    {
        // Debug.Log("CameraEffectsManager not found");
    }

    // Access the AudioManager to play music and sound effects
    AudioManager audioManager = FindObjectOfType<AudioManager>();

    if (audioManager != null)
    {
        if (musicClip != null)
        {
            // Only change the music if a different music clip is specified
            if (audioManager.CurrentMusicClip != musicClip)
            {
                audioManager.PlayMusic(musicClip);
                // Debug.Log("New music started in dialogue node");
            }
        }

        if (soundEffect != null) // Check if there's a sound effect to play
        {
            audioManager.PlaySoundEffect(soundEffect);
            // Debug.Log("Sound effect played in dialogue node");
        }
    }

    if (visualFX != null)
    {
        Instantiate(visualFX); // Trigger vfx
    }
}

}
