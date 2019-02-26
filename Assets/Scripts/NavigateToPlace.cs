using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NavigateToPlace : MonoBehaviour, INavigable
{
    public string levelName;

    public string LevelName() {
        return levelName;
    }
}
