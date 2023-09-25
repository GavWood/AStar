public static class BWFloat
{
    public static bool IsBetween(this float value, float minValue, float maxValue)
    {
        return value > minValue && value < maxValue;
    }
}