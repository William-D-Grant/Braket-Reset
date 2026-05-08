// Filename:            PlayerOptions.cs
// Author:              Professor Wolfe edited by Mars Dunn
// Creation Date:       1/26/2026
// Last Modified:       5/8/2026
// Current Version:     0.2.1
// Previous Version:    0.1.1
// Project:             Braket Reset
// Purpose:             A script that contains all of the player's settings for the given session
// Version Changes:     Added VoiceVolume

using UnityEngine;

public static class PlayerOptions
{

    // The volume of the game's music
    public static float MusicVolume { get; set; } = 0;

    // The volume of the game's sound effects
    public static float SFXVolume { get; set; } = 1;

    // The volume of the game's sound effects
    public static float VoiceVolume { get; set; } = 2;

}
