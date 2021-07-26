/** Reprezentacja Kosmity */
public class Alien extends Entity {
	private double moveSpeed = 75;
	private Game game;

	public Alien(Game game, String ref, int x, int y) {
		super(ref,x,y);
		
		this.game = game;
		dx = -moveSpeed;
	}

	public void move(long delta) {
		// Jeśli dotrzemy do lewej strony,następuje zmiana logiki
		if ((dx < 0) && (x < 10)) {
			game.updateLogic();
		}
		// Tak samo z prawą stroną
		if ((dx > 0) && (x > 750)) {
			game.updateLogic();
		}

		super.move(delta);
	}

	public void MoveDown() {
		dx = -dx;
		y += 10;
		if (y > 570) {
			game.Death();
		}
	}
	public void collisionWith(Entity other) {
		// Obsługa kolizji w klasie abstrakcyjnej
	}
}