using HarmonyLib;
using TimberApi.ModSystem;
using TimberApi.ConsoleSystem;
using TimberApi.ConfigSystem;
using Timberborn.Wellbeing;
using System;
using System.Collections.Generic;
using Timberborn.Persistence;

namespace WellBeingBuffs
{
    [HarmonyPatch]
    public class WellBeingBuffs : IModEntrypoint
    {
        public static WellBeingBuffConfig Config;

        public void Entry(IMod mod, IConsoleWriter consoleWriter)
        {
            Config = mod.Configs.Get<WellBeingBuffConfig>();
            var harmony = new Harmony("Valoneu.plugins.WellBeingBuff");
            harmony.PatchAll();         
        }
        [HarmonyPatch(typeof(WellbeingTierSpecificationDeserializer), nameof(WellbeingTierSpecificationDeserializer.Deserialize))]
        public static void Postfix(WellbeingTierSpecificationDeserializer __instance, WellbeingTierSpecificationDeserializer __result)
        {
            var bonusesAdultExpectancy = new List<WellbeingTierBonusSpecification>();
            bonusesAdultExpectancy.Add(new WellbeingTierBonusSpecification(7, 0.2f * WellBeingBuffConfig.adultLifeExpectancyMultipler));
            bonusesAdultExpectancy.Add(new WellbeingTierBonusSpecification(17, 0.4f * WellBeingBuffConfig.adultLifeExpectancyMultipler));
            bonusesAdultExpectancy.Add(new WellbeingTierBonusSpecification(27, 0.6f * WellBeingBuffConfig.adultLifeExpectancyMultipler));
            bonusesAdultExpectancy.Add(new WellbeingTierBonusSpecification(37, 0.8f * WellBeingBuffConfig.adultLifeExpectancyMultipler));
            bonusesAdultExpectancy.Add(new WellbeingTierBonusSpecification(47, 1f * WellBeingBuffConfig.adultLifeExpectancyMultipler));
            bonusesAdultExpectancy.Add(new WellbeingTierBonusSpecification(57, 1.2f * WellBeingBuffConfig.adultLifeExpectancyMultipler));
            bonusesAdultExpectancy.Add(new WellbeingTierBonusSpecification(67, 1.4f * WellBeingBuffConfig.adultLifeExpectancyMultipler));
            bonusesAdultExpectancy.Add(new WellbeingTierBonusSpecification(77, 1.6f * WellBeingBuffConfig.adultLifeExpectancyMultipler));
            bonusesAdultExpectancy.Add(new WellbeingTierBonusSpecification(87, 1.8f * WellBeingBuffConfig.adultLifeExpectancyMultipler));
            bonusesAdultExpectancy.Add(new WellbeingTierBonusSpecification(97, 2f * WellBeingBuffConfig.adultLifeExpectancyMultipler));

            var bonusesAdultMovement = new List<WellbeingTierBonusSpecification>();
            bonusesAdultMovement.Add(new WellbeingTierBonusSpecification(2, 0.2f * WellBeingBuffConfig.adultMovementSpeedMultipler));
            bonusesAdultMovement.Add(new WellbeingTierBonusSpecification(12, 0.4f * WellBeingBuffConfig.adultMovementSpeedMultipler));
            bonusesAdultMovement.Add(new WellbeingTierBonusSpecification(22, 0.6f * WellBeingBuffConfig.adultMovementSpeedMultipler));
            bonusesAdultMovement.Add(new WellbeingTierBonusSpecification(32, 0.8f * WellBeingBuffConfig.adultMovementSpeedMultipler));
            bonusesAdultMovement.Add(new WellbeingTierBonusSpecification(42, 1f * WellBeingBuffConfig.adultMovementSpeedMultipler));
            bonusesAdultMovement.Add(new WellbeingTierBonusSpecification(52, 1.2f * WellBeingBuffConfig.adultMovementSpeedMultipler));
            bonusesAdultMovement.Add(new WellbeingTierBonusSpecification(62, 1.4f * WellBeingBuffConfig.adultMovementSpeedMultipler));
            bonusesAdultMovement.Add(new WellbeingTierBonusSpecification(72, 1.6f * WellBeingBuffConfig.adultMovementSpeedMultipler));
            bonusesAdultMovement.Add(new WellbeingTierBonusSpecification(82, 1.8f * WellBeingBuffConfig.adultMovementSpeedMultipler));
            bonusesAdultMovement.Add(new WellbeingTierBonusSpecification(92, 2f * WellBeingBuffConfig.adultMovementSpeedMultipler));

            var bonusesAdultWorking = new List<WellbeingTierBonusSpecification>();
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(5, 0.2f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(10, 0.4f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(15, 0.6f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(20, 0.8f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(25, 1f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(30, 1.2f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(35, 1.4f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(40, 1.6f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(45, 1.8f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(50, 2f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(55, 2.2f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(60, 2.4f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(65, 2.6f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(70, 2.8f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(75, 3f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(80, 3.2f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(85, 3.4f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(90, 3.6f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(95, 3.8f * WellBeingBuffConfig.adultWorkingSpeedMultipler));
            bonusesAdultWorking.Add(new WellbeingTierBonusSpecification(100, 4f * WellBeingBuffConfig.adultWorkingSpeedMultipler));

            var bonusesGolemWorking = new List<WellbeingTierBonusSpecification>();
            bonusesGolemWorking.Add(new WellbeingTierBonusSpecification(0, 0.3f * WellBeingBuffConfig.golemWorkingSpeedMultipler));
            bonusesGolemWorking.Add(new WellbeingTierBonusSpecification(1, 0.9f * WellBeingBuffConfig.golemWorkingSpeedMultipler));
            bonusesGolemWorking.Add(new WellbeingTierBonusSpecification(2, 1.5f * WellBeingBuffConfig.golemWorkingSpeedMultipler));

            var bonusesGolemMovement = new List<WellbeingTierBonusSpecification>();
            bonusesGolemMovement.Add(new WellbeingTierBonusSpecification(0, 0.3f * WellBeingBuffConfig.golemMovementSpeedMultipler));
            bonusesGolemMovement.Add(new WellbeingTierBonusSpecification(1, 0.9f * WellBeingBuffConfig.golemMovementSpeedMultipler));
            bonusesGolemMovement.Add(new WellbeingTierBonusSpecification(2, 1.5f * WellBeingBuffConfig.golemMovementSpeedMultipler));

            var bonusesChildExpectancy = new List<WellbeingTierBonusSpecification>();
            bonusesChildExpectancy.Add(new WellbeingTierBonusSpecification(7, 0.2f * WellBeingBuffConfig.childLifeExpectancyMultipler));
            bonusesChildExpectancy.Add(new WellbeingTierBonusSpecification(17, 0.4f * WellBeingBuffConfig.childLifeExpectancyMultipler));
            bonusesChildExpectancy.Add(new WellbeingTierBonusSpecification(27, 0.6f * WellBeingBuffConfig.childLifeExpectancyMultipler));
            bonusesChildExpectancy.Add(new WellbeingTierBonusSpecification(37, 0.8f * WellBeingBuffConfig.childLifeExpectancyMultipler));
            bonusesChildExpectancy.Add(new WellbeingTierBonusSpecification(47, 1f * WellBeingBuffConfig.childLifeExpectancyMultipler));
            bonusesChildExpectancy.Add(new WellbeingTierBonusSpecification(57, 1.2f * WellBeingBuffConfig.childLifeExpectancyMultipler));
            bonusesChildExpectancy.Add(new WellbeingTierBonusSpecification(67, 1.4f * WellBeingBuffConfig.childLifeExpectancyMultipler));
            bonusesChildExpectancy.Add(new WellbeingTierBonusSpecification(77, 1.6f * WellBeingBuffConfig.childLifeExpectancyMultipler));
            bonusesChildExpectancy.Add(new WellbeingTierBonusSpecification(87, 1.8f * WellBeingBuffConfig.childLifeExpectancyMultipler));
            bonusesChildExpectancy.Add(new WellbeingTierBonusSpecification(97, 2f * WellBeingBuffConfig.childLifeExpectancyMultipler));

            var bonusesChildMovement = new List<WellbeingTierBonusSpecification>();
            bonusesChildMovement.Add(new WellbeingTierBonusSpecification(2, 0.2f * WellBeingBuffConfig.childMovementSpeedMultipler));
            bonusesChildMovement.Add(new WellbeingTierBonusSpecification(12, 0.4f * WellBeingBuffConfig.childMovementSpeedMultipler));
            bonusesChildMovement.Add(new WellbeingTierBonusSpecification(22, 0.6f * WellBeingBuffConfig.childMovementSpeedMultipler));
            bonusesChildMovement.Add(new WellbeingTierBonusSpecification(32, 0.8f * WellBeingBuffConfig.childMovementSpeedMultipler));
            bonusesChildMovement.Add(new WellbeingTierBonusSpecification(42, 1f * WellBeingBuffConfig.childMovementSpeedMultipler));
            bonusesChildMovement.Add(new WellbeingTierBonusSpecification(52, 1.2f * WellBeingBuffConfig.childMovementSpeedMultipler));
            bonusesChildMovement.Add(new WellbeingTierBonusSpecification(62, 1.4f * WellBeingBuffConfig.childMovementSpeedMultipler));
            bonusesChildMovement.Add(new WellbeingTierBonusSpecification(72, 1.6f * WellBeingBuffConfig.childMovementSpeedMultipler));
            bonusesChildMovement.Add(new WellbeingTierBonusSpecification(82, 1.8f * WellBeingBuffConfig.childMovementSpeedMultipler));
            bonusesChildMovement.Add(new WellbeingTierBonusSpecification(92, 2f * WellBeingBuffConfig.childMovementSpeedMultipler));

            var bonusesChildGrowth = new List<WellbeingTierBonusSpecification>();
            bonusesChildGrowth.Add(new WellbeingTierBonusSpecification(2, 0.2f * WellBeingBuffConfig.childGrowthSpeedMultipler));
            bonusesChildGrowth.Add(new WellbeingTierBonusSpecification(12, 0.4f * WellBeingBuffConfig.childGrowthSpeedMultipler));
            bonusesChildGrowth.Add(new WellbeingTierBonusSpecification(22, 0.6f * WellBeingBuffConfig.childGrowthSpeedMultipler));
            bonusesChildGrowth.Add(new WellbeingTierBonusSpecification(32, 0.8f * WellBeingBuffConfig.childGrowthSpeedMultipler));
            bonusesChildGrowth.Add(new WellbeingTierBonusSpecification(42, 1f * WellBeingBuffConfig.childGrowthSpeedMultipler));
            bonusesChildGrowth.Add(new WellbeingTierBonusSpecification(52, 1.2f * WellBeingBuffConfig.childGrowthSpeedMultipler));
            bonusesChildGrowth.Add(new WellbeingTierBonusSpecification(62, 1.4f * WellBeingBuffConfig.childGrowthSpeedMultipler));
            bonusesChildGrowth.Add(new WellbeingTierBonusSpecification(72, 1.6f * WellBeingBuffConfig.childGrowthSpeedMultipler));
            bonusesChildGrowth.Add(new WellbeingTierBonusSpecification(82, 1.8f * WellBeingBuffConfig.childGrowthSpeedMultipler));
            bonusesChildGrowth.Add(new WellbeingTierBonusSpecification(92, 2f * WellBeingBuffConfig.childGrowthSpeedMultipler));

            __result = new WellbeingTierSpecification(
                "BeaverAdult",
                "LifeExpectancy",
                bonusesAdultExpectancy,
                10,
                0.1f * WellBeingBuffConfig.adultLifeExpectancyMultipler
                );
            __result = new WellbeingTierSpecification(
                "BeaverAdult",
                "MovementSpeed",
                bonusesAdultMovement,
                10,
                0.05f * WellBeingBuffConfig.adultMovementSpeedMultipler
                );
            __result = new WellbeingTierSpecification(
                "BeaverAdult",
                "WorkingSpeed",
                bonusesAdultWorking,
                10,
                0.1f * WellBeingBuffConfig.adultWorkingSpeedMultipler
                );
            __result = new WellbeingTierSpecification(
                "Golem",
                "MovementSpeed",
                bonusesGolemMovement,
                10,
                0.1f * WellBeingBuffConfig.golemMovementSpeedMultipler
                );
            __result = new WellbeingTierSpecification(
                "Golem",
                "WorkingSpeed",
                bonusesGolemWorking,
                10,
                0.1f * WellBeingBuffConfig.golemWorkingSpeedMultipler
                );
            __result = new WellbeingTierSpecification(
                "BeaverChild",
                "GrowthSpeed",
                bonusesChildGrowth,
                10,
                0.05f * WellBeingBuffConfig.childGrowthSpeedMultipler
                );
            __result = new WellbeingTierSpecification(
                "BeaverChild",
                "LifeExpectancy",
                bonusesChildExpectancy,
                1,
                0.2f * WellBeingBuffConfig.childLifeExpectancyMultipler
                );
            __result = new WellbeingTierSpecification(
                "BeaverChild",
                "MovementSpeed",
                bonusesChildMovement,
                1,
                0.2f * WellBeingBuffConfig.childMovementSpeedMultipler
                );
        }
    }

    public class WellBeingBuffConfig : IConfig
    {
        public string ConfigFileName => "WellBeingBuffs";

        public static int adultLifeExpectancyMultipler = 2;
        public static int adultMovementSpeedMultipler = 2;
        public static int adultWorkingSpeedMultipler = 2;
        public static int golemMovementSpeedMultipler = 2;
        public static int golemWorkingSpeedMultipler = 2;
        public static int childGrowthSpeedMultipler = 2;
        public static int childLifeExpectancyMultipler = 2;
        public static int childMovementSpeedMultipler = 2;
    }
}
