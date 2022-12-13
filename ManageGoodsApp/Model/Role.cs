using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageGoodsApp.Model;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<User> Users { get; set; }

    [NotMapped]
    public List<User> RoleUsers
    {
        get
        {
            return DataWorker.GetAllUsersByRoleId(Id);
        }
    }
}