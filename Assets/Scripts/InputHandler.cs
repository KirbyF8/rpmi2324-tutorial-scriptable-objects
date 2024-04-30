using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    private void Awake()
    {
        inputField.onEndEdit.AddListener(AcceptUserInput);
    }

    private void AcceptUserInput(string input)
    {
        input = input.ToLower();
        GameManager.Instance.UpdateLogList(input);
        InputComplete();
        string[] separatedWords = GetSeparatedInputWords(input);

        foreach (InputActionSO inputAction in GameManager.Instance.GetInputActions())
        {
            if (inputAction.keyWord.Equals(separatedWords[0]))
            {
                inputAction.RespondToInput(separatedWords);
            }
        }

    }
    private string[] GetSeparatedInputWords(string input)
    {
        return input.Split(" ");
    }

    private void InputComplete()
    {
        inputField.ActivateInputField();
        inputField.text = null;
    }
}
