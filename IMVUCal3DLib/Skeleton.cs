using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace IMVUCal3DLib
{
    public class Skeleton
    {
        public XDocument Document { get; private set; }

        public Skeleton(string skeletonXml)
        {
            Document = Common.ConvertToXmlDocument(skeletonXml);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<XElement> GetBones()
        {
            return Common.GetNodesByName(Document, "bone");
        }

        /// <summary>
        /// Grabs the childid nodes from a skeleton
        /// </summary>
        /// <returns>A collection of childid nodes</returns>
        public List<XElement> GetChildIds()
        {
            return Common.GetNodesByName(Document, "childid");
        }

        /// <summary>
        /// Grabs a specific bone from the skeleton
        /// </summary>
        /// <param name="boneId">The id of the bone to find</param>
        /// <returns>A bone node</returns>
        public XElement GetBoneById(string boneId)
        {
            return GetBones().Where(x => x.Attribute(Common.FormatCasing(Document, "ID")).Value.Equals(boneId)).SingleOrDefault();
        }

        /// <summary>
        /// Grabs a specific bone from the skeleton
        /// </summary>
        /// <param name="boneName">The name of the bone to find</param>
        /// <returns>A bone node</returns>
        public XElement GetBoneByName(string boneName)
        {
            return GetBones().Where(x => x.Attribute(Common.FormatCasing(Document, "NAME")).Value.Equals(boneName)).SingleOrDefault();
        }

        /// <summary>
        /// Removes a bone from the document
        /// </summary>
        /// <param name="boneId">The id of the bone to remove</param>
        public void RemoveBoneWithId(string boneId)
        {
            XElement bone = GetBoneById(boneId);

            if (bone != null)
                bone.Remove();
        }

        /// <summary>
        /// Removes a bone from the document
        /// </summary>
        /// <param name="boneName">The name of the bone to remove</param>
        public void RemoveBoneWithName(string boneName)
        {
            XElement bone = GetBoneByName(boneName);

            if (bone != null)
                bone.Remove();
        }

        
    }
}
