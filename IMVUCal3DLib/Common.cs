using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace IMVUCal3DLib
{
    public static class Common
    {
        /// <summary>
        /// Converts an xml string to an xml document
        /// </summary>
        /// <param name="xml">The xml code to convert</param>
        /// <returns>An xml document</returns>
        public static XDocument ConvertToXmlDocument(string xml)
        {
            try
            {
                return XDocument.Parse(xml);
            }
            catch (XmlException)
            {
                try
                {
                    return XDocument.Parse("<root>" + xml + "</root>");
                }
                catch (XmlException)
                {
                    return null;
                }
            }            
        }

        public static List<XElement> GetNodesByName(XDocument xDoc, string nodeName)
        {
            List<XElement> nodes = new List<XElement>();

            if (string.IsNullOrEmpty(nodeName) || xDoc == null)
                return nodes;

            var comparison = StringComparison.InvariantCultureIgnoreCase;
            var elements =
                  xDoc.Descendants()
                     .Where(x => x.Name.LocalName.IndexOf(nodeName, comparison) != -1);

            nodes = elements.ToList();

            return nodes;
        }

        /// <summary>
        /// Formats the casing of the target to match the xml's header
        /// </summary>
        /// <param name="xml">The xml code to use as a reference</param>
        /// <param name="toConvert">The string to convert</param>
        /// <returns>A converted string</returns>
        public static string FormatCasing(XDocument xDoc, string toConvert)
        {
            XElement headerNode = GetNodesByName(xDoc, "header").FirstOrDefault();

            if (headerNode != null)
            {
                if (headerNode.Name.LocalName == "HEADER")
                    return toConvert.ToUpper();

                if (headerNode.Name.LocalName == "header")
                    return toConvert.ToLower();

                if (headerNode.Name.LocalName == "Header")
                {
                    string firstCharacter = toConvert.Substring(0, 1).ToUpper();
                    string newAttribute = firstCharacter + toConvert.Substring(1, toConvert.Length);
                    return newAttribute;
                }
            }
            else
            {
                XElement templateNode = GetNodesByName(xDoc, "template").FirstOrDefault();

                if (templateNode.Name.LocalName == "TEMPLATE")
                    return toConvert.ToUpper();

                if (templateNode.Name.LocalName == "template")
                    return toConvert.ToLower();

                if (templateNode.Name.LocalName == "Template")
                {
                    string firstCharacter = toConvert.Substring(0, 1).ToUpper();
                    string newAttribute = firstCharacter + toConvert.Substring(1, toConvert.Length);
                    return newAttribute;
                }
            }            

            return null;
        }    
    
    
    }
}
