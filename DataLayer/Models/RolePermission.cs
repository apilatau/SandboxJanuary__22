﻿namespace DataLayer.Models
{
    public class RolePermission : BaseEntity
    {
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public int PermissionId { get; set; }
        public virtual Permission Permission { get; set; }

    }
}
