//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Words. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System;
using System.IO;

using Aspose.Words;

namespace UpdateFields
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            // Demonstrates how to insert fields and update them using Aspose.Words.

            // First create a blank document.
            Document doc = new Document();

            // Use the document builder to insert some content and fields.
            DocumentBuilder builder = new DocumentBuilder(doc);

            // Insert a table of contents at the beginning of the document.
            builder.InsertTableOfContents("\\o \"1-3\" \\h \\z \\u");
            builder.Writeln();

            // Insert some other fields.
            builder.Write("Page: ");
            builder.InsertField("PAGE");
            builder.Write(" of ");
            builder.InsertField("NUMPAGES");
            builder.Writeln();

            builder.Write("Date: ");
            builder.InsertField("DATE");

            // Start the actual document content on the second page.
            builder.InsertBreak(BreakType.SectionBreakNewPage);

            // Build a document with complex structure by applying different heading styles thus creating TOC entries.
            builder.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading1;

            builder.Writeln("Heading 1");

            builder.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading2;

            builder.Writeln("Heading 1.1");
            builder.Writeln("Heading 1.2");

            builder.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading1;

            builder.Writeln("Heading 2");
            builder.Writeln("Heading 3");

            // Move to the next page.
            builder.InsertBreak(BreakType.PageBreak);

            builder.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading2;

            builder.Writeln("Heading 3.1");

            builder.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading3;

            builder.Writeln("Heading 3.1.1");
            builder.Writeln("Heading 3.1.2");
            builder.Writeln("Heading 3.1.3");

            builder.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading2;

            builder.Writeln("Heading 3.2");
            builder.Writeln("Heading 3.3");

            Console.WriteLine("Updating all fields in the document.");

            // Call the method below to update the TOC.
            doc.UpdateFields();

            doc.Save(dataDir + "Document Field Update Out.docx");
        }
    }
}