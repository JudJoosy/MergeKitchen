using System.Collections.Generic;

public class HashSetComparer<T> : IEqualityComparer<HashSet<T>>
{
    public static HashSetComparer<T> Instance { get; } = new HashSetComparer<T>();

    public bool Equals(HashSet<T> x, HashSet<T> y)
    {
        return x.SetEquals(y);
    }

    public int GetHashCode(HashSet<T> obj)
    {
        int hash = 0;
        foreach (T item in obj)
        {
            hash ^= item.GetHashCode();
        }
        return hash;
    }
}
