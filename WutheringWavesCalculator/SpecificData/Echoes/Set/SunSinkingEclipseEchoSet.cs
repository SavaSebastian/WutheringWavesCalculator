using WutheringWaves.Data.Entities;
using WutheringWavesCalculator.SpecificData.Echoes.Blank;

namespace WutheringWavesCalculator.SpecificData.Echoes.Set;

public class SunSinkingEclipseEchoSet : EchoSet
{
    // TODO
    public SunSinkingEclipseEchoSet(List<Echo> echoes) : base(echoes)
    {
        echoes.Add(new BlankEcho(40m));
    }
}