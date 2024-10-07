namespace c_sharp.Models;
public class Provider
{
    // further in the future for multible login-providers
    public string? ProviderName { get; set; }
    public string? ProviderId { get; set; }
    public string? AccessToken { get; set; }
    public DateTime? Expiration { get; set; }

    public string? PasswordHash { get; set; }
    public string? PasswordSalt { get; set; }
}