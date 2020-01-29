using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField] string id;
    public string ID { get { return id; } }
    public string ItemName;
    public Sprite Icon;
    [Range(1, 99)]
    public int MaxStacks = 1;

    protected static readonly StringBuilder sb = new StringBuilder();

    private void OnValidate()
    {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
    }

    public virtual Item GetCopy()
    {
        return this;
    }

    public virtual void Destroy()
    {

    }

    public virtual string GetItemType()
    {
        return "";
    }

    public virtual string GetStats()
    {
        return "";
    }
}
