using BepInEx;
using BepInEx.Configuration;
using System.Security;
using System.Security.Permissions;
using UnityEngine.Networking;

[module: UnverifiableCode]
#pragma warning disable CS0618 // Type or member is obsolete
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

#pragma warning restore CS0618 // Type or member is obsolete


namespace RoR2_RichestPlayerMoneyMirrored
{
    [BepInPlugin("com.DestroyedClone.RichestPlayerMoneyMirrored", "Richest Player Money Mirrored", "1.0.0")]
    [BepInDependency("com.rune580.riskofoptions", BepInDependency.DependencyFlags.SoftDependency)]

    public class Plugin : BaseUnityPlugin
    {
        public static ConfigEntry<bool> cfgBazaarOnly;
        public void Awake()
        {
            RoR2.Stage.onStageStartGlobal += Stage_onStageStartGlobal;

            cfgBazaarOnly = Config.Bind("", "Bazaar Only", false, "If true, then this mod only applies in the bazaar.");

            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("com.rune580.riskofoptions"))
                ModCompat_RiskOfOptions.Initialize();
        }

        private void Stage_onStageStartGlobal(RoR2.Stage stg)
        {
            if (!NetworkServer.active) return;
            if (cfgBazaarOnly.Value && RoR2.Stage.instance.sceneDef.cachedName != "bazaar")
                return;
            uint money = 0;
            foreach (var player in RoR2.PlayerCharacterMasterController.instances)
            {
                if (player.master.money > money)
                {
                    money = player.master.money;
                }
            }

            foreach (var player in RoR2.PlayerCharacterMasterController.instances)
            {
                player.master.money = money;
            }
        }
    }
}
