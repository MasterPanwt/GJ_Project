using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;



public class AudioSettings : MonoBehaviour
{
    // 总音量 Slider
    public Slider masterSlider;

    // BGM 音量 Slider
    public Slider bgmSlider;

    // 音效音量 Slider
    public Slider sfxSlider;

    
    public AudioMixer audioMixer;


    // 游戏开始时执行
    private void Start()
    {
        // 读取之前保存的总音量
        float masterVolume = PlayerPrefs.GetFloat("Main", 80f);

        // 读取之前保存的 BGM 音量
        float bgmVolume = PlayerPrefs.GetFloat("BGM", 80f);

        // 读取之前保存的音效音量
        float sfxVolume = PlayerPrefs.GetFloat("SFX", 80f);


        masterSlider.value = masterVolume;
        
        bgmSlider.value = bgmVolume;
        
        sfxSlider.value = sfxVolume;


        // 把读取到的音量应用到 Audio Mixer
        SetMasterVolume(masterVolume);
        SetBGMVolume(bgmVolume);
        SetSFXVolume(sfxVolume);
    }


    // 设置总音量
    public void SetMasterVolume(float volume)
    {
        // 把 0~100 转换成 0~1
        float normalizedVolume = volume / 100f;

        // 把 0~1 转换成 Audio Mixer 使用的 dB
        float db = Mathf.Log10(Mathf.Max(normalizedVolume, 0.0001f)) * 20f;

        // 修改 Audio Mixer 中的总音量
        audioMixer.SetFloat("Master", db);

        // 保存总音量
        PlayerPrefs.SetFloat("Master", volume);
    }

    // 设置 BGM 音量
    public void SetBGMVolume(float volume)
    {
        // 把 0~100 转换成 0~1
        float normalizedVolume = volume / 100f;

        // 转换成 dB
        float db = Mathf.Log10(Mathf.Max(normalizedVolume, 0.0001f)) * 20f;

        // 修改 Audio Mixer 中的 BGM 音量
        audioMixer.SetFloat("BGM", db);

        // 保存 BGM 音量
        PlayerPrefs.SetFloat("BGM", volume);

    }


    // 设置音效音量
    public void SetSFXVolume(float volume)
    {
        // 把 0~100 转换成 0~1
        float normalizedVolume = volume / 100f;

        // 转换成 dB
        float db = Mathf.Log10(Mathf.Max(normalizedVolume, 0.0001f)) * 20f;

        // 修改 Audio Mixer 中的音效音量
        audioMixer.SetFloat("SFX", db);

        // 保存音效音量
        PlayerPrefs.SetFloat("SFX", volume);
    }
}