
using System.Reflection;
using System.Runtime.InteropServices;

class TempestRenderer
{
    private int _ledCount = 0;
    private int _maxLedIndex = 0;

    private TempestAnimationManager _animationManager;

    private int _playerPosition = 0;
    private int _currentLevel = 0;
    private GameState _gameState = GameState.Unknown;

    public delegate void EmitColorsEvent(List<Color> colors);
    public event EmitColorsEvent? OnEmitColors;

    public delegate void EmitEffectEvent(string effectName);
    public event EmitEffectEvent? OnEmitEffect;

    public TempestRenderer(int ledCount, int maxLedIndex)
    {
        _ledCount = ledCount;
        _maxLedIndex = maxLedIndex;

        _animationManager = new TempestAnimationManager();
        _animationManager.OnEmitColors += (colors) => OnEmitColors?.Invoke(colors);
    }

    public void HandleUpdates(Message message)
    {
        switch(message.Command)
        {
            case "game-state":
                UpdateGameState(message.Argument);
                break;
            case "current-level":
                UpdateCurrentLevel(message.Argument);
                break;
            case "player-position":
                UpdatePlayerPosition(message.Argument);
                break;
            case "zapper":
                _animationManager.PlayAnimation(Animations.Zapper);
                break;
            case "death-state":
                _animationManager.PlayAnimation(message.Argument == "ship-capture" ? Animations.ShipCapture : Animations.ShipExplode);
                break;
        }

        if (_animationManager.IsAnimationPlaying)
        {
            // If the animation manager is currently running an animation then don't attempt
            // to render anything else. We currently expect the animtaion manager to be co-operative
            // and to stop rendering after the fixed time of each animation.
            return;
        }
        else if (_gameState == GameState.TubeDecent)
        {
            // TODO: Use animation manager; hardcoding to magenta now for debugging.
            // _animationManager.PlayAnimation(Animations.TubeDecent);

            // IDEA: Extra bright level tiles fading in and out? Use margenta for testing.
            var colors = new List<Color>();

            for (var i = 0; i < _ledCount; i++)
                colors.Add(Color.Magenta);

            OnEmitColors?.Invoke(colors);
        }
        else if (_gameState == GameState.LevelTransition)
        {
            // TODO: Use animation manager; hardcoding to white now for debugging.
            // _animationManager.PlayAnimation(Animations.LevelTransition);

            // IDEA: Mostly black with rainbow specs fading in and out? Use white for testing.
            var colors = new List<Color>();

            for (var i = 0; i < _ledCount; i++)
                colors.Add(Color.White);

            OnEmitColors?.Invoke(colors);
        }
        else if (_gameState == GameState.GamePlay)
        {
            // No animations or special game states.
            // Render playfield and ship colors.
            var colors = GetGameplayColors();
            OnEmitColors?.Invoke(colors);
        }
    }

    private void UpdateGameState(string stateName)
    {
        switch (stateName)
        {
            case "game-play":
                _gameState = GameState.GamePlay;
                _animationManager.StopAnimation();
                break;
            case "high-scores":
                _gameState = GameState.HighScores;
                _animationManager.StopAnimation();
                break;
            case "title-screen-fade-in":
                _gameState = GameState.TitleScreenFadeIn;
                _animationManager.PlayAnimation(Animations.LogoFadeIn);
                break;
            case "title-screen":
                _gameState = GameState.TitleScreen;
                _animationManager.StopAnimation();
                OnEmitEffect?.Invoke("Rainbow swirl fast");
                break;
            case "tube-decent":
                _gameState = GameState.TubeDecent;
                _animationManager.PlayAnimation(Animations.TubeDecent);
                break;
            case "level-transition":
                _gameState = GameState.LevelTransition;
                _animationManager.PlayAnimation(Animations.LevelApproach);
                break;
            case "high-score-achievement":
                _gameState = GameState.LevelTransition;
                _animationManager.PlayAnimation(Animations.HighScoreAchieved);
                break;
            case "high-score-entry":
                _gameState = GameState.LevelTransition;
                _animationManager.StopAnimation();
                // TODO: Emit Hyperion pre-set/command: marque/white/chasers?
                break;
            case "level-selection":
                _gameState = GameState.LevelTransition;
                _animationManager.StopAnimation();
                OnEmitEffect?.Invoke("Strobe red"); // TODO: Another color? Send duration?
                break;
            default:
                _gameState = GameState.Unknown;
                break;
        }
    }

    private void UpdateCurrentLevel(string levelString)
    {
        var parsedOk = int.TryParse(levelString, out int position);

        if (parsedOk)
            _currentLevel = position;
    }

    private void UpdatePlayerPosition(string positionString)
    {
        var parsedOk = int.TryParse(positionString, out int position);

        if (parsedOk)
            _playerPosition = position;
    }

    private List<Color> GetGameplayColors()
    {
        var colors = new List<Color>();
        var ledIndicies = Utilities.GetLedIndiciesForPlayer(_currentLevel, _playerPosition);
        var colorSet = ColorMaps.Mapping[_currentLevel];

        // Specify the color of each RGB LED in the strip.
        for (var i = 0; i < _ledCount; i++)
        {
            if (ledIndicies.Contains(i))
            {
                // Player occupied level segment
                colors.Add(colorSet.Player);
            }
            else
            {
                // Unoccupied level segment
                colors.Add(colorSet.Level);
            }
        }

        return colors;
    }
}