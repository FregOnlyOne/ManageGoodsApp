using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace ManageGoodsApp.Model;

public class Supply
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Count { get; set; }
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }
    public int? WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }
    public DateTime? DepartureDate { get; set; }
    public DateTime? ArrivalDate { get; set; }

    [NotMapped]
    public string Status
    {
        get
        {
            if (ArrivalDate > DateTime.Today || ArrivalDate == null)
            {
                return "В пути";
            }
            else
            {
                return "Доставлено";
            }
        }
    }

    [NotMapped]
    public Product SupplyProduct
    {
        get
        {
            return DataWorker.GetProductById(ProductId);
        }
    }
    
    [NotMapped]
    public Supplier SupplySupplier
    {
        get
        {
            return DataWorker.GetSupplierById(SupplierId);
        }
    }

    [NotMapped]
    public Warehouse SupplyWarehouse
    {
        get
        {
            return DataWorker.GetWarehouseById(WarehouseId);
        }
    }
}