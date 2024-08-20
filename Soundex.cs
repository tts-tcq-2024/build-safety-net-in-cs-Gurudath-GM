using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public class Soundex
{
    private SoundexConstants soundexConstants;
    private static void SoundexCodeAppend(StringBuilder soundex, char value)
    {
        soundex.Append(char.ToUpper(value));
    }

    private static void GetSoundexCodeProcess(StringBuilder soundex, string name)
    {
        char prevCode = soundexConstants.CodeMap(name[0]);

        foreach (var c in name.Skip(1))
        {
            if (soundex.Length >= 4) break;

            AppendValidCode(soundex, c, ref prevCode);
        }
    }

    private static void AppendValidCode(StringBuilder soundex, char c, ref char prevCode)
    {
        char code = soundexConstants.CodeMap(c);
        if (CheckForValidCode(code, prevCode))
        {
            soundex.Append(code);
            prevCode = code;
        }
    }

    private static bool CheckForValidCode(char code, char prevCode)
    {
        return code != '0' && code != prevCode;
    }

    private static void checkingsoundex(StringBuilder soundex)
    {
        while (soundex.Length < 4)
        {
            soundex.Append('0');
        }
    }
    
    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        return soundexConstants.CodeMap.ContainsKey(c) ? soundexConstants.CodeMap[c] : '0';
    }
    
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        soundexConstants = new SoundexConstants();
        StringBuilder soundex = new StringBuilder();
        SoundexCodeAppend(soundex, name[0]);
        GetSoundexCodeProcess(soundex, name);
        checkingsoundex(soundex);
        return soundex.ToString();
    }
}
