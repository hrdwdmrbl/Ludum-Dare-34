using UnityEngine;
using System;

public enum MazeDirection {
    North,
    East,
    South,
    West
}

public static class MazeDirections {

    public readonly static int Count = Enum.GetNames(typeof(MazeDirection)).Length;

    public static MazeDirection RandomValue {
        get {
			return (MazeDirection)UnityEngine.Random.Range(0, Count);
        }
    }

    private static IntVector2[] vectors = new IntVector2[4]{
        new IntVector2(0, 1),
        new IntVector2(1, 0),
        new IntVector2(0, -1),
        new IntVector2(-1, 0)
    };

    public static IntVector2 ToIntVector2(this MazeDirection direction) {
        return vectors[(int)direction];
    }
}