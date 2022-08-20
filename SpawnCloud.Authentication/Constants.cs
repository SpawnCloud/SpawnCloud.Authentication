namespace SpawnCloud.Authentication;

public static class Constants
{
    public static class ErrorDescriptions
    {
        public const string InvalidCredentials = "Invalid credentials";
        public const string InvalidRefreshToken = "The refresh token is no longer valid.";
        public const string UserSignInNotAllowed = "The user is not allowed to sign in.";
        public const string UserLockedOut = "The user is locked out.";
    }
}