using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

public class Folders
{
    public static IEnumerable<string> FolderNames(string xml, char startingLetter)
    {
        // Parse the XML
        XDocument doc = XDocument.Parse(xml);

        // Extract folder names that start with the specified letter
        var folderNames = doc.Descendants("folder").
            Select(element => element.Attribute("name").Value).Where(name => !string.IsNullOrEmpty(name) && name[0] == startingLetter);

        return folderNames;
    }
    /*
        public static void Main(string[] args)
        {
            string xml =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<folder name=\"c\">" +
                    "<folder name=\"program files\">" +
                        "<folder name=\"uninstall information\" />" +
                    "</folder>" +
                    "<folder name=\"users\" />" +
                "</folder>";

            foreach (string name in Folders.FolderNames(xml, 'u'))
                Console.WriteLine(name);
        }
        */
}
