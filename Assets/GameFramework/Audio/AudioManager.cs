using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    private AudioSource _bgmSource;
    private AudioSource _soundSource;

    protected override void Init()
    {
        // 添加两个音源组件 分别负责背景音乐、音效
        _bgmSource = gameObject.AddComponent<AudioSource>();
        _soundSource = gameObject.AddComponent<AudioSource>();
        _bgmSource.loop = true;
        _bgmSource.volume = 0.6f;
        _soundSource.volume = 1f;
    }

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    public void PlayBGM(string clipName)
    {
        AudioClip clip = Resources.Load<AudioClip>($"Audio/BGM/{clipName}");
        if (clip == null) return;
        _bgmSource.clip = clip;
        _bgmSource.Play();
    }

    /// <summary>
    /// 停止背景音乐
    /// </summary>
    public void StopBGM()
    {
        _bgmSource.Stop();
    }

    /// <summary>
    /// 播放短音效
    /// </summary>
    public void PlaySound(string soundName)
    {
        AudioClip clip = Resources.Load<AudioClip>($"Audio/Sound/{soundName}");
        if (clip == null) return;
        _soundSource.PlayOneShot(clip);
    }
}