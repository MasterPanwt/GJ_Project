using UnityEngine;
using UnityEngine.UI;

public class SongSelectUI : MonoBehaviour
{
    // 负责播放歌曲的 AudioSource
    public AudioSource audioSource;

    // 歌曲1
    public AudioClip song1;

    // 歌曲2
    public AudioClip song2;

    // 歌曲3
    public AudioClip song3;

    // 点击歌曲1
    public void SelectSong1()
    {
        audioSource.pitch = 1f;
        // 把歌曲1交给播放器
        audioSource.clip = song1;

        // 播放歌曲1
        audioSource.Play();
    }

    // 点击歌曲2
    public void SelectSong2()
    {
        audioSource.pitch = 1f;
        // 把歌曲2交给播放器
        audioSource.clip = song2;

        // 播放歌曲2
        audioSource.Play();
    }

    // 点击歌曲3
    public void SelectSong3()
    {
        audioSource.pitch = 1f;
        // 把歌曲3交给播放器
        audioSource.clip = song3;

        // 播放歌曲3
        audioSource.Play();
    }
}