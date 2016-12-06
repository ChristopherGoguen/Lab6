namespace Christopher.Goguen.Lab6.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RentalOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RentalOrder()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int RentalOrderId { get; set; }

        public DateTime CheckoutDate { get; set; }

        public int UniqueId { get; set; }

        public int EmployeeEmployeeId { get; set; }

        public DateTime ReturnDate { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
