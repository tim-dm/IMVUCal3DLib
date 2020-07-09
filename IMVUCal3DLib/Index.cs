﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
namespace IMVUCal3DLib
{
    public static class Index
    {
        /// <summary>
        /// Grabs the last mesh node in an index document
        /// </summary>
        /// <param name="indexXML">The xml code of the index file</param>
        /// <returns>The last XElement in the xml with the name mesh</returns>
        public static XElement GetLastMeshNode(string indexXML)
        {
            IEnumerable<XElement> meshNodes = Utilities.GetNodesByName(indexXML, "mesh");

            if (meshNodes == null)
                return null;

            return meshNodes.Last();
        }

        /// <summary>
        /// Grabs the ids of all the mesh nodes, sorts them and returns the highest value
        /// </summary>
        /// <param name="indexXML">The xml code of the index file</param>
        /// <returns>The largest mesh id</returns>
        public static string GetLargestMeshID(string indexXML)
        {
            IEnumerable<XElement> meshNodes = Utilities.GetNodesByName(indexXML, "mesh");

            if (meshNodes == null)
                return null;

            if (meshNodes.Count() == 1)
            {
                //IMVU asset xml is inconsistent, some files use uppercase node names, others use lowercase and some use a mixture of both.
                string meshId = Regex.Replace(meshNodes.Last().Name.LocalName, "mesh", "", RegexOptions.IgnoreCase);

                //Some index files can have meshes with no ids so the string will be empty
                return string.IsNullOrEmpty(meshId) ? null : meshId;
            }
            else
            {
                List<int> nodeIds = new List<int>();

                foreach (XElement meshNode in meshNodes)
                {
                    string meshId = Regex.Replace(meshNode.Name.LocalName, "mesh", "", RegexOptions.IgnoreCase);

                    if (string.IsNullOrEmpty(meshId))
                        continue;

                    //We set the id to -1 instead of 0 because a mesh node can have an id of 0
                    int id = int.TryParse(meshId, out id) ? id : -1;

                    if (id == -1)
                        continue;

                    nodeIds.Add(id);
                }

                nodeIds.Sort();

                return nodeIds.Count > 0 ? nodeIds.Last().ToString() : null;
            }
        }

        /// <summary>
        /// Grabs all of the mesh nodes and their corrosponding index nodes, sorting their values and returing the highest one
        /// </summary>
        /// <param name="indexXML">The xml code of the index file</param>
        /// <returns>The largest mesh index value</returns>
        public static string GetLargestMeshIndex(string indexXML)
        {
            IEnumerable<XElement> meshNodes = Utilities.GetNodesByName(indexXML, "mesh");

            if (meshNodes == null)
                return null;

            if (meshNodes.Count() == 1)
            {
                string meshIndex = meshNodes.Last().Element("Index").Value;
                return string.IsNullOrEmpty(meshIndex) ? null : meshIndex;
            }
            else
            {
                List<int> nodeIndexs = new List<int>();

                foreach (XElement meshNode in meshNodes)
                {
                    if (meshNode.Element("Index") != null)
                    {
                        string meshIndex = meshNode.Element("Index").Value;

                        if (!string.IsNullOrEmpty(meshIndex))
                        {
                            //We set the index to -1 instead of using the default error value of 0
                            //Because a mesh index can have an id of 0
                            int index = int.TryParse(meshIndex, out index) ? index : -1;

                            //If the int converted successfully
                            if (index != -1)
                            {
                                nodeIndexs.Add(index);
                            }
                        }
                    }
                }

                nodeIndexs.Sort();

                return nodeIndexs.Count > 0 ? nodeIndexs.Last().ToString() : null;
            }
        }







        


    }
}