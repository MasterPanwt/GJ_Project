using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("第一关"); //这里填开始游戏后要到的场景
    }
}
