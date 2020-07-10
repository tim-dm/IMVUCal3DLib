using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace IMVUCal3DLib
{
    public class Mesh
    {
        public XDocument Document { get; private set; }

        public Mesh(string skeletonXml)
        {
            Document = Common.ConvertToXmlDocument(skeletonXml);
        }

        // <summary>
        // Grabs the morphs from a mesh
        // </summary>
        // <returns>A collection of morph nodes</returns>
        public List<XElement> GetMorphs()
        {
            return Common.GetNodesByName(Document, "morph");
        }

        /// <summary>
        /// Grabs all of the submeshes from a mesh file
        /// </summary>
        /// <returns>A collection of morph nodes</returns>
        public List<XElement> GetSubmeshes()
        {
            return Common.GetNodesByName(Document, "submesh");
        }

        /// <summary>
        /// Grabs a submesh with a matching material
        /// </summary>
        /// <param name="materialId">The material attritube value</param>
        /// <returns></returns>
        public XElement GetSubmeshByMaterialId(string materialId)
        {
            return GetSubmeshes().Where(s => s.Attribute(Common.FormatCasing(Document, "material")).Value.Equals(materialId)).SingleOrDefault();
        }






    }
}
