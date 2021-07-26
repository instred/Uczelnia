
import java.awt.Graphics;
import java.awt.Rectangle;

/** Klasa abstrakcyjna reprezentująca każdy objekt w grze */
public abstract class Entity {
	// Koordynaty, rodzaj, prędkość
	protected double x;
	protected double y;
	protected Sprite sprite;
	protected double dx;
	protected double dy;

	// HitBoxy
	private Rectangle player = new Rectangle();
	private Rectangle enemy = new Rectangle();

	public Entity(String ref,int x,int y) {
		this.sprite = SpriteStorage.get().getSprite(ref);
		this.x = x;
		this.y = y;
	}

	public void move(long delta) {
		// Zmiana lokalizacji w zależności od prędkości
		x += (delta * dx) / 1000;
		y += (delta * dy) / 1000;
	}
	//Kolizje obiektów
	public boolean collision(Entity other) {
		player.setBounds((int) x,(int) y,sprite.getWidth(),sprite.getHeight());
		enemy.setBounds((int) other.x,(int) other.y,other.sprite.getWidth(),other.sprite.getHeight());

		return player.intersects(enemy);
	}
	public abstract void collisionWith(Entity other);

	public void setHorizontalMovement(double dx) {
		this.dx = dx;
	}
	public double getHorizontalMovement() {
		return dx;
	}
	// Rysowanie obiektów
	public void draw(Graphics g) {
		sprite.draw(g,(int) x,(int) y);
	}
	public void MoveDown() {
	}
	public int getX() {
		return (int) x;
	}
	public int getY() {
		return (int) y;
	}


}