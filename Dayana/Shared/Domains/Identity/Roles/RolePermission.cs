﻿using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Domains.Identity.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dayana.Shared.Domains.Identity.Roles;

public class RolePermission : BaseDomain, IEntity
{
    #region Navigations

    public int RoleId { get; set; }
    public int PermissionId { get; set; }

    public Permission Permission { get; set; }
    public Role Role { get; set; }

    #endregion
}

public class RolePermissionEntityConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasKey(x => new { x.RoleId, x.PermissionId });

        #region Navigations

        builder
            .HasOne(x => x.Role)
            .WithMany(x => x.RolePermission)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.Permission)
            .WithMany(x => x.Roles)
            .HasForeignKey(x => x.PermissionId)
            .OnDelete(DeleteBehavior.NoAction);

        #endregion

    }
}