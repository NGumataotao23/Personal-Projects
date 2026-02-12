using UnityEngine;
using UnityEngine.Audio;

public class audioController : MonoBehaviour
{
    [SerializeField] AudioMixer master;
    
    [SerializeField] AudioMixerGroup musicGroup;
    [SerializeField] AudioMixerGroup sfxGroup;
    [SerializeField] AudioMixerGroup masterGroup;


    
    void Start()
    {
        
        master.SetFloat("music", Mathf.Log10(PlayerPrefs.GetFloat("musicVolume", 1)) * 20);
        master.SetFloat("sfx", Mathf.Log10(PlayerPrefs.GetFloat("sfxVolume", 1)) * 20);
        
        var sources = FindObjectsByType<AudioSource>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach(var src in sources)
        {
            if (src.outputAudioMixerGroup == null)
            {
                src.outputAudioMixerGroup = GroupSource(src);
            }
        }
        
    }

    AudioMixerGroup GroupSource(AudioSource source)
    {
        if (source.gameObject.CompareTag("music")) return musicGroup;
        if (source.gameObject.CompareTag("sfx")) return sfxGroup;

        return masterGroup;

    }

    
}
