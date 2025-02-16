using System.Net.Mail;

using Compila.Net.Utils.Errors;
using Compila.Net.Utils.Errors.ErrorCodes.Authentication;

namespace Compila.AspNetCore.Utils.Application.ServiceResponses.Concrete.Authentication
{
    #region User Login Responses

    public class InvalidCredentialsResponse : ServiceBadRequestResponseWithErrorCode
    {
        public InvalidCredentialsResponse() : base(new ErrorDetailsWithCode("Invalid login credentials.", 400, AuthenticationErrorCodes.InvalidCredentials)) { }
    }

    public class EmailNotConfirmedResponse : ServiceBadRequestResponseWithErrorCode
    {
        public EmailNotConfirmedResponse() : base(new ErrorDetailsWithCode("Email address is not confirmed.", 400, AuthenticationErrorCodes.NotConfirmedEmail)) { }
        public EmailNotConfirmedResponse(string emailAddress) : base(new ErrorDetailsWithCode($"Email address {emailAddress} is not confirmed.", 400, AuthenticationErrorCodes.NotConfirmedEmail)) { }
    }

    #endregion
    #region User Registration

    public class UserRegistrationFailedResponse : ServiceInternalServerError
    {
        public UserRegistrationFailedResponse(string message) : base(message) { }
    }

    public class DuplicatedEmailResponse : ServiceBadRequestResponseWithErrorCode
    {
        public DuplicatedEmailResponse() : base(new ErrorDetailsWithCode("User already exists.", 400, AuthenticationErrorCodes.DuplicatedEmail)) { }
        public DuplicatedEmailResponse(string emailAddress) : base(new ErrorDetailsWithCode($"User {emailAddress} already exists.", 400, AuthenticationErrorCodes.DuplicatedEmail)) { }
    }

    public class PasswordTooShortResponse : ServiceBadRequestResponseWithErrorCode
    {
        public PasswordTooShortResponse() : base(new ErrorDetailsWithCode("Password is too short.", 400, AuthenticationErrorCodes.PasswordTooShort)) { }
    }

    public class PasswordTooWeak : ServiceBadRequestResponseWithErrorCode
    {
        public PasswordTooWeak() : base(new ErrorDetailsWithCode("Password is too weak.", 400, AuthenticationErrorCodes.PasswordTooWeak)) { }
    }

    #endregion
    #region Email Error Responses

    public class SystemErrorConfirmingEmailResponse : ServiceInternalServerError
    {
        public SystemErrorConfirmingEmailResponse() : base($"An error ocurred confirming email address.") { }
        public SystemErrorConfirmingEmailResponse(string emailAddress) : base($"An error ocurred confirming email address {emailAddress}.") { }
    }

    public class ErrorConfirmingEmailResponse : ServiceBadRequestResponseWithErrorCode
    {
        public ErrorConfirmingEmailResponse() : base(new ErrorDetailsWithCode("Error confirming email address.", 400, AuthenticationErrorCodes.ErrorConfirmingEmail)) { }
        public ErrorConfirmingEmailResponse(string emailAddress) : base(new ErrorDetailsWithCode($"Error confirming email address {emailAddress}.", 400, AuthenticationErrorCodes.ErrorConfirmingEmail)) { }
    }

    public class EmailConfirmationTokenError : ServiceBadRequestResponseWithErrorCode
    {
        public EmailConfirmationTokenError() : base(new ErrorDetailsWithCode("Confirmation token is incorrect or invalid.", 400, AuthenticationErrorCodes.InvalidEmailConfirmationToken)) { }
    }

    public class EmailConfirmationThresholdReachedResponse : ServiceBadRequestResponseWithErrorCode
    {
        public EmailConfirmationThresholdReachedResponse() : base(new ErrorDetailsWithCode("Email confirmation threshold reached.", 400, AuthenticationErrorCodes.EmailConfirmationThresholdReached)) { }
    }

    #endregion
    #region User Error Responses

    public class UserNotFoundResponse : ServiceNotFoundResponse
    {
        public UserNotFoundResponse() : base("User does not exists.") { }
        public UserNotFoundResponse(Guid userId) : base($"User with Id {userId} not found.") { }
        public UserNotFoundResponse(string userName) : base($"User with username {userName} not found.") { }
    }

    #endregion
    #region Token Error Responses

    public class InvalidTokenResponse : ServiceBadRequestResponse
    {
        public InvalidTokenResponse() : base("Token does not exists.") { }
    }

    public class ErrorGeneratingTokenResponse : ServiceInternalServerError
    {
        public ErrorGeneratingTokenResponse() : base("Error generating token.") { }
    }

    #endregion
}
