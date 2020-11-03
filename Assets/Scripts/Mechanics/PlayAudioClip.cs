using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class allows an audio clip to be played during an animation state.
/// </summary>
public class PlayAudioClip : StateMachineBehaviour
{
    /// <summary>
    /// The point in normalized time where the clip should play.
    /// </summary>
    public float t = 0.5f;
    /// <summary>
    /// If greater than zero, the normalized time will be (normalizedTime % modulus).
    /// This is used to repeat the audio clip when the animation state loops.
    /// </summary>
    public float modulus = 0f;

    /// <summary>
    /// The audio clip to be played.
    /// </summary>
    public AudioManager.eSound sound;
    float last_t = 0f;
    float soundTime;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        last_t = stateInfo.normalizedTime;
        soundTime = 0f;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        soundTime += stateInfo.normalizedTime - last_t;
        if (soundTime / modulus > t)
        {
            soundTime -= 1f;
            AudioManager.PlayRandomSound(sound);
        }

        last_t = stateInfo.normalizedTime;
    }
}
