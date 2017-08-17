using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;


public class AbilityDatabase : MonoBehaviour {
    List<Ability> database = new List<Ability>();
    JsonData abilityData;

    private void Start()
    {
        abilityData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Abilities.json"));
    }




}

public class Ability {

    string Name { get; set; }
    string Description { get; set; }
    string Type { get; set; }
    string Element { get; set; }
    Sprite Icon { get; set; }
    float Damage { get; set; }
    float MPcost { get; set; }
    float APCost { get; set; }
    List<AbilityBehaviours> behaviors = new List<AbilityBehaviours>();

    public Ability(string _name, string _description, string _type, string _element, Sprite _icon, float _damage, float _mpCost, float _apCost, List<AbilityBehaviours> _behaviors)
    {
        Name = _name;
        Description = _description;
        Type = _type;
        Element = _element;
        Icon = _icon;
        Damage = _damage;
        MPcost = _mpCost;
        APCost = _apCost;
        behaviors = _behaviors;
    }
    

}
