package struktury;

public abstract class Zbior {

    public abstract void wstaw(Para p) throws Exception;

    public abstract void usun(String s);

    public abstract double czytaj(String s) throws Exception;

    public abstract void ustaw(Para p) throws Exception;

    public abstract Para szukaj(String s) throws Exception;

    public abstract int ile();

    public abstract void czysc();


}
