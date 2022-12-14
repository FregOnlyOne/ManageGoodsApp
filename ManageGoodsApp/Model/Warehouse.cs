using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageGoodsApp.Model;

public class Warehouse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public static List<Product> Products { get; set; }

    [NotMapped]
    public List<Product> WarehouseProducts
    {
        get
        {
            return DataWorker.GetAllProductsByWarehouseId(Id);
        }
    }
}