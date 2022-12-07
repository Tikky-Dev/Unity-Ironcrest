using System.Collections;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEditor;

public class PlayerTest
{
    [UnityTest]
    public IEnumerator _0_Player_spawns_from_prefab()
    {
        yield return null;

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        Assert.AreEqual(
            Vector3.zero,
            player.transform.position);
    }
}
