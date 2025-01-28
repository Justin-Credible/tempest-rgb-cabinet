
class ChaserDemoRenderer
{
    private int _location = 0;
    private int _incrementBy = 1;
    private int _range = 3;
    private int _ledCount = 0;

    public ChaserDemoRenderer(int ledCount)
    {
        _ledCount = ledCount;
    }

    public List<Color> Render()
    {
        var colorSet = ColorMaps.Mapping[1];

        var colors = new List<Color>();

        for (var i = 0; i < _ledCount; i++)
        {
            if (_location >= i - _range && _location <= i + _range)
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

        _location += _incrementBy;

        if (_location >= 56 || _location <= 0)
            _incrementBy = _incrementBy * -1;

        return colors;
    }
}