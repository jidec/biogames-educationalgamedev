using System;
using System.Collections;
using System.Collections.Generic;
 
[System.Serializable]
public class Tuple<T1, T2>
{
    public T1 first;
    public T2 second;

 
    public Tuple(T1 first, T2 second)
    {
        this.first = first;
        this.second = second;
    }
 
    public override string ToString()
    {
        return string.Format("<{0}, {1}>", first, second);
    }
 
    private static bool IsNull(object obj)
    {
        return object.ReferenceEquals(obj, null);
    }
}
