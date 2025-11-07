using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}\n");
    }

    public string GetAsFileString()
    {
        // Save entries in format: date|prompt|entry
        return $"{_date}|{_promptText}|{_entryText}";
    }

    public void LoadFromFileString(string line)
    {
        // Split the saved line back into fields
        string[] parts = line.Split('|');
        _date = parts[0];
        _promptText = parts[1];
        _entryText = parts[2];
    }
}
