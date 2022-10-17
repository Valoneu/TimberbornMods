using HarmonyLib;
using TimberApi.ModSystem;
using TimberApi.ConsoleSystem;
using TimberApi.ConfigSystem;
using Timberborn.Wellbeing;
using System;
using System.Collections.Generic;

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

        [HarmonyPatch(typeof(WellbeingTierService), nameof(WellbeingTierService.Load))]
        public static void Postfix(WellbeingTierService __instance)
        {
            var adultLifeExpectancyList = new adultLifeExpectancyValues(wellbeing, multiplier);
            List<adultLifeExpectancyValues> exampleList = new List<adultLifeExpectancyValues>();
            new adultLifeExpectancyValues(7, 0.2f);

            var adultLifeExpectancy = new WellbeingTierSpecification(
                "BeaverAdult",
                "LifeExpectancy",
                ,
                10,
                0.1f * WellBeingBuffConfig.adultLifeExpectancyMultipler
                );
            var adultMovementSpeed = new WellbeingTierSpecification(
                "BeaverAdult",
                "MovementSpeed",
                ,
                10,
                0.05f * WellBeingBuffConfig.adultMovementSpeedMultipler
                );
            var adultWorkingSpeed = new WellbeingTierSpecification(
                "BeaverAdult",
                "WorkingSpeed",
                ,
                10,
                0.1f * WellBeingBuffConfig.adultWorkingSpeedMultipler
                );
            var golemMovementSpeed = new WellbeingTierSpecification(
                "Golem",
                "MovementSpeed",
                ,
                10,
                0.1f * WellBeingBuffConfig.golemMovementSpeedMultipler
                );
            var golemWorkingSpeed = new WellbeingTierSpecification(
                "Golem",
                "WorkingSpeed",
                ,
                10,
                0.1f * WellBeingBuffConfig.golemWorkingSpeedgMultipler
                );
            var childGrowthSpeed = new WellbeingTierSpecification(
                "BeaverChild",
                "GrowthSpeed",
                ,
                10,
                0.05f * WellBeingBuffConfig.childGrowthSpeedMultipler
                );
            var childLifeExpectancy = new WellbeingTierSpecification(
                "BeaverChild",
                "LifeExpectancy",
                ,
                1,
                0.2f * WellBeingBuffConfig.childLifeExpectancyMultipler
                );
            var childMovementSpeed = new WellbeingTierSpecification(
                "BeaverChild",
                "MovementSpeed",
                ,
                1,
                0.2f * WellBeingBuffConfig.childMovementSpeedMultipler
                );

        }
    }
    public class adultLifeExpectancyValues
    {
        public int WellBeing { get; }
        public float Multiplier { get; }
        public adultLifeExpectancyValues(int wellbeing, float multiplier)
        {
            WellBeing = wellbeing;
            Multiplier = multiplier;
        }
    }
    public class WellBeingBuffConfig : IConfig
    {
        public string ConfigFileName => "WellBeingBuffs";

        public static int adultLifeExpectancyMultipler = 2;
        public static int adultMovementSpeedMultipler = 2;
        public static int adultWorkingSpeedMultipler = 2;
        public static int golemMovementSpeedMultipler = 2;
        public static int golemWorkingSpeedgMultipler = 2;
        public static int childGrowthSpeedMultipler = 2;
        public static int childLifeExpectancyMultipler = 2;
        public static int childMovementSpeedMultipler = 2;
    }
}
