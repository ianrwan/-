using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayDealer<T>
{
    private T[] originalArray;

    public ArrayDealer(T[] originalArray)
    {
        this.originalArray = originalArray;
    }

    public T[] TrimArray(T[] originalArray, int amount)
    {
        this.originalArray = originalArray;
        T[] newArr = new T[amount];

        for(int i = 0 ; i < amount ; i++)
        {
            newArr[i] = originalArray[i];
        }

        return newArr;
    }

    public T[] TrimArray(int amount)
    {
        return TrimArray(originalArray, amount);
    }
}
