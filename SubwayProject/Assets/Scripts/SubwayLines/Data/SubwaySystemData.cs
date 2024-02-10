using SubwayLines.Models;
using UnityEngine;

namespace SubwayLines.Data
{
    [CreateAssetMenu(fileName = "SubwaySystemData", menuName = "Data/SubwaySystemData", order = 1)]
    public class SubwaySystemData : ScriptableObject
    {
        public SubwaySystem subwaySystem = new();
    }
}