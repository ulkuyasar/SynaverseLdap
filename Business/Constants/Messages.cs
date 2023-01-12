using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
	public static class Messages
	{
		public static string SuccessFlow = "İşlem Başarılı";
		public static string SuccessAdded = "Başarıyla Eklendi";
		public static string SuccessDeleted = "Başarıyla Silindi";
		public static string SuccessUpdated = "Başarıyla Düzenlendi";
		public static string SuccessMailSending = "Başarıyla Mail Atıldı";

		public static string SuccessFireBaseNotificationSending = "Notification Basarıyla Kaydedildi";

		public static string UserNotFound = "Kullanıcı Bulunamadı";
		public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
		internal static string PasswordError = "Şifre Hatalı";

		public static string SuccessfullToLogin = "Sisteme Giriş Başarılı";

		public static string UserRegistered = "Kullanıcı Başarıyla Kaydedildi";

		public static string AccessTokenCreated = "Access Token Başarıyla Oluşturuldu";

		public static string AuthorizationDenied = "Yetkiniz Bulunmamaktadır";
		public static string AuthorizationDeniedForApikeyTransaction = "Yetkiniz Bulunmamaktadır. Apikey Error";
		public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";

		public static string BoardIsParentFlow = "Eğer IsParent seçilmemiş ise (yani internete çıkısı yok ise), kesinlikle bir loraGateway ile bağlanılmalı";
		public static string BoardIsNotFound = "Böyle bir board bulunmamaktadır";


	}
}
