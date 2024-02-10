using System;
using UnityEngine;

namespace SubwayLines.Data
{
    [Serializable]
    public class StationData
    {
        [SerializeField] private int id;
        [SerializeField] private string name;

        public int ID => id;
        public string Name => name;
    }
}