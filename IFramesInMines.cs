using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace IFramesInMines
{
    internal sealed class IFramesInMinesMod : Mod
    {
        private ModConfig Config;

        public override void Entry(IModHelper helper)
        {
            this.Config = this.Helper.ReadConfig<ModConfig>();
            int InvincibilityDuration = this.Config.InvincibilityDuration;
            helper.Events.Player.Warped += this.OnWarped;
        }

        private void OnWarped(object sender, WarpedEventArgs e)
        {
            if (e.NewLocation != e.OldLocation && e.NewLocation.NameOrUniqueName.ToLower().StartsWith("undergroundmine"))
            {
                e.Player.currentTemporaryInvincibilityDuration = Config.InvincibilityDuration;
                e.Player.temporarilyInvincible = true;
            }
        }
    }
       
    public sealed class ModConfig
    {
        public int InvincibilityDuration { get; set; } = 1500;
    }
}
