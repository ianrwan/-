using System;

[Serializable]
public class PlayerTest
{
    public string name;
    public int health;
    public int[] items;

    public PlayerTest(string name, int health)
    {
        this.name = name;
        this.health = health;
        this.items = new int[3];
        itemsInput(this.items);
    }

    public void itemsInput(int[] data)
    {
        for(int i = 0 ; i < 3 ; i++)
        {
            data[i] = i*10;
        }
    }
}