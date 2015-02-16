using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneTo(string NextScene)
    {
        Application.LoadLevel(NextScene);
    }
}
