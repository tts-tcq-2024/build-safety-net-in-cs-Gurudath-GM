using Xunit;

public class SoundexTests
{
    [Fact]
    public void HandlesEmptyString()
    {
        Assert.Equal(Soundex.GenerateSoundex(""), string.Empty);
    }

    [Fact]
    public void HandlesSingleCharacter()
    {
        Assert.Equal(Soundex.GenerateSoundex("E"), "E000");
    }

    [Fact]
    public void HandlesMultipleCharacter()
    {    
        Assert.Equal(Soundex.GenerateSoundex("Smith"), "S530");
    }

    [Fact]
    public void HandlesNameWithOnlyVowels()
    {
        Assert.Equal(Soundex.GenerateSoundex("Ouea"), "O000");
    }

    [Fact]
    public void HandlesNameWithOnlyConsonants()
    {
        Assert.Equal(Soundex.GenerateSoundex("Cry"), "C600");
    }

    [Fact]
    public void HandlesUpperAndLowerCaseLetters()
    {
        Assert.Equal(Soundex.GenerateSoundex("sMiTh"), "S530");
    }

    [Fact]
    public void HandlesNamesWithDuplicateConsonants()
    {
        Assert.Equal(Soundex.GenerateSoundex("Tennessee"), "T520");
    }

    [Fact]
    public void HandlesNamesWithNonAlphabeticCharacters()
    {
        Assert.Equal(Soundex.GenerateSoundex("ONeill"), "O540");
    }

    [Fact]
    public void HandlesLongNames()
    {
        Assert.Equal(Soundex.GenerateSoundex("Washington"), "W252");
    }
}
