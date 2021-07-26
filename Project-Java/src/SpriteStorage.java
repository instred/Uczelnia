import java.awt.GraphicsConfiguration;
import java.awt.GraphicsEnvironment;
import java.awt.Image;
import java.awt.Transparency;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.net.URL;
import java.util.HashMap;

import javax.imageio.ImageIO;

/** Menedżer zasobów na ikony gry */
public class SpriteStorage {
	private static SpriteStorage single = new SpriteStorage();

	public static SpriteStorage get() {
		return single;
	}
	
	// Buforowana mapa ikon
	private HashMap<String, Sprite> sprites = new HashMap<String, Sprite>();
	

	public Sprite getSprite(String ref) {
		// Jeśli już jest zapisana, zwróć ją
		if (sprites.get(ref) != null) {
			return (Sprite) sprites.get(ref);
		}
		BufferedImage sourceImage = null;

		try {
			URL url = this.getClass().getClassLoader().getResource(ref);

			if (url == null) {
				fail("Can't find reference: "+ref);
			}

			// Używam ImageIO do czytania obrazu zapisanego
			sourceImage = ImageIO.read(url);
		} catch (IOException e) {
			fail("Failed to load: "+ref);
		}

		// Tworzę obraz odpowiednich wymiarach by zapisać tam swój
		GraphicsConfiguration gc = GraphicsEnvironment.getLocalGraphicsEnvironment().getDefaultScreenDevice().getDefaultConfiguration();
		Image image = gc.createCompatibleImage(sourceImage.getWidth(),sourceImage.getHeight(),Transparency.BITMASK);
		image.getGraphics().drawImage(sourceImage,0,0,null);
		Sprite sprite = new Sprite(image);
		sprites.put(ref,sprite);
		
		return sprite;
	}
	
	// Obsługa błędów
	private void fail(String message) {
		System.err.println(message);
		System.exit(0);
	}
}