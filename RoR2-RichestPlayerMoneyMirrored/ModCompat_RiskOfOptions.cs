using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using RiskOfOptions;
using RiskOfOptions.OptionConfigs;
using RiskOfOptions.Options;

namespace RoR2_RichestPlayerMoneyMirrored
{
    public static class ModCompat_RiskOfOptions
    {
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static void Initialize()
        {
            RiskOfOptions.ModSettingsManager.SetModDescription("Mirrors the Richest Player's Money to everyone on stage start.", "com.DestroyedClone.RichestPlayerMoneyMirrored", "Richest Player Money Mirrored");

            ModSettingsManager.AddOption(new CheckBoxOption(Plugin.cfgBazaarOnly));
        }
    }
}
