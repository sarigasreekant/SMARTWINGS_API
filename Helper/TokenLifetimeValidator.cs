﻿using Microsoft.IdentityModel.Tokens;

namespace  Helper

{
    public static class TokenLifetimeValidator
    {
        public static bool Validate(
        DateTime? notBefore,
        DateTime? expires,
        SecurityToken tokenToValidate,
        TokenValidationParameters @param
    )
        {
            return (expires != null && expires > DateTime.UtcNow);
        }
    }
}
