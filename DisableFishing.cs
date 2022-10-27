using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace DisableFishing
{
    [ApiVersion(2, 1)]
    public class DisableFishing : TerrariaPlugin
    {

        public override string Description => "禁钓鱼";
        public override string Name => "禁钓鱼";
        public override string Author => "hufang360";
        public override Version Version => Assembly.GetExecutingAssembly().GetName().Version;


        public DisableFishing(Main game) : base(game)
        {
        }


        public override void Initialize()
        {
            GetDataHandlers.NewProjectile += OnNewProjectile;
        }

        private void OnNewProjectile(object sender, GetDataHandlers.NewProjectileEventArgs args)
        {
            short ident = args.Identity;
            //Vector2 pos = args.Position;
            //Vector2 vel = args.Velocity;
            //float knockback = args.Knockback;
            //short damage = args.Damage;
            byte owner = args.Owner;
            short type = args.Type;
            //int index = args.Index;
            //float[] ai = args.Ai;

            List<int> bLists = new List<int>() { 360, 361, 362, 363, 364, 365, 366, 381, 382, 775, 760, 986, 987, 988, 989, 990, 991, 992, 993 };
            if(bLists.Contains(type))
            {
                //TShock.Log.ConsoleInfo($"OnNewProjectile:{type}");
                args.Player.RemoveProjectile(ident, owner);
                args.Handled = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                GetDataHandlers.NewProjectile -= OnNewProjectile;
            }
            base.Dispose(disposing);
        }

    }
}
