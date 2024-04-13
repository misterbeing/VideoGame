using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool reloadGame;

    public void Update()
    {
        if (reloadGame)
        {
            resetGame();
            reloadGame = false;
        }
    }
    public void resetGame()
    {
        ResetTransform._resetTransform();
    }


}
