using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Sprite audioOn;
    public Sprite audioOff;
    public GameObject buttonAudio;

    public Slider slider;

    void Update()
    {
        // audio.volume = slider.value;
    }
    public void OnOffAudio()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            buttonAudio.GetComponent<Image>().sprite = audioOff;
        }
        else
        {
            AudioListener.volume = 1;
            buttonAudio.GetComponent<Image>().sprite = audioOn;
        }
    }
    // public void PlaySound()
    // {
    //     audio.PlayOneShot(clip);
    // }
}
