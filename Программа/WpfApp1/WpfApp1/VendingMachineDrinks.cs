//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class VendingMachineDrinks
    {
        public int id { get; set; }
        public int VendingMachineDrinks1 { get; set; }
        public int Drinksld { get; set; }
        public int Count_after_last_update { get; set; }
        public int Count { get; set; }
        public int ProfitSum { get; set; }
        public Nullable<int> Sold { get; set; }
    
        public virtual Drinks Drinks { get; set; }
        public virtual VendingMachines VendingMachines { get; set; }
    }
}
