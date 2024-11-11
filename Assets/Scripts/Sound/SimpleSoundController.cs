using UnityEngine;

namespace Sound
{
    public class SimpleSoundController
    {
        private readonly AudioSource _musicSource;
        private readonly AudioSource _soundSource;

        public SimpleSoundController(AudioSource musicSource, AudioSource soundSource)
        {
            _musicSource = musicSource;
            _soundSource = soundSource;
        }

        public void EnableSound()
        {
            Debug.Log($"Sound is on");
            _soundSource.mute = false;
        }

        public void DisableSound()
        {
            Debug.Log($"Sound is off");
            _soundSource.mute = true;
        }

        public void EnableMusic()
        {
            Debug.Log($"Music is on");
            _musicSource.mute = false;
        }

        public void DisableMusic()
        {
            Debug.Log($"Music is off");
            _musicSource.mute = true;
        }
    }
}
