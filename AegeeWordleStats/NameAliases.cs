namespace AegeeWordleStats;

public class NameAliases
{
    private static readonly List<Tuple<List<string>, string>> Conversions =
    [
        new(["31630562546"], "Tijmen"),
        new(["31682002714"], "Annika"),
        new(["31657619491"], "Naomi"),
        new(["31681736877"], "Hanne"),
        new(["31681694149"], "Jippe"),
        new(["31637040679"], "Paco"),
        new(["31642480335"], "Caspar"),
        new(["31624382245"], "Lena"),
        new(["31628404284"], "Lotte"),
        new(["31639639722"], "Lucas 3963"),
        new(["31637032421"], "Lucas van der Neut"),
        new(["31611785454"], "Dirkje"),
        new(["31622241931"], "Elke"),
        new(["31629990681"], "Noa"),
        new(["31632140899"], "Stef"),
        new(["31617066762"], "Tim"),
        new(["31681011810"], "Myrthe"),
        new(["31652068755"], "Meike"),
        new(["31653884714"], "Marius"),
    ];

    public static string Convert(string input)
    {
        foreach (Tuple<List<string>, string> tuple in 
                 Conversions.Where(tuple => tuple.Item1.Contains(input)))
            return tuple.Item2;

        return input;
    }
}