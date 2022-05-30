using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

public class AudioVolumeControl : MonoBehaviour
{

    public AudioClip testSFX;
   public void adjustVolumeMusic(float sliderValue)
   {
       MMSoundManagerTrackEvent.Trigger(MMSoundManagerTrackEventTypes.SetVolumeTrack,MMSoundManager.MMSoundManagerTracks.Music, sliderValue); 
   }

   public void adjustVolumeSFX(float sliderValue)
   {
       MMSoundManagerTrackEvent.Trigger(MMSoundManagerTrackEventTypes.SetVolumeTrack,MMSoundManager.MMSoundManagerTracks.Sfx, sliderValue);   
   }

   public void testSFXVolume()
   {
        MMSoundManagerSoundPlayEvent.Trigger(testSFX, MMSoundManager.MMSoundManagerTracks.Sfx, this.transform.position);
   }



}

