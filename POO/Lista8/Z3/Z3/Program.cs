namespace Z3 {
    
    public static class Example {
        
        public static void Main() {
            var xml = new DataHandler(new XmlHandler("example.xml"));
            xml.Execute();
        }
    }
}