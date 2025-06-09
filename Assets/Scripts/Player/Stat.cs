using System.Resources;

[System.Serializable]
public class Stat
{
    public string statName;
    public float value;
    
    public Stat(string name, float value)
    {
        statName = name;
        this.value = value;
    }
}
