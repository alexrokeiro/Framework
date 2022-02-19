using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infra
{
    public class RestResult<T> : RestResult
    {
        public T Data { get; }

        public RestResult(T data)
        {
            Data = data;
        }
    }

    public class RestResult
    {
        public bool Success { get; protected set; }
        public string Errors { get; protected set; }

        [JsonIgnore]
        protected int StatusCode { get; set; }

        public static RestResult Create<T>(Result<T> result)
        {
            return new RestResult<T>(result.IsSuccess ? result.Data : default(T))
            {
                Success = result.IsSuccess,
                Errors = result.Error,
                StatusCode = result.IsSuccess ? 200 : 422
            };
        }

        public static IActionResult CreateHttpResponse<T>(Result<T> data)
        {
            return Create(data).ToHttp();
        }

        private IActionResult ToHttp()
        {
            return new ObjectResult(this)
            {
                StatusCode = StatusCode
            };
        }
    }
}
