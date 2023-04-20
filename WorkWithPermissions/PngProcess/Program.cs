using System.Drawing;

class PngProcess
{
    static int Main(string[] args)
    {
        if (args.Length != 1)
        {
            return -1;
        }

        string filename = args[0];
        string pngFilename = Path.ChangeExtension(filename, ".png");

        try
        {
            Bitmap bitmap = new Bitmap(filename);
            bitmap.Save(pngFilename, System.Drawing.Imaging.ImageFormat.Png);
        }
        catch
        {
            return -2;
        }

        return 0;
    }
}