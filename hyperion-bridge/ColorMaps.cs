
// Colors from: https://www.arcade-history.com/?n=tempest-upright-model&page=detail&id=2865
public class ColorMaps
{
    // Tunnel - blue
    // Player ship - yellow
    // SuperZapper - yellow
    // Flippers - red
    // Tankers - purple
    // Spikers/Spikes - green
    // Pulsars - N/A (these do not appear until the next colour scheme)
    private static ColorSet Levels1To16 = new ColorSet
    {
        Level = new Color() { R = 0, G = 0, B = 128 },
        Player = new Color() { R = 192, G = 192, B = 0 },
        Zapper = new Color() { R = 192, G = 192, B = 0 },
    };

    // Tunnel - red
    // Player ship - green
    // SuperZapper - cyan
    // Flippers - purple
    // Tankers - blue
    // Spikers/Spikes - cyan
    // Pulsars - yellow
    private static ColorSet Levels17To32 = new ColorSet
    {
        Level = new Color() { R = 192, G = 0, B = 0 },
        Player = new Color() { R = 0, G = 192, B = 0 },
        Zapper = new Color() { R = 0, G = 192, B = 192 },
    };

    // Tunnel - yellow
    // Player ship - blue
    // SuperZapper - blue
    // Flippers - green
    // Tankers - cyan
    // Spikers/Spikes - red
    // Pulsars - blue
    private static ColorSet Levels33To48 = new ColorSet
    {
        Level = new Color() { R = 192, G = 192, B = 0 },
        Player = new Color() { R = 0, G = 0, B = 128 },
        Zapper = new Color() { R = 0, G = 0, B = 128 },
    };

    // Tunnel - cyan
    // Player ship - blue
    // SuperZapper - red
    // Flippers - green
    // Tankers - purple
    // Spikers/Spikes - red
    // Pulsars - yellow
    private static ColorSet Levels49To64 = new ColorSet
    {
        Level = new Color() { R = 0, G = 192, B = 192 },
        Player = new Color() { R = 0, G = 0, B = 128 },
        Zapper = new Color() { R = 192, G = 0, B = 0 },
    };

    // Tunnel - black (invisible)
    // Player ship - yellow
    // SuperZapper - white
    // Flippers - red
    // Tankers - purple
    // Spikers/Spikes - green
    // Pulsars - cyan
    private static ColorSet Levels65To80 = new ColorSet
    {
        Level = new Color() { R = 0, G = 0, B = 0 },
        Player = new Color() { R = 192, G = 192, B = 0 },
        Zapper = new Color() { R = 192, G = 192, B = 192 },
    };

    // Tunnel - green
    // Player ship - red
    // SuperZapper - purple
    // Flippers - yellow
    // Tankers - purple
    // Spikers/Spikes - blue
    // Pulsars - yellow
    private static ColorSet Levels81To96 = new ColorSet
    {
        Level = new Color() { R = 192, G = 0, B = 0 },
        Player = new Color() { R = 0, G = 192, B = 0 },
        Zapper = new Color() { R = 192, G = 0, B = 192 },
    };

    public static Dictionary<int, ColorSet> Mapping = new Dictionary<int, ColorSet>()
    {
        { 1, Levels1To16 },
        { 2, Levels1To16 },
        { 3, Levels1To16 },
        { 4, Levels1To16 },
        { 5, Levels1To16 },
        { 6, Levels1To16 },
        { 7, Levels1To16 },
        { 8, Levels1To16 },
        { 9, Levels1To16 },
        { 10, Levels1To16 },
        { 11, Levels1To16 },
        { 12, Levels1To16 },
        { 13, Levels1To16 },
        { 14, Levels1To16 },
        { 15, Levels1To16 },
        { 16, Levels1To16 },

        { 17, Levels17To32 },
        { 18, Levels17To32 },
        { 19, Levels17To32 },
        { 20, Levels17To32 },
        { 21, Levels17To32 },
        { 22, Levels17To32 },
        { 23, Levels17To32 },
        { 24, Levels17To32 },
        { 25, Levels17To32 },
        { 26, Levels17To32 },
        { 27, Levels17To32 },
        { 28, Levels17To32 },
        { 29, Levels17To32 },
        { 30, Levels17To32 },
        { 31, Levels17To32 },
        { 32, Levels17To32 },

        { 33, Levels33To48 },
        { 34, Levels33To48 },
        { 35, Levels33To48 },
        { 36, Levels33To48 },
        { 37, Levels33To48 },
        { 38, Levels33To48 },
        { 39, Levels33To48 },
        { 40, Levels33To48 },
        { 41, Levels33To48 },
        { 42, Levels33To48 },
        { 43, Levels33To48 },
        { 44, Levels33To48 },
        { 45, Levels33To48 },
        { 46, Levels33To48 },
        { 47, Levels33To48 },
        { 48, Levels33To48 },

        { 49, Levels49To64 },
        { 50, Levels49To64 },
        { 51, Levels49To64 },
        { 52, Levels49To64 },
        { 53, Levels49To64 },
        { 54, Levels49To64 },
        { 55, Levels49To64 },
        { 56, Levels49To64 },
        { 57, Levels49To64 },
        { 58, Levels49To64 },
        { 59, Levels49To64 },
        { 60, Levels49To64 },
        { 61, Levels49To64 },
        { 62, Levels49To64 },
        { 63, Levels49To64 },
        { 64, Levels49To64 },

        { 65, Levels65To80 },
        { 66, Levels65To80 },
        { 67, Levels65To80 },
        { 68, Levels65To80 },
        { 69, Levels65To80 },
        { 70, Levels65To80 },
        { 71, Levels65To80 },
        { 72, Levels65To80 },
        { 73, Levels65To80 },
        { 74, Levels65To80 },
        { 75, Levels65To80 },
        { 76, Levels65To80 },
        { 77, Levels65To80 },
        { 78, Levels65To80 },
        { 79, Levels65To80 },
        { 80, Levels65To80 },

        { 81, Levels81To96 },
        { 82, Levels81To96 },
        { 83, Levels81To96 },
        { 84, Levels81To96 },
        { 85, Levels81To96 },
        { 86, Levels81To96 },
        { 87, Levels81To96 },
        { 88, Levels81To96 },
        { 89, Levels81To96 },
        { 90, Levels81To96 },
        { 91, Levels81To96 },
        { 92, Levels81To96 },
        { 93, Levels81To96 },
        { 94, Levels81To96 },
        { 95, Levels81To96 },
        { 96, Levels81To96 },
    };
}
