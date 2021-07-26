/** Klasa reprezentująca strzał */
public class Shot extends Entity {
	private double moveSpeed = -300;
	private Game game;
	private boolean used = false;

	public Shot(Game game, String sprite, int x, int y) {
		super(sprite,x,y);
		
		this.game = game;
		
		dy = moveSpeed;
	}
	// Ruchy
	public void move(long delta) {
		super.move(delta);

		if (y < -100) {
			game.removeEntity(this);
		}
	}
	
	// Kolizja strzału
	public void collisionWith(Entity other) {
		// prevents double kills, if we've already hit something,
		// don't collide
		if (used) {
			return;
		}
		
		// Strzał + Kosmita = Usunięcie go
		if (other instanceof Alien) {
			// remove the affected entities
			game.removeEntity(this);
			game.removeEntity(other);
			game.AlienKilled();
			used = true;
		}
	}
}