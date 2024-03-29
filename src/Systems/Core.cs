using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.GameContent;
using System;

[assembly: ModInfo(name: "Glowing Projectiles", modID: "glowingprojectiles", Side = "Client")]

namespace GlowingProjectiles;

public class Core : ModSystem
{
    public override bool ShouldLoad(EnumAppSide forSide) => forSide == EnumAppSide.Client;

    public override void StartClientSide(ICoreClientAPI api)
    {
        base.StartClientSide(api);
        api.Event.OnEntitySpawn += SetGlowLevel;
        api.World.Logger.Event("started '{0}' mod", Mod.Info.Name);
    }

    private void SetGlowLevel(Entity entity)
    {
        if (entity is EntityProjectile || entity.Class.Contains("projectile", StringComparison.OrdinalIgnoreCase))
        {
            entity.Properties.Client.GlowLevel = 255;
        }
    }
}