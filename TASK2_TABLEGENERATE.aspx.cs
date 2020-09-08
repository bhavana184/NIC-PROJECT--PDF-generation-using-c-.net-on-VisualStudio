using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace TASK2_TABLEGENERATE
{
    public partial class TASK2_TABLEGENERATE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Document document = new Document(PageSize.A4, 40, 40, 40, 40);
            Font NormalFont2 = FontFactory.GetFont("Arial", 12, Font.UNDERLINE, BaseColor.BLACK);
            PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();
            PdfPTable table = new PdfPTable(3);

            table.WidthPercentage = 100;
            table.SpacingBefore = 0f;
            table.SpacingAfter = 0f;

           /* Paragraph Text = new Paragraph("Check-List for Direct recruitment to Group 'B'(Non-Gazetted) & 'C' Posts", NormalFont2);
            Text.Alignment = Element.ALIGN_CENTER;//to put the paragraph at center 
            document.Add(Text);*/
            document.Add(Chunk.NEWLINE);//to add new line

            /* // first row
             PdfPCell cell = new PdfPCell(new Phrase("Check-List for Direct recruitment to Group 'B'(Non-Gazetted) & 'C' Posts",NormalFont2));
             cell.Colspan =4;
             cell.HorizontalAlignment=Element.ALIGN_CENTER ;
             cell.Padding=5.0f;
            // cell.BackgroundColor(new BaseColor(140, 221, 8));
             table.AddCell(cell);
            */

            table.AddCell("Sl.No");
            table.AddCell("Roll no.");
            table.AddCell(" ");
            //table.AddCell("Yes/No");


            for (int i = 1; i < 21; i++)
            {
                table.AddCell(" " + i);
                table.AddCell("Rollno." + i);
                table.AddCell("Information" + i);
                //table.AddCell("Y/N " + i);


            }
            document.Add(table);
            document.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=TASK2_TABLEGENERTEWebForm.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(document);
            Response.End();

        }
    }
}