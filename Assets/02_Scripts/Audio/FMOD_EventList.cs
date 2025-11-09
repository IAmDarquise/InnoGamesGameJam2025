using FMODUnity;
using UnityEngine;

public class FMOD_EventList : MonoBehaviour
{
    [field: Header("Music")]
    [field: SerializeField] public EventReference mainMenu { get; private set; }

    [field: Header("SFX")]
    [field: SerializeField] public EventReference holo_hit { get; private set; }
    [field: SerializeField] public EventReference movespeed_down { get; private set; }
    [field: SerializeField] public EventReference movespeed_up { get; private set; }
    [field: SerializeField] public EventReference jumpheight_down { get; private set; }
    [field: SerializeField] public EventReference jumpheight_up { get; private set; }
    [field: SerializeField] public EventReference damage_down { get; private set; }
    [field: SerializeField] public EventReference damage_up { get; private set; }
    [field: SerializeField] public EventReference everything_faster { get; private set; }
    [field: SerializeField] public EventReference firerate_down { get; private set; }
    [field: SerializeField] public EventReference firerate_up { get; private set; }
    [field: SerializeField] public EventReference moon_gravity { get; private set; }
    [field: SerializeField] public EventReference barSeb { get; private set; }
    [field: SerializeField] public EventReference laserpew { get; private set; }
    [field: SerializeField] public EventReference double_spawn { get; private set; }
    [field: SerializeField] public EventReference extra_jump { get; private set; }
    [field: SerializeField] public EventReference faste_enemies { get; private set; }
    [field: SerializeField] public EventReference healthy_enemies { get; private set; }
    [field: SerializeField] public EventReference stronger_enemies { get; private set; }


    public static FMOD_EventList instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("found more than one FMOD_Eventlist in the scene");
            return;
        }

        instance = this;
        //DontDestroyOnLoad(gameObject);

    }

}


