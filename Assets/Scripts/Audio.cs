using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
  AudioSource AudioSource;

  void Start()
  {
    //Fetch the AudioSource component of the GameObject (make sure there is one in the Inspector)
    AudioSource = GetComponent<AudioSource>();
    AudioSource.Play();
    AudioSource.loop = true;
  }

  void Update()
  {
    //Turn the loop on and off depending on the Toggle status

  }
}