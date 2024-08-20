using System;
using System.Text;
using System.Linq;

public class Soundex
{
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        StringBuilder soundex = new StringBuilder();
        Util.AppendInitialCharacter(soundex, name[0]);
        Util.ProcessName(soundex, name);
        Util.FinalizeSoundex(soundex);
        return soundex.ToString();
    }
}
