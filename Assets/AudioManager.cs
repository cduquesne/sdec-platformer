using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource playerSource;
    public AudioClip[] backgroundAudio;
    public AudioClip[] jumpAudio;
    public AudioClip[] respawnAudio;
    public AudioClip[] ouchAudio;
    public AudioClip[] walkAudio;
    public AudioClip[] landOnGroundAudio;
    public AudioClip[] landOnEnemyAudio;
    public AudioClip[] pickupCollectableAudio;

    public enum eSound
    {
        BackgroundLoops,
        CharacterHurt,
        CharacterJump,
        CharacterLandOnEnemy,
        CharacterLandOnGround,
        CharacterRespawn,
        CharacterWalk,
        PickupCollectable
    }

    void Awake()
    {
        instance = this;
        backgroundAudio = AudioUtilities.GetResourcesClips("background_loops");
        ouchAudio = AudioUtilities.GetResourcesClips("character_hurt");
        jumpAudio = AudioUtilities.GetResourcesClips("character_jump");
        landOnEnemyAudio = AudioUtilities.GetResourcesClips("character_land_on_enemy");
        landOnGroundAudio = AudioUtilities.GetResourcesClips("character_land_on_ground");
        respawnAudio = AudioUtilities.GetResourcesClips("character_respawn");
        walkAudio = AudioUtilities.GetResourcesClips("character_walk");
        pickupCollectableAudio = AudioUtilities.GetResourcesClips("pickup_collectable");
    }

    public static void PlayRandomSound(eSound _sound, AudioSource _source = null)
    {
        if (_source == null)
            _source = instance.playerSource;
        var clips = instance.GetSounds(_sound);
        if(clips != null && clips.Length > 0)
            _source.PlayOneShot(clips.Random());
    }

    public static void PlayAllSounds(eSound _sound, AudioSource _source = null)
    {
        if (_source == null)
            _source = instance.playerSource;
        var clips = instance.GetSounds(_sound);
        if (clips != null && clips.Length > 0)
        {
            foreach(var c in clips)
            {
                _source.PlayOneShot(clips.Random());
            }
        }
            
    }

    public string GetSoundPath(eSound _sound)
    {
        switch(_sound)
        {
            case eSound.BackgroundLoops:return "background_loops";
            case eSound.CharacterHurt: return "character_hurt";
            case eSound.CharacterJump: return "character_jump";
            case eSound.CharacterLandOnEnemy: return "character_land_on_enemy";
            case eSound.CharacterLandOnGround: return "character_land_on_ground";
            case eSound.CharacterRespawn: return "character_respawn";
            case eSound.CharacterWalk: return "character_walk";
            case eSound.PickupCollectable: return "pickup_collectable";
            default:
                Debug.LogError("Unknown sound");
                return null;
        }
    }

    public AudioClip[] GetSounds(eSound _sound)
    {
        switch (_sound)
        {
            case eSound.BackgroundLoops: return backgroundAudio;
            case eSound.CharacterHurt: return ouchAudio;
            case eSound.CharacterJump: return jumpAudio;
            case eSound.CharacterWalk: return walkAudio;
            case eSound.CharacterLandOnEnemy: return landOnEnemyAudio;
            case eSound.CharacterLandOnGround: return landOnGroundAudio;
            case eSound.CharacterRespawn: return respawnAudio;
            case eSound.PickupCollectable: return pickupCollectableAudio;
            default:
                Debug.LogError("Unknown sound");
                return null;
        }
    }
}
