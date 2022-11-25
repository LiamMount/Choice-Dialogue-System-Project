using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpeech : MonoBehaviour
{
    public Conversation test;
    public Conversation test2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DialogueManager.StartConversation(test);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            DialogueManager.StartConversation(test2);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            string keyMatchValue = "Test";
            foreach (SavesManager.ChoiceSet choice in SavesManager.instance.activeSave.choiceList)
            {
                if (choice.choiceKey == keyMatchValue)
                {
                    Debug.Log(choice.choiceResult);
                }
            }
        }
    }
}
