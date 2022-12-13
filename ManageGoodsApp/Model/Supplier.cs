using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageGoodsApp.Model;

public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string TaxIdentificationNumber { get; set; }
    public string Phone { get; set; }
    public List<Supply> Suppliers { get; set; }

    [NotMapped]
    public List<Supply> SupplierSupply
    {
        get
        {
            return DataWorker.GetAllSuppliesBySupplierId(Id);
        }
    }
}