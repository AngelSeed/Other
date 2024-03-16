using Dalamud.Game.Text.SeStringHandling;
using ECommons;
using ECommons.ChatMethods;
using ECommons.DalamudServices;
using ECommons.Hooks;
using ECommons.Schedulers;
using Splatoon.SplatoonScripting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplatoonScriptsOfficial.Generic
{
    public class ACTリマインダー : SplatoonScript
    {
        public override HashSet<uint> ValidTerritories => new();
        public override Metadata? Metadata => new(1, "Angel Wings XIV");

        public override void OnDirectorUpdate(DirectorUpdateCategory category)
        {
            if(category.EqualsAny(DirectorUpdateCategory.Commence, DirectorUpdateCategory.Recommence))
            {
                if(!Process.GetProcessesByName("Advanced Combat Tracker").Any())
                {
                    var s = new SeStringBuilder().AddUiForeground("※WARNING※ ACTが起動してないよ！ ※WARNING※", (ushort)UIColor.Red).Build();
                    for (var i = 0; i < 1; i++)
                    {
                        Svc.Chat.Print(s);
                    }
                    Svc.Toasts.ShowError(s.ExtractText());
                }
            }
        }
    }
}
