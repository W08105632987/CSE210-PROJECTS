using System;

public class Fraction
{
    // PRIVATE ATTRIBUTES
    private int _top;       // Numerator
    private int _bottom;    // Denominator

    // 1. No-argument constructor → 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // 2. One-parameter constructor → top/1
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // 3. Two-parameter constructor → top/bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // GETTERS & SETTERS
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // METHODS TO REPRESENT THE FRACTION

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}
