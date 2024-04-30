using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Actions/Go")]
public class GoSO : InputActionSO
{
    public override void RespondToInput(string[] separatedInput)
    {
        RoomManager.Instance.TryToChangeRoom(separatedInput[1]);
    }
}
