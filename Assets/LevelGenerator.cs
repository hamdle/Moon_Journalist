using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public Texture2D map;

	public TileData[] tileData;

	// Use this for initialization
	void Start () {
		GenerateLevel();
	}

	void GenerateLevel()
	{
		for (int x = 0; x < map.width; x++)
		{
			for (int y = 0; y < map.height; y++)
			{
				GenerateTile(x, y);
			}
		}
	}

	void GenerateTile(int x, int y)
	{
		Color pixelColor = map.GetPixel(x, y);

		// Alpha pixel means no tile set so return
		if (pixelColor.a == 0)
			return;

		foreach (TileData tile in tileData)
		{
			if (tile.color.Equals(pixelColor))
			{
				Vector2 position = new Vector2(x, y);
				Instantiate(tile.prefab, position, Quaternion.identity, transform);
			}
		}
	}

}
