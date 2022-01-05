using System;
using System.Collections.Generic;
using System.Text;

namespace IVending
{
    public interface IVendings
    {
        bool Purchase(int number);
        void ShowAll();
        bool InsertMoney(int money);
        int EndTransaction();
      
    }
}
