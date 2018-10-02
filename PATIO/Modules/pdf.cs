using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PATIO.Modules
{
    public class PDF
    {
        public void MergePDF(List<FileInfo> Liste, string fichier_destination)
        {
            // Get some file names

            // Open the output document
            PdfDocument outputDocument = new PdfDocument();
            outputDocument.Info.Title = fichier_destination;
            outputDocument.Options.CompressContentStreams = true;
            //outputDocument.CustomValues.CompressionMode = PdfCustomValueCompressionMode.Compressed;

            // Iterate files
            foreach (FileInfo file in Liste)
            {
                // Open the document to import pages from it.
                PdfDocument inputDocument = PdfReader.Open(file.FullName, PdfDocumentOpenMode.Import);

                // Iterate pages
                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    // Get the page from the external document...
                    PdfPage page = inputDocument.Pages[idx];
                    // ...and add it to the output document.
                    outputDocument.AddPage(page);
                }
            }

            outputDocument.Save(fichier_destination);
            Process.Start(fichier_destination);
        }
    }

 
}
