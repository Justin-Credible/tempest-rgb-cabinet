
public class Color
{
    public int R { get; set; }
    public int G { get; set; }
    public int B { get; set; }

    public string ToGrbValuesString()
    {
        return $"{G},{R},{B}";
    }

    public static Color Black = new Color() { R = 0, G = 0, B = 0 };
    public static Color White = new Color() { R = 192, G = 192, B = 192 };
    public static Color Purple = new Color() { R = 192, G = 0, B = 192 };
}
