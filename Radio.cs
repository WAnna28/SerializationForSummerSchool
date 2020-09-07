using System;

namespace SerializationDEMO
{
    [Serializable]
    public class Radio
    {
        public bool HasTweeters;

        public bool HasSubWoofers;

        public double[] StationPresets;

        [NonSerialized]
        public string RadioID = "Demo-Test02-02-2020";
    }
}
