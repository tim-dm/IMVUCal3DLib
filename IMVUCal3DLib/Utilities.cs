using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace IMVUCal3DLib
{
    public static class Utilities
    {
        /// <summary>
        /// Searches the xml code for all of the nodes with a matching name
        /// </summary>
        /// <param name="xml">The xml code to search</param>
        /// <param name="nodeName">The name of the nodes to find</param>
        /// <returns>A collection of nodes</returns>
        public static List<XElement> GetNodesByName(string xml, string nodeName)
        {
            List<XElement> nodes = new List<XElement>();

            if (string.IsNullOrEmpty(nodeName))
                return nodes;

            XDocument xdoc;

            try
            {
                xdoc = XDocument.Parse(xml);
            }
            catch (XmlException xe)
            {
                return nodes;
            }

            var comparison = StringComparison.InvariantCultureIgnoreCase;
            var elements =
                  xdoc.Descendants()
                     .Where(x => x.Name.LocalName.IndexOf(nodeName, comparison) != -1);

            nodes = elements.ToList();

            return nodes;
        }
    }
}
