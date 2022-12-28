using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BigOn.Application.Extensions
{
    public static partial class Extension
    {
        public static string ToMd5(this string value,string saltKey)
        {
            byte[] buffer = Encoding.UTF8.GetBytes($"{saltKey}{value}BigOn.Domain.AppCode.Extensions");

            //var provider = MD5.Create();
            var provider = new MD5CryptoServiceProvider();

            var buff = provider.ComputeHash(buffer);

            return string.Join("", buff.Select(b => b.ToString("x2")));
        }

        public static string ToSha1(this string value, string saltKey)
        {
            byte[] buffer = Encoding.UTF8.GetBytes($"{saltKey}{value}2BigOn.Domain.AppCode.Extensions");

            var provider = SHA1.Create();

            return string.Join("", provider.ComputeHash(buffer).Select(b => b.ToString("x2")));
        }

        public static string ToSha256(this string value, string saltKey)
        {
            byte[] buffer = Encoding.UTF8.GetBytes($"{saltKey}{value}1BigOn.Domain.AppCode.Extensions");

            var provider = SHA256.Create();

            return string.Join("", provider.ComputeHash(buffer).Select(b => b.ToString("x2")));
        }


        public static string Encrypt(this string value, string key, bool appliedUrlEncode = false)   //123
        {
            try
            {
                using (var provider = new TripleDESCryptoServiceProvider())
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    var keyBuffer = md5.ComputeHash(Encoding.UTF8.GetBytes($"#{key}!2022"));
                    var ivBuffer = md5.ComputeHash(Encoding.UTF8.GetBytes($"2022@{key}$"));

                    var transform = provider.CreateEncryptor(keyBuffer, ivBuffer);

                    using (var ms = new MemoryStream())
                    using (var cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                    {
                        var valueBuffer = Encoding.UTF8.GetBytes(value);

                        cs.Write(valueBuffer, 0, valueBuffer.Length);
                        cs.FlushFinalBlock();

                        ms.Position = 0;
                        var result = new byte[ms.Length];

                        ms.Read(result, 0, result.Length);

                        if (appliedUrlEncode)
                        {
                            return HttpUtility.UrlEncode(Convert.ToBase64String(result));
                        }
                        return Convert.ToBase64String(result);
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static string Decrypt(this string value, string key)
        {
            try
            {
                using (var provider = new TripleDESCryptoServiceProvider())
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    var keyBuffer = md5.ComputeHash(Encoding.UTF8.GetBytes($"#{key}!2022"));
                    var ivBuffer = md5.ComputeHash(Encoding.UTF8.GetBytes($"2022@{key}$"));

                    var transform = provider.CreateDecryptor(keyBuffer, ivBuffer);

                    using (var ms = new MemoryStream())
                    using (var cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                    {
                        var valueBuffer = Convert.FromBase64String(value);

                        cs.Write(valueBuffer, 0, valueBuffer.Length);
                        cs.FlushFinalBlock();

                        ms.Position = 0;
                        var result = new byte[ms.Length];

                        ms.Read(result, 0, result.Length);

                        return Encoding.UTF8.GetString(result);
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
