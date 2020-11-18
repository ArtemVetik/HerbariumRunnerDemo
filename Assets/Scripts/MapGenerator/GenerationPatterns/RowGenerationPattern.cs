using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RowGenerationPattern
{
	protected List<MapRow> Map;
	protected MapObjectContainer ObjectContainer;

	public RowGenerationPattern(List<MapRow> map, MapObjectContainer container)
	{
		Map = map;
		ObjectContainer = container;
	}

    public abstract List<MapObject> GenerateRow(int size);
}
