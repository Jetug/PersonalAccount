using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Models
{
    public static class FileUploader
    {
        const string dataPath = "wwwroot/Data/Documents";

        public static void UploadPassport(IFormFile file, int studentId)
        {
            string path = $"wwwroot/Data/Documents/Passports/Паспорт{studentId}.pdf";

            Upload(file, studentId, path);
        }

        public static void UploadVisa(IFormFile file, int studentId)
        {
            string path = $"wwwroot/Data/Documents/Visas/Виза{studentId}.pdf";

            Upload(file, studentId, path);
        }

        public static void UploadContract(IFormFile file, int studentId)
        {
            string path = $"wwwroot/Data/Documents/Contracts/Договор{studentId}.pdf";

            Upload(file, studentId, path);
        }

        private static void Upload(IFormFile file, int studentId, string path)
        {
            if(file.ContentType == "application/pdf")
            {
                using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }
            }
            else
            {
                Document document = new Document(PageSize.A4, 25, 25, 25, 25);
                using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();
                    //using (var imageStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var page = Image.GetInstance(GetByteArray(file));

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
            LocalDB.WriteDate(path, DateTime.Now);
        }


        private static byte[] GetByteArray(IFormFile file)
        {
            long length = file.Length;

            using var fileStream = file.OpenReadStream();
            byte[] bytes = new byte[length];
            fileStream.Read(bytes, 0, (int)file.Length);
            return bytes;
        }
    }
}
