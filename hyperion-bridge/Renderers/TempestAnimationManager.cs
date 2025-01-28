
public class TempestAnimationManager
{
    public bool IsAnimationPlaying { get; set; } = false;

    private Animations _currentAnimation = Animations.Zapper;

    public delegate void EmitColorsEvent(List<Color> colors);
    public event EmitColorsEvent? OnEmitColors;

    // private static bool zapperActive = false;
    // private static int zapperFrameCounter = 0;
    // private static bool zapperUseBaseColor = true;
    // private static int zapperColorIndex = 0;

    // private static int explosionFrameCounter = 0;
    // private static int explosionColorIndex = 0;

    public void PlayAnimation(Animations animation, bool preempt = false)
    {
        if (!preempt && IsAnimationPlaying)
            return;

        _currentAnimation = animation;
        // IsAnimationPlaying = true;

        // TODO: Start timer w/ event handler
    }

    public void StopAnimation()
    {
        IsAnimationPlaying = false;
        // TODO: Stop timer.
    }
}
