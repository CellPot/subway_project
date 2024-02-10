using System.Collections.Generic;
using UnityEngine;

namespace SubwayLines.Data
{
    [CreateAssetMenu(fileName = "StationsData", menuName = "Data/StationsData", order = 1)]
    public class StationsData : ScriptableObject
    {
        public List<StationData> stations = new();
    }
}