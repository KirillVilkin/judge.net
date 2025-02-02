﻿using System.Security.Claims;

namespace Judge.Services;

public static class ClaimsPrincipalExtensions
{
    public static long GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.TryGetUserId()!.Value;
    }

    public static long? TryGetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal.Identity is not ClaimsIdentity identity)
            return null;
        var claim = identity.FindFirst("id");
        if (claim == null)
            return null;
        
        return long.Parse(claim.Value);
    }
}