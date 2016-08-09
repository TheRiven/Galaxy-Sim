using UnityEngine;
using System.Collections;

public enum objectType
{
    STAR,
    SUN,
    PLANET
}

public interface ISpaceGameObject {

    string name { get; }
    Vector3 position { get; }
    objectType type { get; }
	
}
