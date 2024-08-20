using System.Text;
using System.Linq;

public static class Util
{
    public static void AppendInitialCharacter(StringBuilder soundex, char value)
    {
        soundex.Append(char.ToUpper(value));
    }

    public static void ProcessName(StringBuilder soundex, string name)
    {
        char prevCode = GetSoundexCode(name[0]);
        foreach (var c in name.Skip(1))
        {
            if (soundex.Length >= 4) break;
            AppendValidCode(soundex, c, ref prevCode);
        }
    }

    public static void FinalizeSoundex(StringBuilder soundex)
    {
        while (soundex.Length < 4)
            soundex.Append('0');
    }

    private static void AppendValidCode(StringBuilder soundex, char c, ref char prevCode)
    {
        char code = GetSoundexCode(c);
        if (IsValidCode(code, prevCode))
        {
            soundex.Append(code);
            prevCode = code;
        }
    }

    private static bool IsValidCode(char code, char prevCode)
    {
        return code != '0' && code != prevCode;
    }

    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        return SoundexConstants.CodeMap.TryGetValue(c, out var code) ? code : '0';
    }
}
