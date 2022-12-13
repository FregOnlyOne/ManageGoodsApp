using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageGoodsApp.Model;

public class Audit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime DateTime { get; set; }

    [NotMapped]
    public User AuditUser
    {
        get
        {
            return DataWorker.GetUserById(UserId);
        }
    }
}