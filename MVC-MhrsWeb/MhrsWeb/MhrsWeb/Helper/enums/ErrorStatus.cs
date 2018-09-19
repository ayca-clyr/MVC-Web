using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MhrsWeb.Helper.enums
{
    public enum ErrorStatus
    {
        [StringValue("İstek hatalı (isteğin yapısı hatalı).")]
        BADREQUEST = 400,

        [StringValue("Sayfa Bulunamadı.")]
        NOTFOUND = 404,

        [StringValue("Sunucuda bir hata oluştu ve istek karşılanamadı.")]
        SERVERERROR = 500
    }


    internal class StringValueAttribute : Attribute
    {
        private string _value;

        public StringValueAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }
}