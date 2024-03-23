using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

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

    public static T[] CombineArray(T[] arr1, T[] arr2)
    {
        int combineLength = arr1.Length + arr2.Length;
        T[] combineArr = new T[combineLength];

        int counter = 0;
        for(int i = 0 ; i < arr1.Length ; i++)
        {
            combineArr[counter++] = arr1[i];
        }

        for(int i = 0 ; i < arr2.Length ; i++)
        {
            combineArr[counter++] = arr2[i];
        }

        return combineArr;
    }
}
