using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace CORRECT_WEBFORM
{
    public partial class CORRECTWEBFORM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Document pdfDoc = new Document(PageSize.A4, 40, 50, 40, 50);//top,left,bottom,right (page margins)
                Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
                Font NormalFont1 = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK);
                Font NormalFont2 = FontFactory.GetFont("Arial", 12, Font.UNDERLINE, BaseColor.BLACK);

                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();

                //page1
                //pdfDoc.Add(new Paragraph("Page 1", NormalFont2));

                Paragraph Text = new Paragraph("REQUISITION PERFORMA", NormalFont1);
                Text.Alignment = Element.ALIGN_CENTER;//to put the paragraph at center 
                //underline needed
                pdfDoc.Add(Text);
                pdfDoc.Add(Chunk.NEWLINE);//to add new line

                Paragraph Text1 = new Paragraph("PROFORMA-001", NormalFont1);
                Text1.Alignment = Element.ALIGN_RIGHT;//to put the paragraph at right
                //underline needed
                pdfDoc.Add(Text1);
                pdfDoc.Add(Chunk.NEWLINE);

                Paragraph Text2 = new Paragraph("PROFORMA FOR SENDING REQUISITION TO THE D.S.S.S.BOARD", NormalFont1);
                Text2.Alignment = Element.ALIGN_CENTER;//to put the paragraph at center 
                pdfDoc.Add(Text2);

                Paragraph Text3 = new Paragraph("(Separate Proforma May Be Filled For Each Post)", NormalFont1);
                Text3.Alignment = Element.ALIGN_CENTER;//to put the paragraph at center 
                pdfDoc.Add(Text3);
                pdfDoc.Add(Chunk.NEWLINE);


                Paragraph Text4 = new Paragraph("NOTE: ALL ANSWERS IN THE REQUISITION FORM SHOULD BE GIVEN IN WORDS AND NOT BY DASHES AND DOTS,NO COLUMN SHOULD BE LEFT BLANK.", NormalFont1);
                pdfDoc.Add(Text4);
                pdfDoc.Add(Chunk.NEWLINE);

                Paragraph Text5 = new Paragraph("(To be submitted in duplicate)", NormalFont);
                Text5.Alignment = Element.ALIGN_CENTER;//to put the paragraph at center 
                pdfDoc.Add(Text5);
                pdfDoc.Add(Chunk.NEWLINE);

                Paragraph Text6 = new Paragraph("INSTRUCTIONS", NormalFont1);
                Text6.Alignment = Element.ALIGN_CENTER;//to put the paragraph at center 
                //underline needed
                pdfDoc.Add(Text6);
                pdfDoc.Add(Chunk.NEWLINE);

                Paragraph Text7 = new Paragraph("Kindly note the following instruction before filling up the format:-" +
                Chunk.NEWLINE + "1. The Delhi Subordinate Services Selection Board (DSSSB) is making recruitment of group 'B' & 'C'.Civil/Technical (Non-Gazetted) Posts." +
                Chunk.NEWLINE + "2. The requisition for Group 'B' & 'C' posts may be sent to the secretary, Delhi Subordinate Services Selection Board, FC-18 institutional area Karkardooma Delhi-110092." +
                Chunk.NEWLINE + "3. Each page of the proforma & RRs should be signed & stamped by the competent authority." +
                Chunk.NEWLINE + "4.Each requisition is to be accompanied by the following documents:-" +
                Chunk.NEWLINE + "(a) A copy of latest notification promulgating the Recruitment Rules ( as amended from time to time) dully signed by the Competent Authority." +
                Chunk.NEWLINE + "(b) A copy of the laid down duties and responsibilities attached to the post." +
                Chunk.NEWLINE + "(c) A copy of the No objection certificate obtained from the service department, CCS (Redeployment of surplus staff) Rule,1990 notified vide DOPT letter No.1/5/2000-C/S/_III dated 10/11/2000." +
                Chunk.NEWLINE + "(d) A certificate to this effect that clearance has been obtained from the screening committee of the administrative Department for filling up of the vacant post(s)." +
                Chunk.NEWLINE + "(e) A certificate in accordance with DOPT OMisabilities Act,2016." +
                Chunk.NEWLINE, NormalFont);
                pdfDoc.Add(Text7);

                Paragraph Text8 = new Paragraph("                                                                                                                       ", NormalFont2);
                Text8.Alignment = Element.ALIGN_CENTER;
                pdfDoc.Add(Text8);
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(Chunk.NEWLINE);

                ///Straight horizontal line to be printed.
                //Main Form

                pdfDoc.Add(Chunk.NEXTPAGE);

                Paragraph Text9 = new Paragraph("PROFORMA", NormalFont1);
                Text9.Alignment = Element.ALIGN_CENTER;//to put the paragraph at center 
                //underline needed
                pdfDoc.Add(Text9);
                //pdfDoc.Add(Chunk.NEWLINE);//to add new line

                PdfPTable maintable = new PdfPTable(3);
                maintable.DefaultCell.Border = Rectangle.NO_BORDER;
                maintable.HorizontalAlignment = Element.ALIGN_LEFT;
                maintable.SetWidths(new int[] { 10, 70, 30 });

                maintable.AddCell("1" + ".");
                PdfPCell cell = new PdfPCell(new Phrase("Name of the Department / Organisation / Office",NormalFont ));
                cell.Border = Rectangle.NO_BORDER;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                maintable.AddCell(cell);
                maintable.AddCell("");
                pdfDoc.Add(Chunk.NEWLINE);

                maintable.AddCell("2" + ".");
                maintable.AddCell(new Phrase("Complete postal address of the head of office of the department/organisation",NormalFont));
                maintable.AddCell("");

                pdfDoc.Add(maintable);
                pdfDoc.Add(Chunk.NEWLINE);


                Paragraph Text11 = new Paragraph("3. (a)(i)Brief particulars of the post(s) for which the requisition is being sent:-" +
                    Chunk.NEWLINE,NormalFont);
                pdfDoc.Add(Text11);
                pdfDoc.Add(Chunk.NEWLINE);

                PdfPTable innertable = new PdfPTable(9);
                innertable.HorizontalAlignment = 1;//1=center
                innertable.SetWidths(new int[] {80,60,40,30,30,60,50,50,40 });

                innertable.AddCell("Designation");
                innertable.AddCell("Pay Scale Plus Allowances as admissible Under The Rules");
                innertable.AddCell("Group & Service Cadre");
                PdfPCell cell1 = new PdfPCell(new Phrase("Vacancies pmt./temp."));
                cell1.Colspan = 2;
                innertable.AddCell(cell1);
                innertable.AddCell("Brief Description of the Job Requirements And Nature of Duties Of the Post");
                innertable.AddCell("Sports Persons");
                innertable.AddCell("Reserved For Male/Female");
                innertable.AddCell("Any Other Category Other Than(8 to 9");

                innertable.AddCell("1. ");
                innertable.AddCell("2. ");
                innertable.AddCell("3. ");
                innertable.AddCell("4. ");
                innertable.AddCell("5. ");
                innertable.AddCell("6. ");
                innertable.AddCell("7. ");
                innertable.AddCell("8. ");
                innertable.AddCell("9. ");


                innertable.AddCell(" ");
                innertable.AddCell(" ");
                innertable.AddCell(" ");
                innertable.AddCell(" ");
                innertable.AddCell(" ");
                innertable.AddCell(" ");
                innertable.AddCell(" ");
                innertable.AddCell("  ");
                innertable.AddCell(" ");
                pdfDoc.Add(innertable);

                pdfDoc.Add(Chunk.NEWLINE);

                Paragraph Text12 = new Paragraph("3(a)(ii)" + Chunk.NEWLINE);
                pdfDoc.Add(Text12);

                PdfPTable innertable1 = new PdfPTable(5);
                innertable.HorizontalAlignment = 1;//1=center

                innertable1.AddCell("Total Sanctioned post");
                innertable1.AddCell("Total Sanctioned Post for Direct recruitment");
                innertable1.AddCell("Total Vacant Post for Direct recruitment");
                innertable1.AddCell("Total no. of vacancies requisitioned against direct recruitment");
                innertable1.AddCell("Total backlog vacancies of previous recruitment added to this requisition");

                innertable1.AddCell(" ");
                innertable1.AddCell(" ");
                innertable1.AddCell(" ");
                innertable1.AddCell(" ");
                innertable1.AddCell(" ");
                pdfDoc.Add(innertable1);

                pdfDoc.Add(Chunk.NEWLINE);

                Paragraph Text13 = new Paragraph("3(a)(iii) prospects of promotion to higher posts or time scale,if provided in the notified RR's:" + Chunk.NEWLINE);
                pdfDoc.Add(Text13);
                pdfDoc.Add(Chunk.NEWLINE);
                
                PdfPTable maintable1 = new PdfPTable(5);
                maintable1.HorizontalAlignment = Rectangle.ALIGN_LEFT;
                maintable1.SetWidths(new int[] { 20, 70,70, 120,60 });
                maintable1.DefaultCell.Border = Rectangle.NO_BORDER;
                maintable1.AddCell("");
                maintable1.AddCell("Present Scale");
                maintable1.AddCell(" ");
                maintable1.AddCell("Period of next promotion");
                maintable1.AddCell(" ");

                maintable1.AddCell(" ");
                maintable1.AddCell(" ");
                maintable1.AddCell(" ");
                maintable1.AddCell(" ");
                maintable1.AddCell(" ");

                pdfDoc.Add(maintable1);
                pdfDoc.Add(Chunk.NEWLINE);

                Paragraph Text14 = new Paragraph("(b) break-up vacancies(this may be shown in the format of vertical and horizontal components as indicated below:-" + Chunk.NEWLINE);
                pdfDoc.Add(Text14);
                pdfDoc.Add(Chunk.NEWLINE);

                pdfDoc.Add(Chunk.NEXTPAGE);

                Paragraph Text15 = new Paragraph("(c) Category-wise(vertical) Break-up of vacancies  ");
                Text1.Alignment = Element.ALIGN_LEFT;
                pdfDoc.Add(Text15);
                pdfDoc.Add(Chunk.NEWLINE);

                PdfPTable maintable2 = new PdfPTable(5);
                maintable2.HorizontalAlignment = 1;
                maintable2.DefaultCell.Border = Rectangle.NO_BORDER;
                //maintable.SetWidths(new int[] { 5, 20, 10, 15, 30 });

                PdfPCell cell2 = new PdfPCell(new Phrase("Category"));
                cell2.Border = Rectangle.NO_BORDER;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.Colspan = 3;
                maintable2.AddCell(cell2);

                maintable2.AddCell("  ");

                PdfPCell cell3 = new PdfPCell(new Phrase("No. of vacancies"));
                cell3.Border = Rectangle.NO_BORDER;
                maintable2.AddCell(cell3);

                maintable2.AddCell(" ");
                maintable2.AddCell(" ");
                maintable2.AddCell(" ");
                maintable2.AddCell(" ");
                maintable2.AddCell(" ");


                maintable2.AddCell(" (i)");
                maintable2.AddCell("UR");
                maintable2.AddCell(":");
                maintable2.AddCell("  ");
                maintable2.AddCell("-------");

                maintable2.AddCell("(ii)");
                maintable2.AddCell("OBC");
                maintable2.AddCell(":");
                maintable2.AddCell("  ");
                maintable2.AddCell("-------");

                maintable2.AddCell("(iii)");
                maintable2.AddCell("SC");
                maintable2.AddCell(":");
                maintable2.AddCell("  ");
                maintable2.AddCell("-------");

                maintable2.AddCell("(iv)");
                maintable2.AddCell("ST");
                maintable2.AddCell(":");
                maintable2.AddCell("  ");
                maintable2.AddCell("-------");

                maintable2.AddCell(" ");
                maintable2.AddCell("Total");
                maintable2.AddCell(":");
                maintable2.AddCell("  ");
                maintable2.AddCell("-------");

                pdfDoc.Add(maintable2);
                pdfDoc.Add(Chunk.NEWLINE);

                Paragraph Text17 = new Paragraph("(d)Horizontal Reservation :" + Chunk.NEWLINE +
                    Chunk.NEWLINE + "(I)Whether the post is identified as suitable for" + Chunk.NEWLINE);
                pdfDoc.Add(Text17);
                pdfDoc.Add(Chunk.NEWLINE);

                PdfPTable maintable4 = new PdfPTable(4);
                maintable4.HorizontalAlignment = 1;
                maintable4.DefaultCell.Border = Rectangle.NO_BORDER;
                maintable4.AddCell(" (i)");
                maintable4.AddCell("OH");
                maintable4.AddCell("");
                maintable4.AddCell("Yes/No");
                maintable4.AddCell(" (ii)");
                maintable4.AddCell("HH");
                maintable4.AddCell("");
                maintable4.AddCell("Yes/No");
                maintable4.AddCell(" (iii)");
                maintable4.AddCell("VH");
                maintable4.AddCell("");
                maintable4.AddCell("Yes/No");
                pdfDoc.Add(maintable4);
                pdfDoc.Add(Chunk.NEWLINE);

                Paragraph text100 = new Paragraph("(II)Out of the total vacancies shown in Col.3(c),the number of vacancies for " +
                 "      PH(Horizontal reservation  and the subcategories (OA /OL /OAL /BA /BL /Blind /        Partially Blind /Deaf /Partially Deaf & Dumb etc.) should be clearly mentioned: " + Chunk.NEWLINE);
                pdfDoc.Add(text100);
                pdfDoc.Add(Chunk.NEWLINE);

                PdfPTable maintable5 = new PdfPTable(4);
                maintable5.HorizontalAlignment = 1;
                maintable5.DefaultCell.Border = Rectangle.NO_BORDER;
                maintable5.AddCell(" (i)");
                maintable5.AddCell("OH");
                maintable5.AddCell("-");
                maintable5.AddCell(" ");

                maintable5.AddCell(" (ii)");
                maintable5.AddCell("HH");
                maintable5.AddCell("-");
                maintable5.AddCell(" ");

                maintable5.AddCell(" (iii)");
                maintable5.AddCell("VH");
                maintable5.AddCell("-");
                maintable5.AddCell(" ");

                pdfDoc.Add(maintable5);
                pdfDoc.Add(Chunk.NEWLINE);

                pdfDoc.Add(Chunk.NEWLINE);
                Paragraph Text101 = new Paragraph("   (IV) Out of the total vacancies shown above in Col.3(c),the number of vacancies " +
                  Chunk.NEWLINE + "           for Ex-servicemen (Horizontal reservation)" + Chunk.NEWLINE +
                  Chunk.NEWLINE + "   (Please note that the vacancies mentioned in the vertical component shall be the" +
                  Chunk.NEWLINE + "   total number of vacancies inclusive of the horizontal componet)" + Chunk.NEWLINE +
                  Chunk.NEWLINE + "    4. Qualification and experience as laid down it the Notified Recruitment Rules" +
                  Chunk.NEWLINE + "        including any relaxation." 
                  );
                pdfDoc.Add(Text101);
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(Chunk.NEXTPAGE);

                Paragraph Text18 = new Paragraph("  A.  QUALIFICATIONS" , NormalFont1);
                pdfDoc.Add(Text18);
                

                PdfPTable maintable6 = new PdfPTable(3);
                maintable6.DefaultCell.Border = Rectangle.NO_BORDER;
                maintable6.HorizontalAlignment = Element.ALIGN_LEFT;
                maintable6.SetWidths(new int[] { 10, 70, 30 });

                maintable6.AddCell("("+"a" + ")");
                PdfPCell cell4 = new PdfPCell(new Phrase("Essential", NormalFont));
                cell4.Border = Rectangle.NO_BORDER;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                maintable6.AddCell(cell4);
                maintable6.AddCell("");
                pdfDoc.Add(Chunk.NEWLINE);

                maintable6.AddCell("("+"b" + ")");
                maintable6.AddCell(new Phrase("Desirable(Please indicate 'Nil' if not specified in the recruitment rules)", NormalFont));
                maintable6.AddCell("");

                pdfDoc.Add(maintable6);
                pdfDoc.Add(Chunk.NEWLINE);

                Paragraph Text20 = new Paragraph("B.  EXPERIENCE" + Chunk.NEWLINE + Chunk.NEWLINE, NormalFont1);
                pdfDoc.Add(Text20);

                PdfPTable maintable7 = new PdfPTable(3);
                maintable7.DefaultCell.Border = Rectangle.NO_BORDER;
                maintable7.HorizontalAlignment = Element.ALIGN_LEFT;
                maintable7.SetWidths(new int[] { 10, 70, 30 });

                maintable7.AddCell("(" + "a" + ")");
                PdfPCell cell5 = new PdfPCell(new Phrase("Essential", NormalFont));
                cell5.Border = Rectangle.NO_BORDER;
                cell5.HorizontalAlignment = Element.ALIGN_LEFT;
                maintable7.AddCell(cell5);
                maintable7.AddCell("");
                pdfDoc.Add(Chunk.NEWLINE);

                maintable7.AddCell("(" + "b" + ")");
                maintable7.AddCell(new Phrase("Desirable(Please indicate 'Nil' if not specified in the recruitment rules)", NormalFont));
                maintable7.AddCell("");
                pdfDoc.Add(maintable7);
                pdfDoc.Add(Chunk.NEWLINE);

                PdfPTable maintable8 = new PdfPTable(3);
                maintable8.DefaultCell.Border = Rectangle.NO_BORDER;
                maintable8.HorizontalAlignment = Element.ALIGN_LEFT;
                maintable8.SetWidths(new int[] { 10, 70, 30 });

                maintable8.AddCell("5" + ".");
                PdfPCell cell6 = new PdfPCell(new Phrase("Whether qualification and experience are relaxable in case of SC/ST", NormalFont));
                cell6.Border = Rectangle.NO_BORDER;
                cell6.HorizontalAlignment = Element.ALIGN_LEFT;
                maintable8.AddCell(cell6);
                maintable8.AddCell("");
                pdfDoc.Add(Chunk.NEWLINE);

                Paragraph Text22 = new Paragraph("6.  Age Limits:" + Chunk.NEWLINE, NormalFont1);
                pdfDoc.Add(Text22);
                Paragraph Text23 = new Paragraph("(a) As per recruitment rules" + Chunk.NEWLINE +
                                                 "(b) Relaxation in upper age limit available to:" + Chunk.NEWLINE);
                pdfDoc.Add(Text23);
                pdfDoc.Add(Chunk.NEWLINE);

                PdfPTable maintable9 = new PdfPTable(7);
                maintable9.DefaultCell.Border = Rectangle.NO_BORDER;
                maintable9.HorizontalAlignment = Element.ALIGN_LEFT;
                maintable9.SetWidths(new int[] { 10,15, 70,30,20, 30,20 });

                maintable9.AddCell("");
                maintable9.AddCell(" (i)");
                maintable9.AddCell("SC");
                maintable9.AddCell(" ");
                maintable9.AddCell("by");
                maintable9.AddCell(" ------------");
                maintable9.AddCell("Years");

                maintable9.AddCell("");
                maintable9.AddCell(" (ii)");
                maintable9.AddCell("ST");
                maintable9.AddCell(" ");
                maintable9.AddCell("by");
                maintable9.AddCell(" ------------");
                maintable9.AddCell("Years");

                maintable9.AddCell("");
                maintable9.AddCell(" (iii)");
                maintable9.AddCell("OBC");
                maintable9.AddCell(" ");
                maintable9.AddCell("by");
                maintable9.AddCell(" ------------");
                maintable9.AddCell("Years");

                maintable9.AddCell("");
                maintable9.AddCell(" (iv)");
                maintable9.AddCell("PH");
                maintable9.AddCell(" ");
                maintable9.AddCell("by");
                maintable9.AddCell(" ------------");
                maintable9.AddCell("Years");

                maintable9.AddCell("");
                maintable9.AddCell(" (v)");
                maintable9.AddCell("PH & SC/ST");
                maintable9.AddCell(" ");
                maintable9.AddCell("by");
                maintable9.AddCell(" ------------");
                maintable9.AddCell("Years");

                maintable9.AddCell("");
                maintable9.AddCell(" (vi)");
                maintable9.AddCell("PH & OBC");
                maintable9.AddCell(" ");
                maintable9.AddCell("by");
                maintable9.AddCell(" ------------");
                maintable9.AddCell("Years");

                maintable9.AddCell("");
                maintable9.AddCell(" (vii)");
                maintable9.AddCell("Departmental Candidates");
                maintable9.AddCell(" ");
                maintable9.AddCell("by");
                maintable9.AddCell(" ------------");
                maintable9.AddCell("Years");

                maintable9.AddCell("");
                maintable9.AddCell(" (viii)");
                maintable9.AddCell("Are the age limits relaxable for  Women/Widows/Divorced Women ");
                maintable9.AddCell(" ");
                maintable9.AddCell("by");
                maintable9.AddCell(" ------------");
                maintable9.AddCell("Years");

                maintable9.AddCell("");
                maintable9.AddCell(" (ix)");
                maintable9.AddCell("Contractual Employees");
                maintable9.AddCell(" ");
                maintable9.AddCell("by");
                maintable9.AddCell(" ------------");
                maintable9.AddCell("Years");

                maintable9.AddCell("");
                maintable9.AddCell(" (x)");
                maintable9.AddCell("Are the limits and relaxations as above are in accordance with the prescribed recruitment rules? If no please state the reason for deviation.");
                maintable9.AddCell(" ");
                maintable9.AddCell(" ");
                maintable9.AddCell(" ");
                maintable9.AddCell(" ");

                maintable9.AddCell("");
                maintable9.AddCell(" (xi)");
                maintable9.AddCell(" Whether the benefits of added years of services admissible under Rule 30 of the CCS(Pension)Rules is applicable to the posts");
                maintable9.AddCell(" ");
                maintable9.AddCell("");
                maintable9.AddCell(" ");
                maintable9.AddCell("");
                pdfDoc.Add(maintable9);
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(Chunk.NEXTPAGE);

                Paragraph Text24 = new Paragraph("NOTE: As regards age relaxation to physically categories candidates, your attention is invited to DOPT OM No. 43019 / 28 / 86 - Estt.(D) dated 01 / 02 / 1999", NormalFont1);
                pdfDoc.Add(Text24);
                //pdfDoc.Add(Chunk.NEWLINE);

                PdfPTable maintable10 = new PdfPTable(3);
                maintable10.DefaultCell.Border = Rectangle.NO_BORDER;
                maintable10.HorizontalAlignment = Element.ALIGN_LEFT;
                maintable10.SetWidths(new int[] { 10, 70, 30 });
                pdfDoc.Add(Chunk.NEWLINE);

                maintable10.AddCell("7" + ".");
                PdfPCell cell7 = new PdfPCell(new Phrase("Period of probation"));
                cell7.Border = Rectangle.NO_BORDER;
                cell7.HorizontalAlignment = Element.ALIGN_LEFT;
                maintable10.AddCell(cell7);
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("8" + ".");
                maintable10.AddCell("Any other requirements or conditions specified  for this post or not covered by the above Columns.");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("9" + ".");
                maintable10.AddCell("Name,address and telephone number of the Departmental Representative who will be Deputed to assist the DSSSB directly?");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("10" + ".");
                maintable10.AddCell("Whether the requisitioning authority is authorized by the Administra itive Department, to place the requisition with the DSSSB directly? ");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("11" + ".");
                maintable10.AddCell("If a Vacancy is permanent whether it is to filled on permanent or temporary basis.If a  vacancy is temporary, how long is it expected to  last irrespective of the period for which it had been sanctioned. ");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("12" + ".");
                maintable10.AddCell("a) Have recruitment rules for the  posts been approved by the Competent Authority.Quote the reference number and date.Enclosed an authenticated copy of latest notification promulgating the rules.");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell(" b) If  (a) above is not done ,the reason thereof. ");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");
                
                maintable10.AddCell("13.");
                maintable10.AddCell("Is the post is pensionable or non-pensionable? ");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("a)Are there any Provident Fund or other benefits & if so,please specify. ");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("b) Whether the New Defined Contributory Pension Scheme w.e.f.01 / 01 / 2004 as per Govt.of India OM No. 1{ 7}{ 2}/ 2003 / 1A dated 07 / 01 / 2004 is applicable in compliance of instructions contained in letter No. F.14(1) / 2004 / Fin.(B) dated 19 / 07 / 2006 Issued by Finance(Budget) Department of GNCT of Delhi. ");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("14.");
                maintable10.AddCell(" Name,address and telephone number of the Department Representative with whom these proposals may be discussed.");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("15.");
                maintable10.AddCell(" Whether the captioned post(s) has / have been 7 / 3 / 6 / e / Coordn./ 99 dated 05 / 08 / 1999 and subsequent orders issued in this regard by the Department of Finance,GNCT of Delhi.");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("16.");
                maintable10.AddCell(" Whether the number of vacancies reserved for SC / ST / OBC as mentioned in Col.2(c) above is in accordance with the reservation quota fixed for these communities as per the DOPTOM No. 36012 / 2 / 96 - Estt.(Res.)dated 02 / 07 / 1997 and DOPT No.36012 / 5 / 97 - Est.(Res.) Vol.II dated 20 / 07 / 2000.");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("17.");
                maintable10.AddCell(" Whether the vacancies for physically handicapped and Ex-serviceman have been worked out with reference to DOPT OM No. 36035/02/2017-Estt.(Res) dated 15/01/2018 the right of persons with disabilities Act,2016.");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("18.");
                maintable10.AddCell(" Letter number and date of last requisition for the same post (alongwith category wise break-up of the number of vacancies) placed with the DSSSB  by your office.");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("19.");
                maintable10.AddCell(" Letter number & date by which nomination has been made by DSSSB to your office earlier for the same post.");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("20.");
                maintable10.AddCell(" Whether the provision for addition of two years been taken into consideration in this requisition as per Notification No. 15012/6/98/Estt.(D) dated 21/12/1998 issued by the Govt. of India ,Ministry of Public Grievances and Pension(DOPT),New Delhi.");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("21.");
                maintable10.AddCell(" The validity of panel will be 90 days after the publication of entire merit list for the candidates falling the original zone of consideration and thereafter 45 days for extended zone of consideration .After this period the merit list for the particular examination would stand automatically exhausted.");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                maintable10.AddCell("");
                maintable10.AddCell("");
                maintable10.AddCell("");

                pdfDoc.Add(maintable10);
                pdfDoc.Add(Chunk.NEWLINE);

                Paragraph Text70 = new Paragraph("It is certified that :" + Chunk.NEWLINE +
                Chunk.NEWLINE + "    (a) The information furnished aganist the above mentioned columns are correct and based on the official records available with the office;" +
                Chunk.NEWLINE + "    (b) Vacancies projected in this requisition are regular and all regular vacancies on date which fall within the direct recruitment quota have been included in this requisition,and also the necessary sanction of the GNCT of Delhi for these posts is available");
                pdfDoc.Add(Text70);

                //pdfDoc.Add(Chunk.NEXTPAGE);

                //Page 8
                //pdfDoc.Add(new Paragraph("Page 8", NormalFont2));
                //pdfDoc.Add(Chunk.NEWLINE);

                Paragraph Text1002 = new Paragraph("    (c) The vacancies reported shall not be withdrawn nor the number and category break-up of vacancies shall be altered under my circumstances;" +
             Chunk.NEWLINE + "    (d) Suitable personnel are not avaiable with the Surplus Cell of Services Department , GNCT of Delhi for filling up these vacancies;" +
              Chunk.NEWLINE + "    (e) while sending requisition , policy relating to 4% reservation for persons with disabilities has been taken care of;" +
             Chunk.NEWLINE + "    (f)  (I) The post for which this requisition is being sent has been identified as suitable for being manned by persons with disabilities. Vacancies reserved for the disabled have been suitably indicated in the vacancy position; " +
               Chunk.NEWLINE + "         (II) The post for which this requisition is being sent has been identified as suitable for being manned by persons with disabilties . However , none of the vacancies reported hereby has been earmarked reserved for the diabled;" +
               Chunk.NEWLINE + "         (III) The post for which this requisition is being sent has been identified as suitable for being manned by persons with disabilities;" +
               Chunk.NEWLINE + "         (IV) The estabilishment/organisation to which the post is to be filled up,for which this requisition is being sent has been exempted from the provisions for Section 33 of the Persons with Disabilities (Equal Opportunities , Protection of Rights and full Participation) Act, 1995;" +
               Chunk.NEWLINE + "    (g) The number of vacancies reserved for SC,ST,OBC etc. as mentioned in column 3(c) above are in accordance with the reservation quota fixed by the Government for these communities;" +
               Chunk.NEWLINE + "    (h) Candidate nominated by the DSSSB aganist the vacancies reported in this reuisition shall be given appointment by this office within three months from the date of nomination;" +
               Chunk.NEWLINE + "    (i) It is also certified that all enclosures required with requisition are enclosed herewith." +
               Chunk.NEWLINE + "    (j) It is certified that number of vacancies reserved for SC/ST/OBC/Physically handicapped,Ex-Serviceman,Male & Female mentioned in col. No. 3 (c & d) above are in accordance with the latest post based reservation roaster/reservation quota fixed by the Government for these communities." +
               Chunk.NEWLINE, NormalFont);

                pdfDoc.Add(Text1002);
                Paragraph Text341 = new Paragraph(" Signature, Name,Designation and" +
                    Chunk.NEWLINE + "Offical seal of the officer authorized" +
                    Chunk.NEWLINE + "to send this requisition" +
                    Chunk.NEWLINE + " Tel. No." +
                    Chunk.NEWLINE
                    , NormalFont);
                Text341.Alignment = Element.ALIGN_RIGHT;
                pdfDoc.Add(Text341);
                Paragraph Text67 = new Paragraph("Place:" + Chunk.NEWLINE + "Date:" + Chunk.NEWLINE, NormalFont);
                Text67.Alignment = Element.ALIGN_LEFT;
                pdfDoc.Add(Text67);
                Paragraph Text69 = new Paragraph("NOTE:", NormalFont2);
                pdfDoc.Add(Text69);
                Paragraph Text89 = new Paragraph("In case it has been decided that any of the vacancies should nt be filled , the details thereof , together with the period of which these are to be held in abeyance , may be given separately in an Annexure to be signed by the Officier signing this requisition ." + Chunk.NEWLINE + Chunk.NEWLINE + "*Strike off whichever is not applicable." + Chunk.NEWLINE, NormalFont);
                pdfDoc.Add(Text89);

                //page9
                pdfDoc.Add(Chunk.NEXTPAGE);
                Paragraph Text29 = new Paragraph("FORM NO. 002" + Chunk.NEWLINE + "DRAFT ADVERTISEMENT(Please see instructions below)" + Chunk.NEWLINE, NormalFont1); ;
                Text29.Alignment = Element.ALIGN_CENTER;//to put the paragraph at center 
                pdfDoc.Add(Text29);


                PdfPTable table7 = new PdfPTable(4);
                table7.HorizontalAlignment = 0;
                table7.WidthPercentage = 105f;

                table7.SetWidths(new int[] { 5, 30, 30, 20 });
                table7.DefaultCell.Border = Rectangle.NO_BORDER;

                table7.AddCell("");
                table7.AddCell("");
                table7.AddCell("");
                table7.AddCell("");

                table7.AddCell("");
                table7.AddCell("");
                table7.AddCell("");
                table7.AddCell("");


                // first row
                PdfPCell cell111 = new PdfPCell(new Paragraph("Name of the post " + Chunk.NEWLINE + "Number of vacancies: -Total_______(UR______, OBC______, SC_______, ST_______)"));
                cell111.Border = Rectangle.NO_BORDER;
                cell111.HorizontalAlignment = Element.ALIGN_LEFT;

                cell111.Colspan = 4;
                table7.AddCell(cell111);
                // second row


                cell = new PdfPCell(new Paragraph("Vacancies for EXSM________, PH(OH_______, VH_______, VI_______, IV______,)etc. as per  "));
                cell.Colspan = 4;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);

                cell = new PdfPCell(new Phrase(" 001 proforma : "));
                cell.Colspan = 4;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);

                cell = new PdfPCell(new Phrase("(The following will be strictly according to Recruitement Rules.)"));

                cell.Colspan = 4;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);


                cell = new PdfPCell(new Phrase("   1. Qualifications :- "));
                cell.Colspan = 4;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);



                table7.AddCell("");
                cell = new PdfPCell(new Phrase(" (i) Essential :- "));
                cell.Colspan = 3;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);


                table7.AddCell("");
                cell = new PdfPCell(new Phrase("(ii) Desirable :- "));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Colspan = 3;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);

                cell = new PdfPCell(new Phrase("   2. Experience :- "));
                cell.Colspan = 4;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);


                table7.AddCell("");
                cell = new PdfPCell(new Phrase(" (i) Essential :- "));
                cell.Colspan = 3;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);


                table7.AddCell("");
                cell = new PdfPCell(new Phrase("(ii) Desirable :- "));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Colspan = 3;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);


                cell = new PdfPCell(new Phrase("   3. Physical Standards :- "));
                cell.Colspan = 4;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);

                table7.AddCell("");
                cell = new PdfPCell(new Phrase(" (i) Essential :- "));
                cell.Colspan = 3;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);


                table7.AddCell("");
                cell = new PdfPCell(new Phrase("(ii) Desirable :- "));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Colspan = 3;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);

                table7.AddCell("");
                table7.AddCell("");
                table7.AddCell("");
                table7.AddCell("");

                table7.AddCell("");
                table7.AddCell("");
                table7.AddCell("");
                table7.AddCell("");

                cell = new PdfPCell(new Phrase("Pay Scale :____________, Group:___________, Probation Period :________________ ,"));

                cell.Colspan = 4;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);



                cell = new PdfPCell(new Phrase(" Age Limit:____________to ___________"));
                cell.Colspan = 4;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);


                cell = new PdfPCell(new Phrase("Relaxable for SC / ST:______Yrs. , OBC ______Yrs. , PH:______Yrs., PH & SC / ST:______Yrs.,"));
                cell.Colspan = 4;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);


                cell = new PdfPCell(new Phrase("PH & OBC :_______Yrs., Govt.Employee:________Yrs., Departmental Candidates:"));
                cell.Colspan = 4;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);


                cell = new PdfPCell(new Phrase("________Yrs., Any Other Category:________Yrs."));
                cell.Colspan = 4;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);

                cell = new PdfPCell(new Phrase(" Dully vetted and attested"));
                cell.Colspan = 4;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);

                cell = new PdfPCell(new Phrase("SD"));
                cell.Colspan = 4;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);

                cell = new PdfPCell(new Phrase("(Stamped)"));
                cell.Colspan = 4;

                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.Border = Rectangle.NO_BORDER;
                table7.AddCell(cell);

                table7.AddCell("");
                table7.AddCell("");
                table7.AddCell("");
                table7.AddCell("");

                table7.AddCell("");
                table7.AddCell("");
                table7.AddCell("");
                table7.AddCell("");

                table7.AddCell("");
                table7.AddCell("");
                table7.AddCell("");
                table7.AddCell("");


                pdfDoc.Add(table7);
                Paragraph Text30 = new Paragraph("Instructions for filling up Form No.002" + Chunk.NEWLINE + "Note: -" + Chunk.NEWLINE + "1.The information provided in the form 002 will be published in the newspaper as it is .This vetted draft(Form No. 002) from the competent authority will be treated as final in case of any deviation from information provided in form No. 001.So, Kindly fill in the form 002 by paying personal attention." + Chunk.NEWLINE + Chunk.NEWLINE + "2.Departments may include any sub categories, in reservations in vacancies / age relaxation, which are not already included in the proforma." + Chunk.NEWLINE + Chunk.NEWLINE + "3.Categories not applicable may be indicated as N.A." + Chunk.NEWLINE + Chunk.NEWLINE + "4.Departments are not to fill the proforma by hand.They need to retype the proforma and information before sending them.");
                Text30.Alignment = Element.ALIGN_LEFT;
                pdfDoc.Add(Text30);

                // page 10

                //pdfDoc.Add(new Paragraph("Page 10", NormalFont2));
                //pdfDoc.Add(Chunk.NEWLINE);
                Paragraph Text39 = new Paragraph(" Certified that :" + Chunk.NEWLINE + Chunk.NEWLINE + "     The requirements of the Persons with Disability(Equal Opportunities, Protection of Rights and full Participation) RPWD Act, 2016 and the policy relating to reservation for Persons with Disability has been taken care of while sending this requisition." + Chunk.NEWLINE + Chunk.NEWLINE + "     The suitability and reservation for PH has been considered / worked out on the basis of DoPT OM No. 36035 / 3 / 2004 - Estt(Res) dated 29 / 12 / 2005 { Notification No. 16 - 70 / 2004 - DDIII dated 18 / 01 / 2007 , 15 / 03 / 2007, 23 / 03 / 2007 supersedes the Notification No. 16 - 25 / 99 - NI.I dated 31 / 05 / 2001 referred in this DoPT OM No. 36035 / 8 / 2003 - Estt.(Res)} dated 26 / 04 / 2006, No. 36035 / 10 / 2006 - Estt.(Res) Desk dated 12 / 12 / 2006 , RPWD Act, 2016 and subsequent amendments / instruction thereof." + Chunk.NEWLINE + Chunk.NEWLINE + "     That the post of .....................Under this requisition has been identified as being suitable for being manned by persons with disabilities.The vacancies reported in this requisition fall at point No. ...................of Cycle...................of 100 point reservation out of which..................No.of vacancies are reservation for persons with disabilities(i.e.Post is suitable and Reserved for PH)." + Chunk.NEWLINE + Chunk.NEWLINE + "OR" + Chunk.NEWLINE + Chunk.NEWLINE + "    That the post of...............................Under this requisition has been identified as being suitable to be manned by persons with disabilities . None of the proposed Vacancies is earmarked as reserved for the disabled (i.e.Post is suitable but not reserved for PH)." + Chunk.NEWLINE + Chunk.NEWLINE + "OR" + Chunk.NEWLINE + Chunk.NEWLINE + "    That the post of.............................being requisitioned has not been identified as being suitable to be manned by persons with disabilities(i.e.Post is not suitable and thus not reserved for PH)." + Chunk.NEWLINE);
                pdfDoc.Add(Text39);

                pdfDoc.Add(Chunk.NEWLINE);

                Paragraph Text37 = new Paragraph("[Strike out the clauses that are not applicable ]");
                Text37.Alignment = Element.ALIGN_CENTER;
                pdfDoc.Add(Text37);

                pdfDoc.Add(Chunk.NEWLINE);

                Paragraph Text40 = new Paragraph("*********", NormalFont1);
                Text40.Alignment = Element.ALIGN_CENTER;
                pdfDoc.Add(Text40);



                pdfWriter.CloseStream = false;
                pdfDoc.Close();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=TestWebForm.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
    }
}