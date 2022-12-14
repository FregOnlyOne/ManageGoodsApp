using System.ComponentModel.DataAnnotations.Schema;

namespace ManageGoodsApp.Model;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Patronymic { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public int? WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }

    [NotMapped]
    public Role UserRole
    {
        get
        {
            return DataWorker.GetRoleById(RoleId);
        }
    }

    [NotMapped]
    public Warehouse UserWarehouse
    {
        get
        {
            return DataWorker.GetWarehouseById(WarehouseId);
        }
    }
}