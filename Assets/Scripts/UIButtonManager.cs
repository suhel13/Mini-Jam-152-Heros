using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{
    public void SwitchToVillage()
    {
        GameManager.instance.SwitchToState(GameManager.gameState.Village);
    }

    public void SwitchToToolSelect()
    {
        GameManager.instance.SwitchToState(GameManager.gameState.ToolSelect);
    }

    public void SwitchToRun()
    {
        GameManager.instance.SwitchToState(GameManager.gameState.Run);
    }

    public void SwitchToEndScrean()
    {
        GameManager.instance.SwitchToState(GameManager.gameState.EndScrean);
    }
}