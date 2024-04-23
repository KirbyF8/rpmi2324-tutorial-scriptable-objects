using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance { get; private set; }

    public const string NEW_LINE = "\n";

    private List<string> logList = new List<string>();

    [SerializeField] TextMeshProUGUI displayText;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("+1 instance");
        }

        Instance = this;


    }

    private void DisplayRoomText()
    {
        string fullText = RoomManager.Instance.currentRoom.description + NEW_LINE;
        UpdateLogList(fullText);
    }

    public void UpdateLogList(string stringToAdd)
    {
        logList.Add(stringToAdd);
        DisplayText();
    }

    private void DisplayText()
    { 

    displayText.text = string.Join(NEW_LINE, logList.ToArray());

    }

}
