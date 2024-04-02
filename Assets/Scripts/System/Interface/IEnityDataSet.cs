using UnityEngine;

// this interface can let you access the same data in maincharacter and enemy
// for example: main character has speed and also enemy, so you can get the speed by using GetSpeed()
public interface IEntityDataGet
{
    // get gameobject which it attached
    public GameObject GetGameObject();
    
    // get speed from the entity
    public int GetSpeed();
    
}