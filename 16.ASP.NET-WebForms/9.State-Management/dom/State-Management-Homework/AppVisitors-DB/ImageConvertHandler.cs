namespace AppVisitors_DB
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.Web;

    public class ImageConvertHandler:IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/png";

            var text = context.Request.Params["text"];
            if (text == null) text = string.Empty;
            var image = this.CreateBitmapImage(text);

            image.Save(context.Response.OutputStream, ImageFormat.Png);
        }

        public bool IsReusable
        {
            get { return false; }
        }

        private Bitmap CreateBitmapImage(string sImageText)
        {
            Bitmap objBmpImage = new Bitmap(1, 1);

            int intWidth = 0;
            int intHeight = 0;

            Font objFont = new Font("SegoeUI", 60, FontStyle.Bold, GraphicsUnit.Pixel);

            Graphics objGraphics = Graphics.FromImage(objBmpImage);

            intWidth = (int)objGraphics.MeasureString(sImageText, objFont).Width;
            intHeight = (int)objGraphics.MeasureString(sImageText, objFont).Height;

            objBmpImage = new Bitmap(objBmpImage, new Size(intWidth, intHeight));

            objGraphics = Graphics.FromImage(objBmpImage);

            objGraphics.Clear(Color.White);
            objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            objGraphics.DrawString(sImageText, objFont, new SolidBrush(Color.FromArgb(102, 102, 102)), 0, 0);
            objGraphics.Flush();
            return (objBmpImage);
        }  
    }
}