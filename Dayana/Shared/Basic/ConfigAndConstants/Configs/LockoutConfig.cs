namespace Dayana.Shared.Basic.ConfigAndConstants.Configs;

public class LockoutConfig
{
    public const string Key = "Lockout";

    public readonly int FailedLoginLimit = 13;
    public readonly TimeSpan Duration = TimeSpan.FromDays(1);
}