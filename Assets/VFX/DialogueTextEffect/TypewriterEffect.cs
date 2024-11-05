using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public float typingSpeed = 0.05f;
    private Text dialogueText;
    public bool IsComplete { get; private set; }

    void Awake()
    {
        dialogueText = GetComponent<Text>();
    }

    public IEnumerator Type(string text)
    {
        IsComplete = false;
        dialogueText.text = "";
        foreach (char c in text.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        IsComplete = true;
    }

    public void InstantDisplay(string text)
    {
        StopAllCoroutines();
        dialogueText.text = text;
        IsComplete = true;
    }
}
