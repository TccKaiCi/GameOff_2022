using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaiCi
{
    public class SoundManager : Singleton<SoundManager>
    {
        public AudioSource audioSource;

        public void Play() => audioSource.Play();
        public void Stop() => audioSource.Stop();
    }
}