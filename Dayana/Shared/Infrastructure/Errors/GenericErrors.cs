﻿using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Basic.MethodsAndObjects.Models;

namespace Dayana.Shared.Infrastructure.Errors;
public static class GenericErrors<TEntity> where TEntity : class, IEntity
{
    public static ErrorModel InvalidVariableError(string variableName) => new ErrorModel(
      code: 666,
      title: $"{nameof(TEntity)} Error",
         (
        Language: Language.English,
        Message: $"Invalid property : '{variableName.ToLower()}' in -> object: '{nameof(TEntity)}' error"
      ));

    public static ErrorModel NotFoundError(string variableName) => new ErrorModel(
     code: 69,
     title: $"{nameof(TEntity)} Error",
        (
       Language: Language.English,
       Message: $"object: '{nameof(TEntity)}' -> with this '{variableName.ToLower()}' -> not found"
     ));

    public static ErrorModel CustomError(string causeOfError, string? variableName = "unknown") => new ErrorModel(
    code: 85,
    title: $"{nameof(TEntity)} Error",
       (
      Language: Language.English,
      Message: $"object: '{nameof(TEntity)}' | '{variableName.ToLower()}' property error | \n {causeOfError.ToLower()}"
    ));

    public static ErrorModel IntervalError(int min, int max, string variableName) => new ErrorModel(
   code: 13,
   title: $"{nameof(TEntity)} Error",
      (
     Language: Language.English,
     Message: $"object: '{nameof(TEntity)}' | '{variableName.ToLower()}' property error | \n "
   ));

    public static ErrorModel DuplicateError(string variableName) => new ErrorModel(
 code: 2022,
 title: $"{nameof(TEntity)} Error",
    (
   Language: Language.English,
   Message: $"object: '{nameof(TEntity)}' | with this '{variableName.ToLower()}' already exists | \n "
 ));
}
