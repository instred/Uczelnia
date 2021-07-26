/** Reprezentacja obiektu gracza */
public class PlayerShip extends Entity {
	private Game game;

	public PlayerShip(Game game, String ref, int x, int y) {
		super(ref,x,y);
		
		this.game = game;
	}
	// Jeśli dotrzemy do krawędzi, statek nie poruszy się dalej
	public void move(long delta) {
		if ((dx < 0) && (x < 10)) {
			return;
		}
		if ((dx > 0) && (x > 750)) {
			return;
		}
		super.move(delta);
	}
	// Kolizja gracza, jeśli to kosmita, game over
	public void collisionWith(Entity other) {
		if (other instanceof Alien) {
			game.Death();
		}
	}
}