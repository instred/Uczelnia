package struktury;

public class ZbiorNaTablicy extends Zbior {

    protected int size;
    protected int numberOfElements = 0;
    protected Para[] zbior;

    public ZbiorNaTablicy()
    {
        this.zbior = new Para[2];
        this.size = 2;
    }

    public ZbiorNaTablicy(int size) throws Exception
    {
        if(size < 2)
            throw new Exception("Zbyt mała tablica");

        this.zbior = new Para[size];
        this.size = size;
    }

    public void wstaw(Para p) throws Exception
    {
        try
        {
            this.szukaj(p.klucz);
        } catch (Exception e) {
            this.zbior[this.numberOfElements] = p;
            this.numberOfElements++;
            return;
        }
        throw new Exception("Para o podanym kluczu już istnieje");


    }

    public void poprzesuwaj(int n)
    {
        for(int i = n; i < this.numberOfElements - 1; i++)
        {
            this.zbior[i] = this.zbior[i+1];
        }
    }

    // Usuwanie pary, polega na zastosowaniu funkcji z przesunięciem

    public void usun(String s)
    {
        for(int i = 0; i < this.numberOfElements; i++) {
            if(this.zbior[i].klucz.equals(s))
            {
                this.poprzesuwaj(i);
                numberOfElements--;
                break;
            }
        }
    }

    public double czytaj(String s) throws Exception
    {
        for(int i = 0; i < this.numberOfElements; i++) {
            if(this.zbior[i].klucz.equals(s))
                return this.zbior[i].get();
        }

        throw new Exception("Para o danym kluczu nie istnieje.");
    }

    public void ustaw(Para p) throws Exception
    {
        for(int i = 0; i < this.numberOfElements; i++) {
            if(this.zbior[i].klucz.equals(p.klucz)) {
                this.zbior[i] = p;
                return;
            }
        }

        this.wstaw(p);
    }

    public Para szukaj(String s) throws Exception
    {
        for(int i = 0; i < this.numberOfElements; i++) {
            if(this.zbior[i].klucz.equals(s))
                return this.zbior[i];
        }

        throw new Exception("Para o podanym kluczu nie istnieje.");
    }


    public int ile()
    {
        return this.numberOfElements;
    }

    public void czysc()
    {
        this.zbior = new Para[size];
        this.numberOfElements = 0;
    }

}
