using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace File_Upload_Homework
{
    using System.IO;
    using System.Text;

    using DbFileUpload.data;
    using DbFileUpload.models;

    using Ionic.Zip;

    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = -1;

            var db = new FilesDbContext();

            var file = Request.Files["uploaded"];
            if (file.ContentType != "application/zip" && file.ContentType != "application/octed-stream" && Path.GetExtension(file.FileName)!=".zip")
            {
                Response.Write("The file must be .zip !!!");
                return;
            }

            var length = file.ContentLength;
            var data = new byte[length + 1];
            file.InputStream.Read(data,0,length);

            var memStream = new MemoryStream(data);
            var zipFile = ZipFile.Read(memStream, new ReadOptions() { Encoding = Encoding.UTF8 });

            foreach (var entry in zipFile)
            {
                var fileStream = new MemoryStream();
                entry.Extract(fileStream);
                db.Files.Add(new UploadedFile()
                {
                    CreatedOn = DateTime.Now,
                    Data = fileStream.ToArray(),
                    FileName = entry.FileName
                });

            }
            db.SaveChanges();

            Response.ContentType = "application/json";
            Response.Write("{}");
        }
    }
}