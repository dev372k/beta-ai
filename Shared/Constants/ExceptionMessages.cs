﻿namespace Shared.Constants;

public class ExceptionMessages
{
    public const string RECORD_DOESNOT_EXIST = "The specified record does not exist.";
    public const string RECORD_ALREADY_EXISTS = "The record already exists.";
    public const string CANNOT_DELETE = "Cannot delete the record because record are associated with it.";
    public const string PAGINATION_ERROR = "PageSize and PageNo must be greater than 0.";
    public const string INVALID_API_KEY = "Invalid API key provided";
    public const string UNKNOWN_SERVICE = "Please provided the valid service.";
}
