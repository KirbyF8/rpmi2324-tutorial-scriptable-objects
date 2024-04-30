using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Room")]
public class RoomSO : ScriptableObject
{
    public string roomName;
    [TextArea(5,15)] public string description;
    public Exit[] exits;

}
