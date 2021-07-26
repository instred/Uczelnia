DROP FUNCTION IF EXISTS exercise1func
GO

CREATE FUNCTION exercise1func(@days int) RETURNS TABLE
RETURN
	SELECT 
	czyt.PESEL, COUNT(wyp.Wypozyczenie_ID) AS LiczbaEgzemplarzy
	FROM	
		[dbo].Czytelnik AS czyt,
		[dbo].Wypozyczenie AS wyp
	WHERE
		czyt.Czytelnik_ID = wyp.Czytelnik_ID AND
		wyp.Liczba_Dni > @days
	GROUP BY czyt.PESEL
GO

SELECT * FROM exercise1func(13)