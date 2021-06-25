using Microsoft.AspNetCore.Mvc.Testing;
using MQuince.Entities.Authentication;
using MQuince.Entities.Users;
using MQuince.Services.Contracts.Interfaces;
using MQuince.WebAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace MQuince.Integration.Tests
{
    public static class Helpers

    {


        public static ByteArrayContent GetByteArrayContent(object o)
        {
            var myContent = JsonConvert.SerializeObject(o);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }

        

      
    }
}
