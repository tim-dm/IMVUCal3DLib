using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace IMVUCal3DLib
{
    public class Material
    {
        public XDocument Document { get; private set; }

        public Material(string skeletonXml)
        {
            Document = Common.ConvertToXmlDocument(skeletonXml);
        }

        /// <summary>
        /// Gets the material node
        /// </summary>
        /// <returns>The material node</returns>
        public XElement GetMaterial()
        {
            XElement material = Common.GetNodesByName(Document, "material", true).FirstOrDefault();

            if (material == null)
                return null;

            return material;
        }

        /// <summary>
        /// Gets the name of the texture asigned to the map
        /// </summary>
        /// <returns>A texture file name</returns>
        public string GetMapTextureName()
        {
            XElement map = Common.GetNodesByName(Document, "map", true).FirstOrDefault();

            if (map == null)
                return "";

            return map.Value;
        }
    }
}
