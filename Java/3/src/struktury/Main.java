package struktury;

public class Main {
    public static void main(String args[]) throws Exception {
        Para para1 = new Para("klucz1", 5);
        Para para2 = new Para("klucz2", 6);
        Para para3 = new Para("klucz3", 8);
        String napis = para1.toString();
        System.out.print(napis);

        ZbiorNaTablicy zbior = new ZbiorNaTablicy(5);
        zbior.wstaw(para2);
        zbior.wstaw(para1);
        zbior.czytaj("klucz1");
    }
}
