using System.Security.Cryptography;

class ZipProcess
{
    private static HashAlgorithm GetHashAlgorithm(string algorithm)
    {
        switch (algorithm)
        {
            case "MD5":
                return MD5.Create();
            case "SHA1":
                return SHA1.Create();
            case "SHA256":
                return SHA256.Create();
            case "SHA384":
                return SHA384.Create();
            case "SHA512":
                return SHA512.Create();
            default:
                return null;
        }
    }

    static int Main(string[] args)
    {
        if (args.Length != 2)
        {
            return -1;
        }

        string filename = args[0];
        string algorithm = args[1];
        //string filename = "C:\\Универ\\КГ\\лаб2\\Лабораторная работа 2_12_13а группы.pdf";
        //string algorithm = "sha256";
        string destinationFile = Path.ChangeExtension(filename, null) + "_hash_" + algorithm;

        var hashAlgorithm = GetHashAlgorithm(algorithm.ToUpper());

        if (hashAlgorithm == null)
            return -3;

        try
        {
            using (hashAlgorithm)
            {
                using (var fileStream = new FileStream(filename,
                                                       FileMode.Open,
                                                       FileAccess.Read,
                                                       FileShare.ReadWrite))
                {
                    var hash = hashAlgorithm.ComputeHash(fileStream);
                    var hashString = Convert.ToBase64String(hash);
                    hashString = hashString.TrimEnd('=');

                    using (StreamWriter writer = File.CreateText(destinationFile))
                    {
                        writer.WriteLine(hashString);
                    }
                }
            }
        }
        catch (Exception)
        {
            return -2;
        }

        return 0;
    }
}