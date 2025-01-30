namespace WT_DataAnalysis;

public struct CurrentTrackData
{
    public double LatMin;
    public double LatMax;
    public double LonMin;
    public double LonMax;
}

public class TrackData
{
    // TODO:
    // this needs to be named around finish line data
    public static CurrentTrackData GetTrackData(string currentTrack)
    {
        switch (currentTrack)
        {
            case "smsp":
                return new CurrentTrackData
                {
                    LatMin = -33.803855,
                    LatMax = -33.803649,
                    LonMin = 150.870905,
                    LonMax = 150.870954
                };
            case "morganpark":
                return new CurrentTrackData
                {
                    LatMin = -28.262057,
                    LatMax = -28.262087,
                    LonMin = 152.036282,
                    LonMax = 152.036477
                };
            case "winton":
                return new CurrentTrackData
                {
                    LatMin = -28.262057,
                    LatMax = -28.262087,
                    LonMin = 152.036282,
                    LonMax = 152.036477
                };
            default:
                return new CurrentTrackData
                {
                    LatMin = 0,
                    LatMax = 0,
                    LonMin = 0,
                    LonMax = 0
                };
        }
    }

    // TODO:
    // then do one here for map sizing, which is currently at the top of DrawTrackMap()
}
