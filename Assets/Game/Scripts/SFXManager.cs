using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;


public class SFXManager : MonoBehaviour
{
    public AudioClip[] menuClicks;
    public AudioClip[] levelSelectClicks;
    public AudioClip[] gameUIClicks;

    public void PlaySoundButtonPlay()
    {
        MMSoundManagerPlayOptions options;
        options = MMSoundManagerPlayOptions.Default;
        options.Persistent = true;
        options.MmSoundManagerTrack = MMSoundManager.MMSoundManagerTracks.Sfx; 
        MMSoundManagerSoundPlayEvent.Trigger(menuClicks[0], options);
        
    }

    public void PlaySoundButtonSettings()
    {
        MMSoundManagerSoundPlayEvent.Trigger(menuClicks[1], MMSoundManager.MMSoundManagerTracks.Sfx, this.transform.position);
    }

    public void PlaySoundButtonBack()
    {
        MMSoundManagerSoundPlayEvent.Trigger(menuClicks[2], MMSoundManager.MMSoundManagerTracks.Sfx, this.transform.position);
    }

    public void PlaySoundLevelSelect(int level)
    {
        MMSoundManagerPlayOptions options;
        options = MMSoundManagerPlayOptions.Default;
        options.Persistent = true;
        options.MmSoundManagerTrack = MMSoundManager.MMSoundManagerTracks.Sfx; 
        MMSoundManagerSoundPlayEvent.Trigger(levelSelectClicks[level-1], options);
    }
}
