using System.Diagnostics;
using System.IO.Compression;
using System.Security.Principal;

class ZipProcess
{
    static int Main(string[] args)
    {
        if (args.Length != 1)
        {
            return -1;
        }

        string sourceFile = args[0];
        string destinationFile = sourceFile + ".zip";

        try
        {
            // поток для чтения исходного файла
            using FileStream sourceStream = new FileStream(sourceFile, FileMode.Open);
            using FileStream targetStream = File.Create(destinationFile);
            //// поток архивации
            using GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
            //// копируем байты из одного потока в другой
            sourceStream.CopyTo(compressionStream);

            compressionStream.Close();
            sourceStream.Close();
            targetStream.Close();
        }
        catch (UnauthorizedAccessException)
        {
            return -2;
        }
        catch
        {
            return -3;
        }

        return 0;
    }
}