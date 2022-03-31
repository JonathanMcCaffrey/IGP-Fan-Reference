using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Model.Immortal.Entity.Data;
using Model.Immortal.Entity.Parts;
using Model.Immortal.Types;

namespace Model.Immortal.Entity;

public class EntityModel {
    public static readonly string GameVersion = "0.0.6.8900a";

     private static Dictionary<string, EntityModel> _database;

     private static List<EntityModel> entityModels;

     private static List<EntityModel> entityModelsOnlyHotkey;

     private static Dictionary<string, List<EntityModel>> entityModelsByHotkey;


    public EntityModel() { }

    public EntityModel(string data, string entity, bool isSpeculative = false) {
        DataType = data;
        EntityType = entity;
        IsSpeculative = isSpeculative;
    }

    [Key] public int Id { get; set; } = 1;



    public string DataType { get; set; }

    // TODO Serilization currently being used for build orders
    public string EntityType { get; set; }

    public List<IEntityPartInterface> EntityParts { get; set; } = new();

    public bool IsSpeculative { get; set; }

    //TODO Use these values
    public string Name { get; set; } = "";
    public string Descriptive { get; set; } = DescriptiveType.None;
    public string Description { get; set; } = "";
    public string Notes { get; set; }

    
    public EntityModel Clone() {
        return (EntityModel)MemberwiseClone();
    }

    
    public void Copy(EntityModel entity) {
        DataType = entity.DataType;
        EntityType = entity.EntityType;
        EntityParts = entity.EntityParts.ToList();
    }

    
    public EntityModel AddPart(IEntityPartInterface unitPart) {
        EntityParts.Add(unitPart);
        return this;
    }

    
    public static Dictionary<string, EntityModel> GetDictionary() {
        if (_database == null) _database = DATA.Get();

        return _database;
    }

    
    public static EntityModel Get(string entity) {
        if (_database == null) _database = DATA.Get();

        return _database[entity];
    }

    
    public static List<EntityModel> GetList() {
        if (entityModels == null) entityModels = DATA.Get().Values.ToList();

        return entityModels;
    }

    
    public static List<EntityModel> GetListOnlyHotkey() {
        if (entityModelsOnlyHotkey == null) {
            entityModelsOnlyHotkey = new List<EntityModel>();

            foreach (var entity in DATA.Get().Values)
                if (entity.Hotkey() != null)
                    entityModelsOnlyHotkey.Add(entity);
        }

        return entityModelsOnlyHotkey;
    }

    
    public static Dictionary<string, List<EntityModel>> GetEntitiesByHotkey() {
        if (entityModelsByHotkey == null) {
            entityModelsByHotkey = new Dictionary<string, List<EntityModel>>();

            foreach (var entity in GetList()) {
                var entityHotkey = entity.Hotkey();
                if (entityHotkey != null) {
                    if (!entityModelsByHotkey.ContainsKey(entityHotkey.Hotkey))
                        entityModelsByHotkey[entityHotkey.Hotkey] = new List<EntityModel>();

                    entityModelsByHotkey[entityHotkey.Hotkey].Add(entity);
                }
            }
        }


        return entityModelsByHotkey;
    }

    
    public static EntityModel GetFrom(string hotkey, string hotkeyGroup, bool holdSpace, string faction,
        string immortal) {
        if (hotkey == null || hotkey == "") return null;

        var foundList = from entity in GetEntitiesByHotkey()[hotkey]
            where entity.Hotkey()?.HotkeyGroup == hotkeyGroup
                  && entity.Hotkey()?.HoldSpace == holdSpace
                  && entity.Faction()?.Faction == faction
                  && (entity.Vanguard()?.Immortal == immortal || entity.Vanguard() == null)
                  && (entity.Replaceds().Count == 0 || (from replace in entity.Replaceds()
                      where replace.Immortal == immortal
                      select replace).ToList().Count == 0)
            select entity;

        if (foundList == null || foundList.Count() == 0) return null;

        var found = foundList.First();

        return found;
    }

    
    public EntityInfoModel Info() {
        return (EntityInfoModel)EntityParts.Find(x => x.GetType() == typeof(EntityInfoModel));
    }

    
    public EntitySupplyModel Supply() {
        return (EntitySupplyModel)EntityParts.Find(x => x.GetType() == typeof(EntitySupplyModel));
    }

    
    public EntityTierModel Tier() {
        return (EntityTierModel)EntityParts.Find(x => x.GetType() == typeof(EntityTierModel));
    }

    
    public EntityProductionModel Production() {
        return (EntityProductionModel)EntityParts.Find(x => x.GetType() == typeof(EntityProductionModel));
    }

    
    public EntityMovementModel Movement() {
        return (EntityMovementModel)EntityParts.Find(x => x.GetType() == typeof(EntityMovementModel));
    }

    
    public EntityVitalityModel Vitality() {
        return (EntityVitalityModel)EntityParts.Find(x => x.GetType() == typeof(EntityVitalityModel));
    }

    
    public List<EntityRequirementModel> Requirements() {
        return EntityParts.FindAll(x => x.GetType() == typeof(EntityRequirementModel))
            .Cast<EntityRequirementModel>().ToList();
    }

    
    public List<EntityWeaponModel> Weapons() {
        return EntityParts.FindAll(x => x.GetType() == typeof(EntityWeaponModel))
            .Cast<EntityWeaponModel>().ToList();
    }

    
    public List<EntityVanguardReplacedModel> Replaceds() {
        return EntityParts.FindAll(x => x.GetType() == typeof(EntityVanguardReplacedModel))
            .Cast<EntityVanguardReplacedModel>().ToList();
    }

    
    public EntityVanguardAddedModel Vanguard() {
        return (EntityVanguardAddedModel)EntityParts.Find(x => x.GetType() == typeof(EntityVanguardAddedModel));
    }

    
    public EntityHotkeyModel Hotkey() {
        return (EntityHotkeyModel)EntityParts.Find(x => x.GetType() == typeof(EntityHotkeyModel));
    }

    
    public EntityFactionModel Faction() {
        return (EntityFactionModel)EntityParts.Find(x => x.GetType() == typeof(EntityFactionModel));
    }

    
    public EntityHarvestModel Harvest() {
        return (EntityHarvestModel)EntityParts.Find(x => x.GetType() == typeof(EntityHarvestModel));
    }

    
    public List<EntityIdAbilityModel> IdAbilities() {
        return EntityParts.FindAll(x => x.GetType() == typeof(EntityIdAbilityModel))
            .Cast<EntityIdAbilityModel>().ToList();
    }

    
    public List<EntityIdArmyModel> IdArmies() {
        return EntityParts.FindAll(x => x.GetType() == typeof(EntityIdArmyModel))
            .Cast<EntityIdArmyModel>().ToList();
    }

    
    public List<EntityIdPassiveModel> IdPassives() {
        return EntityParts.FindAll(x => x.GetType() == typeof(EntityIdPassiveModel))
            .Cast<EntityIdPassiveModel>().ToList();
    }

    
    public List<EntityIdUpgradeModel> IdUpgrades() {
        return EntityParts.FindAll(x => x.GetType() == typeof(EntityIdUpgradeModel))
            .Cast<EntityIdUpgradeModel>().ToList();
    }

    
    public List<EntityIdVanguardModel> IdVanguards() {
        return EntityParts.FindAll(x => x.GetType() == typeof(EntityIdVanguardModel))
            .Cast<EntityIdVanguardModel>().ToList();
    }

    
    public List<EntityIdPyreSpellModel> IdPyreSpells() {
        return EntityParts.FindAll(x => x.GetType() == typeof(EntityIdPyreSpellModel))
            .Cast<EntityIdPyreSpellModel>().ToList();
    }

    public List<EntityMechanicModel> Mechanics() {
        return EntityParts.FindAll(x => x.GetType() == typeof(EntityMechanicModel))
            .Cast<EntityMechanicModel>().ToList();
    }

    public List<EntityPassiveModel> Passives() {
        return EntityParts.FindAll(x => x.GetType() == typeof(EntityPassiveModel))
            .Cast<EntityPassiveModel>().ToList();
    }

    public List<EntityStrategyModel> Strategies() {
        return EntityParts.FindAll(x => x.GetType() == typeof(EntityStrategyModel))
            .Cast<EntityStrategyModel>().ToList();
    }
}