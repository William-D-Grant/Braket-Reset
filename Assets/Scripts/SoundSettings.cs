// Filename:            SoundSettings.cs
// Author:              Professor Wolfe edited by Mars Dunn
// Creation Date:       1/29/2026
// Last Modified:       5/8/2026
// Current Version:     0.2.0
// Previous Version:    0.1.1
// Project:             Braket Reset
// Purpose:             Handles updates made to audio settings
// Version Changes:     Updated version for "Braket Reset" integration

using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [Tooltip("The slider for SFX volume")]
    public Slider _sfxVolumeSlider;

    [Tooltip("The slider for music volume")]
    public Slider _musicVolumeSlider;

    [Tooltip("The slider for voice lines volume")]
    public Slider _voiceVolumeSlider;

    // Singleton AudioManager for all actual changes to audio
    private AudioManager _audioManager;

    // Name:        Awake
    // Description: Called immediately upon the object loading in
    // Parameters:  None
    // Returns:     None
    void Awake()
    {
        _audioManager = AudioManager.SingletonInstance;
    }

    // Name:        Start
    // Description: Called immediately before the object's first Update frame
    // Parameters:  None
    // Returns:     None
    void Start()
    {
        _sfxVolumeSlider.value = PlayerOptions.SFXVolume;
        _musicVolumeSlider.value = PlayerOptions.MusicVolume;
        _voiceVolumeSlider.value = PlayerOptions.VoiceVolume;
    }

    // Name:        UpdateSFXVolume
    // Description: Forwards SFX volume changes to the audio manager
    // Parameters:  float updatedValue - The new SFX volume modifier
    // Returns:     None
    public void UpdateSFXVolume(float updatedValue)
    {
        _audioManager.UpdateSFXVolume(updatedValue);
    }

    // Name:        UpdateMusicVolume
    // Description: Forwards music volume changes to the audio manager
    // Parameters:  float updatedValue - The new music volume modifier
    // Returns:     None
    public void UpdateMusicVolume(float updatedValue)
    {
        _audioManager.UpdateMusicVolume(updatedValue);
    }

    // Name:        UpdateVoiceVolume
    // Description: Forwards voice line volume changes to the audio manager
    // Parameters:  float updatedValue - The new voice volume modifier
    // Returns:     None
    public void UpdateVoiceVolume(float updatedValue)
    {
        _audioManager.UpdateVoiceVolume(updatedValue);
    }

}
