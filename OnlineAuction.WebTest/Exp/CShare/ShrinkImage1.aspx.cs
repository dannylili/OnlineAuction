using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.IO;

namespace OnlineAuction.WebTest.Exp.CShare
{
    public partial class ShrinkImage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 1 将水印图片扩大到和上传图片大小一样的临时图片
        /// 2 将水印图片和上传图片合成一张图片
        /// 3 保存图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Graphics g = null;
            System.Drawing.Image upimage = null;
            System.Drawing.Image thumimg = null;
            System.Drawing.Image simage = null;
            System.Drawing.Image newSimage = null;
            Bitmap outputfile = null;

            try
            {
                string extension = Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToUpper();
                string filename = DateTime.Now.ToString("yyyyMMddhhmmss");
                string smallpath = Server.MapPath(".") + "/smallimg/";
                string bigpath = Server.MapPath(".") + "/bigimg/";
                int width, height, newwidth, newheight;
                System.Drawing.Image.GetThumbnailImageAbort callb = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                if (!Directory.Exists(smallpath))
                    Directory.CreateDirectory(smallpath);
                if (!Directory.Exists(bigpath))
                    Directory.CreateDirectory(bigpath);
                Stream upimgfile = FileUpload1.PostedFile.InputStream;
                // string simagefile = Server.MapPath("a8logo.jpg"); //要加水印的文件 
                string simagefile = Server.MapPath("watePrint.png");
                simage = System.Drawing.Image.FromFile(simagefile);
                upimage = System.Drawing.Image.FromStream(upimgfile); //上传的图片 
                width = upimage.Width;
                height = upimage.Height;
                newSimage = simage.GetThumbnailImage(width, height, null, IntPtr.Zero);
                if (width > height)
                {
                    newwidth = 200;
                    newheight = (int)((double)height / (double)width * (double)newwidth);
                }
                else
                {
                    newheight = 200;
                    newwidth = (int)((double)width / (double)height * (double)newheight);
                }
                thumimg = upimage.GetThumbnailImage(newwidth, newheight, callb, IntPtr.Zero);
                outputfile = new Bitmap(upimage);
                g = Graphics.FromImage(outputfile);
                //g.DrawImage(simage, new Rectangle(upimage.Width - simage.Width, upimage.Height - simage.Height, upimage.Width, upimage.Height), 0, 0, upimage.Width, upimage.Height, GraphicsUnit.Pixel);
                g.DrawImage(newSimage, new Rectangle(0, 0, upimage.Width, upimage.Height), 0, 0, upimage.Width, upimage.Height, GraphicsUnit.Pixel);
                string newpath = bigpath + filename + extension; //原始图路径 
                string thumpath = smallpath + filename + extension; //缩略图路径 
                outputfile.Save(newpath);
                thumimg.Save(thumpath);
                outputfile.Dispose();



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (g != null)
                    g.Dispose();
                if (thumimg != null)
                    thumimg.Dispose();
                if (upimage != null)
                    upimage.Dispose();
                if (simage != null)
                    simage.Dispose();
                if (newSimage != null)
                    newSimage.Dispose();
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
    }
}