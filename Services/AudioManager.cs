using Raylib_cs;

namespace Shnake.Services;

public class AudioManager : IService
{
    public static AudioManager Instance { get; } = new();

    private readonly Dictionary<SoundEffect, Sound> _sounds = new();
    private readonly Dictionary<Musique, Music> _musics = new();

    private Musique _currentMusic = Musique.MusicMagicalForest;

    private AudioManager()
    {
        ShutdownManager.RegisterService(this);
        Raylib.InitAudioDevice();
        foreach (var soundEffect in Enum.GetValues<SoundEffect>())
        {
            Sound sound = Raylib.LoadSound(soundEffect.GetPath());
            _sounds.Add(soundEffect, sound);
        }

        foreach (var musique in Enum.GetValues<Musique>())
        {
            Music music = Raylib.LoadMusicStream(musique.GetPath());
            _musics.Add(musique, music);
        }
    }

    public void PlaySound(SoundEffect soundEffect)
    {
        Raylib.PlaySound(_sounds[soundEffect]);
    }

    public void PlayMusic(Musique music)
    {
        if (Raylib.IsMusicStreamPlaying(_musics[_currentMusic]))
            Raylib.StopMusicStream(_musics[_currentMusic]);
        _currentMusic = music;
        Raylib.PlayMusicStream(_musics[music]);
    }

    public void Unload()
    {
        foreach (var music in _musics.Values)
        {
            Raylib.UnloadMusicStream(music);
        }

        foreach (var sound in _sounds.Values)
        {
            Raylib.UnloadSound(sound);
        }

        Raylib.CloseAudioDevice();
    }

    public void Update()
    {
        Raylib.UpdateMusicStream(_musics[_currentMusic]);
    }
}