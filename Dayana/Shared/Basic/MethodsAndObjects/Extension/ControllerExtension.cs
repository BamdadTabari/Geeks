﻿using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Infrastructure.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Dayana.Shared.Basic.MethodsAndObjects.Extension;

public static class ControllerExtension
{
    public static IActionResult ReturnResponse(this ControllerBase controller, OperationResult operation)
    {
        object response = operation.Value;
        if (response is ErrorModel errorModel)
            response = new ErrorResponse(errorModel);

        return operation.Status switch
        {
            OperationResultStatus.Ok => controller.Ok(response),
            OperationResultStatus.Invalidated => controller.BadRequest(response),
            OperationResultStatus.NotFound => controller.NotFound(response),
            OperationResultStatus.Unauthorized => controller.UnprocessableEntity(response),
            OperationResultStatus.UnProcessable => controller.UnprocessableEntity(response),
            _ => controller.UnprocessableEntity(response)
        };
    }
}