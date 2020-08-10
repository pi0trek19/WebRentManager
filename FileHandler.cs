using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager
{
    public class FileHandler
    {
        private string GetExtension(string fileName)
        {
            int lenght = fileName.Length;
            char c = fileName[lenght - 1];
            string ext = "";
            while (c != '.')
            {
                ext += c;
                lenght--;
                c = fileName[lenght - 1];
            }
            ext += fileName[lenght - 1];
            char[] extarr = ext.ToCharArray();
            Array.Reverse(extarr);
            string extfinal = "";
            foreach (var item in extarr)
            {
                extfinal += item;
            }
            return extfinal;
        }
        public FileDescription UploadSingleFile(IFormFile iFormFile, FileType fileType, string entityName,DateTime dateTime, string description = null)
        {
            FileDescription fileDescription = new FileDescription
            {
                Enabled = true,
                Ext = GetExtension(iFormFile.FileName),
                DateAdded = DateTime.Now,
                FileType=fileType,
                Id = Guid.NewGuid(),
                //ContentType=iFormFile.ContentType,
                FileName= entityName + "_"+ fileType.ToString()+"_"+ dateTime.ToString("yyyy-MM-dd"),
                Description=description
                //dodać kodowanie procentowe znaków nazwy pliku
            };
            BackblazeAPI api = new BackblazeAPI();
            api.AutorizeAccount();
            BakcblazeGetUploadUrlResponse urlResponse = api.GetUploadUrl();

            MemoryStream ms = new MemoryStream();
            iFormFile.CopyTo(ms);
            ms.Close();
            byte[] bytes = ms.ToArray();

            string backblazeFileId = api.UploadFile(fileDescription.FileName, bytes, iFormFile.ContentType, urlResponse);
            fileDescription.BackblazeFileId = backblazeFileId;
            return fileDescription;
        }


    }
}
