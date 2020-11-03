using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoopPlayer : MonoBehaviour
{
    AudioClip[] backgroundClips;
    string folder = "background_loops";
    // Start is called before the first frame update
    void Start()
    {
        var clips = AudioManager.instance.GetSounds(AudioManager.eSound.BackgroundLoops);
        foreach(var c in clips)
        {
            var s = gameObject.AddComponent<AudioSource>();
            s.loop = true;
            s.clip = c;
            s.spatialBlend = 0f;
            s.Play();
        }
    }
}

public static class AudioUtilities
{
    public static AudioClip[] GetResourcesClips(string _folder)
    {
        return Resources.LoadAll<AudioClip>(_folder);
    }

    public static AudioClip Random(this AudioClip[] _clips)
    {
        if (_clips == null) return null;
        return _clips[UnityEngine.Random.Range(0, _clips.Length)];
    }
}
