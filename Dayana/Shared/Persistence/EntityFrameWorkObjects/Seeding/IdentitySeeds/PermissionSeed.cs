﻿using Dayana.Shared.Domains.Identity.Permissions;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.Seeding.IdentitySeeds;

public static class PermissionSeed
{
    public static List<Permission> All => IdentityPermissions.ToList();

    private static IEnumerable<Permission> IdentityPermissions { get; } = _identityPermissions.Select((x, i) =>
        new Permission
        {
            Id = i + 1,
            Value = x.Value,
            Name = x.Name,
            Title = x.Title,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        });

    private static IEnumerable<Permission> _identityPermissions => new List<Permission>
    {
        new Permission { Value = "identity.users.command", Name= "UserManagement" , Title = "مدیریت کاربران"},
        new Permission { Value = "identity.roles.command", Name= "RoleManagement" , Title = "مدیریت نقش‌ها" },
        new Permission { Value = "identity.claims.command", Name= "ClaimManagement" , Title = "مدیریت دسترسی ها" },
        new Permission { Value = "identity.users.query", Name= "UserView" , Title = "نمایش  مدیریت کاربران" },
        new Permission { Value = "identity.roles.query", Name= "RoleView" , Title = "نمایش  مدیریت نقش ها" },
        new Permission { Value = "identity.claims.query", Name= "ClaimView" , Title = "نمایش  مدیریت دسترسی ها" }
    };

}