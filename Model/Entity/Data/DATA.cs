using System.Collections.Generic;
using Model.Immortal.Entity.Parts;
using Model.Immortal.Types;
using Newtonsoft.Json;

namespace Model.Immortal.Entity.Data;

public class DATA {
    public static string AsJson() {
        var json = JsonConvert.SerializeObject(Get(), Formatting.Indented);
        return json;
    }

    public static Dictionary<string, EntityModel> Get() {
        return new Dictionary<string, EntityModel> {
            // Neutrals

            // Pyre Events
            {
                DataType.PYREEVENT_CampTaken, new EntityModel(DataType.PYREEVENT_CampTaken, EntityType.Pyre_Event)
                    .AddPart(new EntityInfoModel { Name = "Pyre Camp", Description = "Provides 25 when taken." })
                    .AddPart(new EntityPyreRewardModel { BaseReward = 25 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "2" })
            }, {
                DataType.PYREEVENT_MinerTaken, new EntityModel(DataType.PYREEVENT_MinerTaken, EntityType.Pyre_Event)
                    .AddPart(new EntityInfoModel { Name = "Pyre Camp", Description = "Provides 90 when taken." })
                    .AddPart(new EntityPyreRewardModel
                        { BaseReward = 0, OverTimeRewardDuration = 90, OverTimeReward = 1 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "2" })
            }, {
                DataType.PYREEVENT_TowerKilled, new EntityModel(DataType.PYREEVENT_TowerKilled, EntityType.Pyre_Event)
                    .AddPart(new EntityInfoModel { Name = "Tower Taken", Description = "Provides 10 when destroyed." })
                    .AddPart(new EntityPyreRewardModel { BaseReward = 10 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "2" })
            },

            // TEAPOTS
            {
                DataType.TEAPOT_Teapot, new EntityModel(DataType.TEAPOT_Teapot, EntityType.Teapot)
                    .AddPart(new EntityInfoModel { Name = "Teapot", Notes = @"Very powerful! So Fast" })
                    .AddPart(new EntityVitalityModel { Health = 70, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 400 })
            }, {
                DataType.TEAPOT_FlyingTeapot, new EntityModel(DataType.TEAPOT_FlyingTeapot, EntityType.Teapot)
                    .AddPart(new EntityInfoModel { Name = "Flying Teapot", Notes = @"Much flying, Wow!" })
                    .AddPart(new EntityRequirementModel
                        { Name = "Teapot", Requirement = RequirementType.Morph, DataType = DataType.TEAPOT_Teapot })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 50 })
                    .AddPart(new EntityVitalityModel { Health = 70, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 400, Movement = MovementType.Air })
            },

            // Families
            {
                DataType.FAMILY_Rae,
                new EntityModel(DataType.FAMILY_Rae, EntityType.Family, true)
                    .AddPart(new EntityInfoModel {
                        Name = "Rae",
                        Notes =
                            @"Enslaved insectoid faction family. Controlled by the Amn Baal, a god not from the dimension of creation. Few Rae are allowed to have free will, and all must obey the call of the work. Maybe?"
                    })
                    .AddPart(new EntityMechanicModel
                        { Name = "Centralized?", Description = "Units can be built only out of the town hall. Maybe?" })
                    .AddPart(new EntityMechanicModel {
                        Name = "Breach?",
                        Description = "Under certain conditions, units can be built anywhere on the map. Maybe?"
                    })
                    .AddPart(new EntityStrategyModel {
                        Notes =
                            "Protect your town halls! If they get sniped, you are going to have trouble keeping up in army production. Maybe?"
                    })
            }, {
                DataType.FAMILY_Sylv,
                new EntityModel(DataType.FAMILY_Sylv, EntityType.Family, true)
                    .AddPart(new EntityInfoModel {
                        Name = "Sylv",
                        Notes =
                            "Plantoid faction family. They heavily rely on their connection to roots and to each other."
                    })
                    .AddPart(new EntityMechanicModel {
                        Name = "Vineway",
                        Description = "Buildings can only built on the vines that spread from already made buildings."
                    })
                    .AddPart(new EntityStrategyModel {
                        Notes =
                            "Taking a risky base? Try to move vineway generating units to the location, so you can build static defense faster."
                    })
            }, {
                DataType.FAMILY_Angelic,
                new EntityModel(DataType.FAMILY_Angelic, EntityType.Family, true)
                    .AddPart(new EntityInfoModel {
                        Name = "Angelic",
                        Notes =
                            "Pyre-based faction family. They seek to protect and guide creation, in the teachings of their god Aros."
                    })
                    .AddPart(new EntityMechanicModel {
                        Name = "Hallowed Ground",
                        Description =
                            "All buildings generate an angelic field that boosts nearby units with additional effects."
                    })
                    .AddPart(new EntityStrategyModel {
                        Notes =
                            "Try to ensure your always fightning on your Hallowed Ground. When on attack, bring with you units that can generate Hallowed Ground, such as the Magi or Ark Mother."
                    })
                    .AddPart(new EntityStrategyModel {
                        Notes =
                            "Your proxy rushes are more dangerous than other families, given your buildings can easily be placed anywhere on the map, and provide the Hallowed Ground bonus."
                    })
            }, {
                DataType.FAMILY_Human,
                new EntityModel(DataType.FAMILY_Human, EntityType.Family, true)
                    .AddPart(new EntityInfoModel {
                        Name = "Human",
                        Notes =
                            "Human governing faction family. They seek power and trade, expanding their territory and control."
                    })
                    .AddPart(new EntityMechanicModel {
                        Name = "Grid?",
                        Description = "Your building benefit from power connections to your townhall. Maybe?"
                    })
                    .AddPart(new EntityStrategyModel {
                        Notes =
                            "Keep small forward bases on the map, so your units have somewhere nearby to reload after a skirmish. Maybe?"
                    })
            }, {
                DataType.FAMILY_Coalition,
                new EntityModel(DataType.FAMILY_Coalition, EntityType.Family, true)
                    .AddPart(new EntityInfoModel {
                        Name = "Coalition?",
                        Notes =
                            "Coalition of species faction family. They make up of variety of groups joining together to surivive in creation. Maybe?"
                    })
                    .AddPart(new EntityMechanicModel {
                        Name = "Diversity?",
                        Description =
                            "Your tech tree is flat, allowing you to special in truly unexpected build orders and compositions. Maybe?"
                    })
            }, {
                DataType.FAMILY_Demonic,
                new EntityModel(DataType.FAMILY_Demonic, EntityType.Family, true)
                    .AddPart(new EntityInfoModel {
                        Name = "Demonic?",
                        Notes =
                            "Not much is known about demons, aside that they are like a pyre-cancer. A part of creation, just not a healthy part. We shouldn't expect any new info a demons until many years after the release of Immortal, should the faction family ever get a gameplay element. Maybe?"
                    })
            }, {
                DataType.FAMILY_NazRa,
                new EntityModel(DataType.FAMILY_NazRa, EntityType.Family, true)
                    .AddPart(new EntityInfoModel {
                        Name = "Naz'Ra",
                        Notes =
                            "An ancient species, believed to of consumed their gods. Naz'Ra were probably all killed off in old wars against the Rae. Some could still be alive, but if I had to guess, they probably won't be appart of the game. Maybe?"
                    })
            },
            // Factions
            // Sylv
            {
                DataType.FACTION_Aru,
                new EntityModel(DataType.FACTION_Aru, EntityType.Faction)
                    .AddPart(new EntityInfoModel {
                        Name = "Aru",
                        Notes =
                            "Sylv variant that is no longer as reliant on the vineway. Instead they rely on a blood god's rootway, and on the god's beasts for protection."
                    })
                    .AddPart(new EntityPassiveModel {
                        Name = "Overgrowth",
                        Description =
                            "Your units have an extra layer of health a regens rapidly when a unit hasn't been damaged recently. This regen is doubled on rootway."
                    })
                    .AddPart(new EntityPassiveModel {
                        Name = "Blood",
                        Description =
                            "Your casters passively get blood for spells. This blood regen rate is increased on rootway. Your casters can also spend their own life as blood. (Spending health as blood is currenly not in game.)"
                    })
                    .AddPart(new EntityPassiveModel {
                        Name = "Blood Wells",
                        Description =
                            "You can summon blood wells for pyre, that allow you to heal your units health and mana."
                    })
                    .AddPart(new EntityStrategyModel {
                        Notes =
                            "Due to Overgrowth, Aru benfit from being able to quickly skrimish their units in and out of combat. Additionally, certain units in the Aru arsenal also favour this playstyle, like the Behemoths, Incubators, Xacals and more."
                    })
                    .AddPart(new EntityStrategyModel {
                        Notes =
                            "Aru have no healing outside of Pyre utility buildings: Towers and Blood Wells. You should always try to hold pyre camps, but also try to consider how you will spend the Pyre to help keep your army alive."
                    })
            }, {
                DataType.FACTION_Iratek,
                new EntityModel(DataType.FACTION_Iratek, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel {
                        Name = "Iratek", Notes = "Sylv faction that relies on the vineway to create a hivemind. Maybe?"
                    })
                    .AddPart(new EntityPassiveModel {
                        Name = "The Chorus?",
                        Description = "Your units become isolated when leaving the vineway. Maybe?"
                    })
            }, {
                DataType.FACTION_Yul,
                new EntityModel(DataType.FACTION_Yul, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel { Name = "Yul", Notes = "A more fungal Sylv faction. Maybe?" })
                    .AddPart(new EntityPassiveModel {
                        Name = "Plant Growth?",
                        Description = "You want to grow important utility units on the vineway. Maybe?"
                    })
            },
            // Factions
            // Angelic
            {
                DataType.FACTION_QRath,
                new EntityModel(DataType.FACTION_QRath, EntityType.Faction)
                    .AddPart(new EntityInfoModel {
                        Name = "Q'Rath",
                        Notes =
                            "Anglic faction that has adopted many humans into their ranks. They seek to bring more into their collective."
                    })
                    .AddPart(new EntityPassiveModel {
                        Name = "Wards",
                        Description =
                            "Your units have an extra layer of health that is always (but slowly) regenerates. The regeneration is double on Hallowed Ground."
                    })
                    .AddPart(new EntityStrategyModel {
                        Notes =
                            "As Q'Rath, you care about fighting on Hallowed Ground, given the regen it provides your units. Additionally, units like the Sipari and Zentari will get additional bonuses when fighting on Hallowed Ground. Try to hold position at forward buildings, Pillars and Ark Mothers."
                    })
            }, {
                DataType.FACTION_YRiah,
                new EntityModel(DataType.FACTION_QRath, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel { Name = "R'Raih", Notes = "An angrier angelic faction. Maybe?" })
                    .AddPart(new EntityPassiveModel
                        { Name = "Berserk?", Description = "Your units get stronger when at low health. Maybe?" })
            }, {
                DataType.FACTION_ArkShai,
                new EntityModel(DataType.FACTION_QRath, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel
                        { Name = "Ark'Shai", Notes = "An more soul sucking angelic faction. Maybe?" })
                    .AddPart(new EntityPassiveModel
                        { Name = "Life Steal?", Description = "Your units gain life when attacking. Maybe?" })
            },
            // Factions
            // Human
            {
                DataType.FACTION_Jora,
                new EntityModel(DataType.FACTION_Jora, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel { Name = "Jora", Notes = "Industrial human faction. Maybe?" })
                    .AddPart(new EntityPassiveModel {
                        Name = "Ammo?",
                        Description =
                            "Your units have limited attacks, which need to be replenished at a building. Maybe?"
                    })
            }, {
                DataType.FACTION_Telmetra,
                new EntityModel(DataType.FACTION_Telmetra, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel { Name = "Talmetra", Notes = "Heavy political faction. Maybe?" })
                    .AddPart(new EntityPassiveModel {
                        Name = "Trade Lines?",
                        Description = "Increase alloy and ether production by connecting bases with roads. Maybe?"
                    })
            }, {
                DataType.FACTION_Kjor,
                new EntityModel(DataType.FACTION_Kjor, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel
                        { Name = "Kjor", Notes = "Aggressive warriors with magical runes. Maybe?" })
                    .AddPart(new EntityPassiveModel {
                        Name = "Rune Recharging?",
                        Description = "Your units have spells that they can only recover at buildings. Maybe?"
                    })
            },
            // Factions
            // Rae
            {
                DataType.FACTION_Herlesh,
                new EntityModel(DataType.FACTION_Herlesh, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel { Name = "Herlesh", Notes = "Biomechanical Rae faction. Maybe?" })
                    .AddPart(new EntityPassiveModel {
                        Name = "Miasma?",
                        Description = "Units leave damage-over-time area-of-effects when the die. Maybe?"
                    })
            }, {
                DataType.FACTION_EntralledRae,
                new EntityModel(DataType.FACTION_EntralledRae, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel
                        { Name = "Entralled Rae", Notes = "Mind controlled Rae faction. Maybe?" })
                    .AddPart(new EntityPassiveModel
                        { Name = "Mind Control?", Description = "Can temporary shut down enemy units. Maybe?" })
            },
            // Factions
            // Coalition
            {
                DataType.FACTION_Khardu,
                new EntityModel(DataType.FACTION_Khardu, EntityType.Faction, true)
                    .AddPart(new EntityInfoModel { Name = "Khardu", Notes = "Horde composed of many species. Maybe?" })
                    .AddPart(new EntityPassiveModel {
                        Name = "Totems?", Description = "Place totems in combat that offer a variety of bonuses. Maybe?"
                    })
            },
            // Immortals
            // Aru
            {
                DataType.IMMORTAL_Mala,
                new EntityModel(DataType.IMMORTAL_Mala, EntityType.Immortal)
                    .AddPart(new EntityInfoModel { Name = ImmortalType.Mala })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityHarvestModel {
                        Resource = ResourceType.Pyre, HarvestedPerInterval = 1, HarvestDelay = 3,
                        RequiresWorker = false, Slots = 1, TotalAmount = -1
                    })
                    .AddPart(new EntityPassiveModel {
                        Name = "Mother's Hunger",
                        Description = "Grants 1 pyre when a unit dies within 600 range of a blood well."
                    })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_SummonGroveGuardian })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_InfuseTroops })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_ConstructBloodWell })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_RedTithe })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_RainOfBlood })
                    .AddPart(new EntityIdVanguardModel { Id = DataType.VANGUARD_Incubator_Mala })
                    .AddPart(new EntityIdVanguardModel { Id = DataType.VANGUARD_DreadSister_Mala })
            }, {
                DataType.IMMORTAL_Xol,
                new EntityModel(DataType.IMMORTAL_Xol, EntityType.Immortal)
                    .AddPart(new EntityInfoModel { Name = ImmortalType.Xol })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityHarvestModel {
                        Resource = ResourceType.Pyre, HarvestedPerInterval = 1, HarvestDelay = 3,
                        RequiresWorker = false, Slots = 1, TotalAmount = -1
                    })
                    .AddPart(new EntityPassiveModel {
                        Name = "[PlaceholderText] Instincts",
                        Description =
                            "[PlaceholderText] Your units can sense nearby enemies in the fog of war. (Not implemented)"
                    })
                    .AddPart(new EntityStrategyModel {
                        Notes =
                            "Sneak small skrimishing units around the map to attack workers and isolated enemy units."
                    })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_SummonGroveGuardian })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_InfuseTroops })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_ConstructBloodWell })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_GreatHunt })
                    .AddPart(new EntityIdVanguardModel { Id = DataType.VANGUARD_BoneStalker_Xol })
                    .AddPart(new EntityIdVanguardModel { Id = DataType.VANGUARD_WhiteWoodReaper_Xol })
            },
            // Immortals
            // Q'Rath
            {
                DataType.IMMORTAL_Ajari,
                new EntityModel(DataType.IMMORTAL_Ajari, EntityType.Immortal)
                    .AddPart(new EntityInfoModel { Name = ImmortalType.Ajari })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityHarvestModel {
                        Resource = ResourceType.Pyre, HarvestedPerInterval = 1, HarvestDelay = 3,
                        RequiresWorker = false, Slots = 1, TotalAmount = -1
                    })
                    .AddPart(new EntityPassiveModel {
                        Name = "[PlaceholderText] Healing Hallowed Ground",
                        Description = "[PlaceholderText] Your Hallowed Ground also heals units."
                    })
                    .AddPart(new EntityStrategyModel
                        { Notes = "Bring your damaged units to full health with Hallowed Ground." })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_SummonCitadel })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_InfuseTroops })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_DeliverFromEvil })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_HeavensAegis })
                    .AddPart(new EntityIdVanguardModel { Id = DataType.VANGUARD_Saoshin_Ajari })
                    .AddPart(new EntityIdVanguardModel { Id = DataType.VANGUARD_ArkMother_Ajari })
            }, {
                DataType.IMMORTAL_Orzum,
                new EntityModel(DataType.IMMORTAL_Orzum, EntityType.Immortal)
                    .AddPart(new EntityInfoModel { Name = ImmortalType.Orzum })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityHarvestModel {
                        Resource = ResourceType.Pyre, HarvestedPerInterval = 1, HarvestDelay = 3,
                        RequiresWorker = false, Slots = 1, TotalAmount = -1
                    })
                    .AddPart(new EntityPassiveModel {
                        Name = "[PlaceholderText] Expansionist",
                        Description = "[PlaceholderText] Your towers cost 25 less pyre."
                    })
                    .AddPart(new EntityStrategyModel
                        { Notes = "You want to leverage building a lot of towers for vision and map control." })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_InfuseTroops })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_SummonCitadel })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_EmpireUnbroken })
                    .AddPart(new EntityIdPyreSpellModel { Id = DataType.ISPELL_PillarOfHeaven })
                    .AddPart(new EntityIdVanguardModel { Id = DataType.VANGUARD_Zentari_Orzum })
                    .AddPart(new EntityIdVanguardModel { Id = DataType.VANGUARD_Sceptre_Orzum })
            },

            // Keys
            {
                DataType.COMMAND_Attack,
                new EntityModel(DataType.COMMAND_Attack, EntityType.Command)
                    .AddPart(new EntityInfoModel
                        { Name = "Attack", Notes = "Makes selected units attack targeted area." })
                    .AddPart(new EntityHotkeyModel { Hotkey = "A", HotkeyGroup = "D" })
            }, {
                DataType.COMMAND_StandGround,
                new EntityModel(DataType.COMMAND_StandGround, EntityType.Command)
                    .AddPart(new EntityInfoModel { Name = "Stand Ground", Notes = "Makes selected units stop moving." })
                    .AddPart(new EntityHotkeyModel { Hotkey = "S", HotkeyGroup = "D" })
            },
            // Starting Structures
            {
                DataType.STARTING_Bastion,
                new EntityModel(DataType.STARTING_Bastion, EntityType.Building)
                    .AddPart(new EntityInfoModel
                        { Name = "Bastion", Notes = "Provides a fully upgraded base worth of alloy." })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Neutral })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Neutral })
                    .AddPart(new EntityHarvestModel {
                        HarvestedPerInterval = 6, RequiresWorker = false, Resource = ResourceType.Alloy, Slots = 1,
                        TotalAmount = 6000
                    })
            }, {
                DataType.STARTING_Tower,
                new EntityModel(DataType.STARTING_Bastion, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "Starting Tower",
                        Notes = "Currently not in game. Can be upgraded to the factions pyre tower."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Neutral })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Neutral })
            },
            // Starting Structures
            // Aru
            {
                DataType.STARTING_TownHall_Aru,
                new EntityModel(DataType.STARTING_TownHall_Aru, EntityType.Building)
                    .AddPart(new EntityInfoModel
                        { Name = "Grove Heart (Starting)", Descriptive = DescriptiveType.Town_Hall_Starting })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVitalityModel
                        { Health = 2000, DefenseLayer = 400, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityHarvestModel {
                        HarvestedPerInterval = 1, RequiresWorker = true, Resource = ResourceType.Alloy, Slots = 6,
                        TotalAmount = 6000
                    })
            },
            // Starting Structures
            // Q'Rath
            {
                DataType.STARTING_TownHall_QRath,
                new EntityModel(DataType.STARTING_TownHall_QRath, EntityType.Building)
                    .AddPart(new EntityInfoModel
                        { Name = "Acropolis (Starting)", Descriptive = DescriptiveType.Town_Hall_Starting })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityVitalityModel
                        { Health = 1600, DefenseLayer = 800, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityHarvestModel {
                        HarvestedPerInterval = 6, RequiresWorker = false, Resource = ResourceType.Alloy, Slots = 1,
                        TotalAmount = 6000
                    })
            },

            // Vanguard
            // Q'Rath
            {
                DataType.VANGUARD_Zentari_Orzum,
                new EntityModel(DataType.VANGUARD_Zentari_Orzum, EntityType.Army)
                    .AddPart(new EntityInfoModel {
                        Name = "Zentari", Descriptive = DescriptiveType.Frontliner,
                        Description =
                            "Brawler (Ground Unit) - Juggernaut infantry that gain a ranged attack in Hallowed Ground."
                    })
                    .AddPart(new EntityTierModel { Tier = 1 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityVanguardAddedModel { ReplaceId = DataType.UNIT_Sipari, ImmortalId = DataType.IMMORTAL_Orzum })
                    .AddPart(new EntityProductionModel { Alloy = 100, BuildTime = 24 })
                    .AddPart(new EntitySupplyModel { Takes = 4 })
                    .AddPart(new EntityVitalityModel { Health = 180, DefenseLayer = 100, Armor = ArmorType.Light })
                    .AddPart(new EntityWeaponModel
                        { Damage = 26, Range = 100, AttacksPerSecond = 0.699f, Targets = TargetType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 26, Range = 300, AttacksPerSecond = 0.699f, Targets = TargetType.Ground })
                    .AddPart(new EntityRequirementModel {
                        Name = "Legion Hall", DataType = DataType.BUILDING_LegionHall,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityMovementModel { Speed = 380, Movement = MovementType.Ground })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_FaithCastBlades })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_IconOfKhastEem })
            }, {
                DataType.VANGUARD_Sceptre_Orzum,
                new EntityModel(DataType.VANGUARD_Sceptre_Orzum, EntityType.Army)
                    .AddPart(new EntityInfoModel
                        { Name = "Sceptre", Descriptive = DescriptiveType.Harrier, Description = "" })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 200, Ether = 125, BuildTime = 40 })
                    .AddPart(new EntityVitalityModel { Health = 350, DefenseLayer = 120, Armor = ArmorType.Heavy })
                    .AddPart(new EntitySupplyModel { Takes = 6 })
                    .AddPart(new EntityWeaponModel {
                        Damage = 30, MediumDamage = 35, HeavyDamage = 40, Range = 600, SecondsBetweenAttacks = 1.8f, AttacksPerSecond = 0.637f,
                        Targets = TargetType.Ground, 
                    })
                    .AddPart(new EntityWeaponModel {
                        Damage = 40, MediumDamage = 45, HeavyDamage = 50, Range = 600, SecondsBetweenAttacks = 1.8f, AttacksPerSecond = 0.637f,
                        Targets = TargetType.Ground,  HasSplash = true
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Angelarium", DataType = DataType.BUILDING_Angelarium,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVanguardAddedModel { ReplaceId = DataType.UNIT_Warden, ImmortalId = DataType.IMMORTAL_Orzum })
                    .AddPart(new EntityMovementModel { Speed = 340, Movement = MovementType.Air })
            }, {
                DataType.VANGUARD_Saoshin_Ajari,
                new EntityModel(DataType.VANGUARD_Saoshin_Ajari, EntityType.Army)
                    .AddPart(new EntityInfoModel {
                        Name = "Saoshin", Descriptive = DescriptiveType.Force_Multiplier,
                        Description =
                            "Support Caster (Ground Unit) - Has a decent melee attack and can buff units for a short duration. It can also heal."
                    })
                    .AddPart(new EntityTierModel { Tier = 1.5f })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityVanguardAddedModel { ReplaceId = DataType.UNIT_Magi, ImmortalId = DataType.IMMORTAL_Ajari })
                    .AddPart(new EntityProductionModel { Alloy = 75, Ether = 75, BuildTime = 35 })
                    .AddPart(new EntitySupplyModel { Takes = 4 })
                    .AddPart(new EntityVitalityModel
                        { Health = 140, DefenseLayer = 100, Armor = ArmorType.Light, IsEtheric = true })
                    .AddPart(new EntityMovementModel { Speed = 380, Movement = MovementType.Ground })
                    .AddPart(new EntityRequirementModel {
                        Name = "Legion Hall", DataType = DataType.BUILDING_LegionHall,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Reliquary", DataType = DataType.BUILDING_Reliquary,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityWeaponModel
                        { Damage = 16, Range = 80, AttacksPerSecond = 0.833f, Targets = TargetType.Ground })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_Leap })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_Invervention })
            }, {
                DataType.VANGUARD_ArkMother_Ajari,
                new EntityModel(DataType.VANGUARD_ArkMother_Ajari, EntityType.Army)
                    .AddPart(new EntityInfoModel {
                        Name = "Ark Mother", Descriptive = DescriptiveType.Dislodger,
                        Description =
                            "Dislodger - Support unit that creates a large area of damage reduction for friendly troops."
                    })
                    .AddPart(new EntityTierModel { Tier = 2 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityVanguardAddedModel { ReplaceId = DataType.UNIT_Hallower, ImmortalId = DataType.IMMORTAL_Ajari })
                    .AddPart(new EntityProductionModel { Alloy = 150, Ether = 100, BuildTime = 40 })
                    .AddPart(new EntitySupplyModel { Takes = 5 })
                    .AddPart(new EntityVitalityModel
                        { Energy = 100, Health = 100, DefenseLayer = 100, Armor = ArmorType.Medium, IsEtheric = true })
                    .AddPart(new EntityRequirementModel {
                        Name = "Soul Foundry", DataType = DataType.BUILDING_SoulFoundry,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "House of Fading Saints", DataType = DataType.BUILDING_HouseOfFadingSaints,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityMovementModel { Speed = 335, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 25, Range = 1100, AttacksPerSecond = 0.4f, Targets = TargetType.Ground })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_OrdainedPassage })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_StabilizeHallowedGround })
            },
            // Vanguards
            // Aru
            {
                DataType.VANGUARD_Incubator_Mala,
                new EntityModel(DataType.VANGUARD_Incubator_Mala, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Incubator", Descriptive = DescriptiveType.Force_Multiplier })
                    .AddPart(new EntityTierModel { Tier = 2 })
                    .AddPart(new EntityRequirementModel {
                        Name = "Amber Womb", DataType = DataType.BUILDING_AmberWomb,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVanguardAddedModel { ReplaceId = DataType.UNIT_Underspine, ImmortalId = DataType.IMMORTAL_Mala })
                    .AddPart(new EntityProductionModel { Alloy = 175, Ether = 50, BuildTime = 35 })
                    .AddPart(new EntitySupplyModel { Takes = 5 })
                    .AddPart(new EntityVitalityModel
                        { Health = 160, DefenseLayer = 40, Armor = ArmorType.Medium, IsEtheric = false })
                    .AddPart(new EntityMovementModel { Speed = 340, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 16, Range = 700, AttacksPerSecond = 0.606f, Targets = TargetType.Ground })
                    .AddPart(new EntityIdPassiveModel() { Id = DataType.PASSIVE_ProjectileGestation })
            }, {
                DataType.VANGUARD_DreadSister_Mala,
                new EntityModel(DataType.VANGUARD_DreadSister_Mala, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Dread Sister", Descriptive = DescriptiveType.Elite_Caster })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityRequirementModel {
                        Name = "Altar of the Worthy", DataType = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Blood Vale", DataType = DataType.BUILDING_RedVale,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVanguardAddedModel { ReplaceId = DataType.UNIT_RedSeer, ImmortalId = DataType.IMMORTAL_Mala })
                    .AddPart(new EntityProductionModel { Alloy = 60, Ether = 150, BuildTime = 45 })
                    .AddPart(new EntitySupplyModel { Takes = 4 })
                    .AddPart(new EntityVitalityModel {
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
            }, {
                DataType.VANGUARD_BoneStalker_Xol,
                new EntityModel(DataType.VANGUARD_BoneStalker_Xol, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Bone Stalker", Descriptive = DescriptiveType.Generalist })
                    .AddPart(new EntityTierModel { Tier = 1 })
                    .AddPart(new EntityRequirementModel {
                        Name = "Altar of the Worthy", DataType = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVanguardAddedModel { ReplaceId = DataType.UNIT_MaskedHunter, ImmortalId = DataType.IMMORTAL_Xol })
                    .AddPart(new EntityProductionModel { Alloy = 50, Ether = 0, BuildTime = 40 })
                    .AddPart(new EntitySupplyModel { Takes = 2 })
                    .AddPart(new EntityVitalityModel
                        { Health = 85, DefenseLayer = 10, Armor = ArmorType.Light, IsEtheric = false })
                    .AddPart(new EntityMovementModel { Speed = 350, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 11, Range = 400, AttacksPerSecond = 1.02f, Targets = TargetType.All })
            }, {
                DataType.VANGUARD_WhiteWoodReaper_Xol,
                new EntityModel(DataType.VANGUARD_WhiteWoodReaper_Xol, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "White Wood Reaper", Descriptive = DescriptiveType.Assassin })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityRequirementModel {
                        Name = "Altar of the Worthy", DataType = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Blood Vale", DataType = DataType.BUILDING_RedVale,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVanguardAddedModel { ReplaceId = DataType.UNIT_Bloodbound, ImmortalId = DataType.IMMORTAL_Xol })
                    .AddPart(new EntityProductionModel { Alloy = 80, Ether = 80, BuildTime = 35 })
                    .AddPart(new EntitySupplyModel { Takes = 4 })
                    .AddPart(new EntityVitalityModel {
                        Energy = 60, Health = 80, DefenseLayer = 40, Defense = DefenseType.Overgrowth,
                        Armor = ArmorType.Medium, IsEtheric = false
                    })
                    .AddPart(new EntityMovementModel { Speed = 448, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel {
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
            }, {
                DataType.UNIT_Sipari,
                new EntityModel(DataType.UNIT_Sipari, EntityType.Army)
                    .AddPart(new EntityInfoModel {
                        Name = "Sipari", Descriptive = DescriptiveType.Frontliner,
                        Description =
                            @"Melee Warrior (Ground Unit) - Front-line warriors enchanced by <b>Hallowed Ground</b>."
                    })
                    .AddPart(new EntityTierModel { Tier = 1 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "Z" })
                    .AddPart(new EntityVanguardReplacedModel { ImmortalId = DataType.IMMORTAL_Orzum, ReplacedById = DataType.VANGUARD_Zentari_Orzum })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 75, BuildTime = 25 })
                    .AddPart(new EntitySupplyModel { Takes = 3 })
                    .AddPart(new EntityVitalityModel { Health = 140, DefenseLayer = 70, Armor = ArmorType.Light })
                    .AddPart(new EntityRequirementModel {
                        Name = "Legion Hall", DataType = DataType.BUILDING_LegionHall,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityMovementModel { Speed = 380, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel {
                        Damage = 20, HeavyDamage = 18, Range = 180, AttacksPerSecond = 0.699f,
                        SecondsBetweenAttacks = 1.43f, Targets = TargetType.Ground
                    })
            }, {
                DataType.UNIT_Magi,
                new EntityModel(DataType.UNIT_Magi, EntityType.Army)
                    .AddPart(new EntityInfoModel {
                        Name = "Magi", Descriptive = DescriptiveType.Force_Multiplier,
                        Description =
                            "Support Caster (Ground Unit) - Heal allies. Can deploy to create Hallowed Ground."
                    })
                    .AddPart(new EntityTierModel { Tier = 1.5f })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 75, Ether = 75, BuildTime = 35 })
                    .AddPart(new EntitySupplyModel { Takes = 3 })
                    .AddPart(new EntityVanguardReplacedModel { ImmortalId = DataType.IMMORTAL_Ajari, ReplacedById = DataType.VANGUARD_Saoshin_Ajari })
                    .AddPart(new EntityRequirementModel {
                        Name = "Legion Hall", DataType = DataType.BUILDING_LegionHall,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Reliquary", DataType = DataType.BUILDING_Reliquary,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Energy = 100, Health = 50, DefenseLayer = 50, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 335, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 7, Range = 600, SecondsBetweenAttacks = 0.94f ,AttacksPerSecond = 1.408f, Targets = 
                        TargetType.All })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_DeployMagi })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_MobilizeQrath })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_MendingCommand })
            }, {
                DataType.UNIT_Zephyr,
                new EntityModel(DataType.UNIT_Zephyr, EntityType.Army)
                    .AddPart(new EntityInfoModel {
                        Name = "Zephyr", Descriptive = DescriptiveType.Generalist,
                        Description =
                            "Ranged Generalist (Ground Unit) - Can attack ground and air. Has a short-ranged teleport ability for advanced mobility."
                    })
                    .AddPart(new EntityTierModel { Tier = 1.5f })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 40, BuildTime = 30 })
                    .AddPart(new EntitySupplyModel { Takes = 4 })
                    .AddPart(new EntityRequirementModel {
                        Name = "Legion Hall", DataType = DataType.BUILDING_LegionHall,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Reliquary", DataType = DataType.BUILDING_Reliquary,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel { Health = 180, DefenseLayer = 90, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 350, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel {
                        Damage = 20, MediumDamage = 24, HeavyDamage = 28, Range = 500, AttacksPerSecond = 0.667f,
                        Targets = TargetType.All
                    })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_Windstep })
            }, {
                DataType.UNIT_Dervish,
                new EntityModel(DataType.UNIT_Dervish, EntityType.Army)
                    .AddPart(new EntityInfoModel {
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
                    .AddPart(new EntityRequirementModel {
                        Name = "Soul Foundry", DataType = DataType.BUILDING_SoulFoundry,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityMovementModel { Speed = 435, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel {
                        Damage = 20, LightDamage = 40, MediumDamage = 30, Range = 250, AttacksPerSecond = 0.5f,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_SiroccoScript })
            }, {
                DataType.UNIT_Absolver,
                new EntityModel(DataType.UNIT_Absolver, EntityType.Army)
                    .AddPart(new EntityInfoModel {
                        Name = "Absolver", Descriptive = DescriptiveType.Zone_Control,
                        Description =
                            "Zone Control (Ground Unit) - Deploys to gain increased rate of fire to hold a position. Can only attack ground."
                    })
                    .AddPart(new EntityTierModel { Tier = 2 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 150, Ether = 75, BuildTime = 35 })
                    .AddPart(new EntitySupplyModel { Takes = 5 })
                    .AddPart(new EntityVitalityModel { Health = 175, DefenseLayer = 150, Armor = ArmorType.Medium })
                    .AddPart(new EntityRequirementModel {
                        Name = "Soul Foundry", DataType = DataType.BUILDING_SoulFoundry,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityMovementModel { Speed = 315, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel {
                        Damage = 11, MediumDamage = 13, HeavyDamage = 15, StructureDamageBonus = 8, Range = 800,
                        AttacksPerSecond = 1.25f, Targets = TargetType.Ground
                    })
                    .AddPart(new EntityWeaponModel {
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
                    .AddPart(new EntityInfoModel {
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
                    .AddPart(new EntityRequirementModel {
                        Name = "Soul Foundry", DataType = DataType.BUILDING_SoulFoundry,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityWeaponModel {
                        Damage = 20, MediumDamage = 30, HeavyDamage = 40, Range = 800, AttacksPerSecond = 0.704f,
                        Targets = TargetType.Air, EthericDamageBonus = 10
                    })
                    .AddPart(new EntityWeaponModel
                        { Damage = 8, Range = 500, AttacksPerSecond = 1.429f, Targets = TargetType.Ground })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_RelicOfTheWrathfulGaze })
            }, {
                DataType.UNIT_Hallower,
                new EntityModel(DataType.UNIT_Hallower, EntityType.Army)
                    .AddPart(new EntityInfoModel {
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
                    .AddPart(new EntityRequirementModel {
                        Name = "Soul Foundry", DataType = DataType.BUILDING_SoulFoundry,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "House of Fading Saints", DataType = DataType.BUILDING_HouseOfFadingSaints,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel { Health = 100, DefenseLayer = 130, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 335, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel {
                        Damage = 60, MediumDamage = 80, HeavyDamage = 100, Range = 1300, AttacksPerSecond = 0.143f,
                        Targets = TargetType.Ground
                    })
            }, {
                DataType.UNIT_Sentinel,
                new EntityModel(DataType.UNIT_Sentinel, EntityType.Army)
                    .AddPart(new EntityInfoModel {
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
                    .AddPart(new EntityRequirementModel {
                        Name = "Angelarium", DataType = DataType.BUILDING_Angelarium,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityWeaponModel {
                        Damage = 28, Range = 500, AttacksPerSecond = 0.714f, Targets = TargetType.Air
                    })
            }, 
            {
                DataType.UNIT_Throne,
                new EntityModel(DataType.UNIT_Throne, EntityType.Army)
                    .AddPart(new EntityInfoModel {
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
                    .AddPart(new EntityRequirementModel {
                        Name = "Angelarium", DataType = DataType.BUILDING_Angelarium,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Bearer of the Crown", DataType = DataType.BUILDING_BearerOfTheCrown,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityMovementModel { Speed = 262, Movement = MovementType.Air })
                    .AddPart(new EntityWeaponModel {
                        Damage = 60, Range = 600, AttacksPerSecond = 0.5f, SecondsBetweenAttacks = 2,
                        Targets = TargetType.All
                    })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_BladesOfTheGodhead })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_BladesOfTheGodhead })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_GodstoneBulwark })
            }, 
            {
                DataType.UNIT_Warden,
                new EntityModel(DataType.UNIT_Warden, EntityType.Army)
                    .AddPart(new EntityInfoModel {
                        Name = "Warden", Descriptive = DescriptiveType.Harrier,
                        Description =
                            @"Gunship (Flying Unit) - Air-to-ground specialist. Flight allos it to ignore terrain."
                    })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityVanguardReplacedModel { ImmortalId = DataType.IMMORTAL_Orzum, ReplacedById = DataType.VANGUARD_Sceptre_Orzum })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 175, Ether = 100, BuildTime = 40 })
                    .AddPart(new EntitySupplyModel { Takes = 6 })
                    .AddPart(new EntityRequirementModel {
                        Name = "Angelarium", DataType = DataType.BUILDING_Angelarium,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel { Health = 300, DefenseLayer = 80, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 420, Movement = MovementType.Air })
                    .AddPart(new EntityWeaponModel
                        { Damage = 32, Range = 600, AttacksPerSecond = 0.556f, Targets = TargetType.Ground })
            }, {
                DataType.UNIT_SharU,
                new EntityModel(DataType.UNIT_SharU, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Shar'U", Descriptive = DescriptiveType.Elite_Caster })
                    .AddPart(new EntityTierModel { Tier = 3.5f })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 110, Ether = 175, BuildTime = 55 })
                    .AddPart(new EntitySupplyModel { Takes = 6 })
                    .AddPart(new EntityRequirementModel {
                        Name = "Angelarium", DataType = DataType.BUILDING_Angelarium,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Eye of Eros", DataType = DataType.BUILDING_EyeOfAros,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 175, DefenseLayer = 125, IsEtheric = true, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 315, Movement = MovementType.Air })
                    .AddPart(new EntityWeaponModel {
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
                    .AddPart(new EntityRequirementModel {
                        Name = "Grove Heart", DataType = DataType.BUILDING_GroveHeart,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel { Health = 50, DefenseLayer = 10, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 400, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 8, Range = 40, AttacksPerSecond = 1.25f, Targets = TargetType.Ground })
            }, {
                DataType.UNIT_MaskedHunter,
                new EntityModel(DataType.UNIT_MaskedHunter, EntityType.Army)
                    .AddPart(new EntityInfoModel {
                        Name = "Masked Hunter", Descriptive = DescriptiveType.Generalist,
                        Description =
                            "Ranged Generalist (Ground Unit) - Can attack ground and air, and sacrifice health for a temporary boost to its range and speed."
                    })
                    .AddPart(new EntityTierModel { Tier = 1 })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "Z" })
                    .AddPart(new EntityVanguardReplacedModel
                        { ImmortalId = DataType.IMMORTAL_Xol, ReplacedById = DataType.VANGUARD_BoneStalker_Xol })
                    .AddPart(new EntityRequirementModel {
                        Name = "Altar of the Worthy", DataType = DataType.BUILDING_AltarOfTheWorthy,
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
            }, {
                DataType.UNIT_Xacal,
                new EntityModel(DataType.UNIT_Xacal, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Xacal", Descriptive = DescriptiveType.Frontliner })
                    .AddPart(new EntityTierModel { Tier = 1.5f })
                    .AddPart(new EntityRequirementModel {
                        Name = "Altar of the Worthy", DataType = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Neurocyte", DataType = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 75, Ether = 30, BuildTime = 25 })
                    .AddPart(new EntitySupplyModel { Takes = 3 })
                    .AddPart(new EntityVitalityModel { Health = 160, DefenseLayer = 70, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 378, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel {
                        Damage = 15, MediumDamage = 20, HeavyDamage = 25, Range = 400, AttacksPerSecond = 0.56f,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_XacalDamage })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_XacalDamage })
            }, {
                DataType.UNIT_Bloodbound,
                new EntityModel(DataType.UNIT_Bloodbound, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Bloodbound", Descriptive = DescriptiveType.Assassin })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityVanguardReplacedModel
                        {  ImmortalId = DataType.IMMORTAL_Xol, ReplacedById = DataType.VANGUARD_WhiteWoodReaper_Xol })
                    .AddPart(new EntityRequirementModel {
                        Name = "Altar of the Worthy", DataType = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Blood Vale", DataType = DataType.BUILDING_RedVale,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 80, Ether = 80, BuildTime = 30 })
                    .AddPart(new EntitySupplyModel { Takes = 4 })
                    .AddPart(new EntityVitalityModel
                        { Energy = 60, Health = 100, DefenseLayer = 40, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 434, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel {
                        Damage = 30, MediumDamage = 40, LightDamage = 50, Range = 80, AttacksPerSecond = 0.714f,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityIdPassiveModel() { Id = DataType.PASSIVE_QuenchingScythes })
            }, 
            {
                DataType.UNIT_RedSeer,
                new EntityModel(DataType.UNIT_RedSeer, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Red Seer", Descriptive = DescriptiveType.Elite_Caster })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityVanguardReplacedModel
                        { ImmortalId = DataType.IMMORTAL_Mala, ReplacedById = DataType.VANGUARD_DreadSister_Mala })
                    .AddPart(new EntityRequirementModel {
                        Name = "Altar of the Worthy", DataType = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Blood Vale", DataType = DataType.BUILDING_RedVale,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 40, Ether = 140, BuildTime = 40 })
                    .AddPart(new EntitySupplyModel { Takes = 3 })
                    .AddPart(new EntityVitalityModel {
                        Energy = 100, Health = 60, DefenseLayer = 75, Defense = DefenseType.Overgrowth,
                        IsEtheric = true, Armor = ArmorType.Light
                    })
                    .AddPart(new EntityMovementModel { Speed = 0, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 9, Range = 700, AttacksPerSecond = 0.798f, Targets = TargetType.Ground })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_BloodPlague })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_DrainingEmbrace })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_AwakenAcaaluk })
            }, {
                DataType.UNIT_Underspine,
                new EntityModel(DataType.UNIT_Underspine, EntityType.Army)
                    .AddPart(new EntityInfoModel
                        { Name = "Underspine", Descriptive = DescriptiveType.Force_Multiplier, Notes = "Has +5 HP regen when burrowed."})
                    .AddPart(new EntityTierModel { Tier = 2 })
                    .AddPart(new EntityVanguardReplacedModel { ImmortalId = DataType.IMMORTAL_Mala, ReplacedById = DataType.VANGUARD_Incubator_Mala })
                    .AddPart(new EntityRequirementModel {
                        Name = "Amber Womb", DataType = DataType.BUILDING_AmberWomb,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 70, Ether = 50, BuildTime = 25 })
                    .AddPart(new EntitySupplyModel { Takes = 3 })
                    .AddPart(new EntityVitalityModel { Health = 140, DefenseLayer = 40, Armor = ArmorType.Medium })
                    .AddPart(new EntityMovementModel { Speed = 350, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 9, Range = 700, SecondsBetweenAttacks = 1.2529f, Targets = 
                        TargetType.All })
                    .AddPart(new EntityWeaponModel
                        { Damage = 9, Range = 600, SecondsBetweenAttacks  = 0.7143f, Targets = 
                        TargetType.Ground })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_DeployMobilizeUnderSpine })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_MobilizeAru })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_OssifyingSwarm })
            }, {
                DataType.UNIT_Ichor,
                new EntityModel(DataType.UNIT_Ichor, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Ichor", Descriptive = DescriptiveType.Harrier })
                    .AddPart(new EntityTierModel { Tier = 2 })
                    .AddPart(new EntityRequirementModel {
                        Name = "Amber Womb", DataType = DataType.BUILDING_AmberWomb,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 95, Ether = 20, BuildTime = 30 })
                    .AddPart(new EntitySupplyModel { Takes = 4 })
                    .AddPart(new EntityVitalityModel { Health = 100, DefenseLayer = 40, Armor = ArmorType.Medium })
                    .AddPart(new EntityMovementModel { Speed = 382, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel {
                        Damage = 13, LightDamage = 32, MediumDamage = 19, Range = 500, AttacksPerSecond = 0.7f,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_DenInstinct })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_PursuitLigaments })
            }, {
                DataType.UNIT_Resinant,
                new EntityModel(DataType.UNIT_Resinant, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Resinant", Descriptive = DescriptiveType.Zone_Control })
                    .AddPart(new EntityTierModel { Tier = 2.5f })
                    .AddPart(new EntityRequirementModel {
                        Name = "Amber Womb", DataType = DataType.BUILDING_AmberWomb,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Neurocyte", DataType = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 150, Ether = 80, BuildTime = 40 })
                    .AddPart(new EntitySupplyModel { Takes = 5 })
                    .AddPart(new EntityVitalityModel { Health = 175, DefenseLayer = 60, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 350, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel {
                        Damage = 25, MediumDamage = 40, HeavyDamage = 55, Range = 800, AttacksPerSecond = 0.7f,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityWeaponModel {
                        Damage = 50, MediumDamage = 60, HeavyDamage = 70, Range = 1000, AttacksPerSecond = 0.467f,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_ResinantDeploy })
                    .AddPart(new EntityIdAbilityModel { Id = DataType.ABILITY_MobilizeAru })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_EngorgedArteries })
            }, {
                DataType.UNIT_Aarox,
                new EntityModel(DataType.UNIT_Aarox, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Aarox", Descriptive = DescriptiveType.Air_Superiority })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityRequirementModel {
                        Name = "Bone Canopy", DataType = DataType.BUILDING_BoneCanopy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Neurocyte", DataType = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 40, Ether = 40, BuildTime = 30 })
                    .AddPart(new EntitySupplyModel { Takes = 2 })
                    .AddPart(new EntityVitalityModel { Health = 35, DefenseLayer = 10, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 532, Movement = MovementType.Air })
                    .AddPart(new EntityWeaponModel
                        { LightDamage = 75, MediumDamage = 100, HeavyDamage = 125,Range = 20, AttacksPerSecond = 1, Targets = 
                        TargetType.Air })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_AaroxBurn })
            }, {
                DataType.UNIT_Thrum,
                new EntityModel(DataType.UNIT_Thrum, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Thrum", Descriptive = DescriptiveType.Harrier })
                    .AddPart(new EntityTierModel { Tier = 3 })
                    .AddPart(new EntityRequirementModel {
                        Name = "Bone Canopy", DataType = DataType.BUILDING_BoneCanopy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 80, Ether = 50, BuildTime = 30 })
                    .AddPart(new EntitySupplyModel { Takes = 3 })
                    .AddPart(new EntityVitalityModel { Health = 120, DefenseLayer = 40, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 525, Movement = MovementType.Air })
                    .AddPart(new EntityWeaponModel {
                        Damage = 11, HeavyDamage = 9, Range = 350, AttacksPerSecond = 0.8f, Targets = TargetType.All
                    })
                
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_ThrumAttackSpeed })
            }, {
                DataType.UNIT_WraithBow,
                new EntityModel(DataType.UNIT_WraithBow, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Wraith Bow", Descriptive = DescriptiveType.Air_Denial })
                    .AddPart(new EntityTierModel { Tier = 2 })
                    .AddPart(new EntityRequirementModel {
                        Name = "Amber Womb", DataType = DataType.BUILDING_AmberWomb,
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
            }, {
                DataType.UNIT_Behemoth,
                new EntityModel(DataType.UNIT_Behemoth, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Behemoth", Descriptive = DescriptiveType.Skirmisher })
                    .AddPart(new EntityTierModel { Tier = 3.5f })
                    .AddPart(new EntityRequirementModel {
                        Name = "Bone Canopy", DataType = DataType.BUILDING_BoneCanopy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Neurocyte", DataType = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "A", HoldSpace = true, HotkeyGroup = "Z" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 190, Ether = 150, BuildTime = 50 })
                    .AddPart(new EntitySupplyModel { Takes = 8 })
                    .AddPart(new EntityVitalityModel { Health = 350, DefenseLayer = 100, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 210, Movement = MovementType.Air })
                    .AddPart(new EntityWeaponModel {
                        Damage = 0, Range = 600, AttacksPerSecond = 0.588f, SecondsBetweenAttacks = 1.7f,
                        Targets = TargetType.Ground
                    })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_BehemothCapacity })
                    .AddPart(new EntityIdPassiveModel { Id = DataType.PASSIVE_SpawnQuitl })
            }, {
                DataType.SUMMON_Quitl,
                new EntityModel(DataType.SUMMON_Quitl, EntityType.Army)
                    .AddPart(new EntityInfoModel { Name = "Quitl", Descriptive = DescriptiveType.Summon })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVitalityModel { Health = 65, Armor = ArmorType.Light })
                    .AddPart(new EntityMovementModel { Speed = 168, Movement = MovementType.Ground })
            },
            // Upgrades
            // Q'Rath
            {
                DataType.UPGRADE_FaithCastBlades,
                new EntityModel(DataType.UPGRADE_FaithCastBlades, EntityType.Tech)
                    .AddPart(new EntityInfoModel {
                        Name = "Faith-Cast Blades", Descriptive = DescriptiveType.Upgrade,
                        Description = "Increases the range of the Zentari's ranged weapon."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 50, Ether = 100, BuildTime = 60 })
                    .AddPart(new EntityRequirementModel {
                        DataType = DataType.BUILDING_Reliquary, Requirement = RequirementType.Production_Building,
                        Name = "Reliquary"
                    })
            }, {
                DataType.UPGRADE_RelicOfTheWrathfulGaze,
                new EntityModel(DataType.UPGRADE_RelicOfTheWrathfulGaze, EntityType.Tech)
                    .AddPart(new EntityInfoModel {
                        Name = "Relic Of The Wrathful Gaze", Descriptive = DescriptiveType.Upgrade,
                        Description = "Increases the Castigator's anti-air weapon range."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "TAB", HoldSpace = true })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 75, Ether = 75, BuildTime = 29 })
                    .AddPart(new EntityRequirementModel {
                        DataType = DataType.BUILDING_HouseOfFadingSaints,
                        Requirement = RequirementType.Production_Building, Name = "House of Fading Saints"
                    })
            }, {
                DataType.UPGRADE_WindStep,
                new EntityModel(DataType.UPGRADE_WindStep, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                        { Name = "Windstep", Descriptive = DescriptiveType.Upgrade, Description = "Unlocks windstep." })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 50, Ether = 75, BuildTime = 55 })
                    .AddPart(new EntityRequirementModel {
                        DataType = DataType.BUILDING_Reliquary, Requirement = RequirementType.Production_Building,
                        Name = "Reliquary"
                    })
            }, {
                DataType.UPGRADE_ZephyrRange,
                new EntityModel(DataType.UPGRADE_ZephyrRange, EntityType.Tech)
                    .AddPart(new EntityInfoModel {
                        Name = "Zephyr Range", Descriptive = DescriptiveType.Upgrade,
                        Description = "Increases Zephyr's range by 100."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 150, Ether = 100, BuildTime = 43 })
                    .AddPart(new EntityRequirementModel {
                        DataType = DataType.BUILDING_Reliquary, Requirement = RequirementType.Production_Building,
                        Name = "Reliquary"
                    })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_WindStep })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_ZephyrRange })
            }, {
                DataType.UPGRADE_SiroccoScript,
                new EntityModel(DataType.UPGRADE_SiroccoScript, EntityType.Tech)
                    .AddPart(new EntityInfoModel {
                        Name = "Sirocco Script", Descriptive = DescriptiveType.Upgrade,
                        Description = "Increases the Dervish's movement speed by 50%."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 75, Ether = 100, BuildTime = 60 })
                    .AddPart(new EntityRequirementModel {
                        DataType = DataType.BUILDING_HouseOfFadingSaints,
                        Requirement = RequirementType.Production_Building, Name = "House of Fading Saints"
                    })
            }, {
                DataType.UPGRADE_IconOfKhastEem,
                new EntityModel(DataType.UPGRADE_IconOfKhastEem, EntityType.Tech)
                    .AddPart(new EntityInfoModel {
                        Name = "Icon of Khast'Eem", Descriptive = DescriptiveType.Upgrade,
                        Description = "Grants the Zentari shields and flat armor reduction."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HoldSpace = true, HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 100, BuildTime = 43 })
                    .AddPart(new EntityRequirementModel {
                        DataType = DataType.BUILDING_EyeOfAros, Requirement = RequirementType.Production_Building,
                        Name = "Eye of Aros"
                    })
            }, {
                DataType.UPGRADE_BladesOfTheGodhead,
                new EntityModel(DataType.UPGRADE_BladesOfTheGodhead, EntityType.Tech)
                    .AddPart(new EntityInfoModel {
                        Name = "Blades of the Godhead", Descriptive = DescriptiveType.Upgrade,
                        Description = "Unlocks Blades of the Godhead"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "A", HoldSpace = true, HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 75, BuildTime = 45 })
                    .AddPart(new EntityRequirementModel {
                        DataType = DataType.BUILDING_BearerOfTheCrown,
                        Requirement = RequirementType.Production_Building, Name = "Bearer of the Crown"
                    })
            }, {
                DataType.UPGRADE_WingsOfTheKenLatir,
                new EntityModel(DataType.UPGRADE_WingsOfTheKenLatir, EntityType.Tech)
                    .AddPart(new EntityInfoModel {
                        Name = "Wings of the Ken'Latir", Descriptive = DescriptiveType.Upgrade,
                        Description = "Increases the Warden's speed and shields significantly."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HoldSpace = true, HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 150, Ether = 100, BuildTime = 30 })
                    .AddPart(new EntityRequirementModel {
                        DataType = DataType.BUILDING_BearerOfTheCrown,
                        Requirement = RequirementType.Production_Building, Name = "Bearer of the Crown"
                    })
            },
            // Upgrades
            // Aru
            {
                DataType.UPGRADE_Offering,
                new EntityModel(DataType.UPGRADE_Offering, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                        { Name = "Offering", Descriptive = DescriptiveType.Upgrade, Description = "Unlocks Offering" })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel {
                        Name = "Altar of Worthy", DataType = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Neurocyte", DataType = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 80, BuildTime = 60 })
            }, {
                DataType.UPGRADE_BloodMothersFevor,
                new EntityModel(DataType.UPGRADE_BloodMothersFevor, EntityType.Tech)
                    .AddPart(new EntityInfoModel
                        { Name = "Blood Mother's Fevor", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "V", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel {
                        Name = "Amber Womb", DataType = DataType.BUILDING_AmberWomb,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Neurocyte", DataType = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 150, BuildTime = 80 })
            }, {
                DataType.UPGRADE_DenInstinct,
                new EntityModel(DataType.UPGRADE_DenInstinct, EntityType.Tech)
                    .AddPart(new EntityInfoModel { Name = "Den Instinct", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel {
                        Name = "Neurocyte", DataType = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 120, BuildTime = 45 })
            }, {
                DataType.UPGRADE_PursuitLigaments,
                new EntityModel(DataType.UPGRADE_PursuitLigaments, EntityType.Tech)
                    .AddPart(new EntityInfoModel { Name = "Pursuit Ligaments", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel {
                        Name = "Neurocyte", DataType = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 75, Ether = 100, BuildTime = 45 })
            }, {
                DataType.UPGRADE_ResinantDeploy,
                new EntityModel(DataType.UPGRADE_ResinantDeploy, EntityType.Tech)
                    .AddPart(new EntityInfoModel { Name = "Resinant Deploy", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel {
                        Name = "Neurocyte", DataType = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Amber Womb", DataType = DataType.BUILDING_AmberWomb,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 50, Ether = 100, BuildTime = 43 })
            }, {
                DataType.UPGRADE_XacalDamage,
                new EntityModel(DataType.UPGRADE_XacalDamage, EntityType.Tech)
                    .AddPart(new EntityInfoModel { Name = "Xacal Damage", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "TAB" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel {
                        Name = "Neurocyte", DataType = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 100, Ether = 75, BuildTime = 60 })
            }, {
                DataType.UPGRADE_BehemothCapacity,
                new EntityModel(DataType.UPGRADE_BehemothCapacity, EntityType.Tech)
                    .AddPart(new EntityInfoModel { Name = "Behemoth Capacity", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "A", HotkeyGroup = "TAB", HoldSpace = true })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel {
                        Name = "Deep Nest", DataType = DataType.BUILDING_DeepNest,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 150, Ether = 150, BuildTime = 46 })
            }, {
                DataType.UPGRADE_WraithBow,
                new EntityModel(DataType.UPGRADE_WraithBow, EntityType.Tech)
                    .AddPart(new EntityInfoModel { Name = "Wraith Bow", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "TAB", HoldSpace = true })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel {
                        Name = "Neurocyte", DataType = DataType.BUILDING_Neurocyte,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 50, Ether = 75, BuildTime = 29 })
                    .AddPart(new EntityIdUpgradeModel { Id = DataType.UPGRADE_WraithBow })
            }, {
                DataType.UPGRADE_BloodPlague,
                new EntityModel(DataType.UPGRADE_BloodPlague, EntityType.Tech)
                    .AddPart(new EntityInfoModel {
                        Name = "Blood Plague", Descriptive = DescriptiveType.Upgrade,
                        Description = "Unlocks Blood Plague"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "TAB", HoldSpace = true })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel {
                        Name = "Blood Vale", DataType = DataType.BUILDING_RedVale,
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
                    .AddPart(new EntityRequirementModel {
                        Name = "Blood Vale", DataType = DataType.BUILDING_RedVale,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel { Alloy = 75, Ether = 120, BuildTime = 80 })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Mala, ReplaceId = DataType.ABILITY_BloodPlague })
            },


            // Passives
            // Q'Rath Passives
            {
                DataType.PASSIVE_MendingCommand,
                new EntityModel(DataType.PASSIVE_MendingCommand, EntityType.Passive)
                    .AddPart(new EntityInfoModel {
                        Name = "Mending Command", Descriptive = DescriptiveType.Ability,
                        Description = @"Autocast ability that heals 48 life and 24 shields over 2 seconds."
                    })
                    .AddPart(new EntityProductionModel{ Pyre = 10, Cooldown = 3})
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            }, 
            {
                DataType.PASSIVE_StabilizeHallowedGround,
                new EntityModel(DataType.PASSIVE_StabilizeHallowedGround, EntityType.Passive)
                    .AddPart(new EntityInfoModel {
                        Name = "Stabilize Hallowed Ground", Descriptive = DescriptiveType.Ability,
                        Description = @"Generates Hallowed Ground on Stabilized"
                    }) //TODO Add a glossary of terms like for Stabilized
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },
            {
                DataType.PASSIVE_GodstoneBulwark,
                new EntityModel(DataType.PASSIVE_GodstoneBulwark, EntityType.Passive)
                    .AddPart(new EntityInfoModel {
                        Name = "Godstone Bulkwark", Descriptive = DescriptiveType.Ability,
                        Description = @"Grants +1 damage reduction."
                    }) 
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },
            
            {
                DataType.PASSIVE_Invervention,
                new EntityModel(DataType.PASSIVE_Invervention, EntityType.Passive)
                    .AddPart(new EntityInfoModel {
                        Name = "Intervention", Descriptive = DescriptiveType.Ability,
                        Description = @"The Saoshin releases healing energy. Allied units nearby heal over several seconds. This automatically activates when the Saoshin drops below 70 HP."
                    }) 
                    .AddPart(new EntityProductionModel { Pyre = 70, Cooldown = 5})
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            },
            // Passives
            // Aru Passives
            {
                DataType.PASSIVE_XacalDamage,
                new EntityModel(DataType.PASSIVE_XacalDamage, EntityType.Passive)
                    .AddPart(new EntityInfoModel {
                        Name = "Xacal Damage", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Xacal builds up charges for double damage overtime. These charges can be spent on attacking."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },
            {
                DataType.PASSIVE_OssifyingSwarm,
                new EntityModel(DataType.PASSIVE_OssifyingSwarm, EntityType.Passive)
                    .AddPart(new EntityInfoModel {
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
                    .AddPart(new EntityInfoModel {
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
                    .AddPart(new EntityInfoModel {
                        Name = "Quenching Scythes", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Recovers 5 life when dealing damage, or 10 mana if life is full."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },
            
            {
                DataType.PASSIVE_EngorgedArteries,
                new EntityModel(DataType.PASSIVE_EngorgedArteries, EntityType.Passive)
                    .AddPart(new EntityInfoModel {
                        Name = "Engorged Arteries", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Grants +2 range when deployed on rootway."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },
            
            {
                DataType.PASSIVE_ProjectileGestation,
                new EntityModel(DataType.PASSIVE_ProjectileGestation, EntityType.Passive)
                    .AddPart(new EntityInfoModel {
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
                    .AddPart(new EntityInfoModel {
                        Name = "Guiding Amber", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Units hit by this attack takes +1 damage for a few seconds, to a maximum of +4."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },
            
            {
                DataType.PASSIVE_SpawnQuitl,
                new EntityModel(DataType.PASSIVE_SpawnQuitl, EntityType.Passive)
                    .AddPart(new EntityInfoModel {
                        Name = "Spawn Quitl", Descriptive = DescriptiveType.Ability,
                        Description = @"Unit spawns Quitl on attack."
                    })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            },

            // Abilities
            // Q'Rath
            {
                DataType.ABILITY_BladesOfTheGodhead,
                new EntityModel(DataType.ABILITY_BladesOfTheGodhead, EntityType.Ability)
                    .AddPart(new EntityInfoModel {
                        Name = "Blades of the Godhead", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"The Throne loses some of its shields and fires all four of its swords at the target location to <b style=""color:orange"">deal damage</b> in a small area of effect. This only affects ground units."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Cooldown = 40 })
            }, {
                DataType.ABILITY_Windstep,
                new EntityModel(DataType.ABILITY_Windstep, EntityType.Ability)
                    .AddPart(new EntityInfoModel {
                        Name = "Windstep", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"The Zephyr <b style=""color: skyblue"">teleports</b> toward target location, draining shields. Windstepping into <b>Halled Ground</b> restores shields instead."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Cooldown = 20 })
            }, {
                DataType.ABILITY_Leap,
                new EntityModel(DataType.ABILITY_Leap, EntityType.Ability)
                    .AddPart(new EntityInfoModel {
                        Name = "Leap", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"The Saoshin leaps to the target location. If she has enough mana, she activates Intervention upon landing."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "V", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Cooldown = 5, Energy = 70 })
            }, {
                DataType.ABILITY_OrdainedPassage,
                new EntityModel(DataType.ABILITY_OrdainedPassage, EntityType.Ability)
                    .AddPart(new EntityInfoModel {
                        Name = "Intervention", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Creates a large area that grants <b style=""color:lime"">significant damage reduction</b> to friendly ground troops within. Reduces the Ark Mother's shields to 0 when used."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "D", HoldSpace = true })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Cooldown = 5, Energy = 75 })
            }, {
                DataType.ABILITY_DeployAbsolver,
                new EntityModel(DataType.ABILITY_DeployAbsolver, EntityType.Ability)
                    .AddPart(new EntityInfoModel {
                        Name = "Deploy Absolver", Descriptive = DescriptiveType.Ability,
                        Description =
                            @"Deploying the Absolver drastically <b style=""color: orange"">increases its attack speed</b>."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "V", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
            }, {
                DataType.ABILITY_DeployMagi,
                new EntityModel(DataType.ABILITY_DeployMagi, EntityType.Ability)
                    .AddPart(new EntityInfoModel {
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
                    .AddPart(new EntityInfoModel {
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
                    .AddPart(new EntityInfoModel {
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
                DataType.ABILITY_Offering,
                new EntityModel(DataType.ABILITY_Offering, EntityType.Ability)
                    .AddPart(new EntityInfoModel {
                        Name = "Offering", Descriptive = DescriptiveType.Ability,
                        Description =
                            "Sacrifices 10 life to increase range, speed, and attack speed for several seconds."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            }, {
                DataType.ABILITY_DiveBomb,
                new EntityModel(DataType.ABILITY_DiveBomb, EntityType.Ability)
                    .AddPart(new EntityInfoModel {
                        Name = "Dive Bomb", Descriptive = DescriptiveType.Ability,
                        Description =
                            "The aarox dives down into the ground, dealing damage in a smaller area. Non-hovering units in the area take additional damage over time."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            }, {
                DataType.ABILITY_CullingStrike,
                new EntityModel(DataType.ABILITY_CullingStrike, EntityType.Ability)
                    .AddPart(new EntityInfoModel {
                        Name = "Culling Strike", Descriptive = DescriptiveType.Ability,
                        Description =
                            "Teleports to target location, and deals massive damage to the nearest ground unit."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Energy = 40, Cooldown = 3 })
            }, {
                DataType.ABILITY_LethalBond,
                new EntityModel(DataType.ABILITY_LethalBond, EntityType.Ability)
                    .AddPart(new EntityInfoModel {
                        Name = "Lethal Bond", Descriptive = DescriptiveType.Ability,
                        Description =
                            "After a short delay, enemy units in the target area receive a debuff which causes them to take double damage from all attacks for a duration."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "D" })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Xol, ReplaceId = DataType.ABILITY_CullingStrike })
                    .AddPart(new EntityProductionModel { Energy = 40 })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            }, {
                DataType.ABILITY_DrainingEmbrace,
                new EntityModel(DataType.ABILITY_DrainingEmbrace, EntityType.Ability)
                    .AddPart(new EntityInfoModel {
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
                    .AddPart(new EntityInfoModel {
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
                    .AddPart(new EntityInfoModel {
                        Name = "Deploy Resinant", Descriptive = DescriptiveType.Ability,
                        Description = "Deploying the Resinant enables it to deal area of effect damage at long range."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "V", HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            }, 
            {
                DataType.ABILITY_DeployMobilizeUnderSpine,
                new EntityModel(DataType.ABILITY_DeployMobilizeUnderSpine, EntityType.Ability)
                    .AddPart(new EntityInfoModel {
                        Name = "Deploy Underspine", Descriptive = DescriptiveType.Ability,
                        Description =
                            "Burrow into the ground to generate rootway and attack air units. Enemies near your attack target will be slowed for a short duration."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HoldSpace = true, HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
            }, {
                DataType.ABILITY_RootVice,
                new EntityModel(DataType.ABILITY_RootVice, EntityType.Ability)
                    .AddPart(new EntityInfoModel {
                        Name = "Root Vice", Descriptive = DescriptiveType.Ability,
                        Description =
                            "Roots all units for several seconds, then leaves them slowed for several seconds after."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "D" })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Mala })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Energy = 50, Cooldown = 10 })
            }, {
                DataType.ABILITY_BirthingStorm,
                new EntityModel(DataType.ABILITY_BirthingStorm, EntityType.Ability)
                    .AddPart(new EntityInfoModel {
                        Name = "Birthing Storm", Descriptive = DescriptiveType.Ability,
                        Description =
                            "Deals damage over time in an area and marks affected units for several seconds. Units that die while marked spawn a quitl.",
                        Notes = "Deals 20 damage + 15% of max life of the target immediately upon affecting the enemy unit. It deals the same damage again after 8 seconds. If the unit dies during those 8 seconds (including the final burst), spawns 1 quitl every 2 supply of the dead unit, rounded up"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "D" })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Mala })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Energy = 80, Cooldown = 2 })
            }, {
                DataType.ABILITY_SummonSiegeMaw,
                new EntityModel(DataType.ABILITY_SummonSiegeMaw, EntityType.Ability)
                    .AddPart(new EntityInfoModel {
                        Name = "Summon Siege Maw", Descriptive = DescriptiveType.Dislodger,
                        Description = "Summons a temporary long-range siege structure at the target location."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HoldSpace = true, HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Mala, ReplaceId = DataType.UNIT_Acaaluk })
                    .AddPart(new EntityProductionModel { Energy = 80, BuildTime = 4, Cooldown = 20 })
                    .AddPart(new EntitySupplyModel { Takes = 0 })
                    .AddPart(new EntityRequirementModel { Name = "Red Seer", DataType = DataType.UNIT_RedSeer })
                    .AddPart(new EntityVitalityModel { Health = 300, DefenseLayer = 100, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 0, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel {
                        Damage = 40, Range = 1300, Targets = TargetType.Ground, MediumDamage = 50, 
                        HeavyDamage = 60
                    })
            }, {
                DataType.ABILITY_AwakenAcaaluk,
                new EntityModel(DataType.ABILITY_AwakenAcaaluk, EntityType.Ability)
                    .AddPart(new EntityInfoModel {
                        Name = "Awaken Acaaluk", Descriptive = DescriptiveType.Dislodger,
                        Description = "The red seer is sacrificed to create an acaaluk."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HoldSpace = true, HotkeyGroup = "D" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 100, BuildTime = 25 })
                    .AddPart(new EntitySupplyModel { Takes = 6 })
                    .AddPart(new EntityRequirementModel
                        { Name = "Red Seer", DataType = DataType.UNIT_RedSeer, Requirement = RequirementType.Morph })
                    .AddPart(new EntityVitalityModel { Health = 200, DefenseLayer = 60, Armor = ArmorType.Heavy })
                    .AddPart(new EntityMovementModel { Speed = 210, Movement = MovementType.Ground })
                    .AddPart(new EntityWeaponModel
                        { Damage = 125, Range = 1500, AttacksPerSecond = 0.175f, Targets = TargetType.Ground })
            },
            // Pyre Spells
            // Q'Rath
            {
                DataType.ISPELL_SummonCitadel,
                new EntityModel(DataType.ISPELL_SummonCitadel, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel {
                        Name = "Summon Citadel",
                        Description = "Creates a powerful defensive structure on a Tower Foundation."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Pyre = 75, BuildTime = 70 })
                    .AddPart(new EntityVitalityModel
                        { Health = 1000, DefenseLayer = 500, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityWeaponModel {
                        Damage = 20, Range = 800, AttacksPerSecond = 1.124f, Targets = TargetType.All,
                        MediumDamage = 25, HeavyDamage = 30
                    })
            }, {
                DataType.ISPELL_PillarOfHeaven,
                new EntityModel(DataType.ISPELL_PillarOfHeaven, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel {
                        Name = "Pillar of Heavens",
                        Description =
                            @"Summons a powerful monument that slams into the ground to <b style=""color:orange"">deal damage</b> to enemy ground units (and takes damage from everything it lands on). It then creates <b style=""color:white"">Hallowed Ground</b> and nearby friendly units <b style=""color:orange"">gain Attack Speed<b>"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Orzum })
                    .AddPart(new EntityProductionModel { Pyre = 100, Cooldown = 15 })
            }, {
                DataType.ISPELL_EmpireUnbroken,
                new EntityModel(DataType.ISPELL_EmpireUnbroken, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel {
                        Name = "Empire Unbroken",
                        Description =
                            @"Structures in target area <b style=""color:lime"">reduce incoming damage significantly</b> for several seconds."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath  })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Orzum })
                    .AddPart(new EntityProductionModel { Pyre = 50, Cooldown = 15 })
            }, {
                DataType.ISPELL_InfuseTroops,
                new EntityModel(DataType.ISPELL_InfuseTroops, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel {
                        Name = "Infuse Troops",
                        Description =
                            @"Allied units in a large area <b style=""color:skyblue"">gain Movement Speed</b> and <b style=""color:orange"">gain Attack Speed</b> for several seconds."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Any })
                    .AddPart(new EntityProductionModel { Pyre = 75, Cooldown = 20 })
            }, {
                DataType.ISPELL_DeliverFromEvil,
                new EntityModel(DataType.ISPELL_DeliverFromEvil, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel {
                        Name = "Deliver from Evil",
                        Description =
                            @"Units in the area <b style=""gain bonus shields"">. After a short delay, allied units in teh area <b style=""color:skyblue"">teleport to your nearest Town Hall</b>."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Ajari })
                    .AddPart(new EntityProductionModel { Pyre = 50, Cooldown = 60 })
            }, {
                DataType.ISPELL_HeavensAegis,
                new EntityModel(DataType.ISPELL_HeavensAegis, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel {
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
                    .AddPart(new EntityInfoModel {
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
            }, {
                DataType.ISPELL_ConstructBloodWell,
                new EntityModel(DataType.ISPELL_ConstructBloodWell, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel {
                        Name = "Construct Blood Well",
                        Description =
                            "Creates a rootway generating structure that heals nearby allied units, and transfers it's blood to nearby allied units."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Pyre = 50, Cooldown = 21 })
            }, {
                DataType.ISPELL_RedTithe,
                new EntityModel(DataType.ISPELL_RedTithe, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel {
                        Name = "Red Tithe",
                        Description = "Sacrifice target unit to create an area that regenerates life and mana."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "1" })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Mala })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Pyre = 40, Cooldown = 60 })
            }, {
                DataType.ISPELL_RainOfBlood,
                new EntityModel(DataType.ISPELL_RainOfBlood, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel {
                        Name = "Rain of Blood",
                        Description = "Massively increases life, shield and mana regeneration for 30 seconds."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "1" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVanguardAddedModel { ImmortalId = DataType.IMMORTAL_Mala })
                    .AddPart(new EntityProductionModel { Pyre = 130, Cooldown = 30 })
            }, {
                DataType.ISPELL_GreatHunt,
                new EntityModel(DataType.ISPELL_GreatHunt, EntityType.Pyre_Spell)
                    .AddPart(new EntityInfoModel { Name = "Great Hunt" })
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
                    .AddPart(new EntityInfoModel {
                        Name = "Acropolis", Descriptive = DescriptiveType.Town_Hall,
                        Description = "Town Hall (Structure) - Necessary for collecting Alloy and Ether."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel
                        { Alloy = 350, BuildTime = 100, RequiresWorker = true, ConsumesWorker = true })
                    .AddPart(new EntityVitalityModel
                        { Health = 1600, DefenseLayer = 800, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityHarvestModel {
                        HarvestedPerInterval = 1, RequiresWorker = true, Resource = ResourceType.Alloy, Slots = 2,
                        TotalAmount = 3600
                    })
            }, {
                DataType.BUPGRADE_MiningLevel2_QRath,
                new EntityModel(DataType.BUPGRADE_MiningLevel2_QRath, EntityType.Building_Upgrade)
                    .AddPart(new EntityInfoModel {
                        Name = "Mining Level 2", Descriptive = DescriptiveType.Upgrade,
                        Description = "Upgrades the nearest resource cluster to allow more workers to mine from it."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "CONTROL" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityRequirementModel {
                        Name = "Acropolis", DataType = DataType.BUILDING_Acropolis, Requirement = RequirementType.Morph
                    })
                    .AddPart(new EntityProductionModel { Alloy = 75, BuildTime = 20, RequiresWorker = false })
                    .AddPart(new EntityHarvestModel {
                        HarvestedPerInterval = 1, RequiresWorker = true, Resource = ResourceType.Alloy, Slots = 2,
                        TotalAmount = 3600
                    })
            }, {
                DataType.BUPGRADE_MiningLevel3_QRath,
                new EntityModel(DataType.BUPGRADE_MiningLevel3_QRath, EntityType.Building_Upgrade)
                    .AddPart(new EntityInfoModel {
                        Name = "Mining Level 3", Descriptive = DescriptiveType.Upgrade,
                        Description = "Upgrades the nearest resource cluster to allow more workers to mine from it."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "CONTROL" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityRequirementModel {
                        Name = "Mining Level 2", DataType = DataType.BUPGRADE_MiningLevel2_QRath,
                        Requirement = RequirementType.Morph
                    })
                    .AddPart(new EntityProductionModel { Alloy = 125, BuildTime = 20, RequiresWorker = false })
                    .AddPart(new EntityHarvestModel {
                        HarvestedPerInterval = 1, RequiresWorker = true, Resource = ResourceType.Alloy, Slots = 2,
                        TotalAmount = 3600
                    })
            }, {
                DataType.BUILDING_ApostleOfBinding,
                new EntityModel(DataType.BUILDING_ApostleOfBinding, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "Apostle of Binding", Descriptive = DescriptiveType.Ether_Extractor,
                        Description = "Ether Extractor (Structure) - Must be placed on an Ether Node."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "V", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 100, BuildTime = 30, RequiresWorker = true })
                    .AddPart(new EntityVitalityModel
                        { Health = 250, DefenseLayer = 150, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityHarvestModel {
                        HarvestedPerInterval = 1.5625f, RequiresWorker = false, Resource = ResourceType.Ether,
                        Slots = 1, TotalAmount = 1200
                    })
            }, {
                DataType.BUILDING_LegionHall,
                new EntityModel(DataType.BUILDING_LegionHall, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "Legion Hall", Descriptive = DescriptiveType.Production,
                        Description = "Army Production (Structure) - Produces infantry units."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntitySupplyModel { Grants = 16 })
                    .AddPart(new EntityProductionModel { Alloy = 250, BuildTime = 38, RequiresWorker = true })
                    .AddPart(new EntityVitalityModel
                        { Health = 500, DefenseLayer = 500, Armor = ArmorType.Heavy, IsStructure = true })
            }, {
                DataType.DEFENSE_FireSinger,
                new EntityModel(DataType.DEFENSE_FireSinger, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "Fire Singer", Descriptive = DescriptiveType.Defense,
                        Description = "Q'Rath Defensive structure."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel { Alloy = 150, BuildTime = 30, RequiresWorker = true })
                    .AddPart(new EntityRequirementModel {
                        Name = "Legion Hall", DataType = DataType.BUILDING_LegionHall,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 300, DefenseLayer = 300, Armor = ArmorType.Heavy, IsStructure = true })
            }, {
                DataType.BUILDING_Reliquary,
                new EntityModel(DataType.BUILDING_Reliquary, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "Reliquary", Descriptive = DescriptiveType.Research,
                        Description =
                            "Research (Structure) - Unlocks the Zephyr and Magi at the Legion Hall. Contains Legion Hall research."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HoldSpace = true, HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel
                        { Alloy = 150, Ether = 10, BuildTime = 45, RequiresWorker = true })
                    .AddPart(new EntityRequirementModel {
                        Name = "Legion Hall", DataType = DataType.BUILDING_LegionHall,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 550, DefenseLayer = 550, Armor = ArmorType.Heavy, IsStructure = true })
            }, {
                DataType.BUILDING_SoulFoundry,
                new EntityModel(DataType.BUILDING_SoulFoundry, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "Soul Foundry", Descriptive = DescriptiveType.Production,
                        Description = "Army Production (Structure) - Produces advanced ground units."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel
                        { Alloy = 250, Ether = 80, BuildTime = 45, RequiresWorker = true })
                    .AddPart(new EntitySupplyModel { Grants = 16 })
                    .AddPart(new EntityRequirementModel {
                        Name = "Legion Hall", DataType = DataType.BUILDING_LegionHall,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 450, DefenseLayer = 450, Armor = ArmorType.Heavy, IsStructure = true })
            }, {
                DataType.BUILDING_HouseOfFadingSaints,
                new EntityModel(DataType.BUILDING_HouseOfFadingSaints, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "House of the Fading Saints", Descriptive = DescriptiveType.Research,
                        Description = "Research (Structure) - Has tech for the Soul Foundry. Unlocks Hallower."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HoldSpace = true, HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel
                        { Alloy = 175, Ether = 200, BuildTime = 52, RequiresWorker = true })
                    .AddPart(new EntityRequirementModel {
                        Name = "Soul Foundry", DataType = DataType.BUILDING_SoulFoundry,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 1600, DefenseLayer = 800, Armor = ArmorType.Heavy, IsStructure = true })
            }, {
                DataType.BUILDING_Angelarium,
                new EntityModel(DataType.BUILDING_Angelarium, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "Angelarium", Descriptive = DescriptiveType.Production,
                        Description = "Army Production (Structure) - Produces flying units"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel
                        { Alloy = 250, Ether = 80, BuildTime = 48, RequiresWorker = true })
                    .AddPart(new EntitySupplyModel { Grants = 16 })
                    .AddPart(new EntityRequirementModel {
                        Name = "Soul Foundry", DataType = DataType.BUILDING_SoulFoundry,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 1600, DefenseLayer = 800, Armor = ArmorType.Heavy, IsStructure = true })
            }, {
                DataType.BUILDING_EyeOfAros,
                new EntityModel(DataType.BUILDING_EyeOfAros, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "Eye of Aros", Descriptive = DescriptiveType.Research,
                        Description = "Research (Structure) - Unlocks the Shar'U and some late-game Q'Rath upgrades."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HoldSpace = true, HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel
                        { Alloy = 200, Ether = 200, BuildTime = 36, RequiresWorker = true })
                    .AddPart(new EntityRequirementModel {
                        Name = "Angelarium", DataType = DataType.BUILDING_Angelarium,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 500, DefenseLayer = 500, Armor = ArmorType.Heavy, IsStructure = true })
            }, {
                DataType.BUILDING_BearerOfTheCrown,
                new EntityModel(DataType.BUILDING_BearerOfTheCrown, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "Bearer of the Crown", Descriptive = DescriptiveType.Research,
                        Description = "Research (Structure) - Unlocks the Throne and researches for Angelarium."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HoldSpace = true, HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.QRath })
                    .AddPart(new EntityProductionModel
                        { Alloy = 250, Ether = 200, BuildTime = 52, RequiresWorker = true })
                    .AddPart(new EntityRequirementModel {
                        Name = "Angelarium", DataType = DataType.BUILDING_Angelarium,
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
                    .AddPart(new EntityInfoModel {
                        Name = "Grove Heart", Descriptive = DescriptiveType.Town_Hall,
                        Description = "Town Hall (Structure) - Necessary for collection Alloy and Ether."
                    }) //TODO: Add Alloy, Ether and Pyre, Supply to the database
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 350, BuildTime = 100, RequiresWorker = true })
                    .AddPart(new EntityVitalityModel {
                        Health = 2000, DefenseLayer = 400, Defense = DefenseType.Overgrowth, Armor = ArmorType.Heavy,
                        IsStructure = true
                    })
                    .AddPart(new EntityHarvestModel {
                        HarvestedPerInterval = 1, RequiresWorker = true, Resource = ResourceType.Alloy, Slots = 2,
                        TotalAmount = 3600
                    })
            }, {
                DataType.BUPGRADE_GodHeart,
                new EntityModel(DataType.BUPGRADE_GodHeart, EntityType.Building_Upgrade)
                    .AddPart(new EntityInfoModel { Name = "God Heart", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "CONTROL" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityVitalityModel
                        { Health = 2150, DefenseLayer = 450, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityRequirementModel {
                        Name = "Grove Heart", DataType = DataType.STARTING_TownHall_Aru,
                        Requirement = RequirementType.Morph
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "Altar of the Worthy", DataType = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityProductionModel
                        { Alloy = 100, Ether = 75, BuildTime = 36, RequiresWorker = false })
            }, {
                DataType.BUPGRADE_MiningLevel2_Aru,
                new EntityModel(DataType.BUPGRADE_MiningLevel2_Aru, EntityType.Building_Upgrade)
                    .AddPart(new EntityInfoModel {
                        Name = "Mining Level 2", Descriptive = DescriptiveType.Upgrade,
                        Description = "Upgrades the nearest resource cluster to allow more workers to mine from it."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "CONTROL" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel {
                        Name = "Grove Heart", DataType = DataType.BUILDING_GroveHeart,
                        Requirement = RequirementType.Morph
                    })
                    .AddPart(new EntityProductionModel { Alloy = 75, BuildTime = 20, RequiresWorker = false })
                    .AddPart(new EntityHarvestModel {
                        HarvestedPerInterval = 1, RequiresWorker = true, Resource = ResourceType.Alloy, Slots = 2,
                        TotalAmount = 3600
                    })
            }, {
                DataType.BUPGRADE_MiningLevel3_Aru,
                new EntityModel(DataType.BUPGRADE_MiningLevel3_Aru, EntityType.Building_Upgrade)
                    .AddPart(new EntityInfoModel {
                        Name = "Mining Level 3", Descriptive = DescriptiveType.Upgrade,
                        Description = "Upgrades the nearest resource cluster to allow more workers to mine from it."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "CONTROL" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel {
                        Name = "Mining Level 2", DataType = DataType.BUPGRADE_MiningLevel2_Aru,
                        Requirement = RequirementType.Morph
                    })
                    .AddPart(new EntityProductionModel { Alloy = 125, BuildTime = 20, RequiresWorker = false })
                    .AddPart(new EntityHarvestModel {
                        HarvestedPerInterval = 1, RequiresWorker = true, Resource = ResourceType.Alloy, Slots = 2,
                        TotalAmount = 3600
                    })
            }, {
                DataType.BUILDING_EtherMaw,
                new EntityModel(DataType.BUILDING_EtherMaw, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "Ether Maw", Descriptive = DescriptiveType.Ether_Extractor,
                        Description = "Ether Extractor (Structure) - Must be placed on an Ether Node."
                    }) //TODO Add Ether Node to database
                    .AddPart(new EntityHotkeyModel { Hotkey = "V", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 100, BuildTime = 30, RequiresWorker = true })
                    .AddPart(new EntityVitalityModel
                        { Health = 500, DefenseLayer = 0, Armor = ArmorType.Heavy, IsStructure = true })
                    .AddPart(new EntityHarvestModel {
                        HarvestedPerInterval = 1.5625f, RequiresWorker = false, Resource = ResourceType.Ether,
                        Slots = 1, TotalAmount = 1200
                    })
            }, {
                DataType.BUILDING_AltarOfTheWorthy,
                new EntityModel(DataType.BUILDING_AltarOfTheWorthy, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "Altar of the Worthy", Descriptive = DescriptiveType.Production,
                        Description = "Army Production (Structure) - Produces infantry ground units"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntitySupplyModel { Grants = 16 })
                    .AddPart(new EntityProductionModel { Alloy = 250, BuildTime = 36, RequiresWorker = true })
                    .AddPart(new EntityVitalityModel { Health = 1000, Armor = ArmorType.Heavy, IsStructure = true })
            }, {
                DataType.BUILDING_Neurocyte,
                new EntityModel(DataType.BUILDING_Neurocyte, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "Neurocyte", Descriptive = DescriptiveType.Research,
                        Description = "Research (Structure) - Unlocks additional research."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "F", HoldSpace = true, HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel
                        { Alloy = 100, Ether = 75, BuildTime = 30, RequiresWorker = true })
                    .AddPart(new EntityRequirementModel {
                        Name = "Altar of the Worthy", DataType = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 650, DefenseLayer = 150, Armor = ArmorType.Heavy, IsStructure = true })
            }, {
                DataType.DEFENSE_Aerovore,
                new EntityModel(DataType.DEFENSE_Aerovore, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "Aerovore", Descriptive = DescriptiveType.Defense,
                        Description = "Defense Structure - Aru anti-air defense structure."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel { Alloy = 100, BuildTime = 18, RequiresWorker = true })
                    .AddPart(new EntityVitalityModel
                        { Health = 300, DefenseLayer = 50, Armor = ArmorType.Heavy, IsStructure = true })
            }, {
                DataType.BUPGRADE_Omnivore,
                new EntityModel(DataType.BUPGRADE_Omnivore, EntityType.Building_Upgrade)
                    .AddPart(new EntityInfoModel { Name = "Omnivore", Descriptive = DescriptiveType.Upgrade })
                    .AddPart(new EntityHotkeyModel { Hotkey = "Q", HotkeyGroup = "SHIFT" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityRequirementModel {
                        Name = "Aerovore", DataType = DataType.DEFENSE_Aerovore, Requirement = RequirementType.Morph
                    })
                    .AddPart(new EntityProductionModel { Alloy = 50, BuildTime = 18, RequiresWorker = false })
            }, {
                DataType.BUILDING_AmberWomb,
                new EntityModel(DataType.BUILDING_AmberWomb, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "Amber Womb", Descriptive = DescriptiveType.Production,
                        Description = "Army Production (Structure) - Produces advanced ground units"
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "E", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel
                        { Alloy = 250, Ether = 80, BuildTime = 45, RequiresWorker = true })
                    .AddPart(new EntitySupplyModel { Grants = 16 })
                    .AddPart(new EntityRequirementModel {
                        Name = "Altar of the Worthy", DataType = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityRequirementModel {
                        Name = "God Heart", DataType = DataType.BUPGRADE_GodHeart,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityVitalityModel { Health = 1250, Armor = ArmorType.Heavy, IsStructure = true })
            }, {
                DataType.BUILDING_BoneCanopy,
                new EntityModel(DataType.BUILDING_BoneCanopy, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "Bone Canopy", Descriptive = DescriptiveType.Production,
                        Description = "Army Production (Structure) - Aru air production."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel
                        { Alloy = 250, Ether = 80, BuildTime = 36, RequiresWorker = true })
                    .AddPart(new EntitySupplyModel { Grants = 16 })
                    .AddPart(new EntityRequirementModel {
                        Name = "God Heart", DataType = DataType.BUPGRADE_GodHeart,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityVitalityModel { Health = 1250, Armor = ArmorType.Heavy, IsStructure = true })
            }, {
                DataType.BUILDING_RedVale,
                new EntityModel(DataType.BUILDING_RedVale, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "Red Vale", Descriptive = DescriptiveType.Research,
                        Description = "Unlocks the advanced units at the Altar of the Worthy."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "W", HoldSpace = true, HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel
                        { Alloy = 100, Ether = 100, BuildTime = 36, RequiresWorker = true })
                    .AddPart(new EntityRequirementModel {
                        Name = "Altar of the Worthy", DataType = DataType.BUILDING_AltarOfTheWorthy,
                        Requirement = RequirementType.Production_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 800, DefenseLayer = 200, Armor = ArmorType.Heavy, IsStructure = true })
            }, {
                DataType.BUILDING_DeepNest,
                new EntityModel(DataType.BUILDING_DeepNest, EntityType.Building)
                    .AddPart(new EntityInfoModel {
                        Name = "Deep Nest", Descriptive = DescriptiveType.Research,
                        Description = "Unlocks the advanced units and researches at the Bone Canopy."
                    })
                    .AddPart(new EntityHotkeyModel { Hotkey = "R", HoldSpace = true, HotkeyGroup = "C" })
                    .AddPart(new EntityFactionModel { Faction = FactionType.Aru })
                    .AddPart(new EntityProductionModel
                        { Alloy = 175, Ether = 150, BuildTime = 38, RequiresWorker = true })
                    .AddPart(new EntityRequirementModel {
                        Name = "Bone Canopy", DataType = DataType.BUILDING_BoneCanopy,
                        Requirement = RequirementType.Research_Building
                    })
                    .AddPart(new EntityVitalityModel
                        { Health = 850, DefenseLayer = 200, Armor = ArmorType.Heavy, IsStructure = true })
            }
        };
    }
}