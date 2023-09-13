using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegister
{
    public interface IDataView
    {
     
        int Age { get; set; }
        string Search { get; set; }
        string PersonName { get; set; }

        event EventHandler<EventArgs> SaveData;
        event EventHandler<EventArgs> LoadData;

    }
}
