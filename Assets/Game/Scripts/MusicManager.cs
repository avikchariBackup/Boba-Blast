using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MoreMountains.Tools;

public class MusicManager : MonoBehaviour
{
    public AudioClip backgroundMusicMenu;
    public AudioClip backgroundMusicLevel;
    // private int _mySoundID = 0;
    private float _fadeDuration = 5f;

    public bool isMenuMusicPlaying;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayMusicMenu();
        }
    }

    public void PlayMusicMenu()
    {
        MMSoundManagerPlayOptions options;
        options = MMSoundManagerPlayOptions.Default;
        options.Persistent = true;
        options.ID = 0;
        options.MmSoundManagerTrack = MMSoundManager.MMSoundManagerTracks.Music; 
        MMSoundManagerSoundPlayEvent.Trigger(backgroundMusicMenu, options);
        isMenuMusicPlaying = true;
        
    }

    public void PlayMusicLevel()
    {
        StartCoroutine(SoundSequence());
    }

    private IEnumerator SoundSequence()
    {

        MMSoundManagerSoundFadeEvent.Trigger(0, _fadeDuration, 0f, new MMTweenType(MMTween.MMTweenCurve.EaseInCubic));

        yield return MMCoroutine.WaitFor(_fadeDuration);
        
        MMSoundManagerPlayOptions options;
        options = MMSoundManagerPlayOptions.Default;
        options.Persistent = true;
        options.MmSoundManagerTrack = MMSoundManager.MMSoundManagerTracks.Music; 
        MMSoundManagerSoundPlayEvent.Trigger(backgroundMusicLevel, options);
        yield return null;
        MMSoundManagerSoundFadeEvent.Trigger(1, 1, 1f, new MMTweenType(MMTween.MMTweenCurve.EaseInCubic));

    }
   
}
