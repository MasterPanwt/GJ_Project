using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
    这个脚本控制暂停面板，里面有
    继续游戏 ， 回到主菜单  ， 重新开始 ， 设置

    点击设置按键可以到设置面板



*/
public class PauseMenu : MonoBehaviour
{

    public GameObject pausePanel = null;

    public GameObject settingsPanel = null;

    public GameObject audiosettings = null;

    public GameObject slectSongsPanel = null;

    void Update()  //判断是否停止
    {
        // 检测是否按下 R 键
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame(); // 按下 R 键就执行重开
        }

        //是否暂停

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame() //暂停
    {
        pausePanel.SetActive(true); //将这个物体激活

        Time.timeScale = 0f; //改变时间流逝
    }

    public void ResumeGame() //继续游戏
    {
        pausePanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void RestartGame()  //重开
    {
        // 先恢复游戏时间 
        Time.timeScale = 1f; 
        // 重新加载当前场景 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        pausePanel.SetActive(false);
    } 
    
    public void Quit()  //退出游戏
    {
        Application.Quit();
    }

    public void OpenAudioSettings() //打开音量设置
    {
        CloseAllPanel();
        settingsPanel.SetActive(true);
        audiosettings.SetActive(true); //将这个物体激活
    }

    public void OpenSongsSettings() //打开歌曲
    {
        CloseAllPanel();
        settingsPanel.SetActive(true);
        slectSongsPanel.SetActive(true); 
    }

    public void BackPauseMenu() //回到暂停
    {
        CloseAllPanel();
        pausePanel.SetActive(true);
    }

    public void OpenSettings() //打开设置
    {
        settingsPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void CloseAllPanel () //关闭所有面板
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        audiosettings.SetActive(false);
        slectSongsPanel.SetActive(false);
    }

    public void ReloadGame()  //回到主菜单
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("开始游戏");
    }
}
