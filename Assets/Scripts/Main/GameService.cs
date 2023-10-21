using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServiceLocator.Utilities;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Wave;

public class GameService : GenericMonoSingleton<GameService>
{
    [SerializeField]
    private PlayerScriptableObject playerScriptableObject;
    [SerializeField]
    private SoundScriptableObject soundScriptableObject;
    [SerializeField]
    private AudioSource audioEffects, backgroundMusic;
    [SerializeField]
    private UIService uIService;
    [SerializeField]
    private MapScriptableObject mapScriptableObject;
    [SerializeField]
    WaveScriptableObject waveScriptableObject;

    public PlayerService playerService { get; private set; }
    public SoundService soundService { get; private set; }
    public UIService UIService
    {
        get
        {
            return uIService;
        }
    }

    public EventService eventService { get; private set; }
    public MapService mapService { get; private set; }
    public WaveService waveService { get; private set; }

    private void Start()
    {
        playerService = new PlayerService(playerScriptableObject);
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
        eventService = new EventService();
        mapService = new MapService(mapScriptableObject);
        waveService = new WaveService(waveScriptableObject);
    }

    private void Update()
    {
        playerService.Update();
    }
}
