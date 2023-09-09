using System.Collections.Immutable;
using System.Net;
using System.Text.Json.Serialization;
using static System.Text.Json.Serialization.JsonIgnoreCondition;

namespace ResumeTech.Common.Exceptions;

public enum AppErrorType {
    General,
    AuthenticationFailed,
    ValidationFailed
}

public enum AppSubErrorType {
    DataMissing,
    DataInvalid
}

public record AppSubError(string Path, string Message);

public record AppError {
    public Exception? CausedBy { get; }
    public AppErrorType ErrorType { get; }
    public HttpStatusCode StatusCode { get; }
    public string? UserMessage { get; }
    public string? DeveloperMessage { get; }
    public IList<AppSubError> SubErrors { get; }

    public bool IsUserError => (int)StatusCode >= 400 && (int)StatusCode <= 499;

    public AppError(Exception? CausedBy = null, AppErrorType? ErrorType = null, HttpStatusCode? StatusCode = null, string? UserMessage = null, string? DeveloperMessage = null, IList<AppSubError>? SubErrors = null) {
        this.CausedBy = CausedBy;
        this.ErrorType = ErrorType ?? AppErrorType.General;
        this.StatusCode = StatusCode ?? HttpStatusCode.InternalServerError;
        this.UserMessage = UserMessage ??
                           (SubErrors?.Count > 0 ? null : "A system error has occurred. Please contact support@nummi.io for Technical Support");
        this.DeveloperMessage = DeveloperMessage ?? CausedBy?.Message;
        this.SubErrors = SubErrors ?? ImmutableList<AppSubError>.Empty;
    }

    public AppErrorDto ToDto(string traceId, bool includeDevInfo) {
        return new AppErrorDto(
            CausedBy: includeDevInfo ? CausedBy?.GetType().Name : null,
            ErrorType: Enum.GetName(typeof(AppErrorType), ErrorType),
            UserMessage: UserMessage,
            DeveloperMessage: includeDevInfo ? DeveloperMessage : null,
            SubErrors: SubErrors.Count == 0 ? null : SubErrors.Select(e => new AppSubErrorDto(
                Path: e.Path,
                Message: e.Message
            )).ToList(),
            TraceId: traceId
        );
    }

    public static AppErrorBuilder Builder(HttpStatusCode statusCode) {
        return new AppErrorBuilder()
            .StatusCode(statusCode);
    }
    
    public static AppErrorBuilder Builder(AppErrorType errorType) {
        return new AppErrorBuilder()
            .ErrorType(errorType);
    }
}

public class AppErrorBuilder {
    private Exception? _causedBy;
    private AppErrorType _errorType;
    private HttpStatusCode _statusCode;
    private string? _userMessage;
    private string? _developerMessage;
    private HashSet<AppSubError>? _subErrors;

    public AppErrorBuilder CausedBy(Exception exception) {
        _causedBy = exception;
        return this;
    }
    
    public AppErrorBuilder ErrorType(AppErrorType errorType) {
        _errorType = errorType;
        return this;
    }
    
    public AppErrorBuilder StatusCode(HttpStatusCode statusCode) {
        _statusCode = statusCode;
        return this;
    }
    
    public AppErrorBuilder UserMessage(string? userMessage) {
        _userMessage = userMessage;
        return this;
    }
    
    public AppErrorBuilder DeveloperMessage(string? developerMessage) {
        _developerMessage = developerMessage;
        return this;
    }
    
    public AppErrorBuilder SubError(string path, string message) {
        _subErrors ??= new HashSet<AppSubError>();
        _subErrors.Add(new AppSubError(path, message));
        return this;
    }
    
    public AppErrorBuilder SubError(AppSubError subError) {
        _subErrors ??= new HashSet<AppSubError>();
        _subErrors.Add(subError);
        return this;
    }

    public AppErrorBuilder SubErrors(IEnumerable<AppSubError> subErrors) {
        _subErrors ??= new HashSet<AppSubError>();
        _subErrors.UnionWith(subErrors);
        return this;
    }

    public AppError Build() {
        return new AppError(
            CausedBy: _causedBy,
            ErrorType: _errorType,
            StatusCode: _statusCode,
            UserMessage: _userMessage,
            DeveloperMessage: _developerMessage,
            SubErrors: _subErrors?.ToList()
        );
    }

    public AppException ToException() {
        return new AppException(Build());
    }
}

public record AppSubErrorDto(
    [property: JsonIgnore(Condition = WhenWritingNull)] string? Path = null,
    [property: JsonIgnore(Condition = WhenWritingNull)] string? Message = null
);

public record AppErrorDto(
    [property: JsonIgnore(Condition = WhenWritingNull)] string? CausedBy = null,
    [property: JsonIgnore(Condition = WhenWritingNull)] string? ErrorType = null, 
    [property: JsonIgnore(Condition = WhenWritingNull)] string? UserMessage = null, 
    [property: JsonIgnore(Condition = WhenWritingNull)] string? DeveloperMessage = null, 
    [property: JsonIgnore(Condition = WhenWritingNull)] List<AppSubErrorDto>? SubErrors = null, 
    [property: JsonIgnore(Condition = WhenWritingNull)] string? TraceId = null
);