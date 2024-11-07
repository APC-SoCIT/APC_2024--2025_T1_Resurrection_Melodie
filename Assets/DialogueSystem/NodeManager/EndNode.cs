using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XNode;

public class EndNode : BaseNode 
{
    [Input] public int entry;
    public string nextSceneName; // Scene to load
    
    public override string GetString()
    {
        SceneManager.LoadScene(nextSceneName);
        return "End";
    }
}