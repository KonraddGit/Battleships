using Battleships.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Core.Interfaces
{
    public interface IShootingMechanism
    {
        void ShottingPatter();
        void ShotMechanism();
        void ShotOrMiss();
        void Shot(Player player);
    }
}
