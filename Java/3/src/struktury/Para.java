package struktury;

public class Para {
    public final String klucz;
    private double wartosc;

    Para(String klucz, double wartosc)
    {
        this.klucz = klucz;
        this.wartosc = wartosc;
    }

    public double get()
    {
        return wartosc;
    }

    public void set(double val)
    {
        this.wartosc = val;
    }

    @Override
    public String toString() {
        return  klucz + " --> " +  wartosc;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Para para = (Para) o;
        return para.wartosc == this.wartosc;
    }

}
