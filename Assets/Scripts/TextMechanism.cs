using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextMechanism : MonoBehaviour
{
    //text mesh pro gameobject
    public TextMeshProUGUI[] terminalTexts = new TextMeshProUGUI[5];

    int count = 0;

    public TextMeshProUGUI text;

    public TMP_InputField inputField;

    //when enter pressed in input field

    public void SubmitInput()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            TextMeshProUGUI newText = Instantiate(text, text.transform.parent);

            var elem = newText.GetComponentsInChildren<Selectable>();

            foreach (var e in elem)
            {
                e.interactable = false;
            }

            Debug.Log(count);
            Debug.Log(terminalTexts[0]);

            if (count >= 3) {
                Destroy(terminalTexts[0].gameObject);
                for (int i = 0; i < 3; i++) {
                    terminalTexts[i] = terminalTexts[i + 1];
                    if (terminalTexts[i] != null) {
                        terminalTexts[i].transform.position = new Vector3(terminalTexts[i].transform.position.x, terminalTexts[i].transform.position.y + 50, terminalTexts[i].transform.position.z);
                    }
                }

                terminalTexts[count-1] = newText;
                count += 1;

                newText.transform.position = new Vector3(newText.transform.position.x, newText.transform.position.y + 50, newText.transform.position.z);

                inputField.text = "";
                text.transform.position = new Vector3(text.transform.position.x, text.transform.position.y, text.transform.position.z);

                count = 3;
            } else {
                terminalTexts[count] = newText;
                count += 1;

                inputField.text = "";
                text.transform.position = new Vector3(text.transform.position.x, text.transform.position.y - 50, text.transform.position.z);
            }
        }

    }
}
