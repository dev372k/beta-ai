﻿using Shared.Enumerations;

namespace Domain.Entities;

public class User : Base
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string APIKey { get; set; }
    public required enSubscription Subscription { get; set; }
    public required enRole Role { get; set; }
    public string StripeCustomerId { get; set; } = String.Empty;
}