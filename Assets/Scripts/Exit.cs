using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Exit
{
    public string direction;
    [TextArea(5, 15)] public string description;
    public RoomSO room;


   
}
