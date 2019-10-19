using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
public static class Mathr
{
    private static Random _random = new Random();
    private static int[] _permutation;

    private static Vector2D[] _gradients;

    static Mathr()
    {
        CalculatePermutation(out _permutation);
        CalculateGradients(out _gradients);
    }

    private static void CalculatePermutation(out int[] p)
    {
        p = Enumerable.Range(0, 256).ToArray();

        /// shuffle the array
        for (var i = 0; i < p.Length; i++)
        {
            var source = _random.Next(p.Length);

            var t = p[i];
            p[i] = p[source];
            p[source] = t;
        }
    }

    /// <summary>
    /// generate a new permutation.
    /// </summary>
    public static void Reseed()
    {
        CalculatePermutation(out _permutation);
    }

    private static void CalculateGradients(out Vector2D[] grad)
    {
        grad = new Vector2D[256];

        for (var i = 0; i < grad.Length; i++)
        {
            Vector2D gradient;

            do
            {
                gradient = new Vector2D((float)(_random.NextDouble() * 2 - 1), (float)(_random.NextDouble() * 2 - 1));
            }
            while (gradient.LengthSquared() >= 1);

            gradient.Normalize();
            grad[i] = gradient;
        }

    }

    private static float Drop(float t)
    {
        t = Math.Abs(t);
        return 1f - t * t * t * (t * (t * 6 - 15) + 10);
    }

    private static float Q(float u, float v)
    {
        return Drop(u) * Drop(v);
    }

    public static float Noise(float x, float y)
    {
        
        var cell = new Vector2D((float)Math.Floor(x), (float)Math.Floor(y));
        
        var total = 0f;

        var corners = new[] { new Vector2D(0, 0), new Vector2D(0, 1), new Vector2D(1, 0), new Vector2D(1, 1) };

        foreach (var n in corners)
        {
            var ij = Vector2D.Sum(cell, n);
            
            var uv = new Vector2D(x - ij.X, y - ij.Y);

            var index = _permutation[(int)ij.X % _permutation.Length];
            index = _permutation[(index + (int)ij.Y) % _permutation.Length];
            
            var grad = _gradients[index % _gradients.Length];

            total += Q(uv.X, uv.Y) * Vector2D.Dot(grad, uv);
        }

        return Math.Max(Math.Min(total, 1f), -1f);
    }
    public static float InverseLerp(float min, float max, float position){
        float result = 0;
        result = (position - min)/(max - min);
        return result;
    }

    
}