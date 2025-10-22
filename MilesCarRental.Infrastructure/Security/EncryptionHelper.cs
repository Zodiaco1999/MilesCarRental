using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace MilesCarRental.Infrastructure.Security;

public sealed class EncryptionHelper
{
    private readonly byte[] _key;

    public EncryptionHelper(IConfiguration configuration)
    {
        var keyString = configuration["Security:EncryptionKey"]
            ?? throw new InvalidOperationException("EncryptionKey no está configurado en appsettings.json");

        if (keyString.Length != 32)
            throw new InvalidOperationException("La clave de encriptación debe tener exactamente 32 caracteres para AES-256.");

        _key = Encoding.UTF8.GetBytes(keyString);
    }

    public string Decrypt(string cipherText)
    {
        if (string.IsNullOrWhiteSpace(cipherText))
            return string.Empty;

        var fullCipher = Convert.FromBase64String(cipherText);

        using var aes = Aes.Create();
        aes.Key = _key;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        var iv = new byte[aes.BlockSize / 8];
        var cipher = new byte[fullCipher.Length - iv.Length];

        Array.Copy(fullCipher, iv, iv.Length);
        Array.Copy(fullCipher, iv.Length, cipher, 0, cipher.Length);
        aes.IV = iv;

        using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream(cipher);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);

        return sr.ReadToEnd();
    }
}
