using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageGoodsApp.Model;

public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhysicalAddress { get; set; }
    public string LegalAddress { get; set; }
    public string TaxIdentificationNumber { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<Supply> Suppliers { get; set; }

    [NotMapped]
    public List<Supply> SupplierSupplies
    {
        get
        {
            return DataWorker.GetAllSuppliesBySupplierId(Id);
        }
    }
}