using PdfSharp.Fonts;
using System.Diagnostics;

namespace cs_form_230622_pdf
{
    class FontResolver : IFontResolver
    {
        string cur = System.Environment.CurrentDirectory;

        byte[] IFontResolver.GetFont(string faceName)
        {
            switch (faceName)
            {
                case "梅Hyゴシック":
                    return LoadFontData($@"{cur}\ume-hgo4.ttf");

                case "梅HyゴシックO5":
                    return LoadFontData($@"{cur}\ume-hgo5.ttf");

                case "梅明朝":
                    return LoadFontData($@"{cur}\ume-tmo3.ttf");

                case "梅PゴシックC4":
                    return LoadFontData($@"{cur}\ume-pgc4.ttf");

            }

            return null;
        }
        private byte[] LoadFontData(string resourceName)
        {
            try
            {
                using (FileStream stream = new FileStream(resourceName, FileMode.Open, FileAccess.Read))
                {
                    byte[] data = new byte[stream.Length];
                    stream.Read(data, 0, (int)stream.Length);
                    return data;
                }
            }
            catch (FileNotFoundException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }

        FontResolverInfo IFontResolver.ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            switch (familyName)
            {
                case "梅Hyゴシック":
                    return new FontResolverInfo("梅Hyゴシック");

                case "梅HyゴシックO5":
                    return new FontResolverInfo("梅HyゴシックO5");

                case "梅明朝":
                    return new FontResolverInfo("梅明朝");

                case "梅PゴシックC4":
                    return new FontResolverInfo("梅PゴシックC4");
            }

            return null;
        }
    }
}
