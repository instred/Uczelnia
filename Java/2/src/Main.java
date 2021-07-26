import Plaszczyzna.*;

public class Main
{
    public static void main(String[] args)
    {
        System.out.println("-----------------Wektor");
        Wektor v1 = new Wektor(1,0);
        Wektor v2 = new Wektor(2,6);
        Wektor v3 = Wektor.sumuj(v1,v2);
        System.out.println(v1.toString()+ "   "+ v2.toString());
        System.out.println(v3.toString());
        System.out.println("--------Punkt");
        Punkt p1 = new Punkt(2,3);
        Punkt p2 = new Punkt(4,7);
        Punkt p3 = new Punkt(1,1);
        System.out.println(p1.toString());
        System.out.println(p2.toString());
        System.out.println(p3.toString());
        System.out.println("--------Punkt obrócony o 90 stopni");
        p1.obroc(p1,90);
        System.out.println(p1.toString());
        System.out.println("------------Trojkat");
        Trojkat t1 = new Trojkat(p1,p2,p3);
        System.out.println(t1.toString());
        Prosta pr1 = new Prosta(1,5, 3);
        t1.odbij(pr1);
        System.out.println("-----------Trojkat po odbiciu");
        System.out.println(t1.toString());
    }
}