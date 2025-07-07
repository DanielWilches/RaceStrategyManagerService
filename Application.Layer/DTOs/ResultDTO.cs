using Application.Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Layer.DTOs
{
    public class ResultDTO<T>: IModelResult<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public List<T> Data{ get; set; }


        public ResultDTO() { }
        public ResultDTO(bool success, string message,int  statusCode , List<T> data )
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
            Data = data;
        }
    }
}
