
public static class Utilities
{
    public static Color GetExplosionColor(int zapperColorIndex)
    {
        switch (zapperColorIndex)
        {
            case 0:
                return Color.BrightWhite;
            case 1:
                return Color.BrightRed;
            case 2:
                return Color.BrightYellow;
            default:
                return Color.BrightWhite;
        }
    }

    public static Color GetZapperColor(int zapperColorIndex)
    {
        switch (zapperColorIndex)
        {
            case 0:
                return Color.BrightWhite;
            case 1:
                return Color.BrightRed;
            case 2:
                return Color.BrightBlue;
            case 3:
                return Color.BrightGreen;
            case 4:
                return Color.BrightYellow;
            case 5:
                return Color.BrightMagenta;
            case 6:
                return Color.BrightCyan;
            default:
                return Color.BrightWhite;
        }
    }

    public static List<int> GetLedIndiciesForPlayer(int level, int position)
    {
        var levelMap = LevelMaps.Mapping[level];
        var positionMap = levelMap[position];
        return positionMap;
    }
}
