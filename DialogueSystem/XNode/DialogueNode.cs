using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DialogueNode : BaseNode 
{

	[Input] public int entry;
	[Output] public int exit;
	public string speakerName;
	public string dialogueLine;
	public Sprite sprite;
	public GameObject cameraEffectPrefab;
	public GameObject displayEffects; 
	public AudioClip soundEffect;
	public AudioClip musicClip;
	private bool soundPlayed = false;
	public override string GetString()
	{
		return "DialogueNode/" + speakerName + "/" + dialogueLine;
	}
	public override Sprite GetSprite()
	{
		return sprite;
	}

	public void TriggerEffects()
	{
    if (cameraEffectPrefab != null)
        Instantiate(cameraEffectPrefab);  // Trigger camera effect

    if (soundEffect != null)
        AudioSource.PlayClipAtPoint(soundEffect, Camera.main.transform.position);  // Play sound
		soundPlayed = true;
		Debug.Log("SFX should start playing");

    if ( displayEffects!= null)
        Instantiate(displayEffects);  // Special Effects

    if (musicClip != null)
    {
        AudioSource audioSource = Camera.main.GetComponent<AudioSource>(); // Play music
        if (audioSource != null)
        {
            audioSource.clip = musicClip;
            audioSource.Play();
			Debug.Log("Music started playing");
        }
		else
		{
			Debug.LogWarning("Nothing happened");
		}
    }
	
	}
	public void ResetEffects()
    {
        soundPlayed = false; // Reset the flag for the sound effect
    }

	
}