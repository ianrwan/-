using System.Collections;
using System.Collections.Generic;
using Megumin.GameSystem;
using UnityEngine;

public class EnemyVectorHandle : VectorHandle
{
    public EnemyVectorHandle() : this(1){}

    public EnemyVectorHandle(int amount) : base(amount){}

    public override void MakeDictionary()
    {
        jsonDictionary.Add(1, "one-data");
        jsonDictionary.Add(2, "two-data");
        jsonDictionary.Add(3, "three-data");
    }
}
