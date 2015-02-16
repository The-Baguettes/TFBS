using UnityEngine;
using System.Collections;

public class LeaveGame : MonoBehaviour
{
    public void QuitGame(bool quit)
    {
        if (quit)
            Application.Quit();
    }
}
