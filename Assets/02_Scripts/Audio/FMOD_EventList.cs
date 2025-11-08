using FMODUnity;
using UnityEngine;

public class FMOD_EventList : MonoBehaviour
{
    [field: Header("Music")]
    [field: SerializeField] public EventReference mainMenu { get; private set; }

    [field: Header("SFX")]
    [field: SerializeField] public EventReference fart { get; private set; }
    [field: SerializeField] public EventReference mayonnaise { get; private set; }


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


