namespace SpawnCloud.Authentication.Models;

public class LoginOptions
{
    public PasswordLoginOptions Password { get; set; } = new();
}

public class PasswordLoginOptions
{
    public enum LookupMethod
    {
        Username,
        Email,
        EmailOrUsername
    }
    
    public bool Enabled { get; set; } = true;
    public LookupMethod UserLookupMethod { get; set; } = LookupMethod.EmailOrUsername;
    public bool LockoutOnFailure { get; set; } = true;
}