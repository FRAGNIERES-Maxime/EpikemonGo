using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Classes
{
    public class Wave
    {
        public int Level { get; set; }
        public List<MobBehaviour> Mobs { get; set; }
    }
}
