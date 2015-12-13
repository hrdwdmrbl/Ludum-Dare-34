using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class FrameworkExtensions {
    // a map function
    public static void ForEach<T>(this IEnumerable<T> @enum, Action<T> mapFunction) {
        foreach (var item in @enum) mapFunction(item);
    }
}