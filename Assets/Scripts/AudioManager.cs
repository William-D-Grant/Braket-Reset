// Filename:            AudioManager.cs
// Author:              Professor Wolfe edited by Mars Dunn
// Creation Date:       2/1/2026
// Last Modified:       5/8/2026
// Current Version:     0.2.0
// Previous Version:    N/A
// Project:             Braket Resey
// Purpose:             Manages scene-wide audio levels
// Version Changes:     Updated for "Braket Reset" integration
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // Boilerplate code
    private static AudioManager _singletonInstance;

    public static AudioManager SingletonInstance
    {
        get
        {
            return _singletonInstance;
        }
    }

    [SerializeField]
    [Tooltip("The decibel modifier at maximum volume")]
    private float _maximumDecibel = 0;

    [SerializeField]
    [Tooltip("The decibel modifier at minimum volume")]
    private float _minimumDecibel = -80;

    [SerializeField]
    [Tooltip("The audio group for all music sources")]
    private AudioMixerGroup _musicMixerGroup;

    [SerializeField]
    [Tooltip("The audio group for all sound effect sources")]
    private AudioMixerGroup _sfxMixerGroup;

    [SerializeField]
    [Tooltip("The audio group for all voice acting sources")]
    private AudioMixerGroup _voiceMixerGroup;


    // Name:        Awake
    // Description: Runs immediately upon the object loading in
    // Parameters:  None
    // Returns:     None
    void Awake()
    {
        // Boilerplate code
        if (_singletonInstance == null)
        {
            _singletonInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        UpdateSFXVolume(PlayerOptions.SFXVolume);
        UpdateMusicVolume(PlayerOptions.MusicVolume);
        UpdateVoiceVolume(PlayerOptions.VoiceVolume);
    }

    // Name:        UpdateSFXVolume
    // Description: Updates the SFX volume modifier to the provided value
    // Parameters:  float updatedValue - The new modifier for SFX volume
    // Returns:     None
    public void UpdateSFXVolume(float updatedValue)
    {
        PlayerOptions.SFXVolume = updatedValue;
        _sfxMixerGroup.audioMixer.SetFloat("SFX", ModifierToDecibels(updatedValue));
    }

    // Name:        UpdateMusicVolume
    // Description: Updates the music volume modifier to the provided value
    // Parameters:  float updatedValue - The new modifier for music volume
    // Returns:     None
    public void UpdateMusicVolume(float updatedValue)
    {
        PlayerOptions.MusicVolume = updatedValue;
        _musicMixerGroup.audioMixer.SetFloat("Music", ModifierToDecibels(updatedValue));
    }

    // Name:        UpdateVoiceVolume
    // Description: Updates the voice line volume modifier to the provided value
    // Parameters:  float updatedValue - The new modifier for music volume
    // Returns:     None
    public void UpdateVoiceVolume(float updatedValue)
    {
        PlayerOptions.VoiceVolume = updatedValue;
        _voiceMixerGroup.audioMixer.SetFloat("Voice", ModifierToDecibels(updatedValue));
    }

    // Name:        ModifierToDecibels
    // Description: Converts a modifier to decibels
    // Parameters:  float providedModifier - A modifier, typically from 0 - 1
    // Returns:     float - The associated decibel value
    private float ModifierToDecibels(float providedModifier)
    {
        return (_minimumDecibel + (_maximumDecibel - _minimumDecibel) * providedModifier);
    }
}
