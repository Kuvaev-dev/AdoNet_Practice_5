//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PR16
{
    using System;
    using System.Collections.Generic;
    
    public partial class Matches
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Matches()
        {
            this.Commands = new HashSet<Commands>();
        }
    
        public int Id { get; set; }
        public string First_Team { get; set; }
        public string Second_Team { get; set; }
        public int First_Team_Score { get; set; }
        public int Second_Team_Score { get; set; }
        public string Score_Info { get; set; }
        public System.DateTime Match_Date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commands> Commands { get; set; }
    }
}