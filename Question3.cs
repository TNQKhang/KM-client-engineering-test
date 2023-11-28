using System;
using System.Collections.Generic;

// Time spent : 2h30'
public class Question3
{
    public struct Point
    {
        public float x;

        public float y;

        public float z;

        public bool ApproxEquals(Point p, float epsilon = 0.00001f)
        {
            return (Math.Abs(x - p.x) < epsilon) && (Math.Abs(y - p.y) < epsilon) && (Math.Abs(z - p.z) < epsilon);
        }
    }

    public static Point[] OptimizeMesh(Point[] mesh, float epsilon)
    {
        List<List<Point>> pointsGroup = new();

        for (int i = 0; i < mesh.Length; i++)
        {
            List<int> groupIndexes = new();
            Point currPoint = mesh[i];

            // The idea is to put points that are close together into lists.
            // For every point, traverse through those list,
            for (int groupIndex = 0; groupIndex < pointsGroup.Count; groupIndex++)
            {
                foreach (var point in pointsGroup[groupIndex])
                {
                    if (currPoint.ApproxEquals(point, epsilon))
                    {
                        groupIndexes.Add(groupIndex);
                        break;
                    }
                }
            }

            // If current point belongs only to one list, add that point to the list.
            if (groupIndexes.Count == 1)
            {
                pointsGroup[groupIndexes[0]].Add(currPoint);
            }
            // If current point belongs to multiple lists, merge those lists together, then add the point the the merged list.
            // This is account for points that are not close to each other, but have the same point that are close to them.
            else if (groupIndexes.Count > 1)
            {
                List<Point> beginPoints = pointsGroup[groupIndexes[0]];
                for (int groupIndex = groupIndexes.Count - 1; groupIndex >= 1; groupIndex--)
                {
                    int pointIndex = groupIndexes[groupIndex];
                    List<Point> groupToAdd = pointsGroup[pointIndex];
                    beginPoints.AddRange(groupToAdd);
                    pointsGroup.RemoveAt(pointIndex);
                }

                beginPoints.Add(currPoint);
            }
            // Add a new list if it doesn't belong to any
            else
            {
                pointsGroup.Add(new List<Point> { currPoint });
            }
        }

        // Calculate average points
        List<Point> newMesh = new();
        Point averagePoint;

        foreach (var points in pointsGroup)
        {
            averagePoint.x = averagePoint.y = averagePoint.z = 0;
            foreach (var point in points)
            {
                averagePoint.x += point.x;
                averagePoint.y += point.y;
                averagePoint.z += point.z;
            }

            averagePoint.x /= points.Count;
            averagePoint.y /= points.Count;
            averagePoint.z /= points.Count;

            newMesh.Add(averagePoint);
        }

        return newMesh.ToArray();
    }
}
