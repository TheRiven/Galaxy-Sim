using UnityEngine;
using System.Collections;

public interface ISpaceGameObject {

    string name { get; }
    Vector3 position { get; }
    string type { get; }
	
}
