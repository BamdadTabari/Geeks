﻿namespace Dayana.Shared.Domains;

public class BaseDomain
{
    public int Id { get; set; }
    public int CreatorId { get; set; }
    public int UpdaterId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
