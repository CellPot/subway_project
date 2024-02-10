using System;
using System.Collections.Generic;
using UnityEngine;

namespace SubwayLines.Models
{
    [Serializable]
    public class SubwayLine
    {
        [SerializeField] private string name;
        [SerializeField] private List<LineSegment> segments = new();

        public string Name
        {
            get => name;
            set => name = value;
        }

        public List<LineSegment> Segments
        {
            get => segments;
            set => segments = value;
        }

        public bool HasSegment(int index1, int index2)
        {
            return Segments.Exists(segment => SegmentContains(segment, index1, index2));
        }

        private static bool SegmentContains(LineSegment segment, int index1, int index2)
        {
            return (segment.Point1 == index1 && segment.Point2 == index2) ||
                   (segment.Point1 == index2 && segment.Point2 == index1);
        }
    }
}