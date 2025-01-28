
public class Color
{
    public int R { get; set; }
    public int G { get; set; }
    public int B { get; set; }

    public string ToGrbValuesString()
    {
        return $"{G},{R},{B}";
    }

    public static Color White = new Color() { R = 192, G = 192, B = 192 };
    public static Color Black = new Color() { R = 0, G = 0, B = 0 };
    public static Color Magenta = new Color() { R = 192, G = 0, B = 192 };

    public static Color BrightWhite = new Color() { R = 255, G = 255, B = 255 };
    public static Color BrightRed = new Color() { R = 255, G = 0, B = 0 };
    public static Color BrightBlue = new Color() { R = 0, G = 0, B = 255 };
    public static Color BrightGreen = new Color() { R = 0, G = 255, B = 0 };
    public static Color BrightYellow = new Color() { R = 255, G = 255, B = 0 };
    public static Color BrightMagenta = new Color() { R = 255, G = 0, B = 255 };
    public static Color BrightCyan = new Color() { R = 0, G = 255, B = 255 };
}
