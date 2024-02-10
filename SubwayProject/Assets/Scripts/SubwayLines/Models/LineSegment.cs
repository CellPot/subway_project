using System;
using System.Collections.Generic;
using UnityEngine;

namespace SubwayLines.Models
{
    [Serializable]
    public class LineSegment
    {
        [SerializeField] private int point1;
        [SerializeField] private int point2;

        public int Point1
        {
            get => point1;
            set => point1 = value;
        }

        public int Point2
        {
            get => point2;
            set => point2 = value;
        }

        public static List<LineSegment> ConvertToSegments(List<int> connectedPoints)
        {
            var segments = new List<LineSegment>();
            for (var i = 0; i < connectedPoints.Count - 1; i++)
            {
                var segment = new LineSegment()
                {
                    point1 = connectedPoints[i],
                    point2 = connectedPoints[i + 1]
                };

                segments.Add(segment);
            }

            return segments;
        }
    }
}