using System.Collections.Generic;
using Model.Entity.Parts;
using Model.Types;
using Newtonsoft.Json;

namespace Model.Entity.Data;

public class DATA
{
    public static string AsJson()
    {
        var json = JsonConvert.SerializeObject(Get(), Formatting.Indented);
        return json;
    }

    public static Dictionary<string, EntityModel> Get()
    {
        return new Dictionary<string, EntityModel>
        {
            // Neutrals

            // Pyre Events
            {
                DataType.PYREEVENT_CampTaken, new EntityModel(DataType.PYREEVENT_CampTaken, EntityType.Pyre_Event)
                    .AddPart(new EntityInfoModel { Name = "Pyre Camp", Description = "Provides 25 when taken." })
                    .AddPart(new EntityPyreRewardModel { BaseReward = 25 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "2" })
            },
            {
                DataType.PYREEVENT_MinerTaken, new EntityModel(DataType.PYREEVENT_MinerTaken, EntityType.Pyre_Event)
                    .AddPart(new EntityInfoModel { Name = "Pyre Camp", Description = "Provides 90 when taken." })
                    .AddPart(new EntityPyreRewardModel
                        { BaseReward = 0, OverTimeRewardDuration = 90, OverTimeReward = 1 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "2" })
            },
            {
                DataType.PYREEVENT_TowerKilled, new EntityModel(DataType.PYREEVENT_TowerKilled, EntityType.Pyre_Event)
                    .AddPart(new EntityInfoModel { Name = "Tower Taken", Description = "Provides 10 when destroyed." })
                    .AddPart(new EntityPyreRewardModel { BaseReward = 10 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "2" })
            },

            // TEAPOTS
            {
                DataType.TEAPOT_Teapot, new EntityModel(DataType.TEAPOT_Teapot, EntityType.Teapot)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Teapot", Description = "Basic scout. Every faction has this",
                        Notes = @"Very powerful! So Fast"
                    })
                    .AddPart(new EntityVitalityModel { Health = 70, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 400 })
            },
            {
                DataType.TEAPOT_FlyingTeapot, new EntityModel(DataType.TEAPOT_FlyingTeapot, EntityType.Teapot)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Flying Teapot",
                        Description = "Basic observer. Can fly and see hidden units within 1000 range.",
                        Notes = @"Doesn't take up a scout slot."
                    })
                    .AddPart(new EntityRequirementModel { Id = DataType.TEAPOT_Teapot })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 50 })
                    .AddPart(new EntityVitalityModel { Health = 70, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 400, Movement = MovementType.Air })
            },

            // Families
            {
                DataType.FAMILY_Rae,
                new EntityModel(DataType.FAMILY_Rae, EntityType.Family, true)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Rae"
                    })
            },
            {
                DataType.FAMILY_Sylv,
                new EntityModel(DataType.FAMILY_Sylv, EntityType.Family, true)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Sylv"
                    })
            },
            {
                DataType.FAMILY_Angelic,
                new EntityModel(DataType.FAMILY_Angelic, EntityType.Family, true)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Angelic"
                    })
            },
            {
                DataType.FAMILY_Human,
                new EntityModel(DataType.FAMILY_Human, EntityType.Family, true)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Human"
                    })
            },
            {
                DataType.FAMILY_Coalition,
                new EntityModel(DataType.FAMILY_Coalition, EntityType.Family, true)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Coalition?"
                    })
            },
            {
                DataType.FAMILY_Demonic,
                new EntityModel(DataType.FAMILY_Demonic, EntityType.Family, true)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Demonic?"
                    })
            },
            {
                DataType.FAMILY_NazRa,
                new EntityModel(DataType.FAMILY_NazRa, EntityType.Family, true)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Naz'Ra"
                    })
            },
            // Factions
            // Sylv
            {
                DataType.FACTION_Aru,
                new EntityModel(DataType.FACTION_Aru, EntityType.Faction)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Aru"
                    })
                    .AddPart(new EntityPassiveModel
                    {
                        Name = "Overgrowth",
                        Description =
                            "Your units have an extra layer of health a regens rapidly when a unit hasn't been damaged recently. This regen is doubled on rootway."
                    })
                    .AddPart(new EntityPassiveModel
                    {
                        Name = "Blood",
                        Description =
                            "Your casters passively get blood for spells. This blood regen rate is increased on rootway. Your casters can also spend their own life as blood. (Spending health as blood is currenly not in game.)"
                    })
                    .AddPart(new EntityPassiveModel
                    {
                        Name = "Blood Wells",
                        Description =
                            "You can summon blood wells for pyre, that allow you to heal your units health and mana."
                    })
            },
            {
                DataType.FACTION_Iratek,
                new EntityModel(DataType.FACTION_Iratek, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Iratek"
                    })
            },
            {
                DataType.FACTION_Yul,
                new EntityModel(DataType.FACTION_Yul, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel { Name = "Yul" })
            },
            // Factions
            // Angelic
            {
                DataType.FACTION_QRath,
                new EntityModel(DataType.FACTION_QRath, EntityType.Faction)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Q'Rath",
                        Notes =
                            "Angelic faction that has adopted many humans into their ranks. They seek to bring more into their collective."
                    })
                    .AddPart(new EntityPassiveModel
                    {
                        Name = "Wards",
                        Description =
                            "Your units have an extra layer of health that is always (but slowly) regenerates. The regeneration is double on Hallowed Ground."
                    })
            },
            {
                DataType.FACTION_YRiah,
                new EntityModel(DataType.FACTION_QRath, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel { Name = "R'Raih" })
            },
            {
                DataType.FACTION_ArkShai,
                new EntityModel(DataType.FACTION_QRath, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel
                        { Name = "Ark'Shai" })
            },
            // Factions
            // Human
            {
                DataType.FACTION_Jora,
                new EntityModel(DataType.FACTION_Jora, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel { Name = "Jora" })
            },
            {
                DataType.FACTION_Telmetra,
                new EntityModel(DataType.FACTION_Telmetra, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel { Name = "Talmetra" })
            },
            {
                DataType.FACTION_Kjor,
                new EntityModel(DataType.FACTION_Kjor, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel
                        { Name = "Kjor" }
                    )
            },
            // Factions
            // Rae
            {
                DataType.FACTION_Herlesh,
                new EntityModel(DataType.FACTION_Herlesh, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel { Name = "Herlesh" })
            },
            // Factions
            // Coalition
            {
                DataType.FACTION_Khardu,
                new EntityModel(DataType.FACTION_Khardu, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel { Name = "Khardu" })
            },
            // Immortals
            // Aru
            {
                DataType.IMMORTAL_Mala,
                new EntityModel(DataType.IMMORTAL_Mala, EntityType.Immortal)
                    .AddPart(new EntityInfoModel { Name = "Mala" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityHarvestModel
                    {
                        Resource = ResourceType.Pyre, HarvestedPerInterval = 1, HarvestDelay = 3,
                        RequiresWorker = false, Slots = 1, TotalAmount = -1
                    })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.IPASSIVE_MothersHunger })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_SummonGroveGuardian })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_InfuseTroops })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_ConstructBloodWell })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_RedTithe })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_RainOfBlood })
                    .AddPart(new EntityIdVanguardModel { Id = DataType.VANGUARD_Incubator_Mala })
                    .AddPart(new EntityIdVanguardModel { Id = DataType.VANGUARD_DreadSister_Mala })
            },
            {
                DataType.IMMORTAL_Xol,
                new EntityModel(DataType.IMMORTAL_Xol, EntityType.Immortal)
                    .AddPart(new EntityInfoModel { Name = "Xol" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityHarvestModel
                    {
                        Resource = ResourceType.Pyre, HarvestedPerInterval = 1, HarvestDelay = 3,
                        RequiresWorker = false, Slots = 1, TotalAmount = -1
                    })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.IPASSIVE_StalkersSense })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_SummonGroveGuardian })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_InfuseTroops })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_ConstructBloodWell })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_MarkPrey })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_TheGreatHunt })
                    .AddPart(new EntityIdVanguardModel { Id = DataType.VANGUARD_BoneStalker_Xol })
                    .AddPart(new EntityIdVanguardModel { Id = DataType.VANGUARD_WhiteWoodReaper_Xol })
            },
            // Immortals
            // Q'Rath
            {
                DataType.IMMORTAL_Ajari,
                new EntityModel(DataType.IMMORTAL_Ajari, EntityType.Immortal)
                    .AddPart(new EntityInfoModel { Name = "Ajari" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityHarvestModel
                    {
                        Resource = ResourceType.Pyre, HarvestedPerInterval = 1, HarvestDelay = 3,
                        RequiresWorker = false, Slots = 1, TotalAmount = -1
                    })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.IPASSIVE_HealingGround })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_SummonCitadel })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_InfuseTroops })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_DeliverFromEvil })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_HeavensAegis })
                    .AddPart(new EntityIdVanguardModel { Id = DataType.VANGUARD_Saoshin_Ajari })
                    .AddPart(new EntityIdVanguardModel { Id = DataType.VANGUARD_ArkMother_Ajari })
            },
            {
                DataType.IMMORTAL_Orzum,
                new EntityModel(DataType.IMMORTAL_Orzum, EntityType.Immortal)
                    .AddPart(new EntityInfoModel { Name = "Orzum" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityHarvestModel
                    {
                        Resource = ResourceType.Pyre, HarvestedPerInterval = 1, HarvestDelay = 3,
                        RequiresWorker = false, Slots = 1, TotalAmount = -1
                    })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.IPASSIVE_Expansionist })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_InfuseTroops })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_SummonCitadel })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_EmpireUnbroken })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_PillarOfHeaven })
                    .AddPart(new EntityIdVanguardModel { Id = DataType.VANGUARD_Zentari_Orzum })
                    .AddPart(new EntityIdVanguardModel { Id = DataType.VANGUARD_Sceptre_Orzum })
            },

            // Immortal Passives
            {
                DataType.IPASSIVE_HealingGround,
                new EntityModel(DataType.IPASSIVE_HealingGround, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                        { Name = "Healing Ground", Description = "Ajari's Hallowed Ground has a healing effect." })
            },
            {
                DataType.IPASSIVE_Expansionist,
                new EntityModel(DataType.IPASSIVE_Expansionist, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                        { Name = "Expansionist", Description = "Orzum's Pyre Towers cost 25 less pyre." })
            },
            {
                DataType.IPASSIVE_MothersHunger,
                new EntityModel(DataType.IPASSIVE_MothersHunger, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Mother's Hunger",
                        Description =
                            "Mala's Blood Wells grant you pyre for nearby non-quitl deaths, based on the supply.",
                        Notes = "+1 per supply"
                    })
            },
            {
                DataType.IPASSIVE_StalkersSense,
                new EntityModel(DataType.IPASSIVE_StalkersSense, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Stalker's Sense", Description = "Xol's units sense nearby enemies in the fog of war.",
                        Notes = "Not implemented."
                    })
            },

            // Keys
            {
                DataType.COMMAND_Attack,
                new EntityModel(DataType.COMMAND_Attack, EntityType.Command)
                    .AddPart(new EntityInfoModel
                        { Name = "Attack", Description = "Makes selected units attack targeted area." })
                    .AddPart(new EntityHotkeyModel { Hotkey = "A", HotkeyGroup = "D" })
            },
            {
                DataType.COMMAND_StandGround,
                new EntityModel(DataType.COMMAND_StandGround, EntityType.Command)
                    .AddPart(new EntityInfoModel
                        { Name = "Stand Ground", Description = "Makes selected units stop moving." })
                    .AddPart(new EntityHotkeyModel { Hotkey = "S", HotkeyGroup = "D" })
            },
            // Starting Structures
            {
                DataType.STARTING_Bastion,
                new EntityModel(DataType.STARTING_Bastion, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Bastion",
                        Description = "Provides a fully upgraded base worth of alloy.",
                        Notes = "Revives in 40 seconds when destroyed."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Neutral })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Neutral })
                    .AddPart(new EntityHarvestModel
                    {
                        HarvestedPerInterval = 6, RequiresWorker = false, Resource = ResourceType.Alloy, Slots = 1,
                        TotalAmount = 6000
                    })
                    .AddPart(new EntityVitalityModel { Health = 500, Armor = ArmorType.Heavy })
                    .AddPart(new EntityWeaponModel
                        { Damage = 30, AttacksPerSecond = 1.401f, Targets = TargetType.All, Range = 700 })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_BastionPassives })
            },
            {
                DataType.STARTING_Tower,
                new EntityModel(DataType.STARTING_Tower, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Starting Tower",
                        Notes = "Currently not in game. Can be upgraded to the factions pyre tower."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Neutral })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Neutral })
                    .AddPart(new EntityVitalityModel
                        { Health = 1000, DefenseLayer = 500, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 20, Range = 800, AttacksPerSecond = 1.124f, Targets = TargetType.All,
                        MediumDamage = 25, HeavyDamage = 30
                    })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Respite })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_HallowedGround })
            },
            // Starting Structures
            // Aru
            {
                DataType.STARTING_TownHall_Aru,
                new EntityModel(DataType.STARTING_TownHall_Aru, EntityType.Building, true)
                    .AddPart(new EntityInfoModel
                        { Name = "Grove Heart (Starting)", Descriptive = DescriptiveType.Town_Hall_Starting })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVitalityModel
                        { Health = 2000, DefenseLayer = 400, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityHarvestModel
                    {
                        HarvestedPerInterval = 1, RequiresWorker = true, Resource = ResourceType.Alloy, Slots = 6,
                        TotalAmount = 6000
                    })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Rootway })
            },
            // Starting Structures
            // Q'Rath
            {
                DataType.STARTING_TownHall_QRath,
                new EntityModel(DataType.STARTING_TownHall_QRath, EntityType.Building, true)
                    .AddPart(new EntityInfoModel
                        { Name = "Acropolis (Starting)", Descriptive = DescriptiveType.Town_Hall_Starting })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityVitalityModel
                        { Health = 1600, DefenseLayer = 800, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityHarvestModel
                    {
                        HarvestedPerInterval = 6, RequiresWorker = false, Resource = ResourceType.Alloy, Slots = 1,
                        TotalAmount = 6000
                    })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_HallowedGround })
            },

            // Vanguard
            // Q'Rath
            {
                DataType.VANGUARD_Zentari_Orzum,
                new EntityModel(DataType.VANGUARD_Zentari_Orzum, EntityType.Army)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Zentari", Descriptive = DescriptiveType.Frontliner,
                        Description =
                            "Brawler (Ground Unit) - Juggernaut infantry that gain a ranged attack in Hallowed Ground."
                    })
                    .AddPart(new EntityTierModel { Tier = 1 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityVanguardAddedModel
                        { ReplaceId = DataType.UNIT_Sipari, ImmortalId = DataType.IMMORTAL_Orzum })
                    .AddPart(new EntityProductionModel { Alloy = 100, BuildTime = 24 })
                    .AddPart(new EntitySupplyModel { Takes = 4 })
                    .AddPart(new EntityVitalityModel { Health = 180, DefenseLayer = 100, Armor = ArmorType.Light })
                    .AddPart(new EntityWeaponModel
                        { Damage = 26, Range = 100, AttacksPerSecond = 0.699f, Targets = TargetType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 26, Range = 300, AttacksPerSecond = 0.699f, Targets = TargetType.Ground })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_LegionHall,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityMovementModel { Speed = 380, Movement = MovementType.Ground })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_FaithCastBlades })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_IconOfKhastEem })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_IconOfKhastEem })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_FaithCastBlades })
            },
            {
                DataType.VANGUARD_Sceptre_Orzum,
                new EntityModel(DataType.VANGUARD_Sceptre_Orzum, EntityType.Army)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Sceptre", Descriptive = DescriptiveType.Harrier, Description = "",
                        Notes = "Loses 16 energy per second when moving."
                    })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 200, Ether = 125, BuildTime = 40 })
                    .AddPart(new EntityVitalityModel { Health = 350, DefenseLayer = 120, Armor = ArmorType.Heavy })
                    .AddPart(new EntitySupplyModel { Takes = 6 })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 30, MediumDamage = 35, HeavyDamage = 40, Range = 600, SecondsBetweenAttacks = 1.8f,
                        AttacksPerSecond = 0.637f,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 40, MediumDamage = 45, HeavyDamage = 50, Range = 600, SecondsBetweenAttacks = 1.8f,
                        AttacksPerSecond = 0.637f,
                        Targets = TargetType.Ground, HasSplash = true
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Angelarium,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVanguardAddedModel
                        { ReplaceId = DataType.UNIT_Warden, ImmortalId = DataType.IMMORTAL_Orzum })
                    .AddPart(new EntityMovementModel { Speed = 340, Movement = MovementType.Air })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_RegentsWrath })
            },
            {
                DataType.VANGUARD_Saoshin_Ajari,
                new EntityModel(DataType.VANGUARD_Saoshin_Ajari, EntityType.Army)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Saoshin", Descriptive = DescriptiveType.Force_Multiplier,
                        Description =
                            "Support Caster (Ground Unit) - Has a decent melee attack and can buff units for a short duration. It can also heal."
                    })
                    .AddPart(new EntityTierModel { Tier = 1.5f })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityVanguardAddedModel
                        { ReplaceId = DataType.UNIT_Magi, ImmortalId = DataType.IMMORTAL_Ajari })
                    .AddPart(new EntityProductionModel { Alloy = 75, Ether = 75, BuildTime = 35 })
                    .AddPart(new EntitySupplyModel { Takes = 4 })
                    .AddPart(new EntityVitalityModel
                        { Health = 140, DefenseLayer = 100, Armor = ArmorType.Light, IsEtheric = true })
                    .AddPart(new EntityMovementModel { Speed = 380, Movement = MovementType.Ground })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_LegionHall,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Reliquary,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityWeaponModel
                        { Damage = 16, Range = 80, AttacksPerSecond = 0.833f, Targets = TargetType.Ground })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_Leap })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Invervention })
            },
            {
                DataType.VANGUARD_ArkMother_Ajari,
                new EntityModel(DataType.VANGUARD_ArkMother_Ajari, EntityType.Army)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Ark Mother", Descriptive = DescriptiveType.Dislodger,
                        Description =
                            "Dislodger - Support unit that creates a large area of damage reduction for friendly troops."
                    })
                    .AddPart(new EntityTierModel { Tier = 2 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityVanguardAddedModel
                        { ReplaceId = DataType.UNIT_Hallower, ImmortalId = DataType.IMMORTAL_Ajari })
                    .AddPart(new EntityProductionModel { Alloy = 150, Ether = 100, BuildTime = 40 })
                    .AddPart(new EntitySupplyModel { Takes = 5 })
                    .AddPart(new EntityVitalityModel
                        { Energy = 100, Health = 100, DefenseLayer = 100, Armor = ArmorType.Medium, IsEtheric = true })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_SoulFoundry,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_HouseOfFadingSaints,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityMovementModel { Speed = 335, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 25, Range = 1100, AttacksPerSecond = 0.4f, Targets = TargetType.Ground })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_OrdainedPassage })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_HallowingRites })
            },
            // Vanguards
            // Aru
            {
                DataType.VANGUARD_Incubator_Mala,
                new EntityModel(DataType.VANGUARD_Incubator_Mala, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Incubator", Descriptive = DescriptiveType.Force_Multiplier })
                    .AddPart(new EntityTierModel { Tier = 2 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AmberWomb,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVanguardAddedModel
                        { ReplaceId = DataType.UNIT_Underspine, ImmortalId = DataType.IMMORTAL_Mala })
                    .AddPart(new EntityProductionModel { Alloy = 175, Ether = 50, BuildTime = 35 })
                    .AddPart(new EntitySupplyModel { Takes = 5 })
                    .AddPart(new EntityVitalityModel
                        { Health = 160, DefenseLayer = 40, Armor = ArmorType.Medium, IsEtheric = false })
                    .AddPart(new EntityMovementModel { Speed = 340, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 16, Range = 700, AttacksPerSecond = 0.606f, Targets = TargetType.Ground })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_ProjectileGestation })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_FallenHarvest })
            },
            {
                DataType.VANGUARD_DreadSister_Mala,
                new EntityModel(DataType.VANGUARD_DreadSister_Mala, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Dread Sister", Descriptive = DescriptiveType.Elite_Caster })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_RedVale,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVanguardAddedModel
                        { ReplaceId = DataType.UNIT_RedSeer, ImmortalId = DataType.IMMORTAL_Mala })
                    .AddPart(new EntityProductionModel { Alloy = 60, Ether = 150, BuildTime = 45 })
                    .AddPart(new EntitySupplyModel { Takes = 4 })
                    .AddPart(new EntityVitalityModel
                    {
                        Energy = 100, Health = 60, DefenseLayer = 75, Armor = ArmorType.Light,
                        Defense = DefenseType.Overgrowth, IsEtheric = false
                    })
                    .AddPart(new EntityMovementModel { Speed = 315, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 14, Range = 750, AttacksPerSecond = 0.714f, Targets = TargetType.Ground })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_RootVice })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_BirthingStorm })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_SummonSiegeMaw })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_BirthingStorm })
            },
            {
                DataType.VANGUARD_BoneStalker_Xol,
                new EntityModel(DataType.VANGUARD_BoneStalker_Xol, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Bone Stalker", Descriptive = DescriptiveType.Generalist })
                    .AddPart(new EntityTierModel { Tier = 1 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVanguardAddedModel
                        { ReplaceId = DataType.UNIT_MaskedHunter, ImmortalId = DataType.IMMORTAL_Xol })
                    .AddPart(new EntityProductionModel { Alloy = 50, Ether = 0, BuildTime = 20 })
                    .AddPart(new EntitySupplyModel { Takes = 2 })
                    .AddPart(new EntityVitalityModel
                        { Health = 85, DefenseLayer = 10, Armor = ArmorType.Light, IsEtheric = false })
                    .AddPart(new EntityMovementModel { Speed = 350, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 11, Range = 400, AttacksPerSecond = 1.02f, Targets = TargetType.All })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Stalk })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Ambush })
            },
            {
                DataType.VANGUARD_WhiteWoodReaper_Xol,
                new EntityModel(DataType.VANGUARD_WhiteWoodReaper_Xol, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "White Wood Reaper", Descriptive = DescriptiveType.Assassin })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_RedVale,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVanguardAddedModel
                        { ReplaceId = DataType.UNIT_Bloodbound, ImmortalId = DataType.IMMORTAL_Xol })
                    .AddPart(new EntityProductionModel { Alloy = 80, Ether = 80, BuildTime = 35 })
                    .AddPart(new EntitySupplyModel { Takes = 4 })
                    .AddPart(new EntityVitalityModel
                    {
                        Energy = 60, Health = 80, DefenseLayer = 40, Defense = DefenseType.Overgrowth,
                        Armor = ArmorType.Medium, IsEtheric = false
                    })
                    .AddPart(new EntityMovementModel { Speed = 448, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 40, Range = 100, AttacksPerSecond = 1,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_LethalBond })
            },
            // Units
            // Q'Rath
            {
                DataType.WORKER_Mote,
                new EntityModel(DataType.WORKER_Mote, EntityType.Worker)
                    .AddPart(new EntityInfoModel { Name = "Mote", Descriptive = DescriptiveType.Worker })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 50, BuildTime = 20 })
                    .AddPart(new EntityVitalityModel { Health = 30, DefenseLayer = 30, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 400, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 5, Range = 50, AttacksPerSecond = 1.887f, Targets = TargetType.Ground })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_HarvestAlloy })
            },
            {
                DataType.UNIT_Sipari,
                new EntityModel(DataType.UNIT_Sipari, EntityType.Army)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Sipari", Descriptive = DescriptiveType.Frontliner,
                        Description =
                            @"Melee Warrior (Ground Unit) - Front-line warriors enchanced by <b>Hallowed Ground</b>."
                    })
                    .AddPart(new EntityTierModel { Tier = 1 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "Z" })
                    .AddPart(new EntityVanguardReplacedModel
                        { ImmortalId = DataType.IMMORTAL_Orzum, ReplacedById = DataType.VANGUARD_Zentari_Orzum })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 75, BuildTime = 25 })
                    .AddPart(new EntitySupplyModel { Takes = 3 })
                    .AddPart(new EntityVitalityModel { Health = 140, DefenseLayer = 70, Armor = ArmorType.Light })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_LegionHall,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityMovementModel { Speed = 380, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 20, HeavyDamage = 18, Range = 180, AttacksPerSecond = 0.699f,
                        SecondsBetweenAttacks = 1.43f, Targets = TargetType.Ground
                    })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_GreavesOfAhqar })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_FortifiedIcons })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_GreavesOfAhqar })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_FortifiedIcons })
            },
            {
                DataType.UNIT_Magi,
                new EntityModel(DataType.UNIT_Magi, EntityType.Army)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Magi", Descriptive = DescriptiveType.Force_Multiplier,
                        Description =
                            "Support Caster (Ground Unit) - Heal allies. Can deploy to create Hallowed Ground."
                    })
                    .AddPart(new EntityTierModel { Tier = 1.5f })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 75, Ether = 75, BuildTime = 35 })
                    .AddPart(new EntitySupplyModel { Takes = 3 })
                    .AddPart(new EntityVanguardReplacedModel
                        { ImmortalId = DataType.IMMORTAL_Ajari, ReplacedById = DataType.VANGUARD_Saoshin_Ajari })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_LegionHall,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Reliquary,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Energy = 100, Health = 50, DefenseLayer = 50, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 335, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 7, Range = 600, SecondsBetweenAttacks = 0.94f, AttacksPerSecond = 1.408f, Targets =
                            TargetType.All
                    })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_DeployMagi })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_MobilizeQrath })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_MendingCommand })
            },
            {
                DataType.UNIT_Zephyr,
                new EntityModel(DataType.UNIT_Zephyr, EntityType.Army)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Zephyr", Descriptive = DescriptiveType.Generalist,
                        Description =
                            "Ranged Generalist (Ground Unit) - Can attack ground and air. Has a short-ranged teleport ability for advanced mobility."
                    })
                    .AddPart(new EntityTierModel { Tier = 1.5f })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 40, BuildTime = 30 })
                    .AddPart(new EntitySupplyModel { Takes = 4 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_LegionHall,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Reliquary,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel { Health = 180, DefenseLayer = 90, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 350, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 20, MediumDamage = 24, HeavyDamage = 28, Range = 500, AttacksPerSecond = 0.667f,
                        Targets = TargetType.All
                    })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_WindStep })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_ZephyrRange })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_Windstep })
            },
            {
                DataType.UNIT_Dervish,
                new EntityModel(DataType.UNIT_Dervish, EntityType.Army)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Dervish", Descriptive = DescriptiveType.Harrier,
                        Description =
                            "Skirmisher (Ground Unit) - Swift unit used to harrass enemy outposts. Can only attack ground."
                    })
                    .AddPart(new EntityTierModel { Tier = 2 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 125, Ether = 10, BuildTime = 35 })
                    .AddPart(new EntitySupplyModel { Takes = 4 })
                    .AddPart(new EntityVitalityModel { Health = 140, DefenseLayer = 100, Armor = ArmorType.Medium })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_SoulFoundry,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityMovementModel { Speed = 435, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                    {
                        LightDamage = 32, MediumDamage = 24, Damage = 16, Range = 300, AttacksPerSecond = 0.5f,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_SiroccoScript })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_RadiantWard })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_RadiantWard })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_SiroccoScript })
            },
            {
                DataType.UNIT_Absolver,
                new EntityModel(DataType.UNIT_Absolver, EntityType.Army)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Absolver", Descriptive = DescriptiveType.Zone_Control,
                        Description =
                            "Zone Control (Ground Unit) - Deploys to gain increased rate of fire to hold a position. Can only attack ground.",
                        Notes = "Deploy time is 2 seconds. Mobilize time is 1.5 seconds."
                    })
                    .AddPart(new EntityTierModel { Tier = 2 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 150, Ether = 75, BuildTime = 35 })
                    .AddPart(new EntitySupplyModel { Takes = 5 })
                    .AddPart(new EntityVitalityModel { Health = 175, DefenseLayer = 150, Armor = ArmorType.Medium })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_SoulFoundry,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityMovementModel { Speed = 315, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 11, MediumDamage = 13, HeavyDamage = 15, StructureDamageBonus = 8, Range = 800,
                        AttacksPerSecond = 1.25f, Targets = TargetType.Ground
                    })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 4, MediumDamage = 6, HeavyDamage = 8, Range = 800, AttacksPerSecond = 2.857f,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_DeployAbsolver })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_MobilizeQrath })
                    .AddPart(new EntityPassiveModel { Name = "?", Description = "Hits multiple units when deployed." })
            },
            {
                DataType.UNIT_Castigator,
                new EntityModel(DataType.UNIT_Castigator, EntityType.Army)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Castigator", Descriptive = DescriptiveType.Air_Denial,
                        Description =
                            "Air Denial (Ground Unit) - A tough walker with a powerful, long-range anti-air attack."
                    })
                    .AddPart(new EntityTierModel { Tier = 2 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 190, Ether = 75, BuildTime = 35 })
                    .AddPart(new EntitySupplyModel { Takes = 5 })
                    .AddPart(new EntityVitalityModel { Health = 200, DefenseLayer = 100, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 340, Movement = MovementType.Ground })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_SoulFoundry,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 20, MediumDamage = 30, HeavyDamage = 40, Range = 800, AttacksPerSecond = 0.704f,
                        Targets = TargetType.Air, EthericDamageBonus = 10
                    })
                    .AddPart(new EntityWeaponModel
                        { Damage = 8, Range = 500, AttacksPerSecond = 1.429f, Targets = TargetType.Ground })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_RelicOfTheWrathfulGaze })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_Maledictions })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_RelicOfTheWrathfulGaze })
            },
            {
                DataType.UNIT_Hallower,
                new EntityModel(DataType.UNIT_Hallower, EntityType.Army)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Hallower", Descriptive = DescriptiveType.Dislodger,
                        Description =
                            "Dislodger (Ground Unit) - Long range artillery that can break entrenched enemy positions. Can only attack ground."
                    })
                    .AddPart(new EntityTierModel { Tier = 2.5f })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityVanguardReplacedModel
                        { ImmortalId = DataType.IMMORTAL_Ajari, ReplacedById = DataType.VANGUARD_ArkMother_Ajari })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 150, Ether = 75, BuildTime = 35 })
                    .AddPart(new EntitySupplyModel { Takes = 5 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_SoulFoundry,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_HouseOfFadingSaints,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel { Health = 100, DefenseLayer = 130, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 335, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 60, MediumDamage = 80, HeavyDamage = 100, Range = 1300, AttacksPerSecond = 0.143f,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_HallowedRuin })
            },
            {
                DataType.UNIT_Sentinel,
                new EntityModel(DataType.UNIT_Sentinel, EntityType.Army)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Sentinel", Descriptive = DescriptiveType.Air_Superiority,
                        Description = "Flying Anti-Air Angel"
                    })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 150, Ether = 75, BuildTime = 35 })
                    .AddPart(new EntitySupplyModel { Takes = 5 })
                    .AddPart(new EntityVitalityModel { Health = 150, DefenseLayer = 100, Armor = ArmorType.Medium })
                    .AddPart(new EntityMovementModel { Speed = 525, Movement = MovementType.Air })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Angelarium,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 28, Range = 500, AttacksPerSecond = 0.714f, Targets = TargetType.Air
                    })
            },
            {
                DataType.UNIT_Throne,
                new EntityModel(DataType.UNIT_Throne, EntityType.Army)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Throne", Descriptive = DescriptiveType.Generalist,
                        Description =
                            "Crown Jewel (Flying Unit) - Massive flying bruiser that automatically attacks nearby units with its swords, even while moving."
                    })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "A", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 250, Ether = 100, BuildTime = 50 })
                    .AddPart(new EntitySupplyModel { Takes = 9 })
                    .AddPart(new EntityVitalityModel { Health = 350, DefenseLayer = 200, Armor = ArmorType.Heavy })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Angelarium,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_BearerOfTheCrown,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityMovementModel { Speed = 262, Movement = MovementType.Air })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 60, Range = 600, AttacksPerSecond = 0.5f, SecondsBetweenAttacks = 2,
                        Targets = TargetType.All
                    })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_BladesOfTheGodhead })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_BladesOfTheGodhead })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_GodstoneBulwark })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_ThroneMovingShot })
            },
            {
                DataType.UNIT_Warden,
                new EntityModel(DataType.UNIT_Warden, EntityType.Army)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Warden", Descriptive = DescriptiveType.Harrier,
                        Description =
                            @"Gunship (Flying Unit) - Air-to-ground specialist. Flight allos it to ignore terrain."
                    })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityVanguardReplacedModel
                        { ImmortalId = DataType.IMMORTAL_Orzum, ReplacedById = DataType.VANGUARD_Sceptre_Orzum })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 175, Ether = 100, BuildTime = 40 })
                    .AddPart(new EntitySupplyModel { Takes = 6 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Angelarium,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel { Health = 300, DefenseLayer = 80, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 420, Movement = MovementType.Air })
                    .AddPart(new EntityWeaponModel
                        { Damage = 32, Range = 600, AttacksPerSecond = 0.556f, Targets = TargetType.Ground })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_WingsOfTheKenLatir })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_WingsOfTheKenLatir })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_ExecutionRites })
            },
            {
                DataType.UNIT_SharU,
                new EntityModel(DataType.UNIT_SharU, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Shar'U", Descriptive = DescriptiveType.Elite_Caster })
                    .AddPart(new EntityTierModel { Tier = 3.5f })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 110, Ether = 175, BuildTime = 55 })
                    .AddPart(new EntitySupplyModel { Takes = 6 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Angelarium,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_EyeOfAros,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 175, DefenseLayer = 125, IsEtheric = true, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 315, Movement = MovementType.Air })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 10, Range = 650, AttacksPerSecond = 0.714f, SecondsBetweenAttacks = 1.4f,
                        Targets = TargetType.All
                    })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_Awestrike })
            },
            // Units
            // Aru
            {
                DataType.WORKER_Symbiote,
                new EntityModel(DataType.WORKER_Symbiote, EntityType.Worker)
                    .AddPart(new EntityInfoModel { Name = "Symbiote", Descriptive = DescriptiveType.Worker })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 50, BuildTime = 20 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_GroveHeart,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel { Health = 50, DefenseLayer = 10, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 400, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 8, Range = 40, AttacksPerSecond = 1.25f, Targets = TargetType.Ground })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_HarvestAlloy })
            },
            {
                DataType.UNIT_MaskedHunter,
                new EntityModel(DataType.UNIT_MaskedHunter, EntityType.Army)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Masked Hunter", Descriptive = DescriptiveType.Generalist,
                        Description =
                            "Ranged Generalist (Ground Unit) - Can attack ground and air, and sacrifice health for a temporary boost to its range and speed."
                    })
                    .AddPart(new EntityTierModel { Tier = 1 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "Z" })
                    .AddPart(new EntityVanguardReplacedModel
                        { ImmortalId = DataType.IMMORTAL_Xol, ReplacedById = DataType.VANGUARD_BoneStalker_Xol })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 50, BuildTime = 20 })
                    .AddPart(new EntitySupplyModel { Takes = 2 })
                    .AddPart(new EntityVitalityModel
                        { Health = 85, DefenseLayer = 25, Defense = DefenseType.Overgrowth, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 350, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 7, Range = 400, AttacksPerSecond = 1.4f, Targets = TargetType.All, HeavyDamage = 6 })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_Offering })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_BloodMothersFevor })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.ABILITY_Offering })
            },
            {
                DataType.UNIT_Xacal,
                new EntityModel(DataType.UNIT_Xacal, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Xacal", Descriptive = DescriptiveType.Frontliner })
                    .AddPart(new EntityTierModel { Tier = 1.5f })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 75, Ether = 30, BuildTime = 25 })
                    .AddPart(new EntitySupplyModel { Takes = 3 })
                    .AddPart(new EntityVitalityModel { Health = 160, DefenseLayer = 70, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 378, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 15, MediumDamage = 20, HeavyDamage = 25, Range = 400, AttacksPerSecond = 0.56f,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_XacalDamage })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_XacalDamage })
            },
            {
                DataType.UNIT_Bloodbound,
                new EntityModel(DataType.UNIT_Bloodbound, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Bloodbound", Descriptive = DescriptiveType.Assassin })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityVanguardReplacedModel
                        { ImmortalId = DataType.IMMORTAL_Xol, ReplacedById = DataType.VANGUARD_WhiteWoodReaper_Xol })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_RedVale,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 80, Ether = 80, BuildTime = 30 })
                    .AddPart(new EntitySupplyModel { Takes = 4 })
                    .AddPart(new EntityVitalityModel
                        { Energy = 60, Health = 100, DefenseLayer = 40, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 434, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 30, MediumDamage = 40, LightDamage = 50, Range = 80, AttacksPerSecond = 0.714f,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_QuenchingScythes })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.ABILITY_CullingStrike })
            },
            {
                DataType.UNIT_RedSeer,
                new EntityModel(DataType.UNIT_RedSeer, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Red Seer", Descriptive = DescriptiveType.Elite_Caster })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityVanguardReplacedModel
                        { ImmortalId = DataType.IMMORTAL_Mala, ReplacedById = DataType.VANGUARD_DreadSister_Mala })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_RedVale,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 40, Ether = 140, BuildTime = 40 })
                    .AddPart(new EntitySupplyModel { Takes = 3 })
                    .AddPart(new EntityVitalityModel
                    {
                        Energy = 100, Health = 60, DefenseLayer = 75, Defense = DefenseType.Overgrowth,
                        IsEtheric = true, Armor = ArmorType.Light
                    })
                    .AddPart(new EntityMovementModel { Speed = 0, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 9, Range = 700, AttacksPerSecond = 0.798f, Targets = TargetType.Ground })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_BloodPlague })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_DrainingEmbrace })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_AwakenAcaaluk })
            },
            {
                DataType.UNIT_Underspine,
                new EntityModel(DataType.UNIT_Underspine, EntityType.Army)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Underspine", Descriptive = DescriptiveType.Force_Multiplier,
                        Notes = "Has +5 HP regen when burrowed."
                    })
                    .AddPart(new EntityTierModel { Tier = 2 })
                    .AddPart(new EntityVanguardReplacedModel
                        { ImmortalId = DataType.IMMORTAL_Mala, ReplacedById = DataType.VANGUARD_Incubator_Mala })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 70, Ether = 50, BuildTime = 25 })
                    .AddPart(new EntitySupplyModel { Takes = 3 })
                    .AddPart(new EntityVitalityModel { Health = 140, DefenseLayer = 40, Armor = ArmorType.Medium })
                    .AddPart(new EntityMovementModel { Speed = 350, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 9, Range = 700, SecondsBetweenAttacks = 1.2529f, Targets =
                            TargetType.All
                    })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 9, Range = 600, SecondsBetweenAttacks = 0.7143f, Targets =
                            TargetType.Ground
                    })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_DeployMobilizeUnderSpine })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_MobilizeAru })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_OssifyingSwarm })
            },
            {
                DataType.UNIT_Ichor,
                new EntityModel(DataType.UNIT_Ichor, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Ichor", Descriptive = DescriptiveType.Harrier })
                    .AddPart(new EntityTierModel { Tier = 2 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AmberWomb,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 95, Ether = 20, BuildTime = 30 })
                    .AddPart(new EntitySupplyModel { Takes = 4 })
                    .AddPart(new EntityVitalityModel { Health = 100, DefenseLayer = 40, Armor = ArmorType.Medium })
                    .AddPart(new EntityMovementModel { Speed = 382, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 13, LightDamage = 32, MediumDamage = 19, Range = 500, AttacksPerSecond = 0.7f,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_DenInstinct })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_PursuitLigaments })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_ExternalDigestion })
            },
            {
                DataType.UNIT_Resinant,
                new EntityModel(DataType.UNIT_Resinant, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Resinant", Descriptive = DescriptiveType.Zone_Control })
                    .AddPart(new EntityTierModel { Tier = 2.5f })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AmberWomb,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 150, Ether = 80, BuildTime = 40 })
                    .AddPart(new EntitySupplyModel { Takes = 5 })
                    .AddPart(new EntityVitalityModel { Health = 175, DefenseLayer = 60, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 350, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 25, MediumDamage = 40, HeavyDamage = 55, Range = 800, AttacksPerSecond = 0.7f,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 50, MediumDamage = 60, HeavyDamage = 70, Range = 1000, AttacksPerSecond = 0.467f,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_ResinantDeploy })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_MobilizeAru })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_EngorgedArteries })
            },
            {
                DataType.UNIT_Aarox,
                new EntityModel(DataType.UNIT_Aarox, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Aarox", Descriptive = DescriptiveType.Air_Superiority })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_BoneCanopy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 40, Ether = 40, BuildTime = 30 })
                    .AddPart(new EntitySupplyModel { Takes = 2 })
                    .AddPart(new EntityVitalityModel { Health = 35, DefenseLayer = 10, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 532, Movement = MovementType.Air })
                    .AddPart(new EntityWeaponModel
                    {
                        LightDamage = 75, MediumDamage = 100, HeavyDamage = 125, Range = 20, AttacksPerSecond = 1,
                        Targets =
                            TargetType.Air
                    })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_AaroxBurn })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_DiveBomb })
            },
            {
                DataType.UNIT_Thrum,
                new EntityModel(DataType.UNIT_Thrum, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Thrum", Descriptive = DescriptiveType.Harrier })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_BoneCanopy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 80, Ether = 50, BuildTime = 30 })
                    .AddPart(new EntitySupplyModel { Takes = 3 })
                    .AddPart(new EntityVitalityModel { Health = 120, DefenseLayer = 40, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 525, Movement = MovementType.Air })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 11, HeavyDamage = 9, Range = 350, AttacksPerSecond = 0.8f, Targets = TargetType.All
                    })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_BloodFrenzy })
            },
            {
                DataType.UNIT_WraithBow,
                new EntityModel(DataType.UNIT_WraithBow, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Wraith Bow", Descriptive = DescriptiveType.Air_Denial })
                    .AddPart(new EntityTierModel { Tier = 2 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AmberWomb,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 80, Ether = 30, BuildTime = 30 })
                    .AddPart(new EntitySupplyModel { Takes = 3 })
                    .AddPart(new EntityVitalityModel { Health = 120, DefenseLayer = 45, Armor = ArmorType.Medium })
                    .AddPart(new EntityMovementModel { Speed = 350, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 15, Range = 700, AttacksPerSecond = 0.909f, Targets = TargetType.Air })
                    .AddPart(new EntityWeaponModel
                        { Damage = 9, Range = 500, AttacksPerSecond = 0.714f, Targets = TargetType.Ground })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_GuidingAmber })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_WraithBowRange })
            },
            {
                DataType.UNIT_Behemoth,
                new EntityModel(DataType.UNIT_Behemoth, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Behemoth", Descriptive = DescriptiveType.Skirmisher })
                    .AddPart(new EntityTierModel { Tier = 3.5f })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_BoneCanopy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "A", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 190, Ether = 150, BuildTime = 50 })
                    .AddPart(new EntitySupplyModel { Takes = 8 })
                    .AddPart(new EntityVitalityModel { Health = 350, DefenseLayer = 100, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 210, Movement = MovementType.Air })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 0, Range = 600, AttacksPerSecond = 0.588f, SecondsBetweenAttacks = 1.7f,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_BehemothCapacity })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_BehemothCapacity })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_QuitlStorage2 })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_FireQuitl })
            },
            {
                DataType.SUMMON_Quitl,
                new EntityModel(DataType.SUMMON_Quitl, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Quitl", Descriptive = DescriptiveType.Summon })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVitalityModel { Health = 65, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 168, Movement = MovementType.Ground })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Temporary })
            },
            // Upgrades
            // Q'Rath
            {
                DataType.UPGRADE_GreavesOfAhqar,
                new EntityModel(DataType.UPGRADE_GreavesOfAhqar, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Greaves Of Ahqar", Descriptive = DescriptiveType.Upgrade,
                        Description = "Increases the Sipari speed by 75."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 100, BuildTime = 100 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Reliquary,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVanguardReplacedModel
                        { ImmortalId = DataType.IMMORTAL_Orzum, ReplacedById = DataType.UPGRADE_FaithCastBlades })
            },
            {
                DataType.UPGRADE_RadiantWard,
                new EntityModel(DataType.UPGRADE_RadiantWard, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Research Radiant Ward", Descriptive = DescriptiveType.Upgrade,
                        Description = "Unlocks the dervish's Radiant Ward ability"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "V", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 80, Ether = 80, BuildTime = 34 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_HouseOfFadingSaints,
                        Requirement = RequirementType.Production_Building
                    })
            },

            {
                DataType.UPGRADE_FortifiedIcons,
                new EntityModel(DataType.UPGRADE_FortifiedIcons, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Fortified Icons", Descriptive = DescriptiveType.Upgrade,
                        Description = "Sipari gain +20 shields, and Hallowed Ground grants an additional +20 shields."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "TAB", HoldSpace = true })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 100, BuildTime = 43 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_EyeOfAros,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVanguardReplacedModel
                        { ImmortalId = DataType.IMMORTAL_Orzum, ReplacedById = DataType.UPGRADE_IconOfKhastEem })
            },

            {
                DataType.UPGRADE_FaithCastBlades,
                new EntityModel(DataType.UPGRADE_FaithCastBlades, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Faith-Cast Blades", Descriptive = DescriptiveType.Upgrade,
                        Description = "Increases the range of the Zentari's ranged weapon."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 50, Ether = 100, BuildTime = 60 })
                    .AddPart(new EntityRequirementModel
                        { Id = DataType.BUILDING_Reliquary, Requirement = RequirementType.Research_Building })
                    .AddPart(new EntityVanguardAddedModel
                        { ReplaceId = DataType.UPGRADE_GreavesOfAhqar, ImmortalId = DataType.IMMORTAL_Orzum })
            },
            {
                DataType.UPGRADE_RelicOfTheWrathfulGaze,
                new EntityModel(DataType.UPGRADE_RelicOfTheWrathfulGaze, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Relic Of The Wrathful Gaze", Descriptive = DescriptiveType.Upgrade,
                        Description = "Increases the Castigator's anti-air weapon range."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "TAB", HoldSpace = true })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 75, Ether = 75, BuildTime = 29 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_HouseOfFadingSaints,
                        Requirement = RequirementType.Production_Building
                    })
            },
            {
                DataType.UPGRADE_WindStep,
                new EntityModel(DataType.UPGRADE_WindStep, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                        { Name = "Windstep", Descriptive = DescriptiveType.Upgrade, Description = "Unlocks windstep." })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 50, Ether = 75, BuildTime = 55 })
                    .AddPart(new EntityRequirementModel
                        { Id = DataType.BUILDING_Reliquary, Requirement = RequirementType.Production_Building })
            },
            {
                DataType.UPGRADE_ZephyrRange,
                new EntityModel(DataType.UPGRADE_ZephyrRange, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Zephyr Range", Descriptive = DescriptiveType.Upgrade,
                        Description = "Increases Zephyr's range by 100."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 150, Ether = 100, BuildTime = 43 })
                    .AddPart(new EntityRequirementModel
                        { Id = DataType.UPGRADE_ZephyrRange, Requirement = RequirementType.Production_Building })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_WindStep })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_ZephyrRange })
            },
            {
                DataType.UPGRADE_SiroccoScript,
                new EntityModel(DataType.UPGRADE_SiroccoScript, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Sirocco Script", Descriptive = DescriptiveType.Upgrade,
                        Description = "Grant's the Dervish Sirocco Script"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 75, Ether = 100, BuildTime = 60 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_HouseOfFadingSaints,
                        Requirement = RequirementType.Production_Building
                    })
            },
            {
                DataType.UPGRADE_IconOfKhastEem,
                new EntityModel(DataType.UPGRADE_IconOfKhastEem, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Icon of Khast'Eem", Descriptive = DescriptiveType.Upgrade,
                        Description = "Grants the Zentari shields and flat armor reduction."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HoldSpace = true, HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 100, BuildTime = 43 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_EyeOfAros,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVanguardAddedModel
                        { ReplaceId = DataType.UPGRADE_FortifiedIcons, ImmortalId = DataType.IMMORTAL_Orzum })
            },
            {
                DataType.UPGRADE_BladesOfTheGodhead,
                new EntityModel(DataType.UPGRADE_BladesOfTheGodhead, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Blades of the Godhead", Descriptive = DescriptiveType.Upgrade,
                        Description = "Unlocks Blades of the Godhead"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "A", HoldSpace = true, HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 75, BuildTime = 45 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_BearerOfTheCrown, Requirement = RequirementType.Production_Building
                    })
            },
            {
                DataType.UPGRADE_WingsOfTheKenLatir,
                new EntityModel(DataType.UPGRADE_WingsOfTheKenLatir, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Wings of the Ken'Latir", Descriptive = DescriptiveType.Upgrade,
                        Description = "Increases the Warden's speed and shields significantly."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HoldSpace = true, HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 150, Ether = 100, BuildTime = 30 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_BearerOfTheCrown, Requirement = RequirementType.Production_Building
                    })
            },
            // Upgrades
            // Aru
            {
                DataType.UPGRADE_Offering,
                new EntityModel(DataType.UPGRADE_Offering, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Offering",
                        Descriptive = DescriptiveType.Upgrade,
                        Description = "Unlocks Offering"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVanguardReplacedModel
                        { ImmortalId = DataType.IMMORTAL_Xol, ReplacedById = DataType.UPGRADE_Stalk })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 80, BuildTime = 60 })
            },
            {
                DataType.UPGRADE_BloodMothersFevor,
                new EntityModel(DataType.UPGRADE_BloodMothersFevor, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                        { Name = "Blood Mother's Fevor", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "V", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVanguardReplacedModel
                        { ImmortalId = DataType.IMMORTAL_Xol, ReplacedById = DataType.UPGRADE_Ambush })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AmberWomb,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 150, BuildTime = 80 })
            },
            {
                DataType.UPGRADE_DenInstinct,
                new EntityModel(DataType.UPGRADE_DenInstinct, EntityType.Tech)
                    .AddPart(new EntityInfoModel { Name = "Den Instinct", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 120, BuildTime = 45 })
            },
            {
                DataType.UPGRADE_PursuitLigaments,
                new EntityModel(DataType.UPGRADE_PursuitLigaments, EntityType.Tech)
                    .AddPart(new EntityInfoModel { Name = "Pursuit Ligaments", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 75, Ether = 100, BuildTime = 45 })
            },
            {
                DataType.UPGRADE_ResinantDeploy,
                new EntityModel(DataType.UPGRADE_ResinantDeploy, EntityType.Tech)
                    .AddPart(new EntityInfoModel { Name = "Resinant Deploy", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AmberWomb,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 50, Ether = 100, BuildTime = 43 })
            },
            {
                DataType.UPGRADE_XacalDamage,
                new EntityModel(DataType.UPGRADE_XacalDamage, EntityType.Tech)
                    .AddPart(new EntityInfoModel { Name = "Xacal Damage", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 75, BuildTime = 60 })
            },
            {
                DataType.UPGRADE_BehemothCapacity,
                new EntityModel(DataType.UPGRADE_BehemothCapacity, EntityType.Tech)
                    .AddPart(new EntityInfoModel { Name = "Behemoth Capacity", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "A", HotkeyGroup = "TAB", HoldSpace = true })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_DeepNest,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 150, Ether = 150, BuildTime = 46 })
            },
            {
                DataType.UPGRADE_WraithBowRange,
                new EntityModel(DataType.UPGRADE_WraithBowRange, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Wraith Bow Range",
                        Description = "Increase's the range of the Wraith Bow anti-air attack.",
                        Descriptive = DescriptiveType.Upgrade
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "TAB", HoldSpace = true })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 50, Ether = 75, BuildTime = 29 })
            },

            {
                DataType.UPGRADE_Stalk,
                new EntityModel(DataType.UPGRADE_Stalk, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Research Stalk",
                        Description = "Unlocks the Bone Stalker's Stabilize",
                        Descriptive = DescriptiveType.Upgrade
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "TAB", HoldSpace = false })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 80, BuildTime = 60 })
                    .AddPart(new EntityVanguardAddedModel
                        { ReplaceId = DataType.UPGRADE_Offering, ImmortalId = DataType.IMMORTAL_Xol })
            },

            {
                DataType.UPGRADE_Ambush,
                new EntityModel(DataType.UPGRADE_Ambush, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Research Ambush",
                        Description = "When Hidden, the Bone Stalker's next attack deals double damage",
                        Descriptive = DescriptiveType.Upgrade
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "V", HotkeyGroup = "TAB", HoldSpace = false })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 125, BuildTime = 80 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_RedVale,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityVanguardAddedModel
                        { ReplaceId = DataType.UPGRADE_BloodMothersFevor, ImmortalId = DataType.IMMORTAL_Xol })
            },


            {
                DataType.UPGRADE_BloodPlague,
                new EntityModel(DataType.UPGRADE_BloodPlague, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Blood Plague", Descriptive = DescriptiveType.Upgrade,
                        Description = "Unlocks Blood Plague"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "TAB", HoldSpace = true })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_RedVale,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 75, Ether = 120, BuildTime = 80 })
                    .AddPart(new EntityVanguardReplacedModel
                        { ImmortalId = DataType.IMMORTAL_Xol, ReplacedById = DataType.ABILITY_BirthingStorm })
            },
            {
                DataType.UPGRADE_BirthingStorm,
                new EntityModel(DataType.UPGRADE_BirthingStorm, EntityType.Tech)
                    .AddPart(new EntityInfoModel { Name = "Birthing Storm", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "TAB", HoldSpace = true })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_RedVale,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 75, Ether = 120, BuildTime = 80 })
                    .AddPart(new EntityVanguardAddedModel
                        { ImmortalId = DataType.IMMORTAL_Mala, ReplaceId = DataType.ABILITY_BloodPlague })
            },

            // Passives
            // Neutral
            {
                DataType.PASSIVE_BastionPassives,
                new EntityModel(DataType.PASSIVE_BastionPassives, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "(Scouts and Pyre)", Descriptive = DescriptiveType.Passive,
                        Description =
                            @"Bastion generates one scout in 2 minutes, up to a max of 2 scouts. And generates pyre over time."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Any })
            },
            {
                DataType.PASSIVE_Respite,
                new EntityModel(DataType.PASSIVE_Respite, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Respite", Descriptive = DescriptiveType.Passive,
                        Description =
                            @"Nearby units will slowly heal after not attacking or being attacked for 10 seconds."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Any })
            },

            {
                DataType.PASSIVE_HarvestAlloy,
                new EntityModel(DataType.PASSIVE_HarvestAlloy, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Harvest Alloy", Descriptive = DescriptiveType.Passive,
                        Description = "This unit can harvest alloy."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Any })
            },

            // Passives
            // Q'Rath Passives

            {
                DataType.PASSIVE_HallowedWarrior,
                new EntityModel(DataType.PASSIVE_HallowedWarrior, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Hallowed Warrior", Descriptive = DescriptiveType.Ability,
                        Description = @"Gains bonus shields when in Hallowed Ground",
                        Notes = "+20 Shields on Hallowed Ground."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },

            {
                DataType.PASSIVE_GreavesOfAhqar,
                new EntityModel(DataType.PASSIVE_GreavesOfAhqar, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Greaves Of Ahqar", Descriptive = DescriptiveType.Ability,
                        Description = @"+75 Sipari Speed"
                    })
                    .AddPart(new EntityRequirementModel
                        { Id = DataType.UPGRADE_GreavesOfAhqar, Requirement = RequirementType.Research_Upgrade })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },

            {
                DataType.PASSIVE_RelicOfTheWrathfulGaze,
                new EntityModel(DataType.PASSIVE_RelicOfTheWrathfulGaze, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Relic Of The Wrathful Gaze", Descriptive = DescriptiveType.Ability,
                        Description = @"Increases Castigator range against air."
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.UPGRADE_RelicOfTheWrathfulGaze, Requirement = RequirementType.Research_Upgrade
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },
            {
                DataType.PASSIVE_WingsOfTheKenLatir,
                new EntityModel(DataType.PASSIVE_WingsOfTheKenLatir, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Wings of the Ken'Latir", Descriptive = DescriptiveType.Passive,
                        Description = @"Increases the Warden's speed and shields significantly."
                    })
                    .AddPart(new EntityRequirementModel
                        { Id = DataType.UPGRADE_WingsOfTheKenLatir, Requirement = RequirementType.Research_Upgrade })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },

            {
                DataType.PASSIVE_ExecutionRites,
                new EntityModel(DataType.PASSIVE_ExecutionRites, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Execution Rites", Descriptive = DescriptiveType.Passive,
                        Description = @"Warden's attacks charge up to a hit that deals greatly increased damage."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },

            {
                DataType.PASSIVE_IconOfKhastEem,
                new EntityModel(DataType.PASSIVE_IconOfKhastEem, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Icon Of Khast'Eem", Descriptive = DescriptiveType.Passive,
                        Description = @"Grants the Zentari shields and flat armor reduction."
                    })
                    .AddPart(new EntityRequirementModel
                        { Id = DataType.UPGRADE_IconOfKhastEem, Requirement = RequirementType.Research_Upgrade })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },

            {
                DataType.PASSIVE_FaithCastBlades,
                new EntityModel(DataType.PASSIVE_FaithCastBlades, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Faith Cast Blades", Descriptive = DescriptiveType.Passive,
                        Description = @"Increases the range of the Zentari's ranged weapon."
                    })
                    .AddPart(new EntityRequirementModel
                        { Id = DataType.UPGRADE_FaithCastBlades, Requirement = RequirementType.Research_Upgrade })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },

            {
                DataType.PASSIVE_ThroneMovingShot,
                new EntityModel(DataType.PASSIVE_ThroneMovingShot, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Throne Moving Shot", Descriptive = DescriptiveType.Passive,
                        Description = @"Thrones can attack while moving."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },

            {
                DataType.PASSIVE_SiroccoScript,
                new EntityModel(DataType.PASSIVE_SiroccoScript, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Sirocco Script Rites", Descriptive = DescriptiveType.Passive,
                        Description = @"Increases the derish's movement speed"
                    })
                    .AddPart(new EntityRequirementModel { Id = DataType.UPGRADE_SiroccoScript })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },

            {
                DataType.PASSIVE_HallowingRites,
                new EntityModel(DataType.PASSIVE_HallowingRites, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Hallowing Rites", Descriptive = DescriptiveType.Passive,
                        Description = @"Ark Mother's creates Hallowed Ground on stabilize."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },

            {
                DataType.PASSIVE_HallowedRuin,
                new EntityModel(DataType.PASSIVE_HallowedRuin, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Hallowed Ruin", Descriptive = DescriptiveType.Passive,
                        Description = @"Hallowers have splash on attacks that leave an area of Hallowed Ground."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },

            {
                DataType.PASSIVE_RegentsWrath,
                new EntityModel(DataType.PASSIVE_RegentsWrath, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Regent's Wrath", Descriptive = DescriptiveType.Passive,
                        Description =
                            @"Scepters gain energy when stabilized. They lose energy when moving. Energy is spent to have splash on attack."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },

            {
                DataType.PASSIVE_PsalmOfFire,
                new EntityModel(DataType.PASSIVE_PsalmOfFire, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Psalm Of Fire", Descriptive = DescriptiveType.Applies_Debuff,
                        Description = @"Fire Singers deal damage over time against attacked targets."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },

            {
                DataType.PASSIVE_Zeal,
                new EntityModel(DataType.PASSIVE_Zeal, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Zeal", Descriptive = DescriptiveType.Passive,
                        Description = @"30% increased attack speed to allied near Pillar of the Heavens"
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },

            {
                DataType.PASSIVE_HallowedGround,
                new EntityModel(DataType.PASSIVE_HallowedGround, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Hallowed Ground", Descriptive = DescriptiveType.Passive,
                        Description = @"This building generates Hallowed Ground."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },

            {
                DataType.PASSIVE_CastFromLife,
                new EntityModel(DataType.PASSIVE_HallowedGround, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Cast From Life", Descriptive = DescriptiveType.Passive,
                        Description = @"Can spend life instead of energy, when needed.",
                        Notes = "Can't spend more life then unit has. Unit cannot kill itself with Cast From Life."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },

            {
                DataType.PASSIVE_WraithBowRange,
                new EntityModel(DataType.PASSIVE_WraithBowRange, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Wraith Bow Range", Descriptive = DescriptiveType.Ability,
                        Description = @"Increases Wraith Bow range against air."
                    })
                    .AddPart(new EntityRequirementModel
                        { Id = DataType.UPGRADE_WraithBowRange, Requirement = RequirementType.Research_Upgrade })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },

            {
                DataType.PASSIVE_Rootway,
                new EntityModel(DataType.PASSIVE_Rootway, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Rootway", Descriptive = DescriptiveType.Passive,
                        Description = @"Building generates Rootway."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },

            {
                DataType.PASSIVE_BehemothCapacity,
                new EntityModel(DataType.PASSIVE_BehemothCapacity, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Quitl Storage", Descriptive = DescriptiveType.Passive,
                        Description = @"Unit stores quitl for attacks."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },

            {
                DataType.PASSIVE_QuitlStorage2,
                new EntityModel(DataType.PASSIVE_QuitlStorage2, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Quitl Storage", Descriptive = DescriptiveType.Passive,
                        Description = @"Unit stores more quitl for attacks."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel
                        { Id = DataType.UPGRADE_BehemothCapacity, Requirement = RequirementType.Research_Upgrade })
            },

            {
                DataType.PASSIVE_ExternalDigestion,
                new EntityModel(DataType.PASSIVE_ExternalDigestion, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "External Digestion", Descriptive = DescriptiveType.Passive,
                        Description = @"Ichor attacks splash in a cone."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },

            {
                DataType.PASSIVE_Temporary,
                new EntityModel(DataType.PASSIVE_Temporary, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Temporary", Descriptive = DescriptiveType.Passive,
                        Description = @"This unit has a limited duration before it dies."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },


            {
                DataType.PASSIVE_Stalk,
                new EntityModel(DataType.PASSIVE_Stalk, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Stalk", Descriptive = DescriptiveType.Passive,
                        Description =
                            @"After remaining stationary for several seconds, gain Hidden 3 and a movement speed boost.",
                        Notes = "Lose hidden on attacking"
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel { Id = DataType.UPGRADE_Stalk })
            },

            {
                DataType.PASSIVE_Ambush,
                new EntityModel(DataType.PASSIVE_Stalk, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Ambush", Descriptive = DescriptiveType.Passive,
                        Description = @"This unit deals double damage when attacking from hidden."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel { Id = DataType.UPGRADE_Ambush })
            },

            {
                DataType.PASSIVE_HiddenX,
                new EntityModel(DataType.PASSIVE_HiddenX, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Hidden X", Descriptive = DescriptiveType.Passive,
                        Description = @"This unit cannot be seen unless enemies units are within X."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },

            {
                DataType.PASSIVE_FallenHarvest,
                new EntityModel(DataType.PASSIVE_FallenHarvest, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Fallen Harvest", Descriptive = DescriptiveType.Passive,
                        Description = @"Incubator gets energy when nearby non-quitl units die."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },

            {
                DataType.PASSIVE_RestoreLifeblood,
                new EntityModel(DataType.PASSIVE_RestoreLifeblood, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Restore Lifeblood", Descriptive = DescriptiveType.Passive,
                        Description = @"Restores health to a single target."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },


            {
                DataType.PASSIVE_Transfusion,
                new EntityModel(DataType.PASSIVE_Transfusion, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Transfusion", Descriptive = DescriptiveType.Passive,
                        Description = @"Restores energy to a single target."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },


            {
                DataType.PASSIVE_FortifiedIcons,
                new EntityModel(DataType.PASSIVE_FortifiedIcons, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Fortified Icons", Descriptive = DescriptiveType.Ability,
                        Description = @"Increases Sipari shields and increases the bonus while in Hallowed Ground",
                        Notes = "+20 Shields, and +20 Shields on Hallowed Ground."
                    })
                    .AddPart(new EntityRequirementModel
                        { Id = DataType.UPGRADE_FortifiedIcons, Requirement = RequirementType.Research_Upgrade })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },
            {
                DataType.PASSIVE_MendingCommand,
                new EntityModel(DataType.PASSIVE_MendingCommand, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Mending Command", Descriptive = DescriptiveType.Ability,
                        Description = @"Autocast ability that heals 48 life and 24 shields over 2 seconds."
                    })
                    .AddPart(new EntityProductionModel { Pyre = 10, Cooldown = 3 })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },
            {
                DataType.PASSIVE_GodstoneBulwark,
                new EntityModel(DataType.PASSIVE_GodstoneBulwark, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Godstone Bulkwark", Descriptive = DescriptiveType.Ability,
                        Description = @"Grants +1 damage reduction."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },

            {
                DataType.PASSIVE_Invervention,
                new EntityModel(DataType.PASSIVE_Invervention, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Intervention", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"The Saoshin releases healing energy. Allied units nearby heal over several seconds. This automatically activates when the Saoshin drops below 70 HP."
                    })
                    .AddPart(new EntityProductionModel { Pyre = 70, Cooldown = 5 })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },
            // Passives
            // Aru Passives
            {
                DataType.PASSIVE_BloodFrenzy,
                new EntityModel(DataType.PASSIVE_BloodFrenzy, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Blood Frenzy", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Thrums gain more attack speed for a short duration when a near by allied Thrum kills an enemy unit"
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },

            {
                DataType.PASSIVE_XacalDamage,
                new EntityModel(DataType.PASSIVE_XacalDamage, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Xacal Damage", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Xacal builds up charges for double damage overtime. These charges can be spent on attacking."
                    })
                    .AddPart(new EntityRequirementModel
                        { Id = DataType.UPGRADE_XacalDamage, Requirement = RequirementType.Research_Upgrade })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },
            {
                DataType.PASSIVE_OssifyingSwarm,
                new EntityModel(DataType.PASSIVE_OssifyingSwarm, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Ossifying Swarm", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Reduces the movement speed and attack speed of enemies near your attack target.",
                        Notes = "10% movement and attack speed. Stacks up to 5 times."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },

            {
                DataType.PASSIVE_AaroxBurn,
                new EntityModel(DataType.PASSIVE_AaroxBurn, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Aarox Burn", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"The aarox dies when attacking. Any units in its area of effect suffer damage over time.",
                        Notes = "Deals 75 damage over 3 seconds."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },

            {
                DataType.PASSIVE_QuenchingScythes,
                new EntityModel(DataType.PASSIVE_QuenchingScythes, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Quenching Scythes", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Recovers 5 life when dealing damage, or 10 mana if life is full."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },

            {
                DataType.PASSIVE_EngorgedArteries,
                new EntityModel(DataType.PASSIVE_EngorgedArteries, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Engorged Arteries", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Grants +2 range when deployed on rootway."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },

            {
                DataType.PASSIVE_ProjectileGestation,
                new EntityModel(DataType.PASSIVE_ProjectileGestation, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Projectile Gestation", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Fires a quitl at a target enemy unit."
                    })
                    .AddPart(new EntityProductionModel { Energy = 35, Cooldown = 2.5f })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },

            {
                DataType.PASSIVE_GuidingAmber,
                new EntityModel(DataType.PASSIVE_GuidingAmber, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Guiding Amber", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Units hit by this attack takes +1 damage for a few seconds, to a maximum of +4."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },

            {
                DataType.PASSIVE_FireQuitl,
                new EntityModel(DataType.PASSIVE_FireQuitl, EntityType.Passive)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Spawn Quitl", Descriptive = DescriptiveType.Ability,
                        Description = @"Unit spawns Quitl on attack."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },

            // Abilities
            // Q'Rath
            {
                DataType.ABILITY_RadiantWard,
                new EntityModel(DataType.ABILITY_RadiantWard, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Radiant Ward", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Spawns a mine that reveals enemy units, slows them, and makes them take increased damage for a duration."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { DefensiveLayer = 30, Cooldown = 40 })
                    .AddPart(new EntityRequirementModel { Id = DataType.UPGRADE_RadiantWard })
                    .AddPart(new EntityVitalityModel
                        { Health = 30, DefenseLayer = 30, Lasts = 30, Armor = ArmorType.Light })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_HouseOfFadingSaints,
                        Requirement = RequirementType.Production_Building
                    })
            },

            {
                DataType.ABILITY_Maledictions,
                new EntityModel(DataType.ABILITY_Maledictions, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Maledictions", Descriptive = DescriptiveType.Ability,
                        Description = @"Stun ground unit? With Maledictions spell.",
                        Notes = "Not implemented"
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },

            {
                DataType.ABILITY_BladesOfTheGodhead,
                new EntityModel(DataType.ABILITY_BladesOfTheGodhead, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Blades of the Godhead", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"The Throne loses some of its shields and fires all four of its swords at the target location to <b style=""color:orange"">deal damage</b> in a small area of effect. This only affects ground units."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Cooldown = 40 })
            },
            {
                DataType.ABILITY_Windstep,
                new EntityModel(DataType.ABILITY_Windstep, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Windstep", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"The Zephyr <b style=""color: skyblue"">teleports</b> toward target location, draining shields. Windstepping into <b>Halled Ground</b> restores shields instead."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Cooldown = 20 })
            },
            {
                DataType.ABILITY_Leap,
                new EntityModel(DataType.ABILITY_Leap, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Leap", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"The Saoshin leaps to the target location. If she has enough mana, she activates Intervention upon landing."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "V", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Cooldown = 5, Energy = 70 })
            },
            {
                DataType.ABILITY_OrdainedPassage,
                new EntityModel(DataType.ABILITY_OrdainedPassage, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Ordained Passage", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Creates a large area that grants <b style=""color:lime"">significant damage reduction</b> to friendly ground troops within. Reduces the Ark Mother's shields to 0 when used."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "D", HoldSpace = true })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Cooldown = 5, Energy = 75 })
            },
            {
                DataType.ABILITY_DeployAbsolver,
                new EntityModel(DataType.ABILITY_DeployAbsolver, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Deploy Absolver", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Deploying the Absolver drastically <b style=""color: orange"">increases its attack speed</b>."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "V", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },
            {
                DataType.ABILITY_DeployMagi,
                new EntityModel(DataType.ABILITY_DeployMagi, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Deploy Magi", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Deploys the Magic to project <b style=""color:white"">Hallowed Ground</b> around it."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },
            {
                DataType.ABILITY_Awestrike,
                new EntityModel(DataType.ABILITY_Awestrike, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Awestrike", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"After a short delay, enemy ground units at center of the area <b style=""color:orange"">suffer a huge burst of damage</b>. Targets outside the center <b style=""color:orange"">take reduced damage</b>. Then the area is left ablaze damaging units over time."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Cooldown = 8, Energy = 60 })
            },
            {
                DataType.ABILITY_MobilizeQrath,
                new EntityModel(DataType.ABILITY_MobilizeQrath, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Mobilize Q'Rath", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Mobilize all deployed Q'Rath units."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },
            // Abilities
            // Aru
            {
                DataType.ABILITY_MobilizeAru,
                new EntityModel(DataType.ABILITY_MobilizeAru, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Mobilize Aru", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Mobilize all deployed Aru units."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },
            {
                DataType.ABILITY_Offering,
                new EntityModel(DataType.ABILITY_Offering, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Offering", Descriptive = DescriptiveType.Ability,
                        Description =
                            "Sacrifices 10 life to give Masked Hunters +3 damage for 3 shots. And increased speed and attack speed."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel { Id = DataType.UPGRADE_Offering })
            },
            {
                DataType.ABILITY_DiveBomb,
                new EntityModel(DataType.ABILITY_DiveBomb, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Dive Bomb", Descriptive = DescriptiveType.Ability,
                        Description =
                            "The aarox dives down into the ground, dealing damage in a smaller area. Non-hovering units in the area take additional damage over time."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },
            {
                DataType.ABILITY_CullingStrike,
                new EntityModel(DataType.ABILITY_CullingStrike, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Culling Strike", Descriptive = DescriptiveType.Ability,
                        Description =
                            "Teleports to target location, and deals massive damage to the nearest ground unit."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Energy = 40, Cooldown = 3 })
            },
            {
                DataType.ABILITY_LethalBond,
                new EntityModel(DataType.ABILITY_LethalBond, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Lethal Bond", Descriptive = DescriptiveType.Ability,
                        Description =
                            "After a short delay, enemy units in the target area receive a debuff which causes them to take double damage from all attacks for a duration. Also gives the White Wood Reaper invisibility if it affects at least 1 enemy"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "D" })
                    .AddPart(new EntityVanguardAddedModel
                        { ImmortalId = DataType.IMMORTAL_Xol, ReplaceId = DataType.ABILITY_CullingStrike })
                    .AddPart(new EntityProductionModel { Energy = 40 })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },
            {
                DataType.ABILITY_DrainingEmbrace,
                new EntityModel(DataType.ABILITY_DrainingEmbrace, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Draining Embrace", Descriptive = DescriptiveType.Ability,
                        Description = "Units in the target area are rooted and lose mana."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "D" })
                    .AddPart(new EntityProductionModel { Energy = 25, Cooldown = 5 })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },
            {
                DataType.ABILITY_BloodPlague,
                new EntityModel(DataType.ABILITY_BloodPlague, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Blood Plague", Descriptive = DescriptiveType.Ability,
                        Description =
                            "Units that enter the target area suffer heavy damage over time. This damaging effect persists for a few seconds after leaving the plague area."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "D" })
                    .AddPart(new EntityProductionModel { Energy = 75, Cooldown = 2 })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },
            {
                DataType.ABILITY_DeployMobilizeResinant,
                new EntityModel(DataType.ABILITY_DeployMobilizeResinant, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Deploy Resinant", Descriptive = DescriptiveType.Ability,
                        Description = "Deploying the Resinant enables it to deal area of effect damage at long range."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "V", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },
            {
                DataType.ABILITY_DeployMobilizeUnderSpine,
                new EntityModel(DataType.ABILITY_DeployMobilizeUnderSpine, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Deploy Underspine", Descriptive = DescriptiveType.Ability,
                        Description =
                            "Burrow into the ground to generate rootway and attack air units. Enemies near your attack target will be slowed for a short duration."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HoldSpace = true, HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },
            {
                DataType.ABILITY_RootVice,
                new EntityModel(DataType.ABILITY_RootVice, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Root Vice", Descriptive = DescriptiveType.Ability,
                        Description =
                            "Roots all units for several seconds, then leaves them slowed for several seconds after."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "D" })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Mala })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Energy = 50, Cooldown = 10 })
            },
            {
                DataType.ABILITY_BirthingStorm,
                new EntityModel(DataType.ABILITY_BirthingStorm, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Birthing Storm", Descriptive = DescriptiveType.Ability,
                        Description =
                            "Deals damage over time in an area and marks affected units for several seconds. Units that die while marked spawn a quitl.",
                        Notes =
                            "Deals 10 damage + 5% of max life of the target immediately upon affecting the enemy unit. It deals 15 damage + 15% after 8 seconds. If the unit dies during those 8 seconds (including the final burst), spawns 1 quitl every 2 supply of the dead unit, rounded up. Stacking only refreshes duration of debuff."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "D" })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Mala })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Energy = 80, Cooldown = 2 })
            },
            {
                DataType.ABILITY_SummonSiegeMaw,
                new EntityModel(DataType.ABILITY_SummonSiegeMaw, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Summon Siege Maw", Descriptive = DescriptiveType.Dislodger,
                        Description = "Summons a temporary long-range siege structure at the target location."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HoldSpace = true, HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVanguardAddedModel
                        { ImmortalId = DataType.IMMORTAL_Mala, ReplaceId = DataType.UNIT_Acaaluk })
                    .AddPart(new EntityProductionModel { Energy = 80, BuildTime = 4, Cooldown = 20 })
                    .AddPart(new EntitySupplyModel { Takes = 0 })
                    .AddPart(new EntityVitalityModel { Health = 300, DefenseLayer = 100, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 0, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 40, Range = 1300, Targets = TargetType.Ground, MediumDamage = 50,
                        HeavyDamage = 60
                    })
            },
            {
                DataType.ABILITY_AwakenAcaaluk,
                new EntityModel(DataType.ABILITY_AwakenAcaaluk, EntityType.Ability)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Awaken Acaaluk", Descriptive = DescriptiveType.Dislodger,
                        Description = "The red seer is sacrificed to create an acaaluk."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HoldSpace = true, HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 100, BuildTime = 25 })
                    .AddPart(new EntitySupplyModel { Takes = 6 })
                    .AddPart(new EntityRequirementModel
                        { Id = DataType.UNIT_RedSeer, Requirement = RequirementType.Morph })
                    .AddPart(new EntityVitalityModel { Health = 200, DefenseLayer = 60, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 210, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 125, Range = 1500, AttacksPerSecond = 0.175f, Targets = TargetType.Ground })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_HiddenX })
            },
            // Pyre Spells
            // Q'Rath
            {
                DataType.ISPELL_SummonCitadel,
                new EntityModel(DataType.ISPELL_SummonCitadel, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Summon Citadel",
                        Description = "Creates a powerful defensive structure on a Tower Foundation."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Pyre = 75, BuildTime = 70 })
                    .AddPart(new EntityVitalityModel
                        { Health = 1000, DefenseLayer = 500, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityWeaponModel
                    {
                        Damage = 20, Range = 800, AttacksPerSecond = 1.124f, Targets = TargetType.All,
                        MediumDamage = 25, HeavyDamage = 30
                    })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Respite })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_HallowedGround })
            },
            {
                DataType.ISPELL_PillarOfHeaven,
                new EntityModel(DataType.ISPELL_PillarOfHeaven, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Pillar of Heavens",
                        Description =
                            @"Summons a powerful monument that slams into the ground to <b style=""color:orange"">deal damage</b> to enemy ground units (and takes damage from everything it lands on). It then creates <b style=""color:white"">Hallowed Ground</b> and nearby friendly units <b style=""color:orange"">gain Attack Speed<b>"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Orzum })
                    .AddPart(new EntityProductionModel { Pyre = 100, Cooldown = 15 })
                    .AddPart(new EntityVitalityModel
                        { Health = 300, DefenseLayer = 200, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Zeal })
            },
            {
                DataType.ISPELL_EmpireUnbroken,
                new EntityModel(DataType.ISPELL_EmpireUnbroken, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Empire Unbroken",
                        Description =
                            @"Structures in target area <b style=""color:lime"">reduce incoming damage significantly</b> for several seconds."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Orzum })
                    .AddPart(new EntityProductionModel { Pyre = 50, Cooldown = 15 })
            },
            {
                DataType.ISPELL_InfuseTroops,
                new EntityModel(DataType.ISPELL_InfuseTroops, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Infuse Troops",
                        Description =
                            @"Allied units in a large area <b style=""color:skyblue"">gain Movement Speed</b> and <b style=""color:orange"">gain Attack Speed</b> for several seconds."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Any })
                    .AddPart(new EntityProductionModel { Pyre = 75, Cooldown = 20 })
            },
            {
                DataType.ISPELL_DeliverFromEvil,
                new EntityModel(DataType.ISPELL_DeliverFromEvil, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Deliver from Evil",
                        Description =
                            @"Units in the area <b style=""gain bonus shields"">. After a short delay, allied units in teh area <b style=""color:skyblue"">teleport to your nearest Town Hall</b>."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Ajari })
                    .AddPart(new EntityProductionModel { Pyre = 50, Cooldown = 60 })
            },
            {
                DataType.ISPELL_HeavensAegis,
                new EntityModel(DataType.ISPELL_HeavensAegis, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Heaven's Aegis",
                        Description =
                            @"All allied units <b style=""color:lime"">gain bonus shields</b> for several seconds."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Ajari })
                    .AddPart(new EntityProductionModel { Pyre = 150, Cooldown = 120 })
            },
            // Immortal Spells
            // Aru
            {
                DataType.ISPELL_SummonGroveGuardian,
                new EntityModel(DataType.ISPELL_SummonGroveGuardian, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Summon Grove Guardian",
                        Description = "Creates a powerful defensive structure on a Tower Foundation."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Pyre = 75, BuildTime = 70 })
                    .AddPart(new EntityVitalityModel
                        { Health = 1200, DefenseLayer = 200, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityWeaponModel
                        { Damage = 15, Range = 800, AttacksPerSecond = 1.887f, Targets = TargetType.All })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Respite })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Rootway })
            },
            {
                DataType.ISPELL_ConstructBloodWell,
                new EntityModel(DataType.ISPELL_ConstructBloodWell, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Construct Blood Well",
                        Description =
                            "Creates a rootway generating structure that heals nearby allied units, and transfers it's blood to nearby allied units."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Pyre = 50, Cooldown = 21 })
                    .AddPart(new EntityVitalityModel
                        { Health = 400, Energy = 100, DefenseLayer = 50, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_RestoreLifeblood })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Transfusion })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Rootway })
            },
            {
                DataType.ISPELL_RedTithe,
                new EntityModel(DataType.ISPELL_RedTithe, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Red Tithe",
                        Description = "Sacrifice target unit to create an area that regenerates life and mana."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "1" })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Mala })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Pyre = 40, Cooldown = 60 })
            },
            {
                DataType.ISPELL_RainOfBlood,
                new EntityModel(DataType.ISPELL_RainOfBlood, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Rain of Blood",
                        Description = "Massively increases life, shield and mana regeneration for 30 seconds."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Mala })
                    .AddPart(new EntityProductionModel { Pyre = 130, Cooldown = 30 })
            },
            {
                DataType.ISPELL_MarkPrey,
                new EntityModel(DataType.ISPELL_MarkPrey, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Mark Prey",
                        Description =
                            @"Enemy units in the target area are <b>Revealed</b> through fog of war. Units still in the area after a short delay are marked for 10 seconds to take bonus damage and provide Pyre when killed.",
                        Notes = "+3 pyre for kills"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Xol })
                    .AddPart(new EntityProductionModel { Cooldown = 15, Pyre = 25 })
            },
            {
                DataType.ISPELL_TheGreatHunt,
                new EntityModel(DataType.ISPELL_TheGreatHunt, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "The Great Hunt",
                        Description = "Enemy unit and structures have their vision reduce to 3 for a short time."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Xol })
                    .AddPart(new EntityProductionModel { Pyre = 150, Cooldown = 120 })
            },

            // Building
            // Q'Rath
            {
                DataType.BUILDING_Acropolis,
                new EntityModel(DataType.BUILDING_Acropolis, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Acropolis", Descriptive = DescriptiveType.Town_Hall,
                        Description = "Town Hall (Structure) - Necessary for collecting Alloy and Ether."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel
                        { Alloy = 350, BuildTime = 100, RequiresWorker = true, ConsumesWorker = true })
                    .AddPart(new EntityVitalityModel
                        { Health = 1600, DefenseLayer = 800, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityHarvestModel
                    {
                        HarvestedPerInterval = 1, RequiresWorker = true, Resource = ResourceType.Alloy, Slots = 2,
                        TotalAmount = 3600
                    })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_HallowedGround })
            },
            {
                DataType.BUPGRADE_MiningLevel2_QRath,
                new EntityModel(DataType.BUPGRADE_MiningLevel2_QRath, EntityType.Building_Upgrade)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Mining Level 2", Descriptive = DescriptiveType.Upgrade,
                        Description = "Upgrades the nearest resource cluster to allow more workers to mine from it."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "CONTROL" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Acropolis,
                        Requirement = RequirementType.Morph
                    })
                    .AddPart(new EntityProductionModel { Alloy = 75, BuildTime = 20, RequiresWorker = false })
                    .AddPart(new EntityHarvestModel
                    {
                        HarvestedPerInterval = 1, RequiresWorker = true, Resource = ResourceType.Alloy, Slots = 2,
                        TotalAmount = 3600
                    })
            },
            {
                DataType.BUPGRADE_MiningLevel3_QRath,
                new EntityModel(DataType.BUPGRADE_MiningLevel3_QRath, EntityType.Building_Upgrade)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Mining Level 3", Descriptive = DescriptiveType.Upgrade,
                        Description = "Upgrades the nearest resource cluster to allow more workers to mine from it."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "CONTROL" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUPGRADE_MiningLevel2_QRath,
                        Requirement = RequirementType.Morph
                    })
                    .AddPart(new EntityProductionModel { Alloy = 125, BuildTime = 20, RequiresWorker = false })
                    .AddPart(new EntityHarvestModel
                    {
                        HarvestedPerInterval = 1, RequiresWorker = true, Resource = ResourceType.Alloy, Slots = 2,
                        TotalAmount = 3600
                    })
            },
            {
                DataType.BUILDING_ApostleOfBinding,
                new EntityModel(DataType.BUILDING_ApostleOfBinding, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Apostle of Binding", Descriptive = DescriptiveType.Ether_Extractor,
                        Description = "Ether Extractor (Structure) - Must be placed on an Ether Node."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "V", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 100, BuildTime = 30, RequiresWorker = true })
                    .AddPart(new EntityVitalityModel
                        { Health = 250, DefenseLayer = 150, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityHarvestModel
                    {
                        HarvestedPerInterval = 1.5625f, RequiresWorker = false, Resource = ResourceType.Ether,
                        Slots = 1, TotalAmount = 1200
                    })
            },
            {
                DataType.BUILDING_LegionHall,
                new EntityModel(DataType.BUILDING_LegionHall, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Legion Hall", Descriptive = DescriptiveType.Production,
                        Description = "Army Production (Structure) - Produces infantry units."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntitySupplyModel { Grants = 16 })
                    .AddPart(new EntityProductionModel { Alloy = 250, BuildTime = 38, RequiresWorker = true })
                    .AddPart(new EntityVitalityModel
                        { Health = 500, DefenseLayer = 500, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_HallowedGround })
            },
            {
                DataType.DEFENSE_FireSinger,
                new EntityModel(DataType.DEFENSE_FireSinger, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Fire Singer", Descriptive = DescriptiveType.Defense,
                        Description = "Q'Rath Defensive structure."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 150, BuildTime = 30, RequiresWorker = true })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_KeeperOfTheHardenedFlames,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 300, DefenseLayer = 300, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_PsalmOfFire })
            },
            {
                DataType.BUILDING_KeeperOfTheHardenedFlames,
                new EntityModel(DataType.BUILDING_KeeperOfTheHardenedFlames, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Keeper Of the Hardened Flames", Descriptive = DescriptiveType.Defense,
                        Description = ""
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "V", HoldSpace = true, HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 125, BuildTime = 30, RequiresWorker = true })
                    .AddPart(new EntityVitalityModel
                        { Health = 350, DefenseLayer = 450, Armor = ArmorType.Heavy, IsStructure = true })
            },

            {
                DataType.BUILDING_Reliquary,
                new EntityModel(DataType.BUILDING_Reliquary, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Reliquary", Descriptive = DescriptiveType.Research,
                        Description =
                            "Research (Structure) - Unlocks the Zephyr and Magi at the Legion Hall. Contains Legion Hall research."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HoldSpace = true, HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel
                        { Alloy = 150, Ether = 10, BuildTime = 45, RequiresWorker = true })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_LegionHall,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 550, DefenseLayer = 550, Armor = ArmorType.Heavy, IsStructure = true })
            },
            {
                DataType.BUILDING_SoulFoundry,
                new EntityModel(DataType.BUILDING_SoulFoundry, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Soul Foundry", Descriptive = DescriptiveType.Production,
                        Description = "Army Production (Structure) - Produces advanced ground units."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel
                        { Alloy = 250, Ether = 80, BuildTime = 45, RequiresWorker = true })
                    .AddPart(new EntitySupplyModel { Grants = 16 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_LegionHall,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 450, DefenseLayer = 450, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_HallowedGround })
            },
            {
                DataType.BUILDING_HouseOfFadingSaints,
                new EntityModel(DataType.BUILDING_HouseOfFadingSaints, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "House of the Fading Saints", Descriptive = DescriptiveType.Research,
                        Description = "Research (Structure) - Has tech for the Soul Foundry. Unlocks Hallower."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HoldSpace = true, HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel
                        { Alloy = 175, Ether = 200, BuildTime = 52, RequiresWorker = true })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_SoulFoundry,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 500, DefenseLayer = 500, Armor = ArmorType.Heavy, IsStructure = true })
            },
            {
                DataType.BUILDING_Angelarium,
                new EntityModel(DataType.BUILDING_Angelarium, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Angelarium", Descriptive = DescriptiveType.Production,
                        Description = "Army Production (Structure) - Produces flying units"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel
                        { Alloy = 250, Ether = 80, BuildTime = 48, RequiresWorker = true })
                    .AddPart(new EntitySupplyModel { Grants = 16 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_SoulFoundry,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 600, DefenseLayer = 600, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_HallowedGround })
            },
            {
                DataType.BUILDING_EyeOfAros,
                new EntityModel(DataType.BUILDING_EyeOfAros, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Eye of Aros", Descriptive = DescriptiveType.Research,
                        Description = "Research (Structure) - Unlocks the Shar'U and some late-game Q'Rath upgrades."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HoldSpace = true, HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel
                        { Alloy = 200, Ether = 200, BuildTime = 36, RequiresWorker = true })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Angelarium,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 500, DefenseLayer = 500, Armor = ArmorType.Heavy, IsStructure = true })
            },
            {
                DataType.BUILDING_BearerOfTheCrown,
                new EntityModel(DataType.BUILDING_BearerOfTheCrown, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Bearer of the Crown", Descriptive = DescriptiveType.Research,
                        Description = "Research (Structure) - Unlocks the Throne and researches for Angelarium."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HoldSpace = true, HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel
                        { Alloy = 250, Ether = 200, BuildTime = 52, RequiresWorker = true })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_Angelarium,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 500, DefenseLayer = 500, Armor = ArmorType.Heavy, IsStructure = true })
            },
            // Building
            // Aru
            {
                DataType.BUILDING_GroveHeart,
                new EntityModel(DataType.BUILDING_GroveHeart, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Grove Heart", Descriptive = DescriptiveType.Town_Hall,
                        Description = "Town Hall (Structure) - Necessary for collection Alloy and Ether."
                    }) //TODO: Add Alloy, Ether and Pyre, Supply to the database
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 350, BuildTime = 100, RequiresWorker = true })
                    .AddPart(new EntityVitalityModel
                    {
                        Health = 2000, DefenseLayer = 400, Defense = DefenseType.Overgrowth, Armor = ArmorType.Heavy,
                        IsStructure = true
                    })
                    .AddPart(new EntityHarvestModel
                    {
                        HarvestedPerInterval = 1, RequiresWorker = true, Resource = ResourceType.Alloy, Slots = 2,
                        TotalAmount = 3600
                    })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Rootway })
            },
            {
                DataType.BUPGRADE_GodHeart,
                new EntityModel(DataType.BUPGRADE_GodHeart, EntityType.Building_Upgrade)
                    .AddPart(new EntityInfoModel { Name = "God Heart", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "CONTROL" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVitalityModel
                        { Health = 2150, DefenseLayer = 450, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.STARTING_TownHall_Aru,
                        Requirement = RequirementType.Morph
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel
                        { Alloy = 100, Ether = 75, BuildTime = 36, RequiresWorker = false })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Rootway })
            },
            {
                DataType.BUPGRADE_MiningLevel2_Aru,
                new EntityModel(DataType.BUPGRADE_MiningLevel2_Aru, EntityType.Building_Upgrade)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Mining Level 2", Descriptive = DescriptiveType.Upgrade,
                        Description = "Upgrades the nearest resource cluster to allow more workers to mine from it."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "CONTROL" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_GroveHeart,
                        Requirement = RequirementType.Morph
                    })
                    .AddPart(new EntityProductionModel { Alloy = 75, BuildTime = 20, RequiresWorker = false })
                    .AddPart(new EntityHarvestModel
                    {
                        HarvestedPerInterval = 1, RequiresWorker = true, Resource = ResourceType.Alloy, Slots = 2,
                        TotalAmount = 3600
                    })
            },
            {
                DataType.BUPGRADE_MiningLevel3_Aru,
                new EntityModel(DataType.BUPGRADE_MiningLevel3_Aru, EntityType.Building_Upgrade)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Mining Level 3", Descriptive = DescriptiveType.Upgrade,
                        Description = "Upgrades the nearest resource cluster to allow more workers to mine from it."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "CONTROL" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUPGRADE_MiningLevel2_Aru,
                        Requirement = RequirementType.Morph
                    })
                    .AddPart(new EntityProductionModel { Alloy = 125, BuildTime = 20, RequiresWorker = false })
                    .AddPart(new EntityHarvestModel
                    {
                        HarvestedPerInterval = 1, RequiresWorker = true, Resource = ResourceType.Alloy, Slots = 2,
                        TotalAmount = 3600
                    })
            },
            {
                DataType.BUILDING_EtherMaw,
                new EntityModel(DataType.BUILDING_EtherMaw, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Ether Maw", Descriptive = DescriptiveType.Ether_Extractor,
                        Description = "Ether Extractor (Structure) - Must be placed on an Ether Node."
                    }) //TODO Add Ether Node to database
                    .AddPart(new EntityHotkeyModel { Hotkey = "V", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 100, BuildTime = 30, RequiresWorker = true })
                    .AddPart(new EntityVitalityModel
                        { Health = 400, DefenseLayer = 100, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityHarvestModel
                    {
                        HarvestedPerInterval = 1.5625f, RequiresWorker = false, Resource = ResourceType.Ether,
                        Slots = 1, TotalAmount = 1200
                    })
            },
            {
                DataType.BUILDING_AltarOfTheWorthy,
                new EntityModel(DataType.BUILDING_AltarOfTheWorthy, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Altar of the Worthy", Descriptive = DescriptiveType.Production,
                        Description = "Army Production (Structure) - Produces infantry ground units"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntitySupplyModel { Grants = 16 })
                    .AddPart(new EntityProductionModel { Alloy = 250, BuildTime = 36, RequiresWorker = true })
                    .AddPart(new EntityVitalityModel
                        { Health = 900, DefenseLayer = 100, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Rootway })
            },
            {
                DataType.BUILDING_Neurocyte,
                new EntityModel(DataType.BUILDING_Neurocyte, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Neurocyte", Descriptive = DescriptiveType.Research,
                        Description = "Research (Structure) - Unlocks additional research."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HoldSpace = true, HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel
                        { Alloy = 100, Ether = 75, BuildTime = 30, RequiresWorker = true })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 650, DefenseLayer = 150, Armor = ArmorType.Heavy, IsStructure = true })
            },
            {
                DataType.DEFENSE_Aerovore,
                new EntityModel(DataType.DEFENSE_Aerovore, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Aerovore", Descriptive = DescriptiveType.Defense,
                        Description = "Defense Structure - Aru anti-air defense structure."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 100, BuildTime = 18, RequiresWorker = true })
                    .AddPart(new EntityVitalityModel
                        { Health = 300, DefenseLayer = 50, Armor = ArmorType.Heavy, IsStructure = true })
            },
            {
                DataType.BUPGRADE_Omnivore,
                new EntityModel(DataType.BUPGRADE_Omnivore, EntityType.Building_Upgrade)
                    .AddPart(new EntityInfoModel { Name = "Omnivore", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "SHIFT" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.DEFENSE_Aerovore,
                        Requirement = RequirementType.Morph
                    })
                    .AddPart(new EntityProductionModel { Alloy = 50, BuildTime = 18, RequiresWorker = false })
                    .AddPart(new EntityVitalityModel
                        { Health = 400, DefenseLayer = 50, Armor = ArmorType.Heavy, IsStructure = true })
            },
            {
                DataType.BUILDING_AmberWomb,
                new EntityModel(DataType.BUILDING_AmberWomb, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Amber Womb", Descriptive = DescriptiveType.Production,
                        Description = "Army Production (Structure) - Produces advanced ground units"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel
                        { Alloy = 250, Ether = 80, BuildTime = 45, RequiresWorker = true })
                    .AddPart(new EntitySupplyModel { Grants = 16 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUPGRADE_GodHeart,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 1000, DefenseLayer = 250, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Rootway })
            },
            {
                DataType.BUILDING_BoneCanopy,
                new EntityModel(DataType.BUILDING_BoneCanopy, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Bone Canopy", Descriptive = DescriptiveType.Production,
                        Description = "Army Production (Structure) - Aru air production."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel
                        { Alloy = 250, Ether = 80, BuildTime = 36, RequiresWorker = true })
                    .AddPart(new EntitySupplyModel { Grants = 16 })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUPGRADE_GodHeart,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 1000, DefenseLayer = 300, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Rootway })
            },
            {
                DataType.BUILDING_RedVale,
                new EntityModel(DataType.BUILDING_RedVale, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Red Vale", Descriptive = DescriptiveType.Research,
                        Description = "Unlocks the advanced units at the Altar of the Worthy."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HoldSpace = true, HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel
                        { Alloy = 100, Ether = 100, BuildTime = 36, RequiresWorker = true })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 800, DefenseLayer = 200, Armor = ArmorType.Heavy, IsStructure = true })
            },
            {
                DataType.BUILDING_DeepNest,
                new EntityModel(DataType.BUILDING_DeepNest, EntityType.Building)
                    .AddPart(new EntityInfoModel
                    {
                        Name = "Deep Nest", Descriptive = DescriptiveType.Research,
                        Description = "Unlocks the advanced units and researches at the Bone Canopy."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HoldSpace = true, HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel
                        { Alloy = 175, Ether = 150, BuildTime = 38, RequiresWorker = true })
                    .AddPart(new EntityRequirementModel
                    {
                        Id = DataType.BUILDING_BoneCanopy,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 850, DefenseLayer = 200, Armor = ArmorType.Heavy, IsStructure = true })
            }
        };
    }
}