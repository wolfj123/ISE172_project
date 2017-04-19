using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;

namespace MarketClient.BL.AMA
{
    public interface LogicBlock
    {
        bool repeat();

        void setRepeat(bool loop);

        bool isMet(object obj);

        object ask();

        object action(object obj);

        object runBlock();
    }
}
