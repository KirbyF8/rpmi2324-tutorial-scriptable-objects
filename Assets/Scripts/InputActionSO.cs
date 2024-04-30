using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputActionSO : ScriptableObject
{
    public string keyWord;
    public abstract void RespondToInput(string[] separatedInput); 
    

}
