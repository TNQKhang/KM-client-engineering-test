using System;
using System.Collections.Generic;

// Time spent : 3h00'
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
        List<List<int>> pointIndexesGroup = new();

        for (int i = 0; i < mesh.Length; i++)
        {
            Point currPoint = mesh[i];

            // The idea is to put indexes of points that are close together into lists.
            // For every point, traverse through those list.
            bool IsApproxEqual = false;

            foreach (var pointIndexes in pointIndexesGroup)
            {
                IsApproxEqual = true;

                foreach (var pointIndex in pointIndexes)
                {
                    Point point = mesh[pointIndex];

                    if (!currPoint.ApproxEquals(point, epsilon))
                    {
                        IsApproxEqual = false;

                        break;
                    }
                }

                // If the point is approximately equal to every other point in the list
                // Add the point to the list, 
                if (IsApproxEqual)
                {
                    pointIndexes.Add(i);

                    // We only need to put it into one list, 
                    // as put it into multiple list won't reduce the points count further.
                    // Eg. if points 1,2,3 are equals and points 3,4,5 are equals, but not 1,2 and 4,5
                    // Then we only need to collapse 1,2,3 or 3,4,5, then collapse 4,5 or 1,2.
                    break;
                }
            }

            // If it doesn't belong in any list, add a new list
            if (!IsApproxEqual)
                pointIndexesGroup.Add(new List<int> { i });
        }

        // Calculate the average points
        List<Point> newMesh = new();
        Point averagePoint;

        foreach (var pointIndexes in pointIndexesGroup)
        {
            averagePoint.x = averagePoint.y = averagePoint.z = 0;

            foreach (var pointIndex in pointIndexes)
            {
                averagePoint.x += mesh[pointIndex].x;
                averagePoint.y += mesh[pointIndex].y;
                averagePoint.z += mesh[pointIndex].z;
            }

            averagePoint.x /= pointIndexes.Count;
            averagePoint.y /= pointIndexes.Count;
            averagePoint.z /= pointIndexes.Count;

            newMesh.Add(averagePoint);
        }

        return newMesh.ToArray();
    }
}
