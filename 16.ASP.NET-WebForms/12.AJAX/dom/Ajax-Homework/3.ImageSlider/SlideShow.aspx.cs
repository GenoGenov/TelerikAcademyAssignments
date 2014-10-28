namespace _3.ImageSlider
{
    using System;
    using System.IO;
    using System.Web.Script.Services;
    using System.Web.Services;

    using AjaxControlToolkit;

    public partial class Slideshow : System.Web.UI.Page
    {
        public static string ImagePath;
        protected void Page_Load(object sender, EventArgs e)
        {
            ImagePath = Server.MapPath("~/Images");
        }

        [WebMethod]
        [ScriptMethod]
        public static Slide[] GetSlides()
        {
            var files = Directory.GetFiles(ImagePath);
            var result = new Slide[files.Length];
            
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new Slide("Images/"+Path.GetFileName(files[i]),Path.GetFileName(files[i]),"Image "+i);
            }

            return result;
        }

        protected void ImageHolder_OnDataBinding(object sender, EventArgs e)
        {
            var a = 5;
        }
    }
}