﻿namespace GFM.Fundation.App.Response;

public class ErrorDetail
{
    public string Message { get; set; }

    public ErrorDetail(string message)
    {
        Message = message;
    }
}
