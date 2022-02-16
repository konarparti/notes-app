using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotion.Dialogs.Abstract
{
    public interface IInteractionAware
    {
        Action FinishInteraction { get; set; }
    }
}
