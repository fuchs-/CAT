using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class FighterLoader
{
    private Dictionary<string, FighterData> database;

    public FighterLoader()
    {
        this.database = new Dictionary<string, FighterData>();

        this.loadAllFighters();
        Debug.Log(database.Count + " fighters loaded");
    }

    public List<FighterData> getFighterData()
    {
        List<FighterData> ret = new List<FighterData>();

        foreach (FighterData data in database.Values)
        {
            ret.Add(data);
        }

        return ret;
    }

    public FighterData getFighterData(string name)
    {
        return database[name];
    }

    /// <summary>
    /// loads just the fighter.json from all fighters
    /// </summary>
    public Dictionary<string, FighterData> LoadAllFighters()
    {
        FileSystemHelper fileSystem = DataController.FileSystem;

        List<string> fighterDirs = fileSystem.getAllFighterDirectories();

        foreach (string fighterDir in fighterDirs)
        {
            string name = fileSystem.getFighterNameFromDirectoryPath(fighterDir);
            FighterData data = loadFighterData(fighterDir);
            database.Add(name, data);
        }
    }

    private FighterData loadFighterData(string fighterDirectory)
    {
        FighterData data = null;
        data = JsonConvert.DeserializeObject<FighterData>(File.ReadAllText(Path.Combine(fighterDirectory,"fighter.json")));
        return data;
    }


    #region Dev Stuff...

    private void _dev_createTemplates()
    {
        UnitData unit = new UnitData();

        unit.id = "beastmaster_boar_1";
        unit.name = "Boar";

        unit.HP = 300f;
        unit.HPRegen = 1.5f;

        unit.moveSpeed = 4f;
        unit.armor = 0f;
        unit.magicResistance = 0f;
        unit.attackDamage = 16f;
        unit.attackSpeed = 1f;
        unit.attackRange = 2f;

        AbilityData ability = new AbilityData();
        ability.id = "beastmaster_boar_poison";
        ability.name = "Poison";
        ability.scriptFunctionName = "poison";
        ability.type = "passive";
        ability.isUltimate = false;
        ability.manaCost = "0";
        ability.cooldown = "0";
        unit.abilities = new AbilityData[1];
        unit.abilities[0] = ability;

        EffectData effect = new EffectData();
        effect.id = "beastmaster_boar_poison";
        effect.name = "Boar Poison";
        effect.type = "debuff";
        effect.dispellableType = EffectDispellable.Dispellable;
        effect.attributes = new Dictionary<string, string>();
        effect.attributes.Add("move_speed", "10,20,30,40%");
        effect.attributes.Add("attack_speed", "10,20,30,40%");
        effect.attributes.Add("duration", "3");
        unit.effects = new EffectData[1];
        unit.effects[0] = effect;

        FighterData fighter = new FighterData();

        fighter.id = "phantom_assassin";
        fighter.name = "Phantom Assassin";
        fighter.shortName = "PA";
        fighter.universe = "Dota2";
        fighter.affiliation = "Agility";
        fighter.power = 100f;
        fighter.HP = 200f;
        fighter.HPRegen = 0.25f;
        fighter.MP = 75f;
        fighter.strength = 21f;
        fighter.strengthGain = 2.2f;
        fighter.agility = 23f;
        fighter.agilityGain = 3.7f;
        fighter.intelligence = 15f;
        fighter.intelligenceGain = 1.4f;
        fighter.moveSpeed = 3f;
        fighter.armor = 1f;
        fighter.magicResistance = 25f;
        fighter.attackDamage = 24f;
        fighter.attackSpeed = 0.59f;
        fighter.attackRange = 1f;
        fighter.abilities = new AbilityData[4];

        ability = new AbilityData();
        ability.id = "pa_stifling_dagger";
        ability.name = "Stifling Dagger";
        ability.scriptFunctionName = "stiflingDagger";
        ability.image = "pa_stifling_dagger";
        ability.type = "unit_target";
        ability.maxLevel = 4;
        ability.isUltimate = false;
        ability.manaCost = "30";
        ability.cooldown = "6";
        ability.castRange = "2,4,5,6";
        ability.area = "3";

        ability.levelUpRequires = new string[3][];
        ability.levelUpRequires[0] = new string[1];
        ability.levelUpRequires[0][0] = "fighter:3";
        ability.levelUpRequires[1] = new string[1];
        ability.levelUpRequires[1][0] = "fighter:5";
        ability.levelUpRequires[2] = new string[1];
        ability.levelUpRequires[2][0] = "fighter:7";

        fighter.abilities[0] = ability;

        ability = new AbilityData();
        ability.id = "pa_phantom_strike";
        ability.name = "Phantom Strike";
        ability.scriptFunctionName = "phantomStrike";
        ability.image = "pa_phantom_strike";
        ability.type = "unit_target";
        ability.maxLevel = 4;
        ability.isUltimate = false;
        ability.manaCost = "35,40,45,50";
        ability.cooldown = "11,9,7,5";
        ability.castRange = "1000";

        ability.levelUpRequires = new string[3][];
        ability.levelUpRequires[0] = new string[1];
        ability.levelUpRequires[0][0] = "fighter:3";
        ability.levelUpRequires[1] = new string[1];
        ability.levelUpRequires[1][0] = "fighter:5";
        ability.levelUpRequires[2] = new string[1];
        ability.levelUpRequires[2][0] = "fighter:7";

        fighter.abilities[1] = ability;


        ability = new AbilityData();
        ability.id = "pa_blur";
        ability.name = "Blur";
        ability.scriptFunctionName = "blur";
        ability.image = "pa_blur";
        ability.type = "passive";
        ability.maxLevel = 4;
        ability.isUltimate = false;

        ability.levelUpRequires = new string[3][];
        ability.levelUpRequires[0] = new string[1];
        ability.levelUpRequires[0][0] = "fighter:3";
        ability.levelUpRequires[1] = new string[1];
        ability.levelUpRequires[1][0] = "fighter:5";
        ability.levelUpRequires[2] = new string[1];
        ability.levelUpRequires[2][0] = "fighter:7";

        fighter.abilities[2] = ability;

        ability = new AbilityData();
        ability.id = "pa_coup_de_grace";
        ability.name = "Coup de Grace";
        ability.image = "pa_coup_de_grace";
        ability.scriptFunctionName = "coupDeGrace";
        ability.type = "attack_modifier";
        ability.maxLevel = 3;
        ability.isUltimate = true;
        ability.manaCost = "0";
        ability.cooldown = "0";

        ability.levelUpRequires = new string[3][];
        ability.levelUpRequires[0] = new string[1];
        ability.levelUpRequires[0][0] = "fighter:6";
        ability.levelUpRequires[1] = new string[1];
        ability.levelUpRequires[1][0] = "fighter:12";
        ability.levelUpRequires[2] = new string[1];
        ability.levelUpRequires[2][0] = "fighter:18";

        fighter.abilities[3] = ability;

        effect = new EffectData();
        effect.id = "pa_stifling_dagger";
        effect.name = "Stifling Dagger";
        effect.type = "debuff";
        effect.dispellableType = EffectDispellable.Dispellable;
        effect.attributes = new Dictionary<string, string>();
        effect.attributes.Add("move_speed", "-50%");
        effect.attributes.Add("duration", "1.75,2.5,3.25,4");
        fighter.effects = new EffectData[2];
        fighter.effects[0] = effect;

        effect = new EffectData();
        effect.id = "pa_phantom_strike";
        effect.name = "Phantom Strike";
        effect.type = "buff";
        effect.dispellableType = EffectDispellable.Dispellable;
        effect.attributes = new Dictionary<string, string>();
        effect.attributes.Add("attack_speed", "100,125,150,175");
        effect.attributes.Add("duration", "2");
        fighter.effects[1] = effect;

        string path = Path.Combine(DataController.FileSystem.fightersFolderPath, "info");
        File.WriteAllText(Path.Combine(path, "fighter.json"), JsonConvert.SerializeObject(fighter, Formatting.Indented));
        File.WriteAllText(Path.Combine(path, "unit.json"), JsonConvert.SerializeObject(unit, Formatting.Indented));
    }

    #endregion
}
