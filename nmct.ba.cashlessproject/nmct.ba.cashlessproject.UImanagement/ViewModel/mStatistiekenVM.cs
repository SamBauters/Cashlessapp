using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.UImanagement.ViewModel
{
    class mStatistiekenVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Statistiek"; }
        }
    }
}
