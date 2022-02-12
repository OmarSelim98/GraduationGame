using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Audio Manager Stats File")]
public class SOAudioStats : ScriptableObject
{
    [SerializeField] public bool canPerformAction;
    [SerializeField] float songBpm;
    [SerializeField] private float secPerBeat;
    [SerializeField] private float songPosition;
    [SerializeField] private float songPositionInBeats;
    [SerializeField] private float dspSongTime;
    [SerializeField] float beatsPerLoop;
    [SerializeField] private int completedLoops = 0;
    [SerializeField] private float loopPositionInBeats;
    [SerializeField] private float loopPositionInAnalog;
    [SerializeField] private float errorMarginInBeats = 0.25f;

    public bool CanPerformAction { get => CanPerformAction; set => CanPerformAction = value; }
    public float SongBpm { get => songBpm; set => songBpm = value; }
    public float SecPerBeat { get => secPerBeat; set => secPerBeat = value; }
    public float SongPosition { get => songPosition; set => songPosition = value; }
    public float SongPositionInBeats { get => songPositionInBeats; set => songPositionInBeats = value; }
    public float DspSongTime { get => dspSongTime; set => dspSongTime = value; }
    public float BeatsPerLoop { get => beatsPerLoop; set => beatsPerLoop = value; }
    public int CompletedLoops { get => completedLoops; set => completedLoops = value; }
    public float LoopPositionInBeats { get => loopPositionInBeats; set => loopPositionInBeats = value; }
    public float ErrorMarginInBeats { get => errorMarginInBeats; set => errorMarginInBeats = value; }

    public void Initiate()
    {
        secPerBeat = 0;
        songPosition = 0;
        songPosition = 0;
        songPositionInBeats = 0;
        dspSongTime = 0;
        completedLoops = 0;
        loopPositionInAnalog = 0;
    }
    public void CalculateSecPerBeat()
    {
        secPerBeat = 60f / songBpm;
    }

    public void RecordDspTime()
    {
        dspSongTime = (float)AudioSettings.dspTime;
    }

    public void UpdateSongPosition()
    {
        songPosition = (float)(AudioSettings.dspTime) - dspSongTime;
    }
    public void UpdateSongBeats()
    {
        songPositionInBeats = songPosition / secPerBeat;
    }

    public void UpdateLoopPosition()
    {
        if (songPositionInBeats >= (completedLoops + 1) * beatsPerLoop)
            completedLoops++;
        loopPositionInBeats = songPositionInBeats - completedLoops * beatsPerLoop;
    }
    public void UpdateAnaglogLoopPosition()
    {
        loopPositionInAnalog = loopPositionInBeats / beatsPerLoop;
    }

    public void UpdateCanPerformAction()
    {
        if ( loopPositionInBeats >= ((Mathf.Ceil(loopPositionInBeats) - errorMarginInBeats)) ||
         loopPositionInBeats <= ((Mathf.Floor(loopPositionInBeats) + errorMarginInBeats)))
        {
            canPerformAction = true;
        }
        else
        {
            canPerformAction = false;
        }
    }
}
