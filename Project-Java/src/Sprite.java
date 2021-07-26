import java.awt.Graphics;
import java.awt.Image;

/** Klasa odpowiedzialna za obraz obiektów */
public class Sprite {
	private Image image;

	public Sprite(Image image) {
		this.image = image;
	}
	// Pobierz szerokość (w px)
	public int getWidth() {
		return image.getWidth(null);
	}
	// Pobierz wysokość
	public int getHeight() {
		return image.getHeight(null);
	}
	
	// Rysuj na podstawie koordynatów
	public void draw(Graphics g,int x,int y) {
		g.drawImage(image,x,y,null);
	}
}