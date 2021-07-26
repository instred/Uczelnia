using System;
using System.Collections;
using System.Xml;

namespace Z3
{
    public class XmlHandler : IDataStrategy {
        private string Path {get;}
        private XmlDocument _doc;

        public XmlHandler(string file) {
            Path = file;
        }

        public void Connection() {}

        public void GetData() {
            _doc = new XmlDocument();
            _doc.Load(Path);
        }

        private static string LongestNode(IEnumerable nodes) {
            var longestNode = "";

            foreach (XmlNode node in nodes) {
                if (longestNode.Length < node.Name.Length) {
                    longestNode = node.Name;
                }

                var childLongest = LongestNode(node.ChildNodes);
                if (childLongest.Length > longestNode.Length) {
                    longestNode = childLongest;
                }
            }

            return longestNode;
        }

        public void Processing() {
            var element = _doc.DocumentElement;
            if (element == null) return;
            var longestNode = LongestNode(element.ChildNodes);
            Console.WriteLine("Longest node in file: " + longestNode);
        }

        public void Close() {}
    }
}