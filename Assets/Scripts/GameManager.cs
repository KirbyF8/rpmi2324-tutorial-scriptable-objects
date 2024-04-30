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

    [SerializeField] private InputActionSO[] inputActionsArray;

    private void Start()
    {
        DisplayRoomText();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("+1 instance");
        }

        Instance = this;

    }
    public InputActionSO[] GetInputActions()
    {
        return inputActionsArray;
    }

    public void DisplayRoomText()
    {
        ClearAllCollectionsForNewRoom();

        string roomDescription = RoomManager.Instance.currentRoom.description + NEW_LINE;
        string roomExitDescriptions = string.Join(NEW_LINE, RoomManager.Instance.GetExitDescriptionsListInRoom());
        UpdateLogList(roomDescription + roomExitDescriptions);
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

    private void ClearAllCollectionsForNewRoom()
    {
        RoomManager.Instance.ClearExits();
    }
}
