using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SubwayLines.Models
{
    [Serializable]
    public class SubwaySystem
    {
        [SerializeField] private int stationsCount = 14;
        [SerializeField] private List<SubwayLine> lines = new();

        public List<SubwayLine> Lines => lines;
        public int StationsCount => stationsCount;

        public SubwayLine GetLineWithSegment(int index1, int index2)
        {
            return lines.FirstOrDefault(line => line.HasSegment(index1, index2));
        }
    }
}