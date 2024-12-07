using WutheringWaves.Data.Entities;
using WutheringWavesCalculator.SpecificData.Echoes.Blank;

namespace WutheringWavesCalculator.SpecificData.Echoes.Set;

public class LingeringTunesEchoSet : EchoSet
{
    //TODO
    public LingeringTunesEchoSet(List<Echo> echoes) : base(echoes)
    {
        echoes.Add(new BlankEcho(attackPercentage: 30));
    }
}