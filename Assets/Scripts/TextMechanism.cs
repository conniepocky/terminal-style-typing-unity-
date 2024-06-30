using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextMechanism : MonoBehaviour
{

    GameObject FindChildWithTag(GameObject parent, string tag) {
        GameObject child = null;
        
        foreach(Transform transform in parent.transform) {
            if(transform.CompareTag(tag)) {
                child = transform.gameObject;
                break;
            }
        }
        
        return child;
    }

    public GameObject line;

    public TMP_InputField lineInput;

    public ScrollRect scrollRect;

    void Start()
    {
        var pos = new Vector2(0f, Mathf.Sin(Time.time * 10f) * 100f);
        scrollRect.content.localPosition = pos;
    }

    //when enter pressed in input field

    public string OutputMessage(string input) {
        var msg = input.ToLower();

        if (msg == "hello") {
            return "Greetings!";
        } else if (msg == "help") {
            return "Enter 'email' to see list of messages. \nEnter 'shop' to upgrade your system. \nEnter 'exit' to close the terminal.";
        }
        return "ERR Command not found. Enter 'help' for list of commands.";
    }

    public void SubmitInput()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject newLine = Instantiate(line, line.transform.parent);

            var elem = newLine.GetComponentsInChildren<Selectable>();

            foreach (var e in elem)
            {
                e.interactable = false;
            }

            GameObject output = FindChildWithTag(newLine, "output");
            
            output.GetComponent<TextMeshProUGUI>().text = OutputMessage(newLine.GetComponentInChildren<TMP_InputField>().text);

            var lineCount = output.GetComponent<TextMeshProUGUI>().text.Split('\n').Length;

            var outputH = 100;

            if (lineCount > 1) {
                outputH += (15 * lineCount);
            }

            Debug.Log(outputH);

            lineInput.text = "";

            line.transform.position = new Vector3(line.transform.position.x, line.transform.position.y - outputH, line.transform.position.z);
        }

    }
}