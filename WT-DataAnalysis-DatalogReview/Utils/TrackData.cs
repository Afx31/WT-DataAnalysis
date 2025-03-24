namespace WT_DataAnalysis_DatalogReview.Utils;

public struct CurrentTrackCoords
{
    public double LatMin;
    public double LatMax;
    public double LonMin;
    public double LonMax;
}

public class TrackData
{
    public static CurrentTrackCoords GetFinishLineCoords(string currentTrack)
    {
        switch (currentTrack)
        {
            case "smsp":
                return new CurrentTrackCoords
                {
                    //LatMin = -33.803855,
                    //LatMax = -33.803649,
                    //LonMin = 150.870905,
                    //LonMax = 150.870954
                    // TOOD: Temp wider attempt for the line
                    LatMin = -33.803925,
                    LatMax = -33.803573,
                    LonMin = 150.870887,
                    LonMax = 150.870971
                };
            case "morganpark":
                return new CurrentTrackCoords
                {
                    LatMin = -28.262057,
                    LatMax = -28.262087,
                    LonMin = 152.036282,
                    LonMax = 152.036477
                };
            case "winton":
                return new CurrentTrackCoords
                {
                    LatMin = -28.262057,
                    LatMax = -28.262087,
                    LonMin = 152.036282,
                    LonMax = 152.036477
                };
            default:
                return new CurrentTrackCoords
                {
                    LatMin = 0,
                    LatMax = 0,
                    LonMin = 0,
                    LonMax = 0
                };
        }
    }

    public static CurrentTrackCoords GetTrackMapMaxCoords(string currentTrack)
    {
        switch (currentTrack)
        {
            case "smsp":
                return new CurrentTrackCoords
                {
                    LatMin = 150.864046,
                    LatMax = 150.878478,
                    LonMin = -33.809579,
                    LonMax = -33.802297
                };
            case "morganpark":
                return new CurrentTrackCoords
                {
                    LatMin = 152.028940,
                    LatMax = 152.040025,
                    LonMin = -28.265911,
                    LonMax = -28.255305
                };
            //TODO: case "winton":
            default:
                return new CurrentTrackCoords
                {
                    LatMin = 0,
                    LatMax = 0,
                    LonMin = 0,
                    LonMax = 0
                };
        }
    }
}