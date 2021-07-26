using System;
using System.Collections;
using System.Xml;

namespace Z2
{
    public class XmlHandler : DataHandler {
        private string Path {get;}
        private XmlDocument _doc;

        public XmlHandler(string file) {
            Path = file;
        }
        protected override void Connection() {}

        protected override void GetData() {
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

        protected override void Processing() {
            var element = _doc.DocumentElement;
            if (element == null) return;
            var longestNode = LongestNode(element.ChildNodes);
            Console.WriteLine("Longest node in file: " + longestNode);
        }

        protected override void Close() {}
    }
}