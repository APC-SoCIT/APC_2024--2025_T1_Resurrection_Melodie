using UnityEngine;
using UnityEngine.UI;
using XNode;
using System.Collections;

public class NodeParser : MonoBehaviour
{
    public DialogueGraph graph;
    public Text speaker;
    public Text dialogue;
    public Image speakerImage;
    private Coroutine _parser;
    private TypewriterEffect typewriter;

    private void Start()
    {
        typewriter = dialogue.GetComponent<TypewriterEffect>();
        
        foreach (BaseNode b in graph.nodes)
        {
            if (b.GetString() == "Start")
            {
                graph.current = b;
                break;
            }
        }
        _parser = StartCoroutine(ParseNode());
    }

    IEnumerator ParseNode()
    {
        BaseNode b = graph.current;
        string data = b.GetString();
        string[] dataParts = data.Split('/');

        switch (dataParts[0])
        {
            case "Start":
                NextNode("exit");
                break;

            case "DialogueNode":
                speaker.text = dataParts[1];
                StartCoroutine(typewriter.Type(dataParts[2]));
                speakerImage.sprite = b.GetSprite();

                if (b is DialogueNode dialogueNode)
                {
                    dialogueNode.TriggerEffects();
                }

                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                NextNode("exit");
                break;
        }
    }

    public void NextNode(string fieldName)
    {
        if (_parser != null)
        {
            StopCoroutine(_parser);
            _parser = null;
        }

        foreach (NodePort p in graph.current.Ports)
        {
            if (p.fieldName == fieldName)
            {
                graph.current = p.Connection.node as BaseNode;
                break;
            }
        }
        _parser = StartCoroutine(ParseNode());
    }
}
