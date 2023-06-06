using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMadness.Bistate
{
    public static class BistateUtils
    {
        public static List<BistateObject> FindBistatesWithTag(string tag)
        {
            List<BistateObject> bistateObjects = new();
            var taggedObjects = GameObject.FindGameObjectsWithTag(tag);
            foreach (var taggedObject in taggedObjects)
            {
                var bistate = taggedObject.GetComponent<BistateObject>();
                if (bistate != null)
                {
                    bistateObjects.Add(bistate);
                }
            }

            return bistateObjects;
        }
        
    }
}