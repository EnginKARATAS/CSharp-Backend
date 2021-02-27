using Core.Entities.Concrate;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProgramAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz";
        public static string MaintanceTime = "Bakım Zamanı";
        public static string ProductListed = "Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExist = "aynı isme ait kayıt var !";
        public static string CategoryLimitExeded = "kategori limiti aşıldığı için yeni bir ürün eklenemiyor!";
        public static string AuthorizationDenied = "Authorization Denied";

        public static string AccessTokenCreated { get; internal set; }
        public static string UserAlreadyExists { get; internal set; }
        public static User PasswordError { get; internal set; }
        public static string SuccessfulLogin { get; internal set; }
        public static User UserNotFound { get; internal set; }
        public static string UserRegistered { get; internal set; }
    }
}
