

import java.awt.Canvas;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics2D;
import java.awt.event.*;
import java.awt.image.BufferStrategy;
import java.util.ArrayList;

import javax.swing.JFrame;
import javax.swing.JPanel;



/**
 * Jest to główna klasa naszej gry, jest odpowiedzialna za wyświetlanie jak i zarządzanie logiką gry.
 * Wyświetlanie polega na pętli, która sprawdza ruch obiektów w grze, a następnie rysując je w odpowiednim miejscu
 * Pozwala na poruszanie się naszym statkiem, jak i wykrywa eventy w grze, np. gracz umiera/wygrywa.
 */
@SuppressWarnings("serial")
public class Game extends Canvas {
	private BufferStrategy strategy;
	private boolean gameRunning = true;
	// Array list na przeciwników oraz tych którzy zostali zastrzeleni
	private ArrayList<Entity> entities = new ArrayList<Entity>();
	private ArrayList<Entity> removeEntities = new ArrayList<Entity>();
	private int alienCounter;
	private Entity playerShip;
	// Prędkość gracz
	private double speed = 200;
	private long lastFire = 0;
	// Prędkość strzału
	private long fireCooldown = 500;

	private String message = "";
	private boolean keyPress = true;
	private boolean leftPressed = false;
	private boolean rightPressed = false;
	private boolean firePressed = false;
	private boolean logicRequiredThisLoop = false;
	
	/** Budowa okna i naszej gry */
	public Game() {
		// Tworzenie okna
		JFrame container = new JFrame("Space Invaders");
		
		// Zmiana Rozdzielczości
		JPanel panel = (JPanel) container.getContentPane();
		panel.setPreferredSize(new Dimension(800,600));
		panel.setLayout(null);
		setBounds(0,0,800,600);
		panel.add(this);

		setIgnoreRepaint(true);
		
		// Widoczność okna
		container.pack();
		container.setResizable(false);
		container.setVisible(true);
		
		// Obsługa sterowania graczem
		addKeyListener(new KeyInputHandler());
		requestFocus();

		createBufferStrategy(2);
		strategy = getBufferStrategy();
		initEntities();

		// Obsługa zamykania okna po naciśnięciu przycisku
		container.addWindowListener(new WindowAdapter() {
			public void windowClosing(WindowEvent e) {
				System.exit(0);
			}
		});
	}

	/** Main klasa, która uruchamia naszą gre */
	public static void main(String argv[]) {
		Game g =new Game();

		// Start the main game loop, note: this method will not
		// return until the game has finished running. Hence we are
		// using the actual main thread to run the game.
		g.gameLoop();
	}

	// Nowa gra + czyszczenie starych dancych
	public void startGame() {
		entities.clear();
		initEntities();
		leftPressed = false;
		rightPressed = false;
		firePressed = false;
	}

	private void initEntities() {
		// Tworzenie gracza i wyśrodkowanie go
		playerShip = new PlayerShip(this,"Resources/ship.png",370,550);
		entities.add(playerShip);

		// Tworzenie przeciwników (6x12)
		alienCounter = 0;
		for (int row=0;row<6;row++) {
			for (int x=0;x<13;x++) {
				Entity alien = new Alien(this,"Resources/alien.gif",100+(x*50),(50)+row*30);
				entities.add(alien);
				alienCounter++;
			}
		}
	}

	public void updateLogic() {
		logicRequiredThisLoop = true;
	}
	public void removeEntity(Entity entity) {
		removeEntities.add(entity);
	}
	// Przegrana
	public void Death() {
		message = "YOU DIED! Would you like to try again?";
		keyPress = true;
	}
	// Wygrana
	public void Win() {
		message = "You Won!";
		keyPress = true;
	}
	// Licznik Wrogów
	public void AlienKilled() {
		alienCounter--;
		if (alienCounter == 0) {
			Win();
		}
		// Przyśpieszenie przeciwników z każdym pokonanym
		for (int i=0;i<entities.size();i++) {
			Entity entity = (Entity) entities.get(i);
			if (entity instanceof Alien) {
				entity.setHorizontalMovement(entity.getHorizontalMovement() * 1.02);
			}
		}
	}
	
	// Strzały, strzelanie dozwolone po pewnym opóźnieniu, w tym przypadku 500ms
	public void Fire() {
		if (System.currentTimeMillis() - lastFire < fireCooldown) {
			return;
		}
		lastFire = System.currentTimeMillis();
		Shot shot = new Shot(this,"Resources/shot.gif", playerShip.getX()+10, playerShip.getY()-30);
		entities.add(shot);
	}
	// Główna pętla gry
	public void gameLoop() {
		long lastLoopTime = System.currentTimeMillis();
		while (gameRunning) {
			long delta = System.currentTimeMillis() - lastLoopTime;
			lastLoopTime = System.currentTimeMillis();

			Graphics2D g = (Graphics2D) strategy.getDrawGraphics();
			g.setColor(Color.black);
			g.fillRect(0,0,800,600);


			if (!keyPress) {
				for (int i=0;i<entities.size();i++) {
					Entity entity = (Entity) entities.get(i);

					entity.move(delta);
				}
			}

			for (int i=0;i<entities.size();i++) {
				Entity entity = (Entity) entities.get(i);

				entity.draw(g);
			}

			for (int p=0;p<entities.size();p++) {
				for (int s=p+1;s<entities.size();s++) {
					Entity me = (Entity) entities.get(p);
					Entity him = (Entity) entities.get(s);

					if (me.collision(him)) {
						me.collisionWith(him);
						him.collisionWith(me);
					}
				}
			}

			entities.removeAll(removeEntities);
			removeEntities.clear();

			if (logicRequiredThisLoop) {
				for (int i=0;i<entities.size();i++) {
					Entity entity = (Entity) entities.get(i);
					entity.MoveDown();
				}

				logicRequiredThisLoop = false;
			}

			if (keyPress) {
				g.setColor(Color.white);
				g.drawString(message,(800-g.getFontMetrics().stringWidth(message))/2,250);
				g.drawString("Press any key",(800-g.getFontMetrics().stringWidth("Press any key"))/2,300);
			}

			g.dispose();
			strategy.show();

			playerShip.setHorizontalMovement(0);

			if ((leftPressed) && (!rightPressed)) {
				playerShip.setHorizontalMovement(-speed);
			} else if ((rightPressed) && (!leftPressed)) {
				playerShip.setHorizontalMovement(speed);
			}

			if (firePressed) {
				Fire();
			}

			try { Thread.sleep(10); } catch (Exception e) {}
		}
	}

	/** Klasa obsługująca naciskanie przycisków klawiatury by można było się poruszać */
	private class KeyInputHandler extends KeyAdapter {
		private int pressCount = 1;

		public void keyPressed(KeyEvent e) {
			if (keyPress) {
				return;
			}
			if (e.getKeyCode() == KeyEvent.VK_LEFT) {
				leftPressed = true;
			}
			if (e.getKeyCode() == KeyEvent.VK_RIGHT) {
				rightPressed = true;
			}
			if (e.getKeyCode() == KeyEvent.VK_SPACE) {
				firePressed = true;
			}
		}

		public void keyReleased(KeyEvent e) {
			if (keyPress) {
				return;
			}

			if (e.getKeyCode() == KeyEvent.VK_LEFT) {
				leftPressed = false;
			}
			if (e.getKeyCode() == KeyEvent.VK_RIGHT) {
				rightPressed = false;
			}
			if (e.getKeyCode() == KeyEvent.VK_SPACE) {
				firePressed = false;
			}
		}

		public void keyTyped(KeyEvent e) {
			if (keyPress) {
				if (pressCount == 1) {
					keyPress = false;
					startGame();
					pressCount = 0;
				} else {
					pressCount++;
				}
			}
			if (e.getKeyChar() == 27) {
				System.exit(0);
			}
		}
	}
}
