using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Models
{
    public class PdfConverter
    {
        string PdfPath { get; set; }
        FileStream ImageFile { get; set; }


        public PdfConverter(string pdfPath, FileStream imageFile)
        {
            PdfPath = pdfPath;
            ImageFile = imageFile;
        }


        public void WriteImage(string imagePath)
        {
            Document document = new Document();
            using (var stream = new FileStream(PdfPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();
                using (var imageStream = new FileStream("test.jpg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var image = Image.GetInstance(imageStream);
                    document.Add(image);
                }
                document.Close();
            }
        }


        public void WriteImage2(string folder, string imageSrc)
        {
            // Создаем документ
            var document = new Document(PageSize.A4, 25, 25, 25, 25);
            using (var stream = new FileStream(folder + "\\document.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();

                // Проходим по всем изображениям в каталоге

                using (var imageStream = new FileStream(imageSrc, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var page = Image.GetInstance(imageStream);

                    // Размеры изображения
                    float width = page.Width;
                    float height = page.Height;

                    if (width < height)
                    {
                        // Книжная
                        document.SetPageSize(PageSize.A4);
                    }
                    else
                    {
                        // Альбомная
                        document.SetPageSize(PageSize.A4.Rotate());
                    }

                    document.NewPage();

                    // Масштабируем размеры изображения под параметры страницы
                    if (width < height)
                    {
                        // Для книжной ориентации
                        if (page.Height > PageSize.A4.Height - 25)
                        {
                            page.ScaleToFit(PageSize.A4.Width - 25, PageSize.A4.Height - 25);
                        }
                        else if (page.Width > PageSize.A4.Width - 25)
                        {
                            page.ScaleToFit(PageSize.A4.Width - 25, PageSize.A4.Height - 25);
                        }
                    }
                    else
                    {
                        // Для альбомной ориентации
                        if (page.Height > PageSize.A4.Height - 25)
                        {
                            page.ScaleToFit(PageSize.A4.Height - 25, PageSize.A4.Width - 25);
                        }
                        else if (page.Width > PageSize.A4.Width - 25)
                        {
                            page.ScaleToFit(PageSize.A4.Height - 25, PageSize.A4.Width - 25);
                        }
                    }
                    // Добавляем страницу в документ
                    page.Alignment = Image.ALIGN_MIDDLE;
                    document.Add(page);
                }

                document.Close();
            }
        }
    }
}
