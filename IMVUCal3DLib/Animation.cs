using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;

namespace IMVUCal3DLib
{
    public class Animation
    {
        public XDocument Document { get; private set; }

        public Animation(string skeletonXml)
        {
            Document = Common.ConvertToXmlDocument(skeletonXml);
        }

        /// <summary>
        /// Gets the keyframe nodes from the animation
        /// </summary>
        /// <returns>A collection of keyframe nodes</returns>
        public List<XElement> GetKeyFrames()
        {
            return Common.GetNodesByName(Document, "keyframe", true);
        }



    }
}
