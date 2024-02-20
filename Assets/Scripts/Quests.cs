using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Quest",menuName = "ScriptableObjects/Quest")]
public class Quests : ScriptableObject
{
    public string text;
    public string resourseName;
    public int resourseAmount;
}
